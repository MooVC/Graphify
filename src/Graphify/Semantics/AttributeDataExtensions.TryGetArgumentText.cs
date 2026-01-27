namespace Graphify.Semantics
{
    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Provides extensions relating to <see cref="AttributeData"/>.
    /// </summary>
    internal static partial class AttributeDataExtensions
    {
        /// <summary>
        /// Attempts to extract the argument text for an attribute by name or position.
        /// </summary>
        /// <param name="attribute">The attribute to inspect.</param>
        /// <param name="name">The argument name to locate, or empty for positional.</param>
        /// <param name="argumentText">The argument text if found.</param>
        /// <returns><see langword="true"/> when an argument is found; otherwise <see langword="false"/>.</returns>
        public static bool TryGetArgumentText(this AttributeData attribute, string name, out string argumentText)
        {
            if (attribute is null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }

            if (TryGetArgumentTextFromConstructor(attribute, name, out argumentText))
            {
                return true;
            }

            return TryGetArgumentTextFromSyntax(attribute, name, out argumentText);
        }

        private static bool TryGetArgumentTextFromConstructor(AttributeData attribute, string name, out string argumentText)
        {
            argumentText = string.Empty;

            if (!string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (attribute.ConstructorArguments.Length == 0)
            {
                return false;
            }

            TypedConstant argument = attribute.ConstructorArguments[0];

            if (argument.Value is null)
            {
                return false;
            }

            argumentText = argument.Value.ToString();

            return !string.IsNullOrWhiteSpace(argumentText);
        }

        private static bool TryGetArgumentTextFromSyntax(AttributeData attribute, string name, out string argumentText)
        {
            argumentText = string.Empty;

            if (attribute.ApplicationSyntaxReference is null)
            {
                return false;
            }

            if (attribute.ApplicationSyntaxReference.GetSyntax() is not AttributeSyntax syntax)
            {
                return false;
            }

            if (syntax.ArgumentList is null || syntax.ArgumentList.Arguments.Count == 0)
            {
                return false;
            }

            foreach (AttributeArgumentSyntax argument in syntax.ArgumentList.Arguments)
            {
                if (!IsMatch(argument, name))
                {
                    continue;
                }

                argumentText = argument.Expression is LiteralExpressionSyntax literal && literal.IsKind(SyntaxKind.NumericLiteralExpression)
                    ? literal.Token.ValueText
                    : argument.Expression.ToString();

                return !string.IsNullOrWhiteSpace(argumentText);
            }

            return false;
        }

        private static bool IsMatch(AttributeArgumentSyntax argument, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return argument.NameEquals is null && argument.NameColon is null;
            }

            if (argument.NameEquals is object)
            {
                return string.Equals(argument.NameEquals.Name.Identifier.ValueText, name, StringComparison.Ordinal);
            }

            if (argument.NameColon is object)
            {
                return string.Equals(argument.NameColon.Name.Identifier.ValueText, name, StringComparison.Ordinal);
            }

            return false;
        }
    }
}