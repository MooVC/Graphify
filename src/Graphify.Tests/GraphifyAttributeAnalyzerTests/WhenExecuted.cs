namespace Graphify.GraphifyAttributeAnalyzerTests;

using Graphify;
using Graphify.Snippets;
using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using AnalyzerTest = Graphify.AnalyzerTest<Graphify.GraphifyAttributeAnalyzer>;

public sealed class WhenExecuted
{
    [Theory]
    [Snippets(inclusions: [typeof(Unsupported)])]
    public async Task GivenATypeWhenNotPartialThenPartialTypeRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.ExpectedDiagnostics.Add(GetExpectedPartialTypeRule(new LinePosition(2, 1), nameof(Unsupported)));
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    private static DiagnosticResult GetExpectedPartialTypeRule(LinePosition position, string name)
    {
        return new DiagnosticResult(GraphifyAttributeAnalyzer.PartialTypeRule)
            .WithLocation(position)
            .WithArguments(name);
    }
}