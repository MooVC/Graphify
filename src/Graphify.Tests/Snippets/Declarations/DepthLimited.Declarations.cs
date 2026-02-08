namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class DepthLimited
{
    public static class Declarations
    {
        public static readonly Content Main = new(
            """
            namespace Graphify.Testing
            {
                public sealed class DepthChild
                {
                    public string Name { get; set; }
                }

                [Graphify(Depth = 1)]
                public sealed partial class DepthLimited
                {
                    public DepthChild Child { get; set; }
                }
            }
            """,
            LanguageVersion.CSharp8);
    }
}