namespace Graphify.Semantics.INamedTypeSymbolExtensionsTests;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Graphify.Semantics;

public sealed class WhenToSubjectIsCalled
{
    [Fact]
    public void GivenSubjectEncapsulatingMonifiedTypeThenConversionsAreIncluded()
    {
        // Arrange
        const string attribute = """
            namespace Graphify
            {
                using System;

                [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
                internal sealed class GraphifyAttribute<T> : Attribute
                {
                }
            }
            """;

        const string declarations = """
            using Graphify;

            namespace Sample;

            [Graphify<Inner>]
            public sealed partial class Outer
            {
            }

            [Graphify<string>]
            public sealed partial class Inner
            {
            }
            """;

        CSharpParseOptions options = new(LanguageVersion.CSharp11);
        SyntaxTree[] trees =
        [
            CSharpSyntaxTree.ParseText(attribute, options),
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

        SemanticModel model = compilation.GetSemanticModel(trees[1]);
        INamedTypeSymbol? outer = compilation.GetTypeByMetadataName("Sample.Outer");

        _ = outer.ShouldNotBeNull();
        outer.HasGraphify(model, out ITypeSymbol value).ShouldBeTrue();

        // Act
        var subject = outer.ToSubject(compilation, [], value);

        // Assert
        _ = subject.ShouldNotBeNull();
        subject!.Encapsulated.Length.ShouldBe(2);
        subject.Encapsulated[0].Type.ShouldBe("global::Sample.Inner");
        subject.Encapsulated[0].HasConversionFrom.ShouldBeFalse();
        subject.Encapsulated[0].HasConversionTo.ShouldBeFalse();
        subject.Encapsulated[0].HasEqualityOperator.ShouldBeFalse();
        subject.Encapsulated[0].HasInequalityOperator.ShouldBeFalse();
        subject.Encapsulated[1].Type.ShouldBe("string");
        subject.Encapsulated[1].HasConversionFrom.ShouldBeFalse();
        subject.Encapsulated[1].HasConversionTo.ShouldBeFalse();
        subject.Encapsulated[1].HasEqualityOperator.ShouldBeFalse();
        subject.Encapsulated[1].HasInequalityOperator.ShouldBeFalse();
    }

    [Fact]
    public void GivenCircularEncapsulationThenConversionDetectionIsTerminated()
    {
        // Arrange
        const string attribute = """
            namespace Graphify
            {
                using System;

                [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
                internal sealed class GraphifyAttribute<T> : Attribute
                {
                }
            }
            """;

        const string declarations = """
            using Graphify;

            namespace Sample;

            [Graphify<Inner>]
            public sealed partial class Outer
            {
            }

            [Graphify<Outer>]
            public sealed partial class Inner
            {
            }
            """;

        CSharpParseOptions options = new(LanguageVersion.CSharp11);
        SyntaxTree[] trees =
        [
            CSharpSyntaxTree.ParseText(attribute, options),
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

        SemanticModel model = compilation.GetSemanticModel(trees[1]);
        INamedTypeSymbol? outer = compilation.GetTypeByMetadataName("Sample.Outer");

        _ = outer.ShouldNotBeNull();
        outer.HasGraphify(model, out ITypeSymbol value).ShouldBeTrue();

        // Act
        var subject = outer.ToSubject(compilation, [], value);

        // Assert
        _ = subject.ShouldNotBeNull();
        subject!.Encapsulated.Length.ShouldBe(1);
        subject.Encapsulated[0].Type.ShouldBe("global::Sample.Inner");
        subject.Encapsulated[0].HasConversionFrom.ShouldBeFalse();
        subject.Encapsulated[0].HasConversionTo.ShouldBeFalse();
        subject.Encapsulated[0].HasEqualityOperator.ShouldBeFalse();
        subject.Encapsulated[0].HasInequalityOperator.ShouldBeFalse();
    }
}