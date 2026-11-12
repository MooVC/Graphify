namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Names;
    using static Graphify.Strategies.SynchronousRegistrationStrategy_Resources;

    /// <summary>
    /// Generates the synchronous registration for the subject.
    /// </summary>
    internal sealed class GenerateSynchronousRegistrationWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode != Model.Modes.Synchronous || subject.HasRegistration || !subject.CanRegister)
            {
                yield break;
            }

            string name = GetNavigatorName(subject.Name);
            string contract = subject.Qualify(GetNavigatorContractName(subject.Name));
            string code = string.Format(GenerateContent, name, contract, subject.Qualify(name));
            string hint = string.Concat(RegistrationClassName, ".", RegistrationMethodPrefix, name);

            yield return new Source(code, hint);
        }
    }
}