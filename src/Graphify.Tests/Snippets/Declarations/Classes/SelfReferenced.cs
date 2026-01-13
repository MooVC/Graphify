namespace Graphify.Snippets.Declarations.Classes;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Declarations.Classes.SelfReferenced.Annotations;
using static Graphify.Snippets.Snippets;

internal static partial class SelfReferenced
{
    public static readonly Snippets Declaration = new(
        [Generic, NonGeneric],
        new(
            $$"""
            namespace Graphify.Testing.Classes
            {
                [{{BodyTag}}]
                public sealed partial class SelfReferenced
                {
                }
            }
            """,
            LanguageVersion.CSharp2),
        [],
        [],
        nameof(SelfReferenced));
}