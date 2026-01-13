namespace Graphify.SourceTests;

public sealed class WhenConstructed
{
    [Fact]
    public void GivenCodeAndHintThenPropertiesAreSet()
    {
        // Arrange
        const string code = "code";
        const string hint = "hint";

        // Act
        var source = new Source(code, hint);

        // Assert
        source.Code.ShouldBe(code);
        source.Hint.ShouldBe(hint);
    }
}