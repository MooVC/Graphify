namespace Graphify.Snippets;

using System.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

[DebuggerDisplay("{Hint,nq}")]
public sealed record Generated(string Content, string Hint, string? EndOfLine = default, Type? Generator = default)
{
    public void IsExpectedIn(SolutionState state)
    {
        Type generator = Generator ?? typeof(TypeGenerator);
        string content = Content;

        if (EndOfLine is not null && !EndOfLine.Equals(Environment.NewLine, StringComparison.Ordinal))
        {
            content = Content.Replace("\n", EndOfLine);
        }

        state.GeneratedSources.Add((sourceGeneratorType: generator, filename: Hint, content));
    }
}