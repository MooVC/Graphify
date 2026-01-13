namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

public static partial class Attributes
{
    public static class Annotations
    {
        public static readonly Content Generic = new("global::Graphify.GraphifyAttribute<int>", LanguageVersion.CSharp11);

        public static readonly Content NonGeneric = new("Graphify(Type = typeof(int))", LanguageVersion.CSharp2);
    }
}