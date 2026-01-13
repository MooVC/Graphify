namespace Monify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
/// </summary>
internal static partial class INamedTypeSymbolExtensions
{
    private static readonly Type _clonable = typeof(ICloneable);

    /// <summary>
    /// Determines whether or not the <paramref name="subject"/> implements <see cref="ICloneable"/>.
    /// </summary>
    /// <param name="subject">
    /// The symbol for the class to be checked for the declaration.
    /// </param>
    /// <param name="compilation">
    /// The <see cref="Compilation"/> used to source the symbol for <see cref="ICloneable"/>.
    /// </param>
    /// <param name="type">
    /// The type to which the <paramref name="subject"/> is being compared.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="subject"/> declares that it implements <see cref="ICloneable"/>, otherwise <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// The <paramref name="subject"/> is assumed to be a class.
    /// </remarks>
    public static bool IsClonable(this INamedTypeSymbol subject, Compilation compilation)
    {
        INamedTypeSymbol? clonable = compilation.GetTypeByMetadataName(_clonable.FullName);

        if (clonable is null)
        {
            return false;
        }

        bool IsEquatable(INamedTypeSymbol @interface)
        {
            return SymbolEqualityComparer.Default.Equals(@interface, clonable);
        }

        return subject.AllInterfaces.Any(IsEquatable);
    }
}