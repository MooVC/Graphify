namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using static Graphify.Visitors.GenerateAsynchronousNavigatorWhenSubjectVisited_Resources;
    using ModelMode = Graphify.Model.Modes;

    /// <summary>
    /// Generates the asynchronous navigator for a subject.
    /// </summary>
    internal sealed class GenerateAsynchronousNavigatorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

            if (subject.Mode == ModelMode.Asynchronous)
            {
                yield return subject.ToNavigatorSource(GenerateNavigateBody, GenerateInvokeBody, GenerateConcatenationsForSubjectContent, asynchronous: true);
            }
        }
    }
}