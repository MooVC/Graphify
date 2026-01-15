namespace Graphify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Minimum,nq}")]
public sealed record Expectations(string Declaration, Generated[] Generated, LanguageVersion Minimum)
{
    public void IsDeclaredIn(SolutionState state)
    {
        state.Sources.Add(Declaration);

        foreach (Generated generated in Generated)
        {
            generated.IsExpectedIn(state);
        }
    }
}