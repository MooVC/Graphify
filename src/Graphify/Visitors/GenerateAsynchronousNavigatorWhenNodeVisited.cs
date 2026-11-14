namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using static Graphify.Visitors.GenerateAsynchronousNavigatorWhenNodeVisited_Resources;
    using ModelMode = Graphify.Model.Modes;

    /// <summary>
    /// Generates an asynchronous navigation method for a graph node.
    /// </summary>
    internal sealed class GenerateAsynchronousNavigatorWhenNodeVisited
        : ISubjectVisitor<Subject.Graph.Nodes.Node, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Nodes.Node instance)
        {
            Subject subject = instance._Root;

            if (subject.Mode == ModelMode.Asynchronous)
            {
                Node node = instance._Value;
                bool isElement = node.Element is object;

                yield return node.ToNavigatorSource(
                    subject,
                    isElement ? GenerateElementBody : GeneratePropertyBody,
                    isElement ? GenerateConcatenationsForElementContent : GenerateConcatenationsForPropertyContent,
                    GenerateConcatenationsForPropertyElement,
                    asynchronous: true);
            }
        }
    }
}