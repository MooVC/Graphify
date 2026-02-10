namespace Graphify.NavigatorContractGeneratorTests;

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
        var test = new GeneratorTest<NavigatorContractGenerator>(assemblies, language);

        Boilerplate.Navigator.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks]
    public async Task GivenTheContractAlreadyExistsThenTheAttributeIsNotGenerated(ReferenceAssemblies assemblies, LanguageVersion language)
    {
        // Arrange
        const string Declaration = """
namespace Graphify
{
    public interface INavigator<in T>
        where T : class
    {
    }
}
""";

        var test = new GeneratorTest<NavigatorContractGenerator>(assemblies, language);

        test.TestState.Sources.Add(Declaration);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}