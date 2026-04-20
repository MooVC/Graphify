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
        typeof(InspectorContractGenerator),
        typeof(NavigatorExtensionsGenerator),
        typeof(TraverseAttributeGenerator),
        typeof(TypeGenerator),
        typeof(VisitorContractGenerator),
    ];

    [Theory]
    [Snippets(exclusions: [typeof(Unannotated)])]
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
        Boilerplate.Visitor.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}