namespace Graphify.Snippets.Declarations.Structs;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Snippets;

internal static partial class Simple
{
    public static class Declarations
    {
        public static readonly Content Main = new(
            $$"""
            namespace Graphify.Testing.Structs
            {
                [{{BodyTag}}]
                public partial struct Simple
                {
                }
            }
            """,
            LanguageVersion.CSharp2);
    }
}