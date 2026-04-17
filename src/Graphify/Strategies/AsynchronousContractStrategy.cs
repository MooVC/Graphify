namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.ContractStrategy_Resources;

    /// <summary>
    /// Generates asynchronous navigator contracts.
    /// </summary>
    internal sealed class AsynchronousContractStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.Mode == Modes.Synchronous || subject.HasContract)
            {
                yield break;
            }

            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string name = ContractStrategy.GetName(subject.Name);
            string content = string.Format(
                GenerateContent,
                accessibility,
                name,
                subject.Name,
                "IAsyncEnumerable",
                ", global::System.Threading.CancellationToken cancellationToken");

            yield return new Source(content, name);
        }
    }
}