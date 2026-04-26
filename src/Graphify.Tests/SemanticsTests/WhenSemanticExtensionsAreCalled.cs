namespace Graphify.SemanticsTests;

using System.Collections.Immutable;
using Graphify.Model;
using Graphify.Semantics;
using Graphify.Testing;
using Microsoft.CodeAnalysis;

public sealed class WhenSemanticExtensionsAreCalled
{
    private const string Source = """
        using System;
        using System.Collections;
        using System.Collections.Generic;

        namespace Graphify
        {
            [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
            public sealed class GraphifyAttribute : Attribute
            {
                public byte Depth { get; set; }
                public Modes Mode { get; set; }
            }

            [AttributeUsage(AttributeTargets.Property)]
            public sealed class TraverseAttribute : Attribute
            {
                public TraverseScope Scope { get; set; } = TraverseScope.All;
            }

            public enum Modes
            {
                Synchronous,
                Asynchronous,
            }

            public enum TraverseScope
            {
                None,
                All,
                Property,
            }
        }

        namespace Sample
        {
            using Graphify;

            [Graphify(Depth = 0, Mode = Modes.Synchronous)]
            public partial class Root
            {
                [Traverse(Scope = TraverseScope.Property)]
                public Child? PropertyOnly { get; set; }

                public Child? Child { get; set; }

                internal Child? InternalChild { get; set; }

                public string Name { get; set; } = string.Empty;

                public int[] Numbers { get; set; } = [];

                [Traverse(Scope = TraverseScope.None)]
                public Child? Ignored { get; set; }

                private Child? PrivateChild { get; set; }
            }

            public class Child : IEnumerable<Leaf>
            {
                public Leaf? Leaf { get; set; }

                public IEnumerator<Leaf> GetEnumerator() => throw new NotImplementedException();

                IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            }

            public class Leaf
            {
                public int Value { get; set; }
            }

            public static class ServiceCollectionExtensions
            {
                public static object AddRootNavigator(object services) => services;
            }

            public partial class IInternalAnnotatedNavigator
            {
            }

            [Graphify(Depth = 4, Mode = Modes.Asynchronous)]
            internal partial class InternalAnnotated
            {
            }

            [Graphify(Depth = 4, Mode = Modes.Asynchronous)]
            private partial class PrivateAnnotated
            {
            }
        }
        """;

    [Fact]
    public void GivenAnnotatedTypeThenHasGraphifyResolvesDepthAndMode()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");

        // Act
        bool hasGraphify = root.HasGraphify(out byte depth, out Modes mode);

