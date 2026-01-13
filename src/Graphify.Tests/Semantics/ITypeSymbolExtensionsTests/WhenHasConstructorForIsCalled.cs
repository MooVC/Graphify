namespace Graphify.Semantics.ITypeSymbolExtensionsTests;

using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Graphify.Semantics;

public sealed class WhenHasConstructorForIsCalled
{
    [Fact]
    public void GivenMatchingConstructorThenTrueIsReturned()
    {
        // Arrange
        const string declarations = """
            namespace Sample;

            public sealed class Target
            {
                public Target(int value)
                {
                }
            }
            """;

        CSharpParseOptions options = new(LanguageVersion.CSharp11);
        SyntaxTree[] trees =
        [
            CSharpSyntaxTree.ParseText(declarations, options),
        ];

        MetadataReference[] references =
        [
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
        ];

        var compilation = CSharpCompilation.Create(
            "Sample",
            trees,
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        INamedTypeSymbol? subject = compilation.GetTypeByMetadataName("Sample.Target");
        _ = subject.ShouldNotBeNull();

        IMethodSymbol[] constructors = subject.InstanceConstructors.ToArray();
        ITypeSymbol value = compilation.GetSpecialType(SpecialType.System_Int32);

        // Act
        bool result = value.HasConstructorFor(constructors);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenNonMatchingConstructorThenFalseIsReturned()
    {
        // Arrange
        const string declarations = """
            namespace Sample;

            public sealed class Target
            {
                public Target(string value)
                {
                }
            }
            """;

        CSharpParseOptions options = new(LanguageVersion.CSharp11);
        SyntaxTree[] trees =
        [
            CSharpSyntaxTree.ParseText(declarations, options),
        ];

        MetadataReference[] references =
        [
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
        ];

        var compilation = CSharpCompilation.Create(
            "Sample",
            trees,
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        INamedTypeSymbol? subject = compilation.GetTypeByMetadataName("Sample.Target");
        _ = subject.ShouldNotBeNull();

        IMethodSymbol[] constructors = subject.InstanceConstructors.ToArray();
        ITypeSymbol value = compilation.GetSpecialType(SpecialType.System_Int32);

        // Act
        bool result = value.HasConstructorFor(constructors);

        // Assert
        result.ShouldBeFalse();
    }
}