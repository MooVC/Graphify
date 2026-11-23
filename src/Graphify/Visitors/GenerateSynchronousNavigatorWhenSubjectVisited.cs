namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using static Graphify.Visitors.GenerateSynchronousNavigatorWhenSubjectVisited_Resources;
    using ModelMode = Graphify.Model.Modes;

    /// <summary>
    /// Generates the synchronous navigator for a subject.
    /// </summary>
    internal sealed class GenerateSynchronousNavigatorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

            if (subject.Mode == ModelMode.Synchronous)
            {
                yield return subject.ToNavigatorSource(GenerateNavigateBody, GenerateInvokeBody, GenerateConcatenationsForSubjectContent, asynchronous: false);
            }
        }
    }
}