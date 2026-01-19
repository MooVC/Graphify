namespace Graphify.Snippets.Declarations;

public static class Boilerplate
{
    public static readonly Generated Base = new(
        NavigatorGenerator.Content,
        NavigatorGenerator.Name,
        typeof(NavigatorGenerator));

    public static readonly Generated Graphify = new(
        GraphifyAttributeGenerator.Content,
        $"{GraphifyAttributeGenerator.Name}Attribute",
        typeof(GraphifyAttributeGenerator));

    public static readonly Generated Ignore = new(
        IgnoreAttributeGenerator.Content,
        $"{IgnoreAttributeGenerator.Name}Attribute",
        typeof(IgnoreAttributeGenerator));

    public static readonly Generated Navigator = new(
        NavigatorContractGenerator.Content,
        NavigatorContractGenerator.Name,
        typeof(NavigatorContractGenerator));

    public static readonly Generated Visitor = new(
        VisitorContractGenerator.Content,
        VisitorContractGenerator.Name,
        typeof(VisitorContractGenerator));
}