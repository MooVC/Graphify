namespace Graphify.Console.Simple;

/// <summary>
/// Represents a simple entity with a name, age, and species information.
/// </summary>
[Graphify]
public sealed partial class Simple
{
    /// <summary>
    /// Gets the species name represented by this class.
    /// </summary>
    /// <value>
    /// The species name represented by this class.
    /// </value>
    public static string Species { get; } = "Human";

    /// <summary>
    /// Gets or sets the age value associated with the current instance.
    /// </summary>
    /// <value>
    /// The age value associated with the current instance.
    /// </value>
    public int Age { get; set; }

    /// <summary>
    /// Gets a value indicating whether the person is considered an adult based on their age.
    /// </summary>
    /// <value>
    /// A value indicating whether the person is considered an adult based on their age.
    /// </value>
    public bool IsAdult => Age >= 18;

    /// <summary>
    /// Gets or sets the name associated with the current instance.
    /// </summary>
    /// <value>
    /// The name associated with the current instance.
    /// </value>
    public string Name { get; set; } = string.Empty;
}