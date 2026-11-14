namespace Graphify.Syntax
{
    using System;
    using MooVC.Syntax.CSharp;
    using Attribute = System.Attribute;

    /// <summary>
    /// Provides extensions for using C# type spellings in generated declarations.
    /// </summary>
    internal static partial class StringExtensions
    {
        /// <summary>
        /// Converts a C# type spelling to a symbol while preserving its qualification and syntax.
        /// </summary>
        /// <param name="spelling">The complete C# type spelling, such as the display string returned by Roslyn.</param>
        /// <returns>A symbol that preserves the supplied type spelling when rendered.</returns>
        public static Symbol ToSymbol(this string spelling)
        {
            if (spelling.EndsWith(nameof(Attribute), StringComparison.Ordinal))
            {
                spelling += "/**/";
            }

            return (Qualification)(Moniker)spelling;
        }
    }
}