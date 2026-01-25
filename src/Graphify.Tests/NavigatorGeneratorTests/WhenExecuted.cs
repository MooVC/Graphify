namespace Graphify.NavigatorGeneratorTests;

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
        var test = new GeneratorTest<NavigatorGenerator>(
            assemblies,
            language,
            typeof(NavigatorGenerator),
            typeof(NavigatorContractGenerator),
            typeof(VisitorContractGenerator));

        Boilerplate.Navigator.IsExpectedIn(test.TestState);
        Boilerplate.Base.IsExpectedIn(test.TestState);
        Boilerplate.Visitor.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}