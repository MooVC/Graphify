namespace Graphify.Snippets;

using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

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

        SourceHashAlgorithm checksumAlgorithm = generator == typeof(TypeGenerator) ? SourceHashAlgorithm.Sha256 : SourceHashAlgorithm.Sha1;
        var source = SourceText.From(content, Encoding.UTF8, checksumAlgorithm);

        state.GeneratedSources.Add((sourceGeneratorType: generator, filename: Hint, content: source));
    }
}