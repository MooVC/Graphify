namespace Graphify.Semantics
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="IPropertySymbol"/>.
    /// </summary>
    internal static partial class IPropertySymbolExtensions
    {
        /// <summary>
        /// Gets the declaration accessibility for the provided property.
        /// </summary>
        /// <param name="property">
        /// The property symbol to inspect.
        /// </param>
        /// <returns>
        /// The declaration accessibility for the property.
        /// </returns>
        public static string GetDeclaration(this IPropertySymbol property)
        {
            return property.DeclaredAccessibility == Accessibility.Internal
                ? "internal"
                : "public";
        }
    }
}