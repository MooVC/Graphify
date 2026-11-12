namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Names;
    using static Graphify.Strategies.AsynchronousVisitorStrategy_Resources;

    /// <summary>
    /// Generates the asynchronous visitor for the subject.
    /// </summary>
    internal sealed class GenerateAsynchronousVisitorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode != Model.Modes.Asynchronous)
            {
                yield break;
            }

            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string code = string.Format(GenerateContent, accessibility, subject.Name, subject.Type);

            yield return new Source(code, string.Concat(InterfaceNamePrefix, subject.Name, VisitorTypeSuffix));
        }
    }
}