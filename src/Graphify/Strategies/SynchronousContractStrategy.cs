namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.SynchronousContractStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating synchronous navigator interfaces.
    /// </summary>
    internal sealed class SynchronousContractStrategy
        : IStrategy
    {
        public static string GetName(string subject)
        {
            return $"I{subject}Navigator";
        }

        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.Mode != Modes.Synchronous || subject.HasContract)
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