namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.SynchronousVisitorStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating synchronous visitor interfaces.
    /// </summary>
    internal sealed class SynchronousVisitorStrategy
        : IStrategy
    {
        /// <summary>
        /// Generates a synchronous visitor interface for the specified subject.
        /// </summary>
        /// <param name="subject">The subject for which to generate the visitor interface.</param>
        /// <returns>The generated visitor interface source, or no source when the subject is not synchronous.</returns>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.Mode != Modes.Synchronous)
            {
                yield break;
            }

            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string code = string.Format(GenerateContent, accessibility, subject.Name, subject.Type);

            yield return new Source(code, $"I{subject.Name}Visitor");
        }
    }
}