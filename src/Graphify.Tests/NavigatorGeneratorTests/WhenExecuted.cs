namespace Graphify.NavigatorExtensionsGeneratorTests;

using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenExecuted
{
    [Test]
    [MethodDataSource(typeof(Frameworks), nameof(Frameworks.DefaultCases))]
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

    [Test]
    [MethodDataSource(typeof(Frameworks), nameof(Frameworks.DefaultCases))]
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