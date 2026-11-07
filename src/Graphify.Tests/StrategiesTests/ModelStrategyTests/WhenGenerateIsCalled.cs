namespace Graphify.StrategiesTests.ModelStrategyTests;

using System.Collections.Immutable;
using Graphify.Model;
using Graphify.Strategies;
using Microsoft.CodeAnalysis;

public sealed class WhenGenerateIsCalled
{
    [Test]
    [Arguments((string?)null)]
    [Arguments("_")]
    [Arguments("Graph")]
    public void GivenInternalPropertyThenGraphAndValueDeclarationsAreInternal(string? prefix)
    {
        // Arrange
        var strategy = new ModelStrategy();
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

        // Act
        Source generated = strategy.Generate(subject).Single();

        // Assert
        generated.Code.ShouldContain("internal static partial class Graph");
        generated.Code.ShouldContain("internal sealed partial class Secret");
        generated.Code.ShouldContain($"internal int {prefix}Value {{ get; private set; }}");
    }

    [Test]
    public void GivenInternalPropertyWithChildPropertyThenWrapperDeclarationIsInternal()
    {
        // Arrange
        var strategy = new ModelStrategy();
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

        // Act
        Source generated = strategy.Generate(subject).Last();

        // Assert
        generated.Code.ShouldContain("internal partial class Secret");
    }
}