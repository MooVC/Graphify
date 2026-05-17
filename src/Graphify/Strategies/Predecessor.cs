namespace Graphify.Strategies
{
    using Graphify.Model;
    using Valuify;

    /// <summary>
    /// Represents a predecessor element or property used for internal processing.
    /// </summary>
    [Valuify]
    internal sealed partial class Predecessor
    {
        public string Declaration { get; private set; } = string.Empty;

        public bool IsIndex { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Type { get; private set; } = string.Empty;

        /// <summary>
        /// Creates a new instance of the Predecessor class based on the specified Element.
        /// </summary>
        /// <param name="element">The Element from which to create the Predecessor. Cannot be <see langword="null"/>.</param>
        /// <returns>A Predecessor instance initialized with the properties of the specified Element.</returns>
        public static Predecessor From(Element element)
        {
            return From(element, "public");
        }

        /// <summary>
        /// Creates a new instance of the Predecessor class based on the specified Element.
        /// </summary>
        /// <param name="element">The Element from which to create the Predecessor. Cannot be <see langword="null"/>.</param>
        /// <param name="declaration">The declaration accessibility to apply.</param>
        /// <returns>A Predecessor instance initialized with the properties of the specified Element.</returns>
        public static Predecessor From(Element element, string declaration)
        {
            return new Predecessor
            {
                Declaration = declaration,
                IsIndex = true,
                Name = element.Name,
                Type = element.Type,
            };
        }

        /// <summary>
        /// Creates a new instance of the Predecessor class based on the specified property.
        /// </summary>
        /// <param name="property">The property from which to create the Predecessor instance. Cannot be <see langword="null"/>.</param>
        /// <returns>A new Predecessor instance with values copied from the specified property.</returns>
        public static Predecessor From(Property property)
        {
            return new Predecessor
            {
                Declaration = property.Declaration,
                Name = property.Name,
                Type = property.Type,
            };
        }
    }
}