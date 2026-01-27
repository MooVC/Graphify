namespace Graphify.Semantics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
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

            if ((HasDepthOnConstuctorArguments(attribute, out depth) || HasDescriptorOnSyntax(attribute, out depth)) && depth == 0)
            {
                depth = DefaultDepth;
            }

            return true;
        }

        private static bool HasDepthOnConstuctorArguments(this AttributeData attribute, out byte depth)
        {
            depth = DefaultDepth;

            if (attribute.ConstructorArguments.Length == 0)
            {
                return false;
            }

            TypedConstant argument = attribute.ConstructorArguments.First();

            if (argument.Value is byte value)
            {
                depth = value;

                return true;
            }

            return false;
        }

        private static bool HasDescriptorOnSyntax(this AttributeData attribute, out byte value)
        {
            if (attribute.ApplicationSyntaxReference is object
             && attribute.ApplicationSyntaxReference.GetSyntax() is AttributeSyntax syntax
             && syntax.ArgumentList is object
             && syntax.ArgumentList.Arguments.Count == 1)
            {
                AttributeArgumentSyntax argument = syntax.ArgumentList.Arguments[0];

                string expression = argument.Expression is LiteralExpressionSyntax literal && literal.IsKind(SyntaxKind.NumericLiteralExpression)
                    ? literal.Token.ValueText
                    : argument.Expression.ToString();

                return byte.TryParse(expression, out value);
            }

            value = DefaultDepth;

            return false;
        }
    }
}