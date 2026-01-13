namespace Graphify.Snippets.Declarations.Records;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Snippets;

internal static partial class Nested
{
    public static partial class InRecord
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                $$"""
                namespace Graphify.Testing.Records
                {
                    public sealed partial record Outter<T>
                        where T : struct
                    {
                        [{{BodyTag}}]
                        public sealed partial record Inner
                        {
                        }
                    }
                }
                """,
                LanguageVersion.CSharp9);
        }
    }
}