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
        private static readonly ConcurrentDictionary<string, ImmutableArray<Property>> _cache
             = new ConcurrentDictionary<string, ImmutableArray<Property>>();

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

            ImmutableArray<Property> GetProperties()
            {
                return type
                    .GetMembers()
                    .OfType<IPropertySymbol>()
                    .Where(property => !(property.IsStatic || property.IsIndexer)
                                    && property.ExplicitInterfaceImplementations.Length == 0
                                    && !property.Type.Equals(type, SymbolEqualityComparer.Default))
                    .Select(property => property.ToProperty())
                    .ToImmutableArray();
            }

            return _cache.GetOrAdd(key, _ => GetProperties());
        }
    }
}