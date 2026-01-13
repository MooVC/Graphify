namespace Graphify.Snippets.Declarations;

public static class Internal
{
    public static readonly Generated HashCode = new(
        HashCodeGenerator.Content,
        Extensions.None,
        "Graphify.Internal.HashCode",
        Generator: typeof(HashCodeGenerator));

    public static readonly Generated SequenceEqualityComparer = new(
        SequenceEqualityComparerGenerator.Content,
        Extensions.None,
        "Graphify.Internal.SequenceEqualityComparer",
        Generator: typeof(SequenceEqualityComparerGenerator));
}