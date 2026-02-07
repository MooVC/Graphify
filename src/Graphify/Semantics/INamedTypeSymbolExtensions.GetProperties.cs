namespace Graphify.Semantics
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        /// <summary>
        /// Returns a collection of <see cref="Property"/> for each property belonging to <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        /// The class from which the properties are to be retrieved.
        /// </param>
        /// <returns>
        /// The collection of <see cref="Property"/> for each property belonging to <paramref name="type"/>.
        /// </returns>
        public static ImmutableArray<Property> GetProperties(this INamedTypeSymbol type)
        {
            INamedTypeSymbol current = type;
            var all = new List<Property>();
            var cache = new ConcurrentDictionary<string, Property[]>();

            do
            {
                ImmutableArray<Property> properties = current.TryGetAllPropertiesFromCache(cache);

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
                        property.Properties = property.Symbol.TryGetAllPropertiesFromCache(cache);
                    }
                }

                all.AddRange(properties);

                current = current.BaseType;
            }
            while (current is object);

            return all.ToImmutableArray();
        }

        private static ImmutableArray<Property> TryGetAllPropertiesFromCache(this ITypeSymbol type, ConcurrentDictionary<string, Property[]> cache)
        {
            string key = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

            if (cache.TryGetValue(key, out Property[] cached))
            {
                return cached.ToImmutableArray();
            }

            Property[] GetProperties()
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
                    .Select(candidate => candidate.Property.ToProperty(candidate.Scope))
                    .ToArray();
            }

            Property[] properties = GetProperties();

            cache[key] = properties;

            foreach (Property property in properties)
            {
                if (property.Element is object)
                {
                    property.Element.Properties = property.Element.Symbol.TryGetAllPropertiesFromCache(cache);
                }
            }

            return properties.ToImmutableArray();
        }
    }
}