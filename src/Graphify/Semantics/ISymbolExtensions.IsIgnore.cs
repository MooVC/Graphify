namespace Graphify.Semantics
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="ISymbol"/>.
    /// </summary>
    internal static partial class ISymbolExtensions
    {
        /// <summary>
        /// Determines whether or not the <paramref name="subject"/> represents the Ignore attribute.
        /// </summary>
        /// <param name="subject">
        /// The symbol to check.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="subject"/> is the Ignore attribute, otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsIgnore(this ISymbol subject)
        {
            return subject.IsAttribute(IgnoreAttributeGenerator.Name);
        }
    }
}