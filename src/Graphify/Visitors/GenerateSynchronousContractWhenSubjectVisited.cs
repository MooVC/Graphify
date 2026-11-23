namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;

    /// <summary>
    /// Generates the synchronous contract for the subject.
    /// </summary>
    internal sealed class GenerateSynchronousContractWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;

            if (subject.Mode != Model.Modes.Synchronous || subject.HasContract)
            {
                yield break;
            }

            string name = GetNavigatorContractName(subject.Name);
            var root = subject.Type.ToSymbol();

            Method navigate = "Navigate".ToNavigationMethod(asynchronous: false)
                .Accepts(parameter => parameter.Named("Root").OfType(root));

            var code = Interface.Undefined.Named(name)
                .WithScope(subject.Accessibility.ToScope())
                .WithMethods(navigate)
                .ToSnippet(Configuration.Options);

            yield return new Source(code, name);
        }
    }
}