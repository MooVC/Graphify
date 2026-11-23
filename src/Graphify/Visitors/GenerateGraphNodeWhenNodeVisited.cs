namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;
    using Property = MooVC.Syntax.CSharp.Property;

    /// <summary>
    /// Generates the class that represents a property or sequence element in the graph.
    /// </summary>
    internal sealed class GenerateGraphNodeWhenNodeVisited
        : ISubjectVisitor<Subject.Graph.Nodes.Node, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Nodes.Node instance)
        {
            Node node = instance._Value;
            Subject subject = instance._Root;
            Class graphNode = DeclareNode(node, subject);

            for (int index = node.Ancestors.Length - 1; index >= 0; index--)
            {
                Predecessor predecessor = node.Ancestors[index];
                graphNode = Class.Undefined.Named(predecessor.Name)
                    .WithScope(GetScope(predecessor.Declaration))
                    .WithExtensibility(Modifiers.Implicit)
                    .Containing(graphNode);
            }

            Snippet code = Class.Undefined.Named(subject.GraphName)
                .WithScope(subject.Accessibility.ToScope())
                .WithExtensibility(Modifiers.Implicit)
                .Containing(graphNode)
                .ToSnippet(Configuration.Options)
                .Block(Configuration.Options, $"{subject.Declaration} {subject.Qualification}");

            string hint = node.Tier == 1
                ? $"{subject.Name}.{node.Name}"
                : $"{subject.Name}.{node.ParentPath}.{node.Name}";

            yield return new Source(code, hint);
        }

        private static Class DeclareNode(Node node, Subject subject)
        {
            Scopes scope = GetScope(node.Property.Declaration);
            var root = subject.Type.ToSymbol();
            var value = node.Type.ToSymbol();
            Symbol contract = root.ToGraph();
            string prefix = subject.PropertyPrefix;
            string rootProperty = prefix + RootPropertyName;
            string parentName = node.Ancestors.Length > 0 ? node.Ancestors[node.Ancestors.Length - 1].Name : string.Empty;
            int prefixLength = 0;

            while (rootProperty == node.Name || rootProperty == parentName)
            {
                prefixLength++;
                rootProperty = new string('_', prefixLength) + prefix + RootPropertyName;
            }

            var assignments = new List<string>();
            var parameters = new List<Parameter>();
            var properties = new List<Property>();

            if (node.Ancestors.Length > 0)
            {
                Predecessor parent = node.Ancestors[node.Ancestors.Length - 1];
                string name = parent.Name.ToCamelCase();
                string parameter = string.IsNullOrEmpty(prefix) && name != "root" ? name : CollisionSafeParentParameterName;
                var type = $"{subject.GraphQualification}.{node.ParentPath}".ToSymbol();

                assignments.Add($"{parent.Name} = {parameter};");
                parameters.Add(Parameter.Undefined.Named(parameter).OfType(type));
                properties.Add(CreateProperty(parent.Name, type, GetScope(parent.Declaration)));
            }

            if (node.Element is object)
            {
                assignments.Add($"{prefix}{IndexPropertyName} = index;");
                parameters.Add(Parameter.Undefined.Named("Index").OfType(typeof(int)));
                properties.Add(CreateProperty(prefix + IndexPropertyName, typeof(int), Scopes.Public));
            }

            assignments.Add($"{rootProperty} = root;");
            assignments.Add($"{prefix}{ValuePropertyName} = value;");
            parameters.Add(Parameter.Undefined.Named("Root").OfType(root));
            parameters.Add(Parameter.Undefined.Named("Value").OfType(value));
            properties.Add(CreateProperty(rootProperty, root, Scopes.Public));
            properties.Add(CreateProperty(prefix + ValuePropertyName, value, scope));

            if (rootProperty != RootPropertyName)
            {
                properties.Add(Property.Undefined
                    .Named(RootPropertyName)
                    .WithExplicitInterface(contract)
                    .OfType(root)
                    .WithBehaviours(accessors => accessors
                        .WithGet($"{rootProperty};")
                        .WithSet(setter => setter.WithMode(Property.Methods.Setter.Modes.ReadOnly))));
            }

            return Class.Undefined.Named(node.Name)
                .WithScope(scope)
                .WithExtensibility(Modifiers.Sealed)
                .Implements(contract)
                .WithConstructors(constructor => constructor
                    .WithScope(Scopes.Internal)
                    .WithParameters(parameters.ToArray())
                    .WithBody(Snippet.From(assignments.ToArray())))
                .WithProperties(properties.ToArray());
        }

        private static Property CreateProperty(string name, Symbol type, Scopes scope)
        {
            return Property.Undefined.Named(name)
                .OfType(type)
                .WithScope(scope)
                .WithBehaviours(accessors => accessors
                    .WithSet(setter => setter.WithMode(Property.Methods.Setter.Modes.Set).WithScope(Scopes.Private)));
        }

        private static Scopes GetScope(string declaration)
        {
            return declaration == "internal" ? Scopes.Internal : Scopes.Public;
        }
    }
}