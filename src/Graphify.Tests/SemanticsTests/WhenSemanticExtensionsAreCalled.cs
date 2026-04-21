namespace Graphify.SemanticsTests
{
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

                    public TraverseAttribute()
                    {
                    }

                    public TraverseAttribute(TraverseScope scope)
                    {
                        Scope = scope;
                    }
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
                [Graphify.Graphify(Depth = 0, Mode = Graphify.Modes.Synchronous)]
                public partial class Root
                {
                    [Graphify.Traverse(Scope = Graphify.TraverseScope.Property)]
                    public Child? PropertyOnly { get; set; }

                    public Child? Child { get; set; }

                    public string Name { get; set; } = string.Empty;

                    public int[] Numbers { get; set; } = [];

                    [Graphify.Traverse(Graphify.TraverseScope.None)]
                    public Child? Ignored { get; set; }
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

                public partial interface IContracted
                {
                }

                public partial class IContractedNavigator
                {
                }

                [Graphify.Graphify(Depth = 4, Mode = Graphify.Modes.Asynchronous)]
                internal partial class InternalAnnotated
                {
                }

                public partial class Outer
                {
                    [Graphify.Graphify]
                    protected internal partial class ProtectedInternalAnnotated
                    {
                    }
                }
            }
            """;

        [Fact]
        public void GivenNullAttributeThenTryGetArgumentTextThrows()
        {
            // Arrange
            AttributeData? attribute = null;

            // Act
            Action act = () => _ = attribute!.TryGetArgumentText(string.Empty, out _);

            // Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GivenNamedArgumentsThenTryGetArgumentTextFindsExpectedValues()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
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
            modeText.ShouldBe("Graphify.Modes.Synchronous");
            hasScope.ShouldBeTrue();
            scopeText.ShouldBe("Graphify.TraverseScope.Property");
        }

        [Fact]
        public void GivenPositionalArgumentsThenTryGetArgumentTextUsesConstructorArguments()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
            IPropertySymbol ignored = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Ignored");
            AttributeData traverse = ignored.GetAttribute(TraverseAttributeGenerator.Name)!;

            // Act
            bool hasValue = traverse.TryGetArgumentText(string.Empty, out string value);

            // Assert
            hasValue.ShouldBeTrue();
            value.ShouldBe(((int)TraverseScope.None).ToString());
        }

        [Fact]
        public void GivenAnnotatedTypeThenHasGraphifyResolvesDepthAndMode()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");

            // Act
            bool hasGraphify = root.HasGraphify(out byte depth, out Modes mode);

            // Assert
            hasGraphify.ShouldBeTrue();
            depth.ShouldBe((byte)16);
            mode.ShouldBe(Modes.Synchronous);
        }

        [Fact]
        public void GivenUnannotatedTypeThenHasGraphifyReturnsFalseWithDefaults()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol leaf = context.GetTypeByMetadataName("Sample.Leaf");

            // Act
            bool hasGraphify = leaf.HasGraphify(out byte depth, out Modes mode);

            // Assert
            hasGraphify.ShouldBeFalse();
            depth.ShouldBe((byte)16);
            mode.ShouldBe(Modes.Asynchronous);
        }

        [Fact]
        public void GivenAttributeQueriesThenGetAttributeAndPredicatesMatch()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
            IPropertySymbol property = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "PropertyOnly");
            INamedTypeSymbol graphifyAttribute = context.GetTypeByMetadataName("Graphify.GraphifyAttribute");
            INamedTypeSymbol traverseAttribute = context.GetTypeByMetadataName("Graphify.TraverseAttribute");

            // Act
            AttributeData? graphify = root.GetAttribute(GraphifyAttributeGenerator.Name);

            // Assert
            graphify.ShouldNotBeNull();
            root.HasAttribute(GraphifyAttributeGenerator.Name).ShouldBeTrue();
            property.HasAttribute(TraverseAttributeGenerator.Name).ShouldBeTrue();
            graphifyAttribute.IsGraphify().ShouldBeTrue();
            traverseAttribute.IsTraverse().ShouldBeTrue();
            graphifyAttribute.IsAttribute(GraphifyAttributeGenerator.Name).ShouldBeTrue();
            traverseAttribute.IsAttribute(TraverseAttributeGenerator.Name).ShouldBeTrue();
        }

        [Fact]
        public void GivenTypeSymbolsThenDeclarationAccessibilityAndContractsAreResolved()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol contracted = context.GetTypeByMetadataName("Sample.IContracted");
            INamedTypeSymbol internalAnnotated = context.GetTypeByMetadataName("Sample.InternalAnnotated");
            INamedTypeSymbol protectedInternal = context.GetTypeByMetadataName("Sample.Outer.ProtectedInternalAnnotated");

            // Act
            string declaration = contracted.GetDeclaration();

            // Assert
            declaration.ShouldBe("partial interface");
            contracted.HasContract().ShouldBeTrue();
            context.GetTypeByMetadataName("Sample.Root").HasRegistration().ShouldBeTrue();
            internalAnnotated.HasSupportedAccessibility().ShouldBeTrue();
            protectedInternal.HasSupportedAccessibility().ShouldBeFalse();
        }

        [Fact]
        public void GivenTraverseAttributeThenScopeIsResolved()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
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
        public void GivenCollectionAndStringPropertiesThenIsSequenceHandlesBothCases()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
            IPropertySymbol numbers = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Numbers");
            IPropertySymbol name = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Name");

            // Act
            bool numberSequence = numbers.Type.IsSequence(root, depth: 4, level: 0, out Element? element);
            bool nameSequence = name.Type.IsSequence(root, depth: 4, level: 0, out Element? ignored);

            // Assert
            numberSequence.ShouldBeTrue();
            element.ShouldNotBeNull();
            element.Name.ShouldBe("Int32");
            nameSequence.ShouldBeFalse();
            ignored.ShouldBeNull();
        }

        [Fact]
        public void GivenAnnotatedTypeThenToSubjectAndGetPropertiesMapExpectedGraph()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source, typeof(Microsoft.Extensions.DependencyInjection.IServiceCollection).Assembly);
            INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");

            // Act
            Subject? subject = root.ToSubject(depth: 4, mode: Modes.Asynchronous, nesting: ImmutableArray<Nesting>.Empty, hasRegistration: true);
            ImmutableArray<Property> properties = root.GetProperties(depth: 4);

            // Assert
            subject.ShouldNotBeNull();
            subject.Name.ShouldBe("Root");
            subject.Declaration.ShouldBe("partial class");
            subject.HasRegistration.ShouldBeTrue();
            subject.HasContract.ShouldBeFalse();
            properties.Length.ShouldBe(4);
            properties.Any(property => property.Name == "Ignored").ShouldBeFalse();
            properties.First(property => property.Name == "PropertyOnly").Properties.ShouldBe(ImmutableArray<Property>.Empty);
        }

        [Fact]
        public void GivenPropertySymbolThenToPropertyMapsElementAndMetadata()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol root = context.GetTypeByMetadataName("Sample.Root");
            IPropertySymbol numbers = root.GetMembers().OfType<IPropertySymbol>().First(candidate => candidate.Name == "Numbers");

            // Act
            Property property = numbers.ToProperty(depth: 4, level: 0, TraverseScope.All);

            // Assert
            property.Name.ShouldBe("Numbers");
            property.Scope.ShouldBe(TraverseScope.All);
            property.Element.ShouldNotBeNull();
            property.Element.Name.ShouldBe("Int32");
            property.Type.ShouldContain("System.Int32[]");
        }

        [Fact]
        public void GivenATypeAndContainerThenToElementReturnsEmptyPropertiesWhenMatchingContainer()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            INamedTypeSymbol child = context.GetTypeByMetadataName("Sample.Child");

            // Act
            Element element = child.ToElement(child, depth: 4, level: 0);

            // Assert
            element.Name.ShouldBe("Child");
            element.Properties.ShouldBe(ImmutableArray<Property>.Empty);
        }
    }
}