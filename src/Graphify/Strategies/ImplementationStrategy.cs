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

            if (tier > subject.Depth)
            {
                yield break;
            }

            GeneratePropertyContent(@namespace, preceding, tier, out string arguments, out string parameters);

            foreach (Property property in properties)
            {
                string moniker = string.Concat(method, property.Name);

                yield return GenerateContentForProperty(
                    arguments,
                    @class,
                    @namespace,
                    moniker,
                    parameters,
                    property,
                    subject,
                    tier,
                    out string next);

                IEnumerable<Source> succeeding = Enumerable.Empty<Source>();

                if (property.IsSequence)
                {
                    succeeding = GenerateContentForElement(
                        @class,
                        property.Element,
                        next,
                        moniker,
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
            Element element,
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
                method,
                element?.Type,
                ToCamelCase(name));

            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            code = string.Format(GenerateContentNest, accessibility, @class, subject.Name, code.Indent());
            string hint = next.Substring(subject.Name.Length + GraphNamespaceLength);

            return new Source(code, $"{@class}.{hint}");
        }

        private static IEnumerable<Source> GenerateContentForElement(
            string @class,
            Element element,
            string @namespace,
            string method,
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
                tier++;
                string name = ToCamelCase(element.Name);
                string body = GenerateConcatenationsForElement(moniker, element.Properties, name, subject, tier);
                GeneratePropertyContent(@namespace, pool, tier, out string arguments, out string parameters);

                yield return GenerateContent(
                    arguments,
                    body.Indent(skip: 0, times: 2, trim: false),
                    @class,
                    element,
                    element.Name,
                    @namespace,
                    moniker,
                    parameters,
                    subject,
                    GenerateContentForElementContent,
                    property.Type,
                    out string next);

                foreach (Source source in GenerateContent(@class, next, moniker, pool, element.Properties, subject, tier))
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
            Property property,
            Subject subject,
            int tier,
            out string next)
        {
            string body = GenerateConcatenationsForProperty(property.Element, method, property.Properties, ToCamelCase(property.Name), subject, tier);

            return GenerateContent(
                arguments,
                body.Indent(skip: 0, trim: false),
                @class,
                property.Element,
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
            string body = GenerateConcatenationsForSubject(subject.Properties, subject);
            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();

            string code = string.Format(
                GenerateNavigatorContent,
                accessibility,
                name,
                contract,
                subject.Name,
                body.Indent(skip: 0, times: 2, trim: false));

            return new Source(code, $"{GetName(subject.Name)}");
        }

        private static string GenerateConcatenations(
            Element element,
            string method,
            in ImmutableArray<Property> properties,
            string variable,
            Subject subject,
            string template,
            int tier)
        {
            if (tier >= subject.Depth || (element is null && properties.Length == 0))
            {
                return string.Empty;
            }

            string call = string.Empty;

            if (tier > 0)
            {
                call = string.Concat(variable, ", ");
            }

            return GenerateConcatenations(call, element, method, properties, template);
        }

        [SuppressMessage("Minor Code Smell", "S3267:Loops should be simplified with \"LINQ\" expressions", Justification = "Suggested approach is less readable.")]
        private static string GenerateConcatenations(string call, Element element, string method, ImmutableArray<Property> properties, string template)
        {
            var builder = new StringBuilder();

            _ = builder.AppendLine();

            if (element is object)
            {
                _ = builder.AppendLine(string.Format(
                    GenerateConcatenationsForPropertyElement,
                    string.Concat(method, element.Name),
                    call,
                    element.Name));
            }

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
            in ImmutableArray<Property> properties,
            string variable,
            Subject subject,
            int tier)
        {
            return GenerateConcatenations(default, method, properties, variable, subject, GenerateConcatenationsForElementContent, tier);
        }

        private static string GenerateConcatenationsForProperty(
            Element element,
            string method,
            in ImmutableArray<Property> properties,
            string variable,
            Subject subject,
            int tier)
        {
            return GenerateConcatenations(element, method, properties, variable, subject, GenerateConcatenationsForPropertyContent, tier);
        }

        private static string GenerateConcatenationsForSubject(in ImmutableArray<Property> properties, Subject subject)
        {
            return GenerateConcatenations(default, string.Empty, properties, string.Empty, subject, GenerateConcatenationsForSubjectContent, 0);
        }

        private static void GeneratePropertyContent(string @namespace, Predecessor[] preceding, int tier, out string arguments, out string parameters)
        {
            if (tier == 1)
            {
                arguments = string.Empty;
                parameters = string.Empty;

                return;
            }

            string parameterName = ToCamelCase(preceding[tier - 2].Name);

            arguments = string.Concat(parameterName, ", ");
            parameters = string.Concat(@namespace, " ", parameterName, ", ");
        }

        private static string ToCamelCase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            return string.Concat(char.ToLowerInvariant(name[0]), name.Substring(1));
        }
    }
}