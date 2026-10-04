namespace Graphify.Strategies
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;
    using static Graphify.GeneratedNames;
    using static Graphify.Strategies.ModelStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating classes that match each tier within the hierarchy that involve a sequence.
    /// </summary>
    internal sealed class ModelStrategy
        : IStrategy
    {
        private const string Declaration = "__DECLARATION__";
        private const string GraphDeclaration = "partial class " + GraphTypeName;

        /// <summary>
        /// Generates a collection of source code representations for the specified subject and its properties.
        /// </summary>
        /// <param name="subject">The subject for which to generate source code. Cannot be <see langword="null"/>.</param>
        /// <returns>
        /// An enumerable collection of <see cref="Source"/> objects representing the generated source code for the subject and its properties.
        /// </returns>
        public IEnumerable<Source> Generate(Subject subject)
        {
            return GenerateContent(subject.Name, Array.Empty<Predecessor>(), subject.Properties, subject, 0);
        }

        private static Predecessor[] AppendCurrentForNextTier(Predecessor[] preceding, int tier, params Predecessor[] predecessors)
        {
            int length = tier + predecessors.Length - 1;
            Predecessor[] pool = ArrayPool<Predecessor>.Shared.Rent(length);

            if (tier > 1)
            {
                Array.Copy(preceding, pool, tier - 1);
            }

            Array.Copy(predecessors, 0, pool, tier - 1, predecessors.Length);

            return pool;
        }

        private static IEnumerable<Source> GenerateContent(
            string @namespace,
            Predecessor[] preceding,
            ImmutableArray<Property> properties,
            Subject subject,
            int tier)
        {
            tier++;

            if (tier > subject.Depth)
            {
                yield break;
            }

            string body = GeneratePropertyContent(@namespace, preceding, subject.PropertyPrefix, tier, out string assignments, out string parameters);
            string wrapper = GenerateWrapperDeclarations(preceding, tier);

            foreach (Property property in properties)
            {
                yield return GenerateContentForProperty(assignments, body, @namespace, parameters, property, subject, tier, wrapper, out string next);

                IEnumerable<Source> succeeding = Enumerable.Empty<Source>();

                if (property.IsSequence)
                {
                    succeeding = GenerateContentForElement(property.Element, next, preceding, property, subject, tier);
                }

                succeeding = succeeding.Concat(GenerateContentsForProperty(next, preceding, property, subject, tier));

                foreach (Source source in succeeding)
                {
                    yield return source;
                }
            }
        }

        private static Source GenerateContent(
            string assignments,
            string body,
            string declaration,
            string name,
            string @namespace,
            string parameters,
            Subject subject,
            string template,
            int tier,
            string type,
            string wrapper,
            out string next)
        {
            string rootContract = string.IsNullOrEmpty(subject.PropertyPrefix)
                ? string.Empty
                : string.Format(GenerateRootContractContent, subject.Type, subject.PropertyPrefix, RootPropertyName);

            string code = string.Format(
                template,
                @namespace,
                name,
                subject.Type,
                parameters,
                type,
                assignments,
                body,
                declaration,
                subject.PropertyPrefix,
                rootContract,
                RootPropertyName,
                ValuePropertyName,
                IndexPropertyName);

            code = ApplyWrapper(code, wrapper, tier);

            string accessibility = subject.Accessibility == Accessibility.Internal
                ? "internal static"
                : "public static";

            code = string.Format(GenerateContentNest, accessibility, GraphDeclaration, code.Indent());
            code = string.Format(GenerateContentNest, subject.Declaration, subject.Qualification, code.Indent());

            next = $"{@namespace}.{name}";

            return new Source(code, next);
        }

        private static IEnumerable<Source> GenerateContentForElement(
            Element element,
            string @namespace,
            Predecessor[] preceding,
            Property property,
            Subject subject,
            int tier)
        {
            Predecessor[] pool = default;

            try
            {
                pool = AppendCurrentForNextTier(preceding, tier, Predecessor.From(property), Predecessor.From(element, property.Declaration));

                tier++;
                string body = GeneratePropertyContent(@namespace, pool, subject.PropertyPrefix, tier, out string assignments, out string parameters);

                string wrapper = GenerateWrapperDeclarations(pool, tier);

                yield return GenerateContent(
                    assignments,
                    body,
                    property.Declaration,
                    element.Name,
                    @namespace,
                    parameters,
                    subject,
                    GenerateContentForElementContent,
                    tier,
                    element.Type,
                    wrapper,
                    out string next);

                foreach (Source source in GenerateContent(next, pool, element.Properties, subject, tier))
                {
                    yield return source;
                }
            }
            finally
            {
                ArrayPool<Predecessor>.Shared.Return(pool);
            }
        }

        private static Source GenerateContentForProperty(
            string assignments,
            string body,
            string @namespace,
            string parameters,
            Property property,
            Subject subject,
            int tier,
            string wrapper,
            out string next)
        {
            return GenerateContent(
                assignments,
                body,
                property.Declaration,
                property.Name,
                @namespace,
                parameters,
                subject,
                GenerateContentForPropertyContent,
                tier,
                property.Type,
                wrapper,
                out next);
        }

        private static IEnumerable<Source> GenerateContentsForProperty(
            string @namespace,
            Predecessor[] preceding,
            Property property,
            Subject subject,
            int tier)
        {
            Predecessor[] pool = default;

            try
            {
                pool = AppendCurrentForNextTier(preceding, tier, Predecessor.From(property));

                foreach (Source succeeding in GenerateContent(@namespace, pool, property.Properties, subject, tier))
                {
                    yield return succeeding;
                }
            }
            finally
            {
                ArrayPool<Predecessor>.Shared.Return(pool);
            }
        }

        private static string ApplyWrapper(string code, string wrapper, int tier)
        {
            if (tier == 1)
            {
                return code;
            }

            code = code.Indent(times: tier - 1);

            return wrapper.Replace(Declaration, code);
        }

        private static string GeneratePropertyContent(string @namespace, Predecessor[] preceding, string propertyPrefix, int tier, out string assignments, out string parameters)
        {
            if (tier == 1)
            {
                assignments = string.Empty;
                parameters = string.Empty;

                return string.Empty;
            }

            Predecessor predecessor = preceding[tier - 2];
            string propertyName = string.Concat(propertyPrefix, predecessor.Name);

            if (!string.IsNullOrEmpty(propertyPrefix)
                && (predecessor.Name == IndexPropertyName || predecessor.Name == RootPropertyName || predecessor.Name == ValuePropertyName))
            {
                propertyName = string.Concat(propertyName, ParentReferenceSuffix);
            }

            string parameterName = string.IsNullOrEmpty(propertyPrefix)
                ? ToCamelCase(predecessor.Name)
                : CollisionSafeParentParameterName;

            string type = ToGraphType(@namespace);
            var assignmentBuilder = new StringBuilder();
            var declarationBuilder = new StringBuilder();

            _ = assignmentBuilder
                .AppendLine()
                .AppendLine(string.Format(GeneratePropertyContentAssignment, propertyName, parameterName));

            _ = declarationBuilder
                .AppendLine()
                .AppendLine(string.Format(GeneratePropertyContentDeclaration, type, propertyName, predecessor.Declaration));

            assignments = assignmentBuilder.ToString();

            parameters = string.Format(GeneratePropertyContentArgument, type, parameterName);

            return declarationBuilder.ToString();
        }

        private static string ToGraphType(string @namespace)
        {
            int separator = @namespace.IndexOf(".", StringComparison.Ordinal);

            if (separator < 0)
            {
                return string.Concat(@namespace, GraphNamespaceSegment);
            }

            return @namespace.Insert(separator, GraphNamespaceSegment);
        }

        private static string ToCamelCase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            return string.Concat(char.ToLowerInvariant(name[0]), name.Substring(1));
        }

        private static string GenerateWrapperDeclarations(Predecessor[] preceding, int tier)
        {
            if (tier == 1)
            {
                return string.Empty;
            }

            string previous = Declaration;

            int tiers = tier - 2;

            for (int index = tiers; index >= 0; index--)
            {
                Predecessor predecessor = preceding[index];

                previous = previous.Indent();
                previous = string.Format(GenerateWrapperDeclarationsContent, predecessor.Name, previous, predecessor.Declaration);
            }

            return previous;
        }
    }
}