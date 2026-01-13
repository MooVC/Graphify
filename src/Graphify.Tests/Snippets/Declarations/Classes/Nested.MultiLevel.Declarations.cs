namespace Graphify.Snippets.Declarations.Classes;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Snippets;

internal static partial class Nested
{
    public static partial class MultiLevel
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                $$"""
                namespace Graphify.Testing.Classes
                {
                    public partial class Snippet
                    {
                        public partial class BlockOptions
                        {
                            [{{BodyTag}}]
                            public sealed partial class InlineStyle
                            {
                            }
                        }
                    }
                }
                """,
                LanguageVersion.CSharp2);
        }
    }
}