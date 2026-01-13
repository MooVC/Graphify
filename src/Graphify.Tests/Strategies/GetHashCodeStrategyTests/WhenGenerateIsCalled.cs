namespace Graphify.Strategies.GetHashCodeStrategyTests;

using Graphify.Model;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenOverridesWhenNotAllowedThenNoSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        var strategy = new GetHashCodeStrategy();

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenOverridesWhenAllowedThenSourceIsReturned()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.CanOverrideGetHashCode = true;
        var strategy = new GetHashCodeStrategy();

        // Act
        Source source = strategy.Generate(subject).Single();

        // Assert
        source.Hint.ShouldBe(nameof(object.GetHashCode));
        source.Code.ShouldContain("public override int GetHashCode()");
    }
}