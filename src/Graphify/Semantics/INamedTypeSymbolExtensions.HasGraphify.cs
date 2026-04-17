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
        /// <param name="symbol">The symbol for the record to be checked for the presence of the Graphify attribute.</param>
        /// <param name="depth">The depth configured on the Graphify attribute, or the default value.</param>
        /// <param name="mode">The mode configured on the Graphify attribute, or the default value.</param>
        /// <returns>True if the Graphify attribute is present on the <paramref name="symbol"/>, otherwise False.</returns>
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

            argumentText = argumentText.Replace($"{GraphifyAttributeGenerator.Name}Attribute.", string.Empty);
            argumentText = argumentText.Replace($"{GraphifyAttributeGenerator.Name}.", string.Empty);
            argumentText = argumentText.Replace("global::Graphify.", string.Empty);
            argumentText = argumentText.Replace("Graphify.", string.Empty);
            argumentText = argumentText.Replace($"{nameof(Modes)}.", string.Empty);

            if (!Enum.TryParse(argumentText, true, out mode))
            {
                return false;
            }

            return true;
        }
    }
}
