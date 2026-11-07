namespace Graphify.TypeGeneratorTests;

using Graphify.Snippets;
using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenExecuted
{
    private static readonly Type[] _generators =
    [
        typeof(GraphifyAttributeGenerator),
        typeof(GraphContractGenerator),
        typeof(NavigatorExtensionsGenerator),
        typeof(TraverseAttributeGenerator),
        typeof(TypeGenerator),
    ];

    public static IEnumerable<TestDataRow<(ReferenceAssemblies Assembly, Expectations Expectations, LanguageVersion Language)>> TypeGenerationCases()
    {
        return SnippetCases.Create(exclusions: [typeof(Unannotated)]);
    }

    [Test]
    [MethodDataSource(nameof(TypeGenerationCases))]
    public async Task GivenAClassTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<TypeGenerator>(assembly, language, _generators);

        Boilerplate.Embedded.IsExpectedIn(test.TestState);
        Boilerplate.Graphify.IsExpectedIn(test.TestState);
        Boilerplate.Inspector.IsExpectedIn(test.TestState);
        Boilerplate.Extensions.IsExpectedIn(test.TestState);
        Boilerplate.Traverse.IsExpectedIn(test.TestState);
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}