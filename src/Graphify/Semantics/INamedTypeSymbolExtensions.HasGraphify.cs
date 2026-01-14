namespace Graphify.Semantics
{
    using Microsoft.CodeAnalysis;

    using static Graphify.GraphifyAttributeGenerator;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        /// <summary>
        /// Determines whether or not the <paramref name="symbol"/> provided is annotated with the Graphify attribute.
        /// </summary>
        /// <param name="symbol">The symbol for the record to be checked for the presence of the Graphify attribute.</param>
        /// <returns>True if the Graphify attribute is present on the <paramref name="symbol"/>, otherwise False.</returns>
        public static bool HasGraphify(this INamedTypeSymbol symbol)
        {
            return symbol.HasAttribute(Name);
        }
    }
}