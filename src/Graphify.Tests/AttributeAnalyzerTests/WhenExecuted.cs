namespace Graphify.AttributeAnalyzerTests;

using System.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using Graphify;
using Graphify.Snippets;
using Graphify.Snippets.Declarations;
using AnalyzerTest = Graphify.AnalyzerTest<Graphify.AttributeAnalyzer>;
using SelfReferencedClass = Graphify.Snippets.Declarations.Classes.SelfReferenced;
using SelfReferencedRecord = Graphify.Snippets.Declarations.Records.SelfReferenced;
using SelfReferencedStruct = Graphify.Snippets.Declarations.Structs.SelfReferenced;
using UnannotatedClass = Graphify.Snippets.Declarations.Classes.Unannotated;
using UnannotatedRecord = Graphify.Snippets.Declarations.Records.Unannotated;
using UnannotatedStruct = Graphify.Snippets.Declarations.Structs.Unannotated;
using UnsupportedClass = Graphify.Snippets.Declarations.Classes.Unsupported;
using UnsupportedRecord = Graphify.Snippets.Declarations.Records.Unsupported;
using UnsupportedStruct = Graphify.Snippets.Declarations.Structs.Unsupported;

public sealed class WhenExecuted
{
    [Theory]
    [Snippets(
        exclusions:
        [
            typeof(Attributes),
            typeof(SelfReferencedClass),
            typeof(SelfReferencedRecord),
            typeof(SelfReferencedStruct),
            typeof(UnannotatedClass),
            typeof(UnsupportedClass),
            typeof(UnannotatedRecord),
            typeof(UnsupportedRecord),
            typeof(UnannotatedStruct),
            typeof(UnsupportedStruct),
        ],
        extensions: Extensions.None)]
    public async Task GivenATypeWhenCompliantThenNoDiagnosticsAreRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Snippets(exclusions: [typeof(Attributes)], inclusions: [typeof(UnsupportedClass), typeof(UnsupportedRecord), typeof(UnsupportedStruct)])]
    public async Task GivenATypeWhenNotPartialThenPartialTypeRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.ExpectedDiagnostics.Add(GetExpectedPartialTypeRule(new LinePosition(2, 5), UnsupportedStruct.Declaration.Name));
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Snippets(exclusions: [typeof(Attributes)], inclusions: [typeof(SelfReferencedClass), typeof(SelfReferencedRecord), typeof(SelfReferencedStruct)])]
    public async Task GivenATypeWhenSelfReferencedThenSelfReferencingRuleIsRaised(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.ExpectedDiagnostics.Add(GetExpectedSelfReferenceRule(new LinePosition(2, 5), SelfReferencedClass.Declaration.Name));
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks(Language = LanguageVersion.CSharp11)]
    public async Task GivenAClassWhenNoStateExistsThenCapturesStateRuleIsNotRaised(ReferenceAssemblies assembly, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.TestState.Sources.Add(
            SourceText.From(
                """
                namespace Graphify.Tests;

                [Graphify<string>]
                public partial class Inner
                {
                }
                """,
                Encoding.UTF8));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks(Language = LanguageVersion.CSharp11)]
    public async Task GivenAPositionalRecordWhenOnlyImplicitStateExistsThenCapturesStateRuleIsRaised(ReferenceAssemblies assembly, LanguageVersion language)
    {
        // Arrange
        var test = new AnalyzerTest(assembly, language);

        test.TestState.Sources.Add(
            SourceText.From(
                """
                namespace Graphify.Tests;

                [Graphify<int>]
                public partial record Age(int Amount);
                """,
                Encoding.UTF8));

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        _ = await act.ShouldThrowAsync<InvalidOperationException>();
    }

    private static DiagnosticResult GetExpectedPartialTypeRule(LinePosition position, string @class)
    {
        return new DiagnosticResult(AttributeAnalyzer.PartialTypeRule)
            .WithLocation(position)
            .WithArguments(@class);
    }

    private static DiagnosticResult GetExpectedSelfReferenceRule(LinePosition position, string @class)
    {
        return new DiagnosticResult(AttributeAnalyzer.SelfReferenceRule)
            .WithLocation(position)
            .WithArguments(@class);
    }
}