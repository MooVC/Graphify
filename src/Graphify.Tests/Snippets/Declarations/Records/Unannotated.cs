namespace Graphify.Snippets.Declarations.Records;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Declarations.Attributes.Annotations;

internal static class Unannotated
{
    public static readonly Snippets Declaration = new(
        [Generic, NonGeneric],
        new(
            """
            namespace Graphify.Testing.Records
            {
                public sealed partial record Unannotated
                {
                }
            }
            """,
            LanguageVersion.CSharp9),
        [],
        [],
        nameof(Unannotated));
}