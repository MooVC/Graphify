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
        typeof(NavigatorContractGenerator),
        typeof(NavigatorGenerator),
        typeof(TraverseAttributeGenerator),
        typeof(TypeGenerator),
        typeof(VisitorContractGenerator),
    ];

    [Theory]
    [Snippets(exclusions: [typeof(Unannotated)], inclusions: [typeof(DepthLimited)])]
    public async Task GivenAClassTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<TypeGenerator>(assembly, language, _generators);

        Boilerplate.Graphify.IsExpectedIn(test.TestState);
        Boilerplate.Navigator.IsExpectedIn(test.TestState);
        Boilerplate.Base.IsExpectedIn(test.TestState);
        Boilerplate.Traverse.IsExpectedIn(test.TestState);
        expectations.IsDeclaredIn(test.TestState);
        Boilerplate.Visitor.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}