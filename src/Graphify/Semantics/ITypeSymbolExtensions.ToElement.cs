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
        /// Creates a new <see cref="Element"/> instance that represents the specified type symbol and its properties.
        /// </summary>
        /// <param name="type">The type symbol to convert to an <see cref="Element"/>. Cannot be <see langword="null"/>.</param>
        /// <returns>
        /// An <see cref="Element"/> representing the provided type symbol, including its name, properties, and symbol information.
        /// </returns>
        public static Element ToElement(this ITypeSymbol type)
        {
            IEnumerable<Property> properties = type is INamedTypeSymbol named
                ? named.GetProperties()
                : Enumerable.Empty<Property>();

            return new Element
            {
                Name = type.Name,
                Properties = properties.ToImmutableArray(),
                Symbol = type,
                Type = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            };
        }
    }
}