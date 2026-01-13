namespace Graphify.Semantics.INamedTypeSymbolExtensionsTests;

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Graphify.Model;
using Graphify.Semantics;

public sealed class WhenGetEncapsulatedIsCalled
{
    [Fact]
    public void GivenGraphifyAttributesWithNamedArgumentsThenPassthroughValuesAreCaptured()
    {
        // Arrange
        const string attribute = """
            namespace Graphify
            {
                using System;

                [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
                internal sealed class GraphifyAttribute : Attribute
                {
                    public Type? Type { get; set; }
                }
            }
            """;

        const string declarations = """
            using Graphify;

            namespace Sample;

            [Graphify(Type = typeof(Inner))]
            public sealed partial class Outer
            {
            }

            [Graphify(Type = typeof(string))]
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
        ImmutableArray<Encapsulated> encapsulated = outer.GetEncapsulated(compilation, value);

        // Assert
        encapsulated.Length.ShouldBe(2);
        encapsulated[0].Type.ShouldBe("global::Sample.Inner");
        encapsulated[1].Type.ShouldBe("string");
    }

    [Fact]
    public void GivenEncapsulatedTypeWithConversionsThenTheyAreCaptured()
    {
        // Arrange
        const string attribute = """
            namespace Graphify
            {
                using System;

                [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
                internal sealed class GraphifyAttribute : Attribute
                {
                    public Type? Type { get; set; }
                }
            }
            """;

        const string declarations = """
            using Graphify;

            namespace Sample;

            [Graphify(Type = typeof(Value))]
            public sealed partial class Wrapper
            {
            }

            public sealed class Value
            {
                public static implicit operator string(Value value) => value.ToString();

                public static explicit operator Value(string value) => new Value();
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
        INamedTypeSymbol? wrapper = compilation.GetTypeByMetadataName("Sample.Wrapper");

        _ = wrapper.ShouldNotBeNull();
        wrapper.HasGraphify(model, out ITypeSymbol value).ShouldBeTrue();

        // Act
        ImmutableArray<Encapsulated> encapsulated = wrapper.GetEncapsulated(compilation, value);

        // Assert
        encapsulated[0].Conversions.Length.ShouldBe(2);
        encapsulated[0].Conversions[0].IsReturnSubject.ShouldBeTrue();
        encapsulated[0].Conversions[0].Parameter.ShouldBe("string");
        encapsulated[0].Conversions[0].Return.ShouldBe("global::Sample.Wrapper");
        encapsulated[0].Conversions[1].IsParameterSubject.ShouldBeTrue();
        encapsulated[0].Conversions[1].Parameter.ShouldBe("global::Sample.Wrapper");
        encapsulated[0].Conversions[1].Return.ShouldBe("string");
    }

    [Fact]
    public void GivenEncapsulatedTypeWithUnaryOperatorsThenTheyAreCaptured()
    {
        // Arrange
        const string attribute = """
            namespace Graphify
            {
                using System;

                [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
                internal sealed class GraphifyAttribute : Attribute
                {
                    public Type? Type { get; set; }
                }
            }
            """;

        const string declarations = """
            using Graphify;

            namespace Sample;

            [Graphify(Type = typeof(Value))]
            public sealed partial class Wrapper
            {
            }

            public sealed class Value
            {
                public static Value operator +(Value value) => value;

                public static Value operator -(Value value) => value;

                public static Value operator !(Value value) => value;

                public static Value operator ~(Value value) => value;

                public static Value operator ++(Value value) => value;

                public static Value operator --(Value value) => value;

                public static bool operator true(Value value) => true;

                public static bool operator false(Value value) => false;
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
        INamedTypeSymbol? wrapper = compilation.GetTypeByMetadataName("Sample.Wrapper");

        _ = wrapper.ShouldNotBeNull();
        wrapper.HasGraphify(model, out ITypeSymbol value).ShouldBeTrue();

        // Act
        ImmutableArray<Encapsulated> encapsulated = wrapper.GetEncapsulated(compilation, value);

        // Assert
        encapsulated[0].UnaryOperators.Length.ShouldBe(8);

        encapsulated[0].UnaryOperators.ShouldContain(@operator => @operator.Operator == "op_UnaryPlus"
            && @operator.IsReturnSubject
            && @operator.Return == "global::Sample.Wrapper"
            && @operator.Symbol == "+");

        encapsulated[0].UnaryOperators.ShouldContain(@operator => @operator.Operator == "op_True"
            && !@operator.IsReturnSubject
            && @operator.Return == "bool"
            && @operator.Symbol == "true");
    }

    [Fact]
    public void GivenEncapsulatedTypeWithBinaryOperatorsThenTheyAreCaptured()
    {
        // Arrange
        const string attribute = """
            namespace Graphify
            {
                using System;

                [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
                internal sealed class GraphifyAttribute : Attribute
                {
                    public Type? Type { get; set; }
                }
            }
            """;

        const string declarations = """
            using Graphify;

            namespace Sample;

            [Graphify(Type = typeof(Value))]
            public sealed partial class Wrapper
            {
            }

            public sealed class Value
            {
                public static Value operator +(Value left, Value right) => left;

                public static Value operator -(Value left, int right) => left;

                public static bool operator <(Value left, Value right) => true;

                public static bool operator >=(int left, Value right) => true;
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
        INamedTypeSymbol? wrapper = compilation.GetTypeByMetadataName("Sample.Wrapper");

        _ = wrapper.ShouldNotBeNull();
        wrapper.HasGraphify(model, out ITypeSymbol value).ShouldBeTrue();

        // Act
        ImmutableArray<Encapsulated> encapsulated = wrapper.GetEncapsulated(compilation, value);

        // Assert
        encapsulated[0].BinaryOperators.Length.ShouldBe(4);

        encapsulated[0].BinaryOperators.ShouldContain(@operator => @operator.Operator == "op_Addition"
            && @operator.IsLeftSubject
            && @operator.IsRightSubject
            && @operator.IsReturnSubject
            && @operator.Symbol == "+");

        encapsulated[0].BinaryOperators.ShouldContain(@operator => @operator.Operator == "op_Subtraction"
            && @operator.IsLeftSubject
            && !@operator.IsRightSubject
            && @operator.IsReturnSubject
            && @operator.Right == "int"
            && @operator.Symbol == "-");

        encapsulated[0].BinaryOperators.ShouldContain(@operator => @operator.Operator == "op_LessThan"
            && @operator.IsLeftSubject
            && @operator.IsRightSubject
            && !@operator.IsReturnSubject
            && @operator.Return == "bool"
            && @operator.Symbol == "<");

        encapsulated[0].BinaryOperators.ShouldContain(@operator => @operator.Operator == "op_GreaterThanOrEqual"
            && !@operator.IsLeftSubject
            && @operator.IsRightSubject
            && !@operator.IsReturnSubject
            && @operator.Left == "int"
            && @operator.Symbol == ">=");
    }
}