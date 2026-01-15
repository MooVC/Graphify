namespace Graphify.Testing;

[Graphify]
public sealed partial class Simple
{
    public static string Species { get; } = "Human";

    public int Age { get; }

    public bool IsAdult => Age >= 18;

    public string Name { get; } = string.Empty;
}