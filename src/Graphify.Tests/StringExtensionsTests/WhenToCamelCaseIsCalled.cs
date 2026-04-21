namespace Graphify.StringExtensionsTests;

public sealed class WhenToCamelCaseIsCalled
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GivenNullOrWhitespaceThenEmptyStringIsReturned(string? name)
    {
        // Arrange
        string expected = string.Empty;

        // Act
        string result = name.ToCamelCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Theory]
    [InlineData("PascalCase", "pascalCase")]
    [InlineData("X", "x")]
    [InlineData("alreadyCamel", "alreadyCamel")]
    [InlineData("Ünicode", "ünicode")]
    [InlineData("1Value", "1Value")]
    public void GivenNonWhitespaceTextThenOnlyTheFirstCharacterIsLowered(string name, string expected)
    {
        // Act
        string result = name.ToCamelCase();

        // Assert
        result.ShouldBe(expected);
    }
}