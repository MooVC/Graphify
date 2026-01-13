namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using static Graphify.Snippets.Declarations.Attributes.Declarations;

public static partial class Attributes
{
    public static readonly Snippets Graphify = new(
        [new(Generic.Content, LanguageVersion.CSharp11), new(NonGeneric.Content, LanguageVersion.CSharp2)],
        new Content(Snippets.BodyTag, LanguageVersion.CSharp1),
        [Generic, NonGeneric],
        [],
        nameof(Graphify));

    public static void IsExpectedIn(this SolutionState state, LanguageVersion language)
    {
        if (language >= LanguageVersion.CSharp11)
        {
            Generic.IsExpectedIn(state);
        }

        NonGeneric.IsExpectedIn(state);
    }
}