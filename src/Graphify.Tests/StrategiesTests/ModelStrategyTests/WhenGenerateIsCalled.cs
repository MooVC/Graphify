namespace Graphify.StrategiesTests.ModelStrategyTests;

using System.Collections.Immutable;
using Graphify.Model;
using Graphify.Strategies;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenInternalPropertyThenValueDeclarationIsInternal()
    {
        // Arrange
        var strategy = new ModelStrategy();
        var subject = new Subject
        {
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
            Qualification = "Root",
            Type = "global::Sample.Root",
        };

        // Act
        Source generated = strategy.Generate(subject).Single();

        // Assert
        generated.Code.ShouldContain("internal int Value { get; private set; }");
    }
}