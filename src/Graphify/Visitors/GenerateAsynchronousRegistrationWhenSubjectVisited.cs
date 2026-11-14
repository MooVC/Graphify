namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;

    /// <summary>
    /// Generates the asynchronous registration for the subject.
    /// </summary>
    internal sealed class GenerateAsynchronousRegistrationWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode != Model.Modes.Asynchronous || subject.HasRegistration || !subject.CanRegister)
            {
                yield break;
            }

            yield return subject.ToRegistrationSource(asynchronous: true);
        }
    }
}