namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using static Graphify.Strategies.AsynchronousNavigatorStrategy_Resources;
    using ModelMode = Graphify.Model.Modes;

    /// <summary>
    /// Generates the asynchronous navigator for a subject.
    /// </summary>
    internal sealed class GenerateAsynchronousNavigatorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode == ModelMode.Asynchronous)
            {
                yield return subject.ToNavigatorSource(GenerateNavigatorContent, GenerateConcatenationsForSubjectContent);
            }
        }
    }
}