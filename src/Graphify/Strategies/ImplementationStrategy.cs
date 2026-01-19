namespace Graphify.Strategies
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Graphify.Model;
    using static Graphify.Strategies.ModelStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating contents that match each tier within the hierarchy that involve a sequence.
    /// </summary>
    internal sealed class ImplementationStrategy
        : IStrategy
    {
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

            return GenerateContent(name, subject.Name, Array.Empty<Predecessor>(), subject.Properties, subject, 0);
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

            string body = GeneratePropertyContent(preceding, tier, out string parameters);

            foreach (Property property in properties)
            {
                yield return GenerateContentForProperty(body, @class, @namespace, parameters, property, subject, out string next);

                IEnumerable<Source> succeeding = Enumerable.Empty<Source>();

                if (property.IsSequence)
                {
                    succeeding = GenerateContentForElement(body, @class, property.Element, next, parameters, preceding, property, subject, tier);
                }

                succeeding = succeeding.Concat(GenerateContentsForProperty(@class, next, preceding, property, subject, tier));

                foreach (Source source in succeeding)
                {
                    yield return source;
                }
            }
        }

        private static Source GenerateContent(
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
            string code = string.Format(
                template,
                @namespace,
                name,
                subject.Type,
                parameters,
                type,
                body);

            code = string.Format(GenerateContentNest, @class, code.Indent());
            next = $"{@namespace}.{name}";

            return new Source(code, next);
        }

        private static IEnumerable<Source> GenerateContentForElement(
            string body,
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
                body,
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
            string body,
            string @class,
            string @namespace,
            string parameters,
            Property property,
            Subject subject,
            out string next)
        {
            return GenerateContent(
                body,
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

        private static string GeneratePropertyContent(Predecessor[] preceding, int tier, out string paramerers)
        {
            if (tier == 1)
            {
                paramerers = string.Empty;

                return string.Empty;
            }

            const string separator = ", ";

            int total = tier - 1;
            string[] arguments = ArrayPool<string>.Shared.Rent(total);
            string[] assignments = ArrayPool<string>.Shared.Rent(total);

            try
            {
                for (int index = 0; index < total; index++)
                {
                    Predecessor predecessor = preceding[index];
                    string variable = predecessor.Name.ToCamelCase();

                    arguments[index] = $"{predecessor.Type} {variable}";
                    assignments[index] = variable;
                }

                paramerers = string.Join(separator, arguments, 0, total);

                return string.Join(separator, assignments, 0, total);
            }
            finally
            {
                ArrayPool<string>.Shared.Return(assignments);
                ArrayPool<string>.Shared.Return(arguments);
            }
        }
    }
}