namespace Graphify.Snippets.Declarations;

public static class Boilerplate
{
    public static readonly Generated Base = new(
        NavigatorExtensionsGenerator.Content,
        NavigatorExtensionsGenerator.Hint,
        typeof(NavigatorExtensionsGenerator));

    public static readonly Generated Graphify = new(
        GraphifyAttributeGenerator.Content,
        $"{GraphifyAttributeGenerator.Name}Attribute.g.cs",
        typeof(GraphifyAttributeGenerator));

    public static readonly Generated Inspector = new(
        InspectorContractGenerator.Content,
        $"{InspectorContractGenerator.Name}.g.cs",
        typeof(InspectorContractGenerator));

    public static readonly Generated Traverse = new(
        TraverseAttributeGenerator.Content,
        $"{TraverseAttributeGenerator.Name}Attribute.g.cs",
        typeof(TraverseAttributeGenerator));

    public static readonly Generated Visitor = new(
        VisitorContractGenerator.Content,
        $"{VisitorContractGenerator.Name}.g.cs",
        typeof(VisitorContractGenerator));
}
