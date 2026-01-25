namespace Graphify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Hint,nq}")]
public sealed record Generated(string Content, string Hint, Type? Generator = default)
{
    public void IsExpectedIn(SolutionState state)
    {
        Type generator = Generator ?? typeof(TypeGenerator);

        state.GeneratedSources.Add((sourceGeneratorType: generator, filename: Hint, content: Content));
    }
}