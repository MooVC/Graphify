namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using Microsoft.CodeAnalysis;
    using static Graphify.Names;
    using static Graphify.Strategies.ModelStrategy_Resources;

    /// <summary>
    /// Generates the class that represents a property or sequence element in the graph.
    /// </summary>
    internal sealed class GenerateGraphNodeWhenNodeVisited
        : ISubjectVisitor<Subject.Graph.Nodes.Node, Source>
    {
        private const string NewLine = "\n";

        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Nodes.Node instance)
        {
            Node node = instance._Value;
            Subject subject = instance._Root;
            string body = GenerateParentContent(node, subject, out string assignments, out string parameters);

            string rootContract = string.IsNullOrEmpty(subject.PropertyPrefix)
                ? string.Empty
                : string.Format(GenerateRootContractContent, subject.Type, subject.PropertyPrefix, RootPropertyName);

            string template = node.Element is null
                ? GenerateContentForPropertyContent
                : GenerateContentForElementContent;

            string code = string.Format(
                template,
                node.ParentPath,
                node.Name,
                subject.Type,
                parameters,
                node.Type,
                assignments,
                body,
                node.Property.Declaration,
                subject.PropertyPrefix,
                rootContract,
                RootPropertyName,
                ValuePropertyName,
                IndexPropertyName);

            for (int index = node.Ancestors.Length - 1; index >= 0; index--)
            {
                Predecessor predecessor = node.Ancestors[index];
                code = GenerationSyntax.Block(code, $"{predecessor.Declaration} partial class {predecessor.Name}");
            }

            string accessibility = subject.Accessibility == Accessibility.Internal ? "internal" : "public";

            code = GenerationSyntax.Block(code, $"{accessibility} static partial class {subject.GraphName}");
            code = GenerationSyntax.Block(code, $"{subject.Declaration} {subject.Qualification}");

            string hint = node.Tier == 1
                ? $"{subject.Name}.{node.Name}"
                : $"{subject.Name}.{node.ParentPath}.{node.Name}";

            yield return new Source(code, hint);
        }

        private static string GenerateParentContent(Node node, Subject subject, out string assignments, out string parameters)
        {
            if (node.Tier == 1)
            {
                assignments = string.Empty;
                parameters = string.Empty;

                return string.Empty;
            }

            Predecessor predecessor = node.Ancestors[node.Ancestors.Length - 1];

            string parameterName = string.IsNullOrEmpty(subject.PropertyPrefix)
                ? predecessor.Name.ToCamelCase()
                : CollisionSafeParentParameterName;

            string type = $"{subject.GraphQualification}.{node.ParentPath}";

            assignments = string.Concat(NewLine, string.Format(GeneratePropertyContentAssignment, predecessor.Name, parameterName), NewLine);
            parameters = string.Format(GeneratePropertyContentArgument, type, parameterName);

            return string.Concat(NewLine, string.Format(GeneratePropertyContentDeclaration, type, predecessor.Name, predecessor.Declaration), NewLine);
        }
    }
}