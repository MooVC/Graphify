namespace Graphify.Strategies
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Text;
    using Graphify.Model;
    using static Graphify.Strategies.ClassStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating classes that match each tier within the hierarchy.
    /// </summary>
    internal sealed class ClassStrategy
        : IStrategy
    {
        /// <summary>
        /// Generates a collection of source code representations for the specified subject and its properties.
        /// </summary>
        /// <param name="subject">The subject for which to generate source code. Cannot be <see langword="null"/>.</param>
        /// <returns>
        /// An enumerable collection of <see cref="Source"/> objects representing the generated source code for the subject and its properties.
        /// </returns>
        public IEnumerable<Source> Generate(Subject subject)
        {
            string @namespace = $"{subject.Namespace}.{subject.Name}";

            return GenerateClasses(@namespace, Array.Empty<Property>(), subject.Properties, subject, 0);
        }

        private static Property[] AppendCurrentPropertyForNextTier(Property[] preceding, int tier, Property property)
        {
            Property[] pool = ArrayPool<Property>.Shared.Rent(tier);

            if (preceding.Length > 0)
            {
                Array.Copy(preceding, pool, preceding.Length);
            }

            pool[preceding.Length] = property;

            return pool;
        }

        private static IEnumerable<Source> GenerateClasses(
            string @namespace,
            Property[] preceding,
            ImmutableArray<Property> properties,
            Subject subject,
            int tier)
        {
            tier++;

            string body = GeneratePropertyContent(preceding, tier, out string assignments, out string parameters);

            foreach (Property property in properties)
            {
                string code = string.Format(
                    GenerateClassesContent,
                    @namespace,
                    property.Name,
                    subject.Qualification,
                    parameters,
                    property.Type,
                    assignments,
                    body);

                string next = $"{@namespace}.{property.Name}";

                yield return new Source(code, next);

                Property[] pool = default;

                try
                {
                    pool = AppendCurrentPropertyForNextTier(preceding, tier, property);

                    foreach (Source succeeding in GenerateClasses(next, pool, property.Properties, subject, tier))
                    {
                        yield return succeeding;
                    }
                }
                finally
                {
                    ArrayPool<Property>.Shared.Return(pool);
                }
            }
        }

        private static string GeneratePropertyContent(Property[] preceding, int tier, out string assignments, out string parameters)
        {
            if (preceding.Length == 0)
            {
                assignments = string.Empty;
                parameters = string.Empty;

                return string.Empty;
            }

            var arguments = new StringBuilder();
            var constructor = new StringBuilder();
            var declarations = new StringBuilder("\n");

            for (int index = 0; index < tier; index++)
            {
                Property property = preceding[index];

                _ = arguments.Append(string.Format(GeneratePropertyContentArgument, property.Type, property.Name.ToLowerInvariant()));
                _ = constructor.AppendLine(string.Format(GeneratePropertyContentAssignment, property.Name, property.Name.ToLowerInvariant()));

                _ = declarations
                    .AppendLine(string.Format(GeneratePropertyContentDeclaration, property.Type, property.Name))
                    .AppendLine();
            }

            assignments = constructor.ToString();
            parameters = arguments.ToString();

            return declarations.ToString();
        }
    }
}