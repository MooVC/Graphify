namespace Graphify.NavigatorExtensionsGeneratorTests;

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
        var test = new GeneratorTest<NavigatorExtensionsGenerator>(
            assemblies,
            language,
            typeof(GraphifyAttributeGenerator),
            typeof(NavigatorExtensionsGenerator),
            typeof(GraphContractGenerator));

        Boilerplate.Embedded.IsExpectedIn(test.TestState);
        Boilerplate.Graphify.IsExpectedIn(test.TestState);
        Boilerplate.Extensions.IsExpectedIn(test.TestState);
        Boilerplate.Inspector.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks]
    public async Task GivenTheClassAlreadyExistsThenTheClassIsNotGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        const string Declaration = "namespace Graphify { public static class NavigatorExtensions { } }";

        var test = new GeneratorTest<NavigatorExtensionsGenerator>(assemblies, language);

        test.TestState.Sources.Add(Declaration);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}