namespace Graphify.Snippets.Declarations;

public static class Boilerplate
{
    public static readonly Generated Base = new(
        NavigatorGenerator.Content,
        NavigatorGenerator.Hint,
        typeof(NavigatorGenerator));

    public static readonly Generated Graphify = new(
        GraphifyAttributeGenerator.Content,
        $"{GraphifyAttributeGenerator.Name}Attribute.g.cs",
        typeof(GraphifyAttributeGenerator));

    public static readonly Generated Ignore = new(
        IgnoreAttributeGenerator.Content,
        $"{IgnoreAttributeGenerator.Name}Attribute.g.cs",
        typeof(IgnoreAttributeGenerator));

    public static readonly Generated Navigator = new(
        NavigatorContractGenerator.Content,
        NavigatorContractGenerator.Hint,
        typeof(NavigatorContractGenerator));

    public static readonly Generated Visitor = new(
        VisitorContractGenerator.Content,
        $"{VisitorContractGenerator.Name}.g.cs",
        typeof(VisitorContractGenerator));
}