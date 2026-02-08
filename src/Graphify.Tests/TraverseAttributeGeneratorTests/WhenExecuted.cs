namespace Graphify.TraverseAttributeGeneratorTests;

using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenExecuted
{
    [Theory]
    [Frameworks]
    public async Task GivenAnAssemblyThenTheAttributeIsGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<TraverseAttributeGenerator>(assemblies, language);

        Boilerplate.Traverse.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}