        // Assert
        hasGraphify.ShouldBeTrue();
        depth.ShouldBe((byte)16);
        mode.ShouldBe(Modes.Synchronous);
    }

    [Fact]
    public void GivenAnnotatedTypeThenToSubjectAndGetPropertiesMapExpectedGraph()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source, typeof(Microsoft.Extensions.DependencyInjection.IServiceCollection).Assembly);
        INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");

        // Act
        var subject = root.ToSubject(depth: 4, mode: Modes.Asynchronous, nesting: [], hasRegistration: true);
        ImmutableArray<Property> properties = root.GetProperties(depth: 4);

        // Assert
        _ = subject.ShouldNotBeNull();
        subject.Name.ShouldBe("Root");
        subject.Declaration.ShouldBe("partial class");
        subject.HasRegistration.ShouldBeTrue();
        subject.HasContract.ShouldBeFalse();
        properties.Length.ShouldBe(5);
        properties.Any(property => property.Name == "Ignored").ShouldBeFalse();
        properties.Any(property => property.Name == "PrivateChild").ShouldBeFalse();
        properties.First(property => property.Name == "InternalChild").Declaration.ShouldBe("internal");
        properties.First(property => property.Name == "PropertyOnly").Properties.ShouldBe([]);
    }

    [Fact]
    public void GivenATypeAndContainerThenToElementReturnsEmptyPropertiesWhenMatchingContainer()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol child = context.GetTypeByMetadataName("Sample.Child");

        // Act
        var element = child.ToElement(child, depth: 4, level: 0);

        // Assert
        element.Name.ShouldBe("Child");
        element.Properties.ShouldBe(ImmutableArray<Property>.Empty);
    }

    [Fact]
    public void GivenAttributeQueriesThenGetAttributeAndPredicatesMatch()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
        IPropertySymbol property = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "PropertyOnly");
        INamedTypeSymbol graphifyAttribute = context.GetTypeByMetadataName("Graphify.GraphifyAttribute");
        INamedTypeSymbol traverseAttribute = context.GetTypeByMetadataName("Graphify.TraverseAttribute");

        // Act
        AttributeData? graphify = root.GetAttribute(GraphifyAttributeGenerator.Name);

        // Assert
        _ = graphify.ShouldNotBeNull();
        root.HasAttribute(GraphifyAttributeGenerator.Name).ShouldBeTrue();
        property.HasAttribute(TraverseAttributeGenerator.Name).ShouldBeTrue();
        graphifyAttribute.IsGraphify().ShouldBeTrue();
        traverseAttribute.IsTraverse().ShouldBeTrue();
        graphifyAttribute.IsAttribute(GraphifyAttributeGenerator.Name).ShouldBeTrue();
        traverseAttribute.IsAttribute(TraverseAttributeGenerator.Name).ShouldBeTrue();
    }

    [Fact]
    public void GivenCollectionAndStringPropertiesThenIsSequenceHandlesBothCases()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
        IPropertySymbol numbers = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Numbers");
        IPropertySymbol name = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Name");

        // Act
        bool numberSequence = numbers.Type.IsSequence(root, depth: 4, level: 0, out Element? element);
        bool nameSequence = name.Type.IsSequence(root, depth: 4, level: 0, out Element? ignored);

        // Assert
        numberSequence.ShouldBeTrue();
        _ = element.ShouldNotBeNull();
        element.Name.ShouldBe("Int32");
        nameSequence.ShouldBeFalse();
        ignored.ShouldBeNull();
    }

    [Fact]
    public void GivenNamedArgumentsThenTryGetArgumentTextFindsExpectedValues()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
        AttributeData graphify = root.GetAttribute(GraphifyAttributeGenerator.Name)!;
        IPropertySymbol property = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "PropertyOnly");
        AttributeData traverse = property.GetAttribute(TraverseAttributeGenerator.Name)!;

        // Act
        bool hasDepth = graphify.TryGetArgumentText(nameof(Subject.Depth), out string depthText);
        bool hasMode = graphify.TryGetArgumentText(nameof(Subject.Mode), out string modeText);
        bool hasScope = traverse.TryGetArgumentText("Scope", out string scopeText);

        // Assert
        hasDepth.ShouldBeTrue();
        depthText.ShouldBe("0");
        hasMode.ShouldBeTrue();
        modeText.ShouldBe("Modes.Synchronous");
        hasScope.ShouldBeTrue();
        scopeText.ShouldBe("TraverseScope.Property");
    }

    [Fact]
    public void GivenNullAttributeThenTryGetArgumentTextThrows()
    {
        // Arrange
        AttributeData? attribute = default;

        // Act
        Action act = () => _ = attribute!.TryGetArgumentText(string.Empty, out _);

        // Assert
        _ = act.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenPropertySymbolThenToPropertyMapsElementAndMetadata()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
        IPropertySymbol numbers = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Numbers");

        // Act
        var property = numbers.ToProperty(depth: 4, level: 0, TraverseScope.All);

        // Assert
        property.Name.ShouldBe("Numbers");
        property.Declaration.ShouldBe("public");
        property.Scope.ShouldBe(TraverseScope.All);
        _ = property.Element.ShouldNotBeNull();
        property.Element.Name.ShouldBe("Int32");
        property.Type.ShouldContain("int[]");
    }

    [Fact]
    public void GivenTraverseAttributeThenScopeIsResolved()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
        IPropertySymbol propertyOnly = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "PropertyOnly");
        IPropertySymbol child = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Child");
        IPropertySymbol ignored = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Ignored");

        // Act
        TraverseScope propertyScope = propertyOnly.GetTraverseScope();
        TraverseScope childScope = child.GetTraverseScope();
        TraverseScope ignoredScope = ignored.GetTraverseScope();

        // Assert
        propertyScope.ShouldBe(TraverseScope.Property);
        childScope.ShouldBe(TraverseScope.All);
        ignoredScope.ShouldBe(TraverseScope.None);
    }

    [Fact]
    public void GivenTypeSymbolsThenDeclarationAccessibilityAndContractsAreResolved()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol internalAnnotated = context.GetTypeByMetadataName("Sample.InternalAnnotated");
        INamedTypeSymbol privateAnnotated = context.GetTypeByMetadataName("Sample.PrivateAnnotated");

        // Act
        string declaration = internalAnnotated.GetDeclaration();

        // Assert
        declaration.ShouldBe("partial class");
        internalAnnotated.HasContract().ShouldBeTrue();
        context.GetTypeByMetadataName("Sample.Root").HasRegistration().ShouldBeTrue();
        internalAnnotated.HasSupportedAccessibility().ShouldBeTrue();
        privateAnnotated.HasSupportedAccessibility().ShouldBeFalse();
    }

    [Fact]
    public void GivenUnannotatedTypeThenHasGraphifyReturnsFalseWithDefaults()
    {
        // Arrange
        var context = RoslynTestContext.Create(Source);
        INamedTypeSymbol leaf = context.GetTypeByMetadataName("Sample.Leaf");

        // Act
        bool hasGraphify = leaf.HasGraphify(out byte depth, out Modes mode);

        // Assert
        hasGraphify.ShouldBeFalse();
        depth.ShouldBe((byte)16);
        mode.ShouldBe(Modes.Asynchronous);
    }
}