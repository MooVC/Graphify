namespace Graphify.Strategies.ConvertToStrategyTests;

using Graphify.Model;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenSubjectWhenHasConversionToThenNoSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated = [new Encapsulated { HasConversionTo = true, Type = "int" }];
        var strategy = new ConvertToStrategy();

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenSubjectWhenLacksConversionToThenSourceIsReturned()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        var strategy = new ConvertToStrategy();

        // Act
        Source source = strategy.Generate(subject).Single();

        // Assert
        source.Hint.ShouldBe("ConvertTo");
        source.Code.ShouldContain("implicit operator Sample(");
    }

    [Fact]
    public void GivenSubjectWithAdditionalConversionsThenAllSourcesAreReturned()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated = [new Encapsulated { Type = "int" }, new Encapsulated { Type = "string" }];
        var strategy = new ConvertToStrategy();

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.Length.ShouldBe(2);
        sources[0].Hint.ShouldBe("ConvertTo");
        sources[1].Hint.ShouldBe("ConvertTo.Passthrough.Level01");
        sources[1].Code.ShouldContain("implicit operator Sample(string value)");
    }
}