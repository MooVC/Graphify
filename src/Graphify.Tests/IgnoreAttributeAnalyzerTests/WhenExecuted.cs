namespace Graphify.IgnoreAttributeAnalyzerTests;

using Graphify.Snippets;
using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using AnalyzerTest = Graphify.AnalyzerTest<Graphify.IgnoreAttributeAnalyzer>;

public sealed class WhenExecuted
{
    [Theory]
    [Snippets(exclusions: [typeof(Unannotated), typeof(Unsupported)])]
    public async Task GivenAClassWhenCompliantThenNoDiagnosticsAreRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language, typeof(GraphifyAttributeGenerator), typeof(IgnoreAttributeGenerator));

        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Snippets(inclusions: [typeof(Unannotated)])]
    public async Task GivenATypeWhenUnannotatedThenCompatibleTargetTypeRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language, typeof(IgnoreAttributeGenerator));

        expectations.IsDeclaredIn(test.TestState);

        test.ExpectedDiagnostics.Add(GetExpectedMissingGraphifyRule(new LinePosition(6, 5), nameof(Unannotated)));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    private static DiagnosticResult GetExpectedMissingGraphifyRule(LinePosition position, string name)
    {
        return new DiagnosticResult(IgnoreAttributeAnalyzer.MissingGraphifyRule)
            .WithLocation(position)
            .WithArguments(name);
    }
}