namespace Graphify;

using Graphify.Model;

internal static class TestSubject
{
    public static Subject Create()
    {
        return new()
        {
            Encapsulated = [new Encapsulated { Type = "int" }],
            Declaration = "class",
            Name = "Sample",
            Namespace = string.Empty,
            Nesting = [],
            Qualification = "Sample",
        };
    }
}