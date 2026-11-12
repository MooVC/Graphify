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
        GraphContractGenerator.Content,
        GraphContractGenerator.Hint,
        Generator: typeof(GraphContractGenerator));

    public static readonly Generated Traverse = new(
        TraverseAttributeGenerator.Content,
        $"{TraverseAttributeGenerator.Name}Attribute.g.cs",
        Generator: typeof(TraverseAttributeGenerator));
}