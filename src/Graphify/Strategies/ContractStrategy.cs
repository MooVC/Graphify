namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;

    /// <summary>
    /// Provides a strategy for generating navigator interface.
    /// </summary>
    internal sealed class ContractStrategy
        : IStrategy
    {
        private static readonly IStrategy _asynchronous = new AsynchronousContractStrategy();
        private static readonly IStrategy _synchronous = new SynchronousContractStrategy();

        /// <summary>
        /// Generates a standardized navigator interface name for the specified subject.
        /// </summary>
        /// <param name="subject">The name of the subject for which to generate the navigator interface name. Cannot be <see langword="null"/>.</param>
        /// <returns>A string representing the navigator interface name in the format "I{subject}Navigator".</returns>
        public static string GetName(string subject)
        {
            return $"I{subject}Navigator";
        }

        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            IStrategy strategy = subject.Mode == Modes.Synchronous
                ? _synchronous
                : _asynchronous;

            return strategy.Generate(subject);
        }
    }
}
