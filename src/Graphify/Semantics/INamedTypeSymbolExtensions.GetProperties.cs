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
        private static readonly ConcurrentDictionary<string, Property[]> _cache
             = new ConcurrentDictionary<string, Property[]>();

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

            do
            {
                ImmutableArray<Property> properties = current.TryGetAllPropertiesFromCache();

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

                    property.Properties = TryGetAllPropertiesFromCache(property.Symbol);
                }

                all.AddRange(properties);

                current = current.BaseType;
            }
            while (current is object);

            return all.ToImmutableArray();
        }

        private static ImmutableArray<Property> TryGetAllPropertiesFromCache(this ITypeSymbol type)
        {
            string key = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

            Property[] GetProperties()
            {
                return type
                    .GetMembers()
                    .OfType<IPropertySymbol>()
                    .Where(property => !(property.IsStatic || property.IsIndexer)
                                    && property.ExplicitInterfaceImplementations.Length == 0
                                    && !property.Type.Equals(type, SymbolEqualityComparer.Default))
                    .Select(property => new
                    {
                        Property = property,
                        Scope = property.GetTraverseScope(),
                    })
                    .Where(candidate => candidate.Scope != TraverseScope.None)
                    .Select(candidate => candidate.Property.ToProperty(candidate.Scope))
                    .ToArray();
            }

            return _cache
                .GetOrAdd(key, _ => GetProperties())
                .ToImmutableArray();
        }
    }
}