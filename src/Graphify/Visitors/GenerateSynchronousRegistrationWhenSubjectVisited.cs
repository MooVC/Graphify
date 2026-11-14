namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;

    /// <summary>
    /// Generates the synchronous registration for the subject.
    /// </summary>
    internal sealed class GenerateSynchronousRegistrationWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

            if (subject.Mode != Model.Modes.Synchronous || subject.HasRegistration || !subject.CanRegister)
            {
                yield break;
            }

            yield return subject.ToRegistrationSource(asynchronous: false);
        }
    }
}