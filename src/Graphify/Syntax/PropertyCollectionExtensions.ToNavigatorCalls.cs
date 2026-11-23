namespace Graphify.Syntax
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using Graphify.Model;

    /// <summary>
    /// Provides extensions for rendering navigation calls for a collection of properties.
    /// </summary>
    internal static partial class PropertyCollectionExtensions
    {
        public static string ToNavigatorCalls(
            this ImmutableArray<Property> properties,
            string method,
            string arguments,
            string propertyCall,
            Element element = null,
            string elementCall = null)
        {
            if (properties.IsEmpty && element is null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            _ = builder.AppendLine();

            if (element is object)
            {
                _ = builder.AppendLine(string.Format(elementCall, $"{method}{element.Name}", arguments, element.Name));
            }

            IEnumerable<string> childCalls = properties.Select(property => string.Format(propertyCall, $"{method}{property.Name}", arguments, property.Name));

            foreach (string childCall in childCalls)
            {
                _ = builder.AppendLine(childCall);
            }

            return builder.ToString();
        }
    }
}