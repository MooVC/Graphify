namespace Graphify.Strategies
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using Graphify.Model;
    using static Graphify.Strategies.ModelStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating classes that match each tier within the hierarchy that involve a sequence.
    /// </summary>
    internal sealed class ModelStrategy
        : IStrategy
    {
        private const string Declaration = "__DECLARATION__";

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

            string body = GeneratePropertyContent(preceding, tier, out string assignments, out string parameters);
            string wrapper = GenerateWrapperDeclarations(preceding, tier);

            foreach (Property property in properties)
            {
                yield return GenerateContentForProperty(assignments, body, @namespace, parameters, property, subject, tier, wrapper, out string next);

                IEnumerable<Source> succeeding = Enumerable.Empty<Source>();

                if (property.IsSequence)
                {
                    succeeding = GenerateContentForElement(assignments, body, property.Element, next, parameters, preceding, property, subject, tier, wrapper);
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
            string code = string.Format(
                template,
                @namespace,
                name,
                subject.Type,
                parameters,
                type,
                assignments,
                body);

            code = ApplyWrapper(code, wrapper, tier);
            code = string.Format(GenerateContentNest, "public static", "partial class Graph", code.Indent());
            code = string.Format(GenerateContentNest, subject.Declaration, subject.Qualification, code.Indent());

            next = $"{@namespace}.{name}";

            return new Source(code, next);
        }

        private static IEnumerable<Source> GenerateContentForElement(
            string assignments,
            string body,
            Element element,
            string @namespace,
            string parameters,
            Predecessor[] preceding,
            Property property,
            Subject subject,
            int tier,
            string wrapper)
        {
            yield return GenerateContent(
                assignments,
                body,
                element.Name,
                @namespace,
                parameters,
                subject,
                GenerateContentForElementContent,
                tier,
                element.Type,
                wrapper,
                out string next);

            Predecessor[] pool = default;

            try
            {
                pool = AppendCurrentForNextTier(preceding, tier, Predecessor.From(property), Predecessor.From(element));

                foreach (Source source in GenerateContent(next, pool, element.Properties, subject, tier + 1))
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

        private static string GeneratePropertyContent(Predecessor[] preceding, int tier, out string assignments, out string parameters)
        {
            if (tier == 1)
            {
                assignments = string.Empty;
                parameters = string.Empty;

                return string.Empty;
            }

            var arguments = new StringBuilder();
            var constructor = new StringBuilder();
            var declarations = new StringBuilder();

            _ = constructor.AppendLine();

            for (int index = 0; index < (tier - 1); index++)
            {
                Predecessor predecessor = preceding[index];

                _ = arguments.Append(string.Format(GeneratePropertyContentArgument, predecessor.Type, predecessor.Name.ToCamelCase()));
                _ = constructor.AppendLine(string.Format(GeneratePropertyContentAssignment, predecessor.Name, predecessor.Name.ToCamelCase()));

                _ = declarations
                    .AppendLine()
                    .AppendLine(string.Format(GeneratePropertyContentDeclaration, predecessor.Type, predecessor.Name));
            }

            assignments = constructor.ToString();
            parameters = arguments.ToString();

            return declarations.ToString();
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
                previous = string.Format(GenerateWrapperDeclarationsContent, predecessor.Name, previous);
            }

            return previous;
        }
    }
}