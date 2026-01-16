namespace Graphify.Console;

/// <summary>
/// Represents a complex entity with a name, age, and a collection of child objects.
/// </summary>
[Graphify]
internal sealed partial class Complex
{
    /// <summary>
    /// Gets or sets the age value.
    /// </summary>
    /// <value>
    /// The age value.
    /// </value>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets the collection of child elements associated with this instance.
    /// </summary>
    /// <value>
    /// The collection of child elements associated with this instance.
    /// </value>
    public Child[] Children { get; set; } = [];

    /// <summary>
    /// Gets or sets the name associated with the object.
    /// </summary>
    /// <value>
    /// The name associated with the object.
    /// </value>
    public string Name { get; set; } = string.Empty;
}