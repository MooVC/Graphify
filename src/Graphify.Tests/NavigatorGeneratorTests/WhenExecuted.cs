namespace Graphify.NavigatorExtensionsGeneratorTests;

using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenExecuted
{
    [Test]
    [MethodDataSource(typeof(Frameworks), nameof(Frameworks.DefaultCases))]
    public async Task GivenAnAssemblyThenTheClassIsGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<NavigatorExtensionsGenerator>(assemblies, language);

        Boilerplate.Extensions.IsExpectedIn(test.TestState);

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

    [Test]
    public async Task GivenAnInternalClassInAReferencedAssemblyThenTheClassIsGenerated()
    {
        // Arrange
        const string Declaration = "namespace Graphify { internal static class NavigatorExtensions { } }";
        const string Dependency = "Dependency";
        var test = new GeneratorTest<NavigatorExtensionsGenerator>(ReferenceAssemblies.Net.Net100, LanguageVersion.CSharp14);

        test.TestState.AdditionalProjects[Dependency].Sources.Add(Declaration);
        test.TestState.AdditionalProjectReferences.Add(Dependency);
        Boilerplate.Extensions.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}