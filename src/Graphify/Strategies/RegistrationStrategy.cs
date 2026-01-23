namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.RegistrationStrategy_Resources;

    /// <summary>
    /// Provides a strategy for generating registration-related source code and standardized navigator names for subjects.
    /// </summary>
    internal sealed class RegistrationStrategy
        : IStrategy
    {
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.HasRegistration || !subject.CanRegister)
            {
                yield break;
            }

            string contract = ContractStrategy.GetName(subject.Name);
            string implementation = ImplementationStrategy.GetName(subject.Name);
            string content = string.Format(GenerateContent, implementation, contract, subject.Name);
            string hint = $"ServiceCollectionExtensions.Add{implementation}";

            yield return new Source(content, hint);
        }
    }
}