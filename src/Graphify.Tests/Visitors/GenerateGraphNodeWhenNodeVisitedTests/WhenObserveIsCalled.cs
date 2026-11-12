namespace Graphify.Visitors.GenerateGraphNodeWhenNodeVisitedTests;

using System.Collections.Immutable;
using Graphify.Model;
using Microsoft.CodeAnalysis;

public sealed class WhenObserveIsCalled
{
    [Test]
    [Arguments((string?)null)]
    [Arguments("_")]
    [Arguments("Graph")]
    public void GivenInternalPropertyThenGraphAndValueDeclarationsAreInternal(string? prefix)
    {
        // Arrange
        var visitor = new GenerateGraphNodeWhenNodeVisited();
        var subject = new Subject
        {
            Accessibility = Accessibility.Internal,
            Declaration = "partial class",
            Depth = 1,
            Name = "Sample.Root",
            Properties =
            [
                new Property
                {
                    Declaration = "internal",
                    Name = "Secret",
                    Properties = ImmutableArray<Property>.Empty,
                    Type = "int",
                },
            ],
            PropertyPrefix = prefix ?? string.Empty,
            Qualification = "Root",
            Type = "global::Sample.Root",
        };
        ImmutableArray<Node> nodes = subject.Nodes;
        var graphNodes = new Subject.Graph.Nodes(subject, nodes);
        var node = new Subject.Graph.Nodes.Node(graphNodes, 0, subject, nodes[0]);

        // Act
        Source generated = visitor.Observe(node).Single();

        // Assert
        generated.Code.ShouldContain("internal static partial class Graph");
        generated.Code.ShouldContain("internal sealed partial class Secret");
        generated.Code.ShouldContain($"internal int {prefix}Value {{ get; private set; }}");
    }

    [Test]
    public void GivenInternalPropertyWithChildPropertyThenWrapperDeclarationIsInternal()
    {
        // Arrange
        var visitor = new GenerateGraphNodeWhenNodeVisited();
        var subject = new Subject
        {
            Declaration = "partial class",
            Depth = 2,
            Name = "Root",
            Properties =
            [
                new Property
                {
                    Declaration = "internal",
                    Name = "Secret",
                    Properties =
                    [
                        new Property
                        {
                            Declaration = "public",
                            Name = "Length",
                            Properties = ImmutableArray<Property>.Empty,
                            Type = "int",
                        },
                    ],
                    Type = "string",
                },
            ],
            Qualification = "Root",
            Type = "global::Sample.Root",
        };
        ImmutableArray<Node> nodes = subject.Nodes;
        int index = nodes.Length - 1;
        var graphNodes = new Subject.Graph.Nodes(subject, nodes);
        var node = new Subject.Graph.Nodes.Node(graphNodes, index, subject, nodes[index]);

        // Act
        Source generated = visitor.Observe(node).Single();

        // Assert
        generated.Code.ShouldContain("internal partial class Secret");
    }
}