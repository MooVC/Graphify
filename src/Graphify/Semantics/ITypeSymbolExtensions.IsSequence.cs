namespace Graphify.Semantics
{
    using System.Linq;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="ITypeSymbol"/>.
    /// </summary>
    internal static partial class ITypeSymbolExtensions
    {
        /// <summary>
        /// Determines whether or not the <paramref name="type"/> represents a sequence.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><see langword="true"/> if the <paramref name="type"/> represents a sequence, otherwise <see langword="false"/>.</returns>
        public static bool IsSequence(this ITypeSymbol type)
        {
            bool IsEnumerable(INamedTypeSymbol @interface)
            {
                return @interface.OriginalDefinition.SpecialType == SpecialType.System_Collections_Generic_IEnumerable_T
                    || @interface.SpecialType == SpecialType.System_Collections_IEnumerable;
            }

            return type.SpecialType != SpecialType.System_String && (type is IArrayTypeSymbol || type.AllInterfaces.Any(IsEnumerable));
        }
    }
}