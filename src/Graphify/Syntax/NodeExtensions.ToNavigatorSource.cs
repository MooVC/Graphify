namespace Graphify.Syntax
{
    using Graphify.Model;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
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
            bool asynchronous)
        {
            string graph = subject.GraphQualification;
            string hint = string.IsNullOrEmpty(node.ParentPath) ? node.Name : $"{node.ParentPath}.{node.Name}";
            string type = $"{graph}.{hint}";
            string arguments = string.Empty;
            var root = subject.Type.ToSymbol();

            Method method = $"Navigate{node.Method}".ToNavigationMethod(asynchronous)
                .WithScope(Scopes.Private);

            if (node.Ancestors.Length > 0)
            {
                string parameter = string.IsNullOrEmpty(subject.PropertyPrefix)
                    ? node.Ancestors[node.Ancestors.Length - 1].Name.ToCamelCase()
                    : CollisionSafeParentParameterName;

                arguments = $"{parameter}, ";
                var parent = $"{graph}.{node.ParentPath}".ToSymbol();
                method = method.Accepts(argument => argument.Named(parameter).OfType(parent));
            }

            method = method.Accepts(parameter => parameter.Named("Root").OfType(root))
                .Accepts(parameter => parameter.Named("Value").OfType(node.Property.Type.ToSymbol()));

            if (asynchronous)
            {
                method = method.Accepts(NavigatorDeclarations.Cancellation);
            }

            Element element = node.Element ?? node.Property.Element;
            string variable = string.IsNullOrEmpty(subject.PropertyPrefix) ? node.Name.ToCamelCase() : CollisionSafeNodeVariableName;

            string calls = node.Tier < subject.Depth
                ? GetChildCalls(node, variable, propertyCall, elementCall)
                : string.Empty;

            var body = Snippet.From(Configuration.Options, string.Format(
                template,
                type,
                arguments,
                calls,
                element?.Type,
                variable,
                subject.Qualify($"{InterfaceNamePrefix}{subject.Name}{VisitorTypeSuffix}")));

            var code = subject.ToNavigatorClass()
                .WithMethods(method.WithBody(body))
                .ToSnippet(Configuration.Options);

            return new Source(
                asynchronous ? code.GuardAsync() : code,
                $"{GetNavigatorName(subject.Name)}.{hint}");
        }

        private static string GetChildCalls(Node node, string variable, string propertyCall, string elementCall)
        {
            string arguments = $"{variable}, ";

            if (node.Element is object)
            {
                return node.Element.Properties.ToNavigatorCalls(node.Method, arguments, propertyCall).Indent(skip: 0, trim: false);
            }

            return node.Property.Properties.ToNavigatorCalls(node.Method, arguments, propertyCall, node.Property.Element, elementCall);
        }
    }
}