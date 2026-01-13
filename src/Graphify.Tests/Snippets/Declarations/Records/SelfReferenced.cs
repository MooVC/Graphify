namespace Graphify.Snippets.Declarations.Records;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Declarations.Classes.SelfReferenced.Annotations;
using static Graphify.Snippets.Snippets;

internal static partial class SelfReferenced
{
    public static readonly Snippets Declaration = new(
        [Generic, NonGeneric],
        new(
            $$"""
            namespace Graphify.Testing.Records
            {
                [{{BodyTag}}]
                public sealed partial record SelfReferenced
                {
                }
            }
            """,
            LanguageVersion.CSharp9),
        [],
        [],
        nameof(SelfReferenced));
}