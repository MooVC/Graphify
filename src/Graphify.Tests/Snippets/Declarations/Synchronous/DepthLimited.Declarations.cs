namespace Graphify.Snippets.Declarations.Synchronous;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class DepthLimited
{
    public static class Declarations
    {
        public static readonly Content Main = new(
            """
            namespace Graphify.Testing.Synchronous
            {
                public sealed class DepthChild
                {
                    public string Name { get; set; }
                }

                [Graphify(Depth = 1, Mode = Graphify.Modes.Synchronous)]
                public sealed partial class DepthLimited
                {
                    public DepthChild Child { get; set; }
                }
            }
            """,
            LanguageVersion.CSharp8);
    }
}