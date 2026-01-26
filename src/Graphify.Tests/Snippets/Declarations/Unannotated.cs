namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Unannotated
{
    public static readonly Snippets Class = new(
        [],
        new(
            """
            using Graphify;

            public sealed class Unannotated
            {
                public int Id { get; set; }

                [Ignore]
                public string Name { get; set; }
            }
            """,
            LanguageVersion.CSharp3),
        [],
        "Unannotated.g.cs");

    public static readonly Snippets Record = new(
        [],
        new(
            """
            using Graphify;

            public sealed record Unannotated
            {
                public int Id { get; set; }
            
                [Ignore]
                public string Name { get; set; }
            }
            """,
            LanguageVersion.CSharp9),
        [],
        "Unannotated.g.cs");

    public static readonly Snippets Struct = new(
        [],
        new(
            """
            using Graphify;

            public struct Unannotated
            {
                public int Id { get; set; }

                [Ignore]
                public string Name { get; set; }
            }
            """,
            LanguageVersion.CSharp3),
        [],
        "Unannotated.g.cs");
}