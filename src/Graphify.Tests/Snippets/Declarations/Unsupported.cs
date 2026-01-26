namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Unsupported
{
    public static readonly Snippets Class = new(
        [],
        new(
            """
            using Graphify;

            [Graphify]
            public sealed class Unsupported
            {
                public int Id { get; set; }

                public string Name { get; set; }
            }
            """,
            LanguageVersion.CSharp8),
        [],
        "Unsupported.g.cs");

    public static readonly Snippets Record = new(
        [],
        new(
            """
            using Graphify;

            [Graphify]
            public sealed record Unsupported(int Id, string Name);
            """,
            LanguageVersion.CSharp9),
        [],
        "Unsupported.g.cs");

    public static readonly Snippets Struct = new(
        [],
        new(
            """
            using Graphify;

            [Graphify]
            public struct Unsupported
            {
                public int Id { get; set; }
            
                public string Name { get; set; }
            }
            """,
            LanguageVersion.CSharp8),
        [],
        "Unsupported.g.cs");
}