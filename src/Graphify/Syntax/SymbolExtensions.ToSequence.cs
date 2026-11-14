namespace Graphify.Syntax
{
    using System.Collections.Generic;
    using MooVC.Syntax.CSharp;

    internal static partial class SymbolExtensions
    {
        /// <summary>
        /// Constructs a synchronous or asynchronous sequence type for an element.
        /// </summary>
        /// <param name="element">The symbol for the sequence's element type.</param>
        /// <param name="asynchronous">Whether to use <see cref="IAsyncEnumerable{T}"/> instead of <see cref="IEnumerable{T}"/>.</param>
        /// <returns>The sequence interface with <paramref name="element"/> as its type argument.</returns>
        public static Symbol ToSequence(this Symbol element, bool asynchronous = false)
        {
            Symbol sequence = asynchronous ? typeof(IAsyncEnumerable<>) : typeof(IEnumerable<>);

            return sequence.WithArguments(element);
        }
    }
}