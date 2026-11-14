namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;

    /// <summary>
    /// Generates the asynchronous contract for the subject.
    /// </summary>
    internal sealed class GenerateAsynchronousContractWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode != Model.Modes.Asynchronous || subject.HasContract)
            {
                yield break;
            }

            string name = GetNavigatorContractName(subject.Name);
            var root = subject.Type.ToSymbol();

            Method navigate = "Navigate".ToNavigationMethod(asynchronous: true)
                .Accepts(parameter => parameter.Named("Root").OfType(root));

            navigate = navigate.Accepts(NavigatorDeclarations.Cancellation);

            Snippet code = Interface.Undefined.Named(name)
                .WithScope(subject.Accessibility.ToScope())
                .WithMethods(navigate)
                .ToSnippet(Configuration.Options);

            yield return new Source(code.GuardAsync(), name);
        }
    }
}