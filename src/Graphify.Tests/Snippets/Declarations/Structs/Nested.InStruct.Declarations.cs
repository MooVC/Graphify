namespace Graphify.Snippets.Declarations.Structs;

using Microsoft.CodeAnalysis.CSharp;
using static Graphify.Snippets.Snippets;

internal static partial class Nested
{
    public static partial class InStruct
    {
        public static class Declarations
        {
            public static readonly Content Main = new(
                $$"""
                namespace Graphify.Testing.Structs
                {
                    public readonly ref partial struct Outter<T>
                        where T : struct
                    {
                        [{{BodyTag}}]
                        public readonly partial struct Inner
                        {
                        }
                    }
                }
                """,
                LanguageVersion.CSharp7_2);
        }
    }
}