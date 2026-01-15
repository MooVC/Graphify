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
            return GenerateClasses(string.Empty, Array.Empty<Property>(), subject.Properties, subject, 0);
        }

        private static Property[] AppendCurrentPropertyForNextTier(Property[] preceding, int tier, Property property)
        {
            Property[] pool = ArrayPool<Property>.Shared.Rent(tier);

            if (tier > 1)
            {
                Array.Copy(preceding, pool, tier - 1);
            }

            pool[tier - 1] = property;

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
            string wrapper = GenerateWrapperDeclarations(preceding, tier);

            foreach (Property property in properties)
            {
                string code = string.Format(
                    GenerateClassesContent,
                    @namespace,
                    property.Name,
                    subject.Type,
                    parameters,
                    property.Type,
                    assignments,
                    body);

                code = ApplyWrapper(code, wrapper, tier);

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

        private static string ApplyWrapper(string code, string wrapper, int tier)
        {
            if (tier == 1)
            {
                return code;
            }

            code = code.Indent(times: tier - 1);

            return wrapper.Replace(Declaration, code);
        }

        private static string GeneratePropertyContent(Property[] preceding, int tier, out string assignments, out string parameters)
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
                Property property = preceding[index];

                _ = arguments.Append(string.Format(GeneratePropertyContentArgument, property.Type, property.Name.ToLowerInvariant()));
                _ = constructor.AppendLine(string.Format(GeneratePropertyContentAssignment, property.Name, property.Name.ToLowerInvariant()));

                _ = declarations
                    .AppendLine()
                    .AppendLine(string.Format(GeneratePropertyContentDeclaration, property.Type, property.Name));
            }

            assignments = constructor.ToString();
            parameters = arguments.ToString();

            return declarations.ToString();
        }

        private static string GenerateWrapperDeclarations(Property[] preceding, int tier)
        {
            if (tier == 1)
            {
                return string.Empty;
            }

            string previous = Declaration;

            for (int index = tier - 2; index >= 0; index--)
            {
                Property property = preceding[index];

                previous = string.Format(GenerateWrapperDeclarationsContent, property.Name, previous);
            }

            return previous;
        }
    }
}