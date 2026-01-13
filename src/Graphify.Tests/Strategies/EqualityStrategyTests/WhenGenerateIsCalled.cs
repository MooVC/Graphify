namespace Graphify.Strategies.EqualityStrategyTests;

using System.Collections.Generic;
using System.Linq;
using Graphify.Model;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenSubjectWhenOperatorsExistThenNoSourceIsGenerated()
    {
        // Arrange
        var strategy = new EqualityStrategy();
        Subject subject = TestSubject.Create();
        subject.HasEqualityOperator = true;

        subject.Encapsulated =
        [
            new Encapsulated { HasEqualityOperator = true, Type = "int" },
            new Encapsulated { HasEqualityOperator = true, Type = "string" },
        ];

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenSubjectWhenOperatorsMissingThenSelfAndValueAreGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        var strategy = new EqualityStrategy();

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.Length.ShouldBe(2);
        sources[0].Hint.ShouldBe("Equality.Self");
        sources[1].Hint.ShouldBe("Equality.Value");
    }

    [Fact]
    public void GivenSubjectWithPassthroughConversionThenSourceIsReturned()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated = [new Encapsulated { Type = "int" }, new Encapsulated { Type = "string" }];
        var strategy = new EqualityStrategy();

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.Length.ShouldBe(3);
        sources[2].Hint.ShouldBe("Equality.Passthrough.Level01");
    }
}