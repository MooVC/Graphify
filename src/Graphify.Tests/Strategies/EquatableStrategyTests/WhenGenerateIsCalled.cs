namespace Graphify.Strategies.EquatableStrategyTests;

using Graphify.Model;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenSubjectWhenHasEquatablesThenNoSourceIsGenerated()
    {
        // Arrange
        var strategy = new EquatableStrategy();
        Subject subject = TestSubject.Create();

        subject.Encapsulated = subject.Encapsulated.Clear();
        subject.IsEquatable = true;
        subject.HasEquatable = true;

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenSubjectWhenDoesNotHaveEquatableThenTwoSourcesAreReturned()
    {
        // Arrange
        var strategy = new EquatableStrategy();
        Subject subject = TestSubject.Create();

        subject.Encapsulated = subject.Encapsulated.Clear();

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.Length.ShouldBe(2);
        sources[0].Hint.ShouldBe("IEquatable.Self");
        sources[1].Hint.ShouldBe("IEquatable.Self.Equals");
    }

    [Fact]
    public void GivenSequenceEncapsulatedValueThenImmutableArrayCheckIsGenerated()
    {
        // Arrange
        var strategy = new EquatableStrategy();
        Subject subject = TestSubject.Create();

        subject.Encapsulated =
        [
            new Encapsulated
            {
                HasEquatable = false,
                IsEquatable = true,
                IsSequence = true,
                Type = "global::System.Collections.Immutable.ImmutableArray<int>",
            },
        ];

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.ShouldContain(source => source.Code.Contains("IsDefault ? other.IsDefault"));
    }

    [Fact]
    public void GivenPassthroughEncapsulatedSequenceThenSequenceComparerIsUsed()
    {
        // Arrange
        var strategy = new EquatableStrategy();
        Subject subject = TestSubject.Create();

        subject.Encapsulated =
        [
            new Encapsulated
            {
                HasEquatable = false,
                IsEquatable = true,
                IsSequence = true,
                Type = "global::System.Collections.Generic.IEnumerable<int>",
            },
        ];

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.ShouldContain(source => source.Code.Contains("SequenceEqualityComparer.Default.Equals"));
    }
}