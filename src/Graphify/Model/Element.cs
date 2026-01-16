namespace Graphify.Model
{
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Valuify;

    /// <summary>
    /// The definition of the <see cref="Element"/> type, which is used to capture information relating to a Element that
    /// forms part of the equality calculation for the type.
    /// </summary>
    [Valuify]
    internal sealed partial class Element
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of properties associated with the type of the property.
        /// </summary>
        /// <value>
        /// The collection of properties associated with the type of the property.
        /// </value>
        public ImmutableArray<Property> Properties { get; set; } = ImmutableArray<Property>.Empty;

        /// <summary>
        /// Gets or sets the underlying type symbol represented by this instance.
        /// </summary>
        /// <value>
        /// The underlying type symbol represented by this instance.
        /// </value>
        public ITypeSymbol Symbol { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified name of the property type.
        /// </summary>
        /// <value>
        /// The fully qualified name of the property type.
        /// </value>
        public string Type { get; set; } = string.Empty;
    }
}