namespace Graphify.Syntax
{
    using Graphify.Model;
    using static Graphify.Names;

    /// <summary>
    /// Provides extensions for rendering graph nodes.
    /// </summary>
    internal static partial class NodeExtensions
    {
        public static Source ToNavigatorSource(
            this Node node,
            Subject subject,
            string template,
            string propertyCall,
            string elementCall,
            string wrapper = null)
        {
            string graph = subject.GraphQualification;
            string navigator = GetNavigatorName(subject.Name);
            string hint = string.IsNullOrEmpty(node.ParentPath) ? node.Name : $"{node.ParentPath}.{node.Name}";
            string type = $"{graph}.{hint}";
            string arguments = string.Empty;
            string parameters = string.Empty;

            if (node.Ancestors.Length > 0)
            {
                string parameter = string.IsNullOrEmpty(subject.PropertyPrefix)
                    ? node.Ancestors[node.Ancestors.Length - 1].Name.ToCamelCase()
                    : CollisionSafeParentParameterName;
                arguments = $"{parameter}, ";
                parameters = $"{graph}.{node.ParentPath} {parameter}, ";
            }

            Element element = node.Element ?? node.Property.Element;
            string variable = string.IsNullOrEmpty(subject.PropertyPrefix) ? node.Name.ToCamelCase() : CollisionSafeNodeVariableName;
            string body = node.Tier < subject.Depth
                ? GetChildCalls(node, variable, propertyCall, elementCall)
                : string.Empty;
            string method = string.Format(
                template,
                subject.Type,
                parameters,
                node.Property.Type,
                type,
                arguments,
                body,
                node.Name,
                node.Method,
                element?.Type,
                variable,
                subject.Qualify($"{InterfaceNamePrefix}{subject.Name}{VisitorTypeSuffix}"));

            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string declaration = GenerationSyntax.Block(method, $"{accessibility} sealed partial class {navigator}");
            string code = wrapper is null ? declaration : string.Format(wrapper, declaration);

            return new Source(code, $"{navigator}.{hint}");
        }

        private static string GetChildCalls(Node node, string variable, string propertyCall, string elementCall)
        {
            string arguments = $"{variable}, ";

            if (node.Element is object)
            {
                return node.Element.Properties.ToNavigatorCalls(node.Method, arguments, propertyCall).Indent(skip: 0, times: 2, trim: false);
            }

            return node.Property.Properties.ToNavigatorCalls(node.Method, arguments, propertyCall, node.Property.Element, elementCall).Indent(skip: 0, trim: false);
        }
    }
}