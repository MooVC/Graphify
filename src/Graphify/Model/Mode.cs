namespace Graphify.Model
{
    /// <summary>
    /// Defines the generation mode for navigator contracts and implementations.
    /// </summary>
    internal enum Mode
    {
        /// <summary>
        /// Generates synchronous navigation using <see cref="System.Collections.Generic.IEnumerable{T}" /> and inspectors.
        /// </summary>
        Synchronous,

        /// <summary>
        /// Generates asynchronous navigation using <see cref="System.Collections.Generic.IAsyncEnumerable{T}" /> and visitors.
        /// </summary>
        Asynchronous,
    }
}
