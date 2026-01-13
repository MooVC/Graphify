namespace Graphify.Snippets.Declarations.Classes;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Snippets;

internal static partial class Simple
{
    public static class Declarations
    {
        public static readonly Content Main = new(
            $$"""
            namespace Graphify.Testing.Classes
            {
                [{{BodyTag}}]
                public partial class Simple
                {
                }
            }
            """,
            LanguageVersion.CSharp2);
    }
}