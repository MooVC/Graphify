namespace Graphify.Semantics
{
    using System.Linq;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="ITypeSymbol"/>.
    /// </summary>
    internal static partial class ITypeSymbolExtensions
    {
        private const int ExpectedArgumentsForEnumerable = 1;

        /// <summary>
        /// Determines whether or not the <paramref name="type"/> represents a sequence.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="container">The type within which the <paramref name="type"/> is defined.</param>
        /// <param name="depth">The configured maximum depth to graph.</param>
        /// <param name="level">The current level within the graph.</param>
        /// <param name="element">The element type if the <paramref name="type"/> is a sequence.</param>
        /// <returns><see langword="true"/> if the <paramref name="type"/> represents a sequence, otherwise <see langword="false"/>.</returns>
        public static bool IsSequence(this ITypeSymbol type, ITypeSymbol container, byte depth, byte level, out Element element)
        {
            bool IsEnumerable(INamedTypeSymbol @interface)
            {
                return @interface.OriginalDefinition.SpecialType == SpecialType.System_Collections_Generic_IEnumerable_T
                    || @interface.SpecialType == SpecialType.System_Collections_IEnumerable;
            }

            element = default;

            if (type.SpecialType == SpecialType.System_String)
            {
                return false;
            }

            if (type is IArrayTypeSymbol array)
            {
                element = array.ElementType.ToElement(container, depth, level);

                return true;
            }

            INamedTypeSymbol enumerable = type.AllInterfaces.FirstOrDefault(IsEnumerable);

            if (enumerable is object && enumerable.TypeArguments.Length == ExpectedArgumentsForEnumerable)
            {
                element = enumerable.TypeArguments[0].ToElement(container, depth, level);

                return true;
            }

            return false;
        }
    }
}