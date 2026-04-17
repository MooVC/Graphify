namespace Graphify.Model
{
    /// <summary>
    /// Indicates the contract generation mode.
    /// </summary>
    internal enum Modes
    {
        /// <summary>
        /// Generates synchronous contracts and navigators.
        /// </summary>
        Synchronous,

        /// <summary>
        /// Generates asynchronous contracts and navigators.
        /// </summary>
        Asynchronous,
    }
}
