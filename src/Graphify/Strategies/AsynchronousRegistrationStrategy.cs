namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.AsynchronousRegistrationStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating registration-related source code and standardized navigator names for subjects.
    /// </summary>
    internal sealed class AsynchronousRegistrationStrategy
        : IStrategy
    {
        /// <summary>
        /// Generates registration source for the provided subject when registration is required.
        /// </summary>
        /// <param name="subject">The subject to inspect for registration support.</param>
        /// <returns>The generated sources for registration.</returns>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.Mode == Modes.Synchronous || subject.HasRegistration || !subject.CanRegister)
            {
                yield break;
            }

            string contract = AsynchronousContractStrategy.GetName(subject.Name);
            string implementation = AsynchronousNavigatorStrategy.GetName(subject.Name);
            string content = string.Format(GenerateContent, implementation, contract, subject.Name);
            string hint = $"ServiceCollectionExtensions.Add{implementation}";

            yield return new Source(content, hint);
        }
    }
}