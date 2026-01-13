namespace Graphify.Snippets.Declarations.Records;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Snippets;

internal static partial class Simple
{
    public static class Declarations
    {
        public static readonly Content Main = new(
            $$"""
            namespace Graphify.Testing.Records
            {
                [{{BodyTag}}]
                public partial record Simple;
            }
            """,
            LanguageVersion.CSharp9);
    }
}