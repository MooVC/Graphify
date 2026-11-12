namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Names;
    using static Graphify.Strategies.SynchronousVisitorStrategy_Resources;

    /// <summary>
    /// Generates the synchronous visitor for the subject.
    /// </summary>
    internal sealed class GenerateSynchronousVisitorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode != Model.Modes.Synchronous)
            {
                yield break;
            }

            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string code = string.Format(GenerateContent, accessibility, subject.Name, subject.Type);

            yield return new Source(code, string.Concat(InterfaceNamePrefix, subject.Name, VisitorTypeSuffix));
        }
    }
}