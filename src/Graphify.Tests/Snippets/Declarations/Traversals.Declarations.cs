namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Traversals
{
    public static class Declarations
    {
        public static readonly Content Main = new(
            """
            namespace Graphify.Testing
            {
                public sealed class TraversalChild
                {
                    public string Name { get; set; }
                }

                [Graphify]
                public sealed partial class Traversals
                {
                    [Traverse(Scope = TraverseScope.None)]
                    public string Ignored { get; set; }

                    [Traverse(Scope = TraverseScope.Property)]
                    public string Title { get; set; }

                    [Traverse(Scope = TraverseScope.All)]
                    public string Description { get; set; }

                    [Traverse(Scope = TraverseScope.None)]
                    public TraversalChild[] IgnoredChildren { get; set; }

                    [Traverse(Scope = TraverseScope.Property)]
                    public TraversalChild[] ShallowChildren { get; set; }

                    [Traverse(Scope = TraverseScope.All)]
                    public TraversalChild[] DeepChildren { get; set; }
                }
            }
            """,
            LanguageVersion.CSharp8);
    }
}