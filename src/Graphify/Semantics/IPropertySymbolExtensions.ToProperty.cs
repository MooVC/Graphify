namespace Graphify.Semantics
{
    using Graphify.Model;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="IPropertySymbol"/>.
    /// </summary>
    internal static partial class IPropertySymbolExtensions
    {
        /// <summary>
        /// Converts the specified Roslyn property symbol to a corresponding <see cref="Property"/> instance.
        /// </summary>
        /// <param name="property">The property symbol to convert. Cannot be <see langword="null"/>.</param>
        /// <returns>A <see cref="Property"/> instance representing the specified property symbol.</returns>
        public static Property ToProperty(this IPropertySymbol property)
        {
            _ = property.Type.IsSequence(out Element element);

            return new Property
            {
                Element = element,
                IsIgnored = false,
                Name = property.Name,
                Symbol = property.Type,
                Type = property.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            };
        }
    }
}