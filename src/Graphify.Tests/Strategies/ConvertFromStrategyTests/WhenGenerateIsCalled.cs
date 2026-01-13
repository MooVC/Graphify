namespace Graphify.Strategies.ConvertFromStrategyTests;

using Graphify.Model;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenSubjectWhenHasConversionFromThenNoSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated = [new Encapsulated { HasConversionFrom = true, Type = "int" }];
        var strategy = new ConvertFromStrategy();

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenSubjectWhenLacksConversionFromThenSourceIsReturned()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        var strategy = new ConvertFromStrategy();

        // Act
        Source source = strategy.Generate(subject).Single();

        // Assert
        source.Hint.ShouldBe("ConvertFrom");
        source.Code.ShouldContain("implicit operator int(");
    }

    [Fact]
    public void GivenSubjectWithAdditionalConversionsThenAllSourcesAreReturned()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated = [new Encapsulated { Type = "int" }, new Encapsulated { Type = "string" }];
        var strategy = new ConvertFromStrategy();

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.Length.ShouldBe(2);
        sources[0].Hint.ShouldBe("ConvertFrom");
        sources[1].Hint.ShouldBe("ConvertFrom.Passthrough.Level01");
        sources[1].Code.ShouldContain("implicit operator string(");
    }
}