namespace Graphify.Console;

using System.Collections.Immutable;

[Graphify]
internal sealed partial class Complex
{
    public string Age { get; set; } = string.Empty;

    public ImmutableArray<Child> Children { get; set; } = ImmutableArray<Child>.Empty;

    public string Name { get; set; } = string.Empty;

    public sealed partial class Child
    {
        public int Age { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}