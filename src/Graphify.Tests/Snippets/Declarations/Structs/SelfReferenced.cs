namespace Graphify.Snippets.Declarations.Structs;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Declarations.Classes.SelfReferenced.Annotations;
using static Graphify.Snippets.Snippets;

internal static partial class SelfReferenced
{
    public static readonly Snippets Declaration = new(
        [Generic, NonGeneric],
        new(
            $$"""
            namespace Graphify.Testing.Structs
            {
                [{{BodyTag}}]
                public partial struct SelfReferenced
                {
                }
            }
            """,
            LanguageVersion.CSharp2),
        [],
        [],
        nameof(SelfReferenced));
}