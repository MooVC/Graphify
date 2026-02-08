namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.ContractStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating navigator interface.
    /// </summary>
    internal sealed class ContractStrategy
        : IStrategy
    {
        /// <summary>
        /// Generates a standardized navigator interface name for the specified subject.
        /// </summary>
        /// <param name="subject">The name of the subject for which to generate the navigator interface name. Cannot be <see langword="null"/>.</param>
        /// <returns>A string representing the navigator interface name in the format "I{subject}Navigator".</returns>
        public static string GetName(string subject)
        {
            return $"I{subject}Navigator";
        }

        /// <summary>
        /// Generates source representations for the specified subject if it does not have an associated contract.
        /// </summary>
        /// <param name="subject">The subject for which to generate source representations. Must not be null.</param>
        /// <returns>
        /// An enumerable collection containing a single source representation if the subject does not have a contract;
        /// otherwise, an empty collection.
        /// </returns>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.HasContract)
            {
                yield break;
            }

            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string name = GetName(subject.Name);
            string content = string.Format(GenerateContent, accessibility, name, subject.Name);

            yield return new Source(content, name);
        }
    }
}