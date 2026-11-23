namespace Graphify.Snippets.Declarations;

public static class Boilerplate
{
    public static readonly Generated Extensions = new(
        NavigatorExtensionsGenerator.Content,
        NavigatorExtensionsGenerator.Hint,
        Generator: typeof(NavigatorExtensionsGenerator));

    public static readonly Generated Graphify = new(
        GraphifyAttributeGenerator.Content,
        $"{GraphifyAttributeGenerator.Name}Attribute.g.cs",
        Generator: typeof(GraphifyAttributeGenerator));

    public static readonly Generated Inspector = new(
        """
        namespace Graphify
        {
            public interface IGraph<out T>

                where T : class
            {
                T Root { get; }
            }
        }
        """,
        GraphContractGenerator.Hint,
        Generator: typeof(GraphContractGenerator));

    public static readonly Generated Traverse = new(
        TraverseAttributeGenerator.Content,
        $"{TraverseAttributeGenerator.Name}Attribute.g.cs",
        Generator: typeof(TraverseAttributeGenerator));

    public static Generated Root(string name, string @namespace)
    {
        return new(
            $$"""
                namespace {{@namespace}}
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class {{name}}
                    {
                        public sealed partial class Graph
                            : global::Graphify.IGraph<global::{{@namespace}}.{{name}}>
                        {
                            private readonly global::{{@namespace}}.{{name}} _root;

                            internal Graph(global::{{@namespace}}.{{name}} root)
                            {
                                _root = root;
                            }

                            global::{{@namespace}}.{{name}} global::Graphify.IGraph<global::{{@namespace}}.{{name}}>.Root => _root;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            $"{@namespace}.{name}.Graph.g.cs");
    }
}