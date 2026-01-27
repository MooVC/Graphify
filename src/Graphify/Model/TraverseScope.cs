namespace Graphify.Model
{
    /// <summary>
    /// Defines how Graphify should traverse a property.
    /// </summary>
    internal enum TraverseScope
    {
        /// <summary>
        /// Do not traverse or include the property.
        /// </summary>
        None,

        /// <summary>
        /// Traverse the property and its child properties.
        /// </summary>
        All,

        /// <summary>
        /// Traverse the property itself but skip its child properties.
        /// </summary>
        Property,
    }
}