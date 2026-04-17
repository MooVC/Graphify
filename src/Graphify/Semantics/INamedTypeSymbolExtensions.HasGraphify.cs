namespace Graphify.Semantics
{
    using System;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;
    using static Graphify.GraphifyAttributeGenerator;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        private const byte DefaultDepth = 16;

        /// <summary>
        /// Determines whether or not the <paramref name="symbol"/> provided is annotated with the Graphify attribute.
        /// </summary>
        public static bool HasGraphify(this INamedTypeSymbol symbol, out byte depth, out Modes mode)
        {
            depth = DefaultDepth;
            mode = Modes.Asynchronous;

            AttributeData attribute = symbol.GetAttribute(Name);

            if (attribute is null)
            {
                return false;
            }

            if (TryGetDepth(attribute, out depth) && depth == 0)
            {
                depth = DefaultDepth;
            }

            _ = TryGetMode(attribute, out mode);

            return true;
        }

        private static bool TryGetDepth(AttributeData attribute, out byte depth)
        {
            depth = DefaultDepth;

            if (!attribute.TryGetArgumentText(nameof(Subject.Depth), out string argumentText))
            {
                return false;
            }

            if (!byte.TryParse(argumentText, out byte value))
            {
                return false;
            }

            depth = value;

            return true;
        }

        private static bool TryGetMode(AttributeData attribute, out Modes mode)
        {
            mode = Modes.Asynchronous;

            if (!attribute.TryGetArgumentText(nameof(Subject.Mode), out string argumentText))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(argumentText))
            {
                return false;
            }

            int separator = argumentText.LastIndexOf('.', StringComparison.Ordinal);

            argumentText = separator >= 0
                ? argumentText.Substring(separator + 1)
                : argumentText;

            return Enum.TryParse(argumentText, ignoreCase: false, out mode);
        }
    }
}
