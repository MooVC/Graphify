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
    public static IEnumerable<TestDataRow<(ReferenceAssemblies Assembly, Expectations Expectations, LanguageVersion Language)>> GenericTypeCases()
    {
        return SnippetCases.Create(inclusions: [typeof(Generic)]);
    }

    public static IEnumerable<TestDataRow<(ReferenceAssemblies Assembly, Expectations Expectations, LanguageVersion Language)>> InaccessibleTypeCases()
    {
        return SnippetCases.Create(inclusions: [typeof(Inaccessible)]);
    }

    public static IEnumerable<TestDataRow<(ReferenceAssemblies Assembly, Expectations Expectations, LanguageVersion Language)>> NonPartialTypeCases()
    {
        return SnippetCases.Create(inclusions: [typeof(Unsupported)]);
    }

    [Test]
    [MethodDataSource(nameof(GenericTypeCases))]
    public async Task GivenATypeWhenGenericThenGenericTypeRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.ExpectedDiagnostics.Add(GetExpectedGenericTypeRule(new LinePosition(2, 1), nameof(Generic)));
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Test]
    [MethodDataSource(nameof(NonPartialTypeCases))]
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

    [Test]
    [MethodDataSource(nameof(InaccessibleTypeCases))]
    public async Task GivenATypeWhenAccessibilityIsNotSupportedThenTypeAccessibilityRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.ExpectedDiagnostics.Add(GetExpectedTypeAccessibilityRule(new LinePosition(4, 5), nameof(Inaccessible)));
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

    private static DiagnosticResult GetExpectedGenericTypeRule(LinePosition position, string name)
    {
        return new DiagnosticResult(GraphifyAttributeAnalyzer.GenericTypeRule)
            .WithLocation(position)
            .WithArguments(name);
    }

    private static DiagnosticResult GetExpectedTypeAccessibilityRule(LinePosition position, string name)
    {
        return new DiagnosticResult(GraphifyAttributeAnalyzer.TypeAccessibilityRule)
            .WithLocation(position)
            .WithArguments(name);
    }
}