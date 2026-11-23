namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using System.Linq;
    using Graphify.Model;
    using Graphify.Syntax;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;
    using Property = MooVC.Syntax.CSharp.Property;

    /// <summary>
    /// Generates the graph node that represents the subject itself.
    /// </summary>
    internal sealed class GenerateGraphRootWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph instance)
        {
            Subject subject = ((IGraph<Subject>)instance).Root;
            var root = subject.Type.ToSymbol();
            Symbol contract = root.ToGraph();
            string field = "_root";
            int prefixLength = 1;

            while (field == subject.GraphName || subject.Properties.Any(property => property.Name == field))
            {
                prefixLength++;
                field = new string('_', prefixLength) + "root";
            }

            var code = Class.Undefined.Named(subject.GraphName)
                .WithScope(subject.Accessibility.ToScope())
                .WithExtensibility(Modifiers.Sealed)
                .Implements(contract)
                .WithFields(storage => storage.Named(field).OfType(root).WithScope(Scopes.Private).IsReadOnly(true))
                .WithConstructors(constructor => constructor
                    .WithScope(Scopes.Internal)
                    .WithParameters(parameter => parameter.Named(RootPropertyName).OfType(root))
                    .WithBody(Snippet.From($"{field} = root;")))
                .WithProperties(property => property
                    .Named(RootPropertyName)
                    .WithExplicitInterface(contract)
                    .OfType(root)
                    .WithBehaviours(accessors => accessors
                        .WithGet($"{field};")
                        .WithSet(setter => setter.WithMode(Property.Methods.Setter.Modes.ReadOnly))))
                .ToSnippet(Configuration.Options)
                .Block(Configuration.Options, $"{subject.Declaration} {subject.Qualification}");

            yield return new Source(code, $"{subject.Name}.{subject.GraphName}");
        }
    }
}