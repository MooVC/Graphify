namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Names;
    using static Graphify.Strategies.SynchronousContractStrategy_Resources;

    /// <summary>
    /// Generates the synchronous contract for the subject.
    /// </summary>
    internal sealed class GenerateSynchronousContractWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode != Model.Modes.Synchronous || subject.HasContract)
            {
                yield break;
            }

            string name = GetNavigatorContractName(subject.Name);
            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string code = string.Format(GenerateContent, accessibility, name, subject.Type);

            yield return new Source(code, name);
        }
    }
}