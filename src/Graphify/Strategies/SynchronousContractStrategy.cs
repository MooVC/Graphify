namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.ContractStrategy_Resources;

    /// <summary>
    /// Generates synchronous navigator contracts.
    /// </summary>
    internal sealed class SynchronousContractStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.Mode != Modes.Synchronous || subject.HasContract)
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
                "IEnumerable",
                string.Empty);

            yield return new Source(content, name);
        }
    }
}
