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
        /// <param name="depth">The configured maximum depth to graph.</param>
        /// <param name="level">The current level within the graph.</param>
        /// <param name="scope">The scope to which the property is to be graphed.</param>
        /// <returns>A <see cref="Property"/> instance representing the specified property symbol.</returns>
        public static Property ToProperty(this IPropertySymbol property, byte depth, byte level, TraverseScope scope)
        {
            _ = property.Type.IsSequence(property.ContainingType, depth, level, out Element element);

            return new Property
            {
                Element = element,
                Name = property.Name,
                Scope = scope,
                Symbol = property.Type,
                Type = property.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            };
        }
    }
}