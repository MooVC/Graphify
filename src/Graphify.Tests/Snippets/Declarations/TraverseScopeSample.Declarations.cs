namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class TraverseScopeSample
{
    public static class Declarations
    {
        public static readonly Content Main = new(
            """
            namespace Graphify.Testing
            {
                public sealed class TraverseScopeChild
                {
                    public string Name { get; set; }
                }

                [Graphify]
                public sealed partial class TraverseScopeSample
                {
                    [Traverse(Scope = TraverseScope.None)]
                    public string Ignored { get; set; }

                    [Traverse(Scope = TraverseScope.Property)]
                    public string Title { get; set; }

                    [Traverse(Scope = TraverseScope.All)]
                    public string Description { get; set; }

                    [Traverse(Scope = TraverseScope.None)]
                    public TraverseScopeChild[] IgnoredChildren { get; set; }

                    [Traverse(Scope = TraverseScope.Property)]
                    public TraverseScopeChild[] ShallowChildren { get; set; }

                    [Traverse(Scope = TraverseScope.All)]
                    public TraverseScopeChild[] DeepChildren { get; set; }
                }
            }
            """,
            LanguageVersion.CSharp8);
    }
}