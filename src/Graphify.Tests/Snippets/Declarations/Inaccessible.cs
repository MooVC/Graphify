namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static class Inaccessible
{
    public static readonly Snippets Declaration = new(
        [],
        new(
            """
            using Graphify;

            public sealed partial class Container
            {
                [Graphify]
                private sealed partial class Inaccessible
                {
                    public int Value { get; set; }
                }
            }
            """,
            LanguageVersion.CSharp8),
        [],
        "Inaccessible.g.cs");
}