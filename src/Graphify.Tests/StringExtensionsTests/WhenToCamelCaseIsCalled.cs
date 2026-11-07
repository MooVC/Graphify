namespace Graphify.StringExtensionsTests;

public sealed class WhenToCamelCaseIsCalled
{
    [Test]
    [Arguments((string?)null)]
    [Arguments("")]
    [Arguments("   ")]
    public void GivenNullOrWhitespaceThenEmptyStringIsReturned(string? name)
    {
        // Arrange
        string expected = string.Empty;

        // Act
        string result = name.ToCamelCase();

        // Assert
        result.ShouldBe(expected);
    }

    [Test]
    [Arguments("PascalCase", "pascalCase")]
    [Arguments("X", "x")]
    [Arguments("alreadyCamel", "alreadyCamel")]
    [Arguments("Ünicode", "ünicode")]
    [Arguments("1Value", "1Value")]
    public void GivenNonWhitespaceTextThenOnlyTheFirstCharacterIsLowered(string name, string expected)
    {
        // Act
        string result = name.ToCamelCase();

        // Assert
        result.ShouldBe(expected);
    }
}