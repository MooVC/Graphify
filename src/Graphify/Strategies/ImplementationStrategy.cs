namespace Graphify.Strategies
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
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
            // TODO: Add the code for the Navgator public method
            return GenerateContent(name, $"{subject.Name}.Graph", Array.Empty<Predecessor>(), subject.Properties, subject, 0);
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
            Predecessor[] preceding,
            ImmutableArray<Property> properties,
            Subject subject,
            int tier)
        {
            tier++;

            GeneratePropertyContent(preceding, tier, out string arguments, out string parameters);

            foreach (Property property in properties)
            {
                yield return GenerateContentForProperty(arguments, @class, @namespace, parameters, property, subject, out string next);

                IEnumerable<Source> succeeding = Enumerable.Empty<Source>();

                if (property.IsSequence)
                {
                    succeeding = GenerateContentForElement(arguments, @class, property.Element, next, parameters, preceding, property, subject, tier);
                }

                succeeding = succeeding.Concat(GenerateContentsForProperty(@class, next, preceding, property, subject, tier));

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
                name);

            code = string.Format(GenerateContentNest, @class, subject.Name, code.Indent());
            string hint = next.Substring(subject.Name.Length + GraphNamespaceLength);

            return new Source(code, $"{@class}.{hint}");
        }

        private static IEnumerable<Source> GenerateContentForElement(
            string arguments,
            string @class,
            Element element,
            string @namespace,
            string parameters,
            Predecessor[] preceding,
            Property property,
            Subject subject,
            int tier)
        {
            yield return GenerateContent(
                arguments,
                $"results = Concat(results, Navigate(index, root, {arguments}, value.{property.Name}), cancellationToken);",
                @class,
                element.Name,
                @namespace,
                parameters,
                subject,
                GenerateContentForElementContent,
                element.Type,
                out string next);

            Predecessor[] pool = default;

            try
            {
                pool = AppendCurrentForNextTier(preceding, tier, Predecessor.From(property), Predecessor.From(element));

                foreach (Source source in GenerateContent(@class, next, pool, element.Properties, subject, tier + 1))
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
            string parameters,
            Property property,
            Subject subject,
            out string next)
        {
            return GenerateContent(
                arguments,
                $"results = Concat(results, Navigate(root, {arguments}, value.{property.Name}), cancellationToken);",
                @class,
                property.Name,
                @namespace,
                parameters,
                subject,
                GenerateContentForPropertyContent,
                property.Type,
                out next);
        }

        private static IEnumerable<Source> GenerateContentsForProperty(
            string @class,
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

                foreach (Source succeeding in GenerateContent(@class, @namespace, pool, property.Properties, subject, tier))
                {
                    yield return succeeding;
                }
            }
            finally
            {
                ArrayPool<Predecessor>.Shared.Return(pool);
            }
        }

        private static void GeneratePropertyContent(Predecessor[] preceding, int tier, out string arguments, out string paramerers)
        {
            if (tier == 1)
            {
                arguments = string.Empty;
                paramerers = string.Empty;

                return;
            }

            const string separator = ", ";

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

                arguments = string.Join(separator, declarations, 0, total);
                paramerers = string.Join(separator, propagations, 0, total);

                arguments = string.Concat(arguments, separator);
                paramerers = string.Concat(paramerers, separator);
            }
            finally
            {
                ArrayPool<string>.Shared.Return(propagations);
                ArrayPool<string>.Shared.Return(declarations);
            }
        }
    }
}