namespace Graphify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;

[DebuggerDisplay("{Name,nq}")]
public sealed record Snippets(Content[] Body, Content Declaration, Generated[] Expected, string Name)
{
    public const string BodyTag = "__BODY__";

    public IEnumerable<Expectations> Render()
    {
        IEnumerable<Content> declarations = Compose();

        foreach (Expectations expectation in Expect(declarations))
        {
            yield return expectation;
        }
    }

    private IEnumerable<Content> Compose()
    {
        if (Body.Length == 0)
        {
            yield return Declaration;
        }
        else
        {
            foreach (Content body in Body)
            {
                string declaration = Declaration.Body.Replace(BodyTag, body.Body);
                LanguageVersion minimum = Highest(body.Minimum, Declaration.Minimum);

                yield return new(declaration, minimum);
            }
        }
    }

    private IEnumerable<Expectations> Expect(IEnumerable<Content> declarations)
    {
        foreach (Content declaration in declarations)
        {
            yield return new Expectations(declaration.Body, Expected, declaration.Minimum);
        }
    }

    private static LanguageVersion Highest(LanguageVersion first, LanguageVersion second)
    {
        return first > second
            ? first
            : second;
    }
}