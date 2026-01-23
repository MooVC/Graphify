namespace Graphify.Strategies
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using Graphify.Model;
    using static Graphify.Strategies.ImplementationStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating contents that match each tier within the hierarchy that involve a sequence.
    /// </summary>
    internal sealed class ImplementationStrategy
        : IStrategy
    {
        private const int GraphNamespaceLength = 7;
        private const string Separator = ", ";

        /// <summary>
        /// Generates a standardized navigator name for the specified subject.
        /// </summary>
        /// <param name="subject">The name of the subject for which to generate the navigator name. Cannot be <see langword="null"/>.</param>
        /// <returns>A string representing the navigator name in the format "{subject}Navigator".</returns>
        public static string GetName(string subject)
        {
            return $"{subject}Navigator";
        }

        /// <summary>
        /// Generates a collection of source code representations for the specified subject and its properties.
        /// </summary>
        /// <param name="subject">The subject for which to generate source code. Cannot be <see langword="null"/>.</param>
        /// <returns>
        /// An enumerable collection of <see cref="Source"/> objects representing the generated source code for the subject and its properties.
        /// </returns>
        public IEnumerable<Source> Generate(Subject subject)
        {
            string name = GetName(subject.Name);
            string @namespace = string.Concat(subject.Qualification, ".Graph");

            yield return GenerateNavigator(name, subject);

            IEnumerable<Source> contents = GenerateContent(name, @namespace, string.Empty, Array.Empty<Predecessor>(), subject.Properties, subject, 0);

            foreach (Source content in contents)
            {
                yield return content;
            }
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
            string @class,
            string @namespace,
            string method,
            Predecessor[] preceding,
            ImmutableArray<Property> properties,
            Subject subject,
            int tier)
        {
            tier++;

            GeneratePropertyContent(preceding, tier, out string arguments, out string parameters);

            foreach (Property property in properties)
            {
                string moniker = string.Concat(method, property.Name);

                yield return GenerateContentForProperty(
                    arguments,
                    @class,
                    @namespace,
                    moniker,
                    parameters,
                    preceding,
                    property,
                    subject,
                    tier,
                    out string next);

                IEnumerable<Source> succeeding = Enumerable.Empty<Source>();

                if (property.IsSequence)
                {
                    succeeding = GenerateContentForElement(
                        arguments,
                        @class,
                        property.Element,
                        next,
                        moniker,
                        parameters,
                        preceding,
                        property,
                        subject,
                        tier);
                }

                succeeding = succeeding.Concat(GenerateContentsForProperty(@class, next, moniker, preceding, property, subject, tier));

                foreach (Source source in succeeding)
                {
                    yield return source;
                }
            }
        }

        private static Source GenerateContent(
            string arguments,
            string body,
            string @class,
            string name,
            string @namespace,
            string method,
            string parameters,
            Subject subject,
            string template,
            string type,
            out string next)
        {
            next = $"{@namespace}.{name}";

            string code = string.Format(
                template,
                subject.Type,
                parameters,
                type,
                next,
                arguments,
                body,
                name,
                method);

            code = string.Format(GenerateContentNest, @class, subject.Name, code.Indent());
            string hint = next.Substring(subject.Name.Length + GraphNamespaceLength);

            return new Source(code, $"{@class}.{hint}");
        }

        private static IEnumerable<Source> GenerateContentForElement(
            string arguments,
            string @class,
            Element element,
            string @namespace,
            string method,
            string parameters,
            Predecessor[] preceding,
            Property property,
            Subject subject,
            int tier)
        {
            Predecessor[] pool = default;
            string moniker = string.Concat(method, element.Name);

            try
            {
                pool = AppendCurrentForNextTier(preceding, tier, Predecessor.From(property), Predecessor.From(element));
                string body = GenerateConcatenationsForElement(moniker, pool, element.Properties, tier);

                yield return GenerateContent(
                    arguments,
                    body.Indent(times: 2),
                    @class,
                    element.Name,
                    @namespace,
                    moniker,
                    parameters,
                    subject,
                    GenerateContentForElementContent,
                    property.Type,
                    out string next);

                foreach (Source source in GenerateContent(@class, next, moniker, pool, element.Properties, subject, tier + 1))
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
            string arguments,
            string @class,
            string @namespace,
            string method,
            string parameters,
            Predecessor[] preceding,
            Property property,
            Subject subject,
            int tier,
            out string next)
        {
            string body = GenerateConcatenationsForProperty(method, preceding, property.Properties, tier);

            return GenerateContent(
                arguments,
                body,
                @class,
                property.Name,
                @namespace,
                method,
                parameters,
                subject,
                GenerateContentForPropertyContent,
                property.Type,
                out next);
        }

        private static IEnumerable<Source> GenerateContentsForProperty(
            string @class,
            string @namespace,
            string method,
            Predecessor[] preceding,
            Property property,
            Subject subject,
            int tier)
        {
            Predecessor[] pool = default;

            try
            {
                pool = AppendCurrentForNextTier(preceding, tier, Predecessor.From(property));

                foreach (Source succeeding in GenerateContent(@class, @namespace, method, pool, property.Properties, subject, tier))
                {
                    yield return succeeding;
                }
            }
            finally
            {
                ArrayPool<Predecessor>.Shared.Return(pool);
            }
        }

        private static Source GenerateNavigator(string name, Subject subject)
        {
            string contract = ContractStrategy.GetName(subject.Name);
            string body = GenerateConcatenationsForSubject(subject.Properties);

            string code = string.Format(
                GenerateNavigatorContent,
                name,
                contract,
                subject.Name,
                body.Indent(times: 2));

            return new Source(code, $"{GetName(subject.Name)}");
        }

        [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "Suggested approach is less readable.")]
        private static string GenerateConcatenations(
            string method,
            Predecessor[] preceding,
            in ImmutableArray<Property> properties,
            string template,
            int tier)
        {
            string call = string.Empty;

            if (tier > 1)
            {
                IEnumerable<string> arguments = preceding
                    .Take(tier - 1)
                    .Select(predecessor => predecessor.Name.ToCamelCase());

                call = string.Join(Separator, arguments);
                call = string.Concat(call, Separator);
            }

            var builder = new StringBuilder();

            foreach (Property property in properties)
            {
                _ = builder.AppendLine(string.Format(
                    template,
                    string.Concat(method, property.Name),
                    call,
                    property.Name));
            }

            return builder.ToString();
        }

        private static string GenerateConcatenationsForElement(
            string method,
            Predecessor[] preceding,
            in ImmutableArray<Property> properties,
            int tier)
        {
            return GenerateConcatenations(method, preceding, properties, GenerateConcatenationsForElementContent, tier);
        }

        private static string GenerateConcatenationsForProperty(
            string method,
            Predecessor[] preceding,
            in ImmutableArray<Property> properties,
            int tier)
        {
            return GenerateConcatenations(method, preceding, properties, GenerateConcatenationsForPropertyContent, tier);
        }

        private static string GenerateConcatenationsForSubject(in ImmutableArray<Property> properties)
        {
            return GenerateConcatenations(string.Empty, Array.Empty<Predecessor>(), properties, GenerateConcatenationsForSubjectContent, 0);
        }

        private static void GeneratePropertyContent(Predecessor[] preceding, int tier, out string arguments, out string paramerers)
        {
            if (tier == 1)
            {
                arguments = string.Empty;
                paramerers = string.Empty;

                return;
            }

            int total = tier - 1;
            string[] declarations = ArrayPool<string>.Shared.Rent(total);
            string[] propagations = ArrayPool<string>.Shared.Rent(total);

            try
            {
                for (int index = 0; index < total; index++)
                {
                    Predecessor predecessor = preceding[index];
                    string variable = predecessor.Name.ToCamelCase();

                    propagations[index] = $"{predecessor.Type} {variable}";
                    declarations[index] = variable;
                }

                arguments = string.Join(Separator, declarations, 0, total);
                paramerers = string.Join(Separator, propagations, 0, total);

                arguments = string.Concat(arguments, Separator);
                paramerers = string.Concat(paramerers, Separator);
            }
            finally
            {
                ArrayPool<string>.Shared.Return(propagations);
                ArrayPool<string>.Shared.Return(declarations);
            }
        }
    }
}