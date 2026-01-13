namespace Graphify.TypeGeneratorTests;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Graphify.Snippets;
using Graphify.Snippets.Declarations;

public sealed class WhenExecuted
{
    private static readonly Type[] _generators =
    [
        typeof(AttributeGenerator),
        typeof(HashCodeGenerator),
        typeof(SequenceEqualityComparerGenerator),
        typeof(TypeGenerator),
    ];

    [Theory]
    [Snippets(exclusions: [typeof(Attributes)])]
    public async Task GivenATypeTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<TypeGenerator>(assembly, language, _generators);

        Attributes.IsExpectedIn(test.TestState, language);
        Internal.HashCode.IsExpectedIn(test.TestState);
        Internal.SequenceEqualityComparer.IsExpectedIn(test.TestState);
        expectations.IsDeclaredIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }
}