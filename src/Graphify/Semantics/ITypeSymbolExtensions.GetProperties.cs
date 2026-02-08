namespace Graphify.Semantics
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="ITypeSymbol"/>.
    /// </summary>
    internal static partial class ITypeSymbolExtensions
    {
        /// <summary>
        /// Returns a collection of <see cref="Property"/> for each property belonging to <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        /// The class from which the properties are to be retrieved.
        /// </param>
        /// <param name="depth">
        /// The depth configured on the Graphify attribute.
        /// </param>
        /// <returns>
        /// The collection of <see cref="Property"/> for each property belonging to <paramref name="type"/>.
        /// </returns>
        public static ImmutableArray<Property> GetProperties(this ITypeSymbol type, byte depth)
        {
            return type.GetProperties(depth, 0);
        }

        public static ImmutableArray<Property> GetProperties(this ITypeSymbol type, byte depth, byte level)
        {
            if (level++ == depth)
            {
                return ImmutableArray<Property>.Empty;
            }

            ITypeSymbol current = type;
            var all = new List<Property>();

            do
            {
                ImmutableArray<Property> properties = current.GetAllProperties(depth, level);

                foreach (Property property in properties)
                {
                    if (property.Scope == TraverseScope.Property)
                    {
                        property.Properties = ImmutableArray<Property>.Empty;

                        if (property.Element is object)
                        {
                            property.Element.Properties = ImmutableArray<Property>.Empty;
                        }

                        continue;
                    }

                    if (!property.Symbol.Equals(current, SymbolEqualityComparer.Default))
                    {
                        property.Properties = property.Symbol.GetAllProperties(depth, level);
                    }
                }

                all.AddRange(properties);

                current = current.BaseType;
            }
            while (current is object);

            return all.ToImmutableArray();
        }

        private static ImmutableArray<Property> GetAllProperties(this ITypeSymbol type, byte depth, byte level)
        {
            return type
                .GetMembers()
                .OfType<IPropertySymbol>()
                .Where(property => !(property.IsStatic || property.IsIndexer)
                                && property.ExplicitInterfaceImplementations.Length == 0)
                .Select(property => new
                {
                    Property = property,
                    Scope = property.GetTraverseScope(),
                })
                .Where(candidate => candidate.Scope != TraverseScope.None)
                .Select(candidate => candidate.Property.ToProperty(depth, level, candidate.Scope))
                .ToImmutableArray();
        }
    }
}