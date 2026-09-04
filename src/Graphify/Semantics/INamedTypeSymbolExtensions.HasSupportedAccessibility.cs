namespace Graphify.Semantics
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        /// <summary>
        /// Determines whether the provided type has a supported accessibility for Graphify generation.
        /// </summary>
        /// <param name="subject">
        /// The type symbol to inspect.
        /// </param>
        /// <returns>
        /// <see langword="true"/> when the type is declared as public or internal; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool HasSupportedAccessibility(this INamedTypeSymbol subject)
        {
            return subject.DeclaredAccessibility == Accessibility.Public
                || subject.DeclaredAccessibility == Accessibility.Internal;
        }
    }
}