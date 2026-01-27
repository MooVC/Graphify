namespace Graphify.TraverseAttributeAnalyzerTests;

using Graphify.Snippets;
using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using AnalyzerTest = Graphify.AnalyzerTest<Graphify.TraverseAttributeAnalyzer>;

public sealed class WhenExecuted
{
    [Theory]
    [Snippets(exclusions: [typeof(Unannotated), typeof(Unsupported)])]
    public async Task GivenAClassWhenCompliantThenNoDiagnosticsAreRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language, typeof(GraphifyAttributeGenerator), typeof(TraverseAttributeGenerator));

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
        var test = new AnalyzerTest(assembly, language, typeof(TraverseAttributeGenerator));

        expectations.IsDeclaredIn(test.TestState);

        test.ExpectedDiagnostics.Add(GetExpectedMissingGraphifyRule(new LinePosition(6, 5), nameof(Unannotated.Class.Name)));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    private static DiagnosticResult GetExpectedMissingGraphifyRule(LinePosition position, string name)
    {
        return new DiagnosticResult(TraverseAttributeAnalyzer.MissingGraphifyRule)
            .WithLocation(position)
            .WithArguments(name);
    }
}