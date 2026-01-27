namespace Graphify.Semantics
{
    using System;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="IPropertySymbol"/>.
    /// </summary>
    internal static partial class IPropertySymbolExtensions
    {
        private const string ScopePropertyName = "Scope";

        /// <summary>
        /// Determines the traversal scope for the <paramref name="property"/> based on the Traverse attribute.
        /// </summary>
        /// <param name="property">
        /// The property to be checked for the presence of the Traverse attribute.
        /// </param>
        /// <returns>
        /// The resolved traversal scope for the <paramref name="property"/>.
        /// </returns>
        public static TraverseScope GetTraverseScope(this IPropertySymbol property)
        {
            AttributeData attribute = property.GetAttribute(TraverseAttributeGenerator.Name);

            if (attribute is null)
            {
                return TraverseScope.All;
            }

            return attribute.TryGetArgumentText(ScopePropertyName, out string argumentText)
                ? ResolveScope(argumentText)
                : TraverseScope.All;
        }

        private static TraverseScope ResolveScope(string argumentText)
        {
            if (string.IsNullOrWhiteSpace(argumentText))
            {
                return TraverseScope.All;
            }

            if (int.TryParse(argumentText, out int value))
            {
                return ResolveScope(value);
            }

            string scopeName = NormalizeScopeName(argumentText);

            return Enum.TryParse(scopeName, ignoreCase: false, out TraverseScope scope)
                ? scope
                : TraverseScope.All;
        }

        private static TraverseScope ResolveScope(int value)
        {
            switch (value)
            {
                case 0:
                    return TraverseScope.None;

                case 1:
                    return TraverseScope.All;

                case 2:
                    return TraverseScope.Property;

                default:
                    return TraverseScope.All;
            }
        }

        private static string NormalizeScopeName(string argumentText)
        {
            string normalized = argumentText.Replace("global::", string.Empty);
            int delimiterIndex = normalized.LastIndexOf('.');

            return delimiterIndex >= 0
                ? normalized.Substring(delimiterIndex + 1)
                : normalized;
        }
    }
}