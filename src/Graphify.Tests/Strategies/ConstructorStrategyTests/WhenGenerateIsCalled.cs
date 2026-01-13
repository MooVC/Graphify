namespace Graphify.Strategies.ConstructorStrategyTests;

using Graphify.Model;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenSubjectWhenHasConstructorThenNoSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated[0].HasConstructor = true;
        var strategy = new ConstructorStrategy();

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenSubjectWhenLacksConstructorThenSourceIsReturned()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        var strategy = new ConstructorStrategy();

        // Act
        Source source = strategy.Generate(subject).Single();

        // Assert
        source.Hint.ShouldBe(ConstructorStrategy.Name);
        source.Code.ShouldContain("public Sample(int value)");
    }

    [Fact]
    public void GivenPassthroughEncapsulatedValueThenHintIncludesPassthrough()
    {
        // Arrange
        Subject subject = TestSubject.Create();

        subject.Encapsulated =
        [
            new Encapsulated { HasConstructor = true, Type = "int" },
            new Encapsulated { Type = "string" },
        ];

        var strategy = new ConstructorStrategy();

        // Act
        Source source = strategy.Generate(subject).Single();

        // Assert
        source.Hint.ShouldBe(".ctor.Passthrough.01");
        source.Code.ShouldContain("public Sample(string value)");
    }
}