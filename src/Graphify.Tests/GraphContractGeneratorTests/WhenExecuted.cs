namespace Graphify.GraphContractGeneratorTests;

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
        var test = new GeneratorTest<GraphContractGenerator>(assemblies, language);

        Boilerplate.Inspector.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks]
    public async Task GivenTheContractAlreadyExistsThenTheContractIsNotGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        const string Declaration = "namespace Graphify { public interface IGraph<out T> where T : class { T Root { get; } } }";

        var test = new GeneratorTest<GraphContractGenerator>(assemblies, language);

        test.TestState.Sources.Add(Declaration);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}