namespace Graphify.Semantics
{
    using System;
    using System.Collections.Generic;
    using Microsoft.CodeAnalysis;
    using static Graphify.GraphifyAttributeGenerator;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        private const byte DefaultDepth = 16;
        private const string DepthPropertyName = "Depth";

        /// <summary>
        /// Determines whether or not the <paramref name="symbol"/> provided is annotated with the Graphify attribute.
        /// </summary>
        /// <param name="symbol">The symbol for the record to be checked for the presence of the Graphify attribute.</param>
        /// <param name="depth">The depth configured on the Graphify attribute, or the default value.</param>
        /// <returns>True if the Graphify attribute is present on the <paramref name="symbol"/>, otherwise False.</returns>
        public static bool HasGraphify(this INamedTypeSymbol symbol, out byte depth)
        {
            depth = DefaultDepth;

            AttributeData attribute = symbol.GetAttribute(Name);

            if (attribute is null)
            {
                return false;
            }

            foreach (KeyValuePair<string, TypedConstant> argument in attribute.NamedArguments)
            {
                if (argument.Key.Equals(DepthPropertyName, StringComparison.Ordinal))
                {
                    depth = GetDepthValue(argument.Value);
                    break;
                }
            }

            return true;
        }

        private static byte GetDepthValue(TypedConstant value)
        {
            if (value.Value is null || value.Kind == TypedConstantKind.Error)
            {
                return DefaultDepth;
            }

            return value.Value switch
            {
                byte depth => depth,
                sbyte depth => (byte)depth,
                short depth => (byte)depth,
                ushort depth => (byte)depth,
                int depth => (byte)depth,
                uint depth => (byte)depth,
                long depth => (byte)depth,
                ulong depth => (byte)depth,
                _ => DefaultDepth,
            };
        }
    }
}