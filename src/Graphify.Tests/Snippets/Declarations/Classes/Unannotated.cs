namespace Graphify.Snippets.Declarations.Classes;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Declarations.Attributes.Annotations;

internal static class Unannotated
{
    public static readonly Snippets Declaration = new(
        [Generic, NonGeneric],
        new(
            """
            namespace Graphify.Testing.Classes
            {
                public sealed partial class Unannotated
                {
                }
            }
            """,
            LanguageVersion.CSharp2),
        [],
        [],
        nameof(Unannotated));
}