namespace Graphify.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata;
    using System.Reflection.Metadata.Ecma335;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;
    using static Graphify.Strategies.RegistrationStrategy_Resources;

    internal sealed class RegistrationStrategy
        : IStrategy
    {
        /// <summary>
        /// Generates a standardized navigator name for the specified subject.
        /// </summary>
        /// <param name="subject">The name of the subject for which to generate the navigator name. Cannot be <see langword="null"/>.</param>
        /// <returns>A string representing the navigator name in the format "{subject}Navigator".</returns>
        public static string GetName(string subject)
        {
            return $"{subject}Navigator";
        }

        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.HasRegistration || !subject.CanRegister)
            {
                yield break;
            }

            string contract = ContractStrategy.GetName(subject.Name);
            string implementation = GetName(subject.Name);
            string content = string.Format(GenerateContent, implementation, contract);

            yield return new Source(content, implementation);
        }
    }
}