namespace Graphify.Console;

using System.Collections.Immutable;

[Graphify]
internal sealed partial class Complex
{
    public int Age { get; set; }

    public Child[] Children { get; set; } = Array.Empty<Child>();

    public string Name { get; set; } = string.Empty;
}