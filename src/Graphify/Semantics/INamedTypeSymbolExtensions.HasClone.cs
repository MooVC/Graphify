namespace Monify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private const int ExpectedParameterCountForClone = 0;

    /// <summary>
    /// Determines whether or not the <paramref name="subject"/> declares <see cref="ICloneable.Clone"/>.
    /// </summary>
    /// <param name="subject">
    /// The <paramref name="subject"/> to be checked.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="subject"/> declares <see cref="ICloneable.Clone"/>, otherwise <see langword="false"/>.
    /// </returns>
    public static bool HasClone(this INamedTypeSymbol subject)
    {
        return subject
            .GetMembers(nameof(ICloneable.Clone))
            .OfType<IMethodSymbol>()
            .Any(method => method.ReturnType.SpecialType == SpecialType.System_Object
                        && method.Parameters.Length == ExpectedParameterCountForClone);
    }
}