namespace Graphify.Visitors
{
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Syntax;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;

    /// <summary>
    /// Generates the asynchronous visitor for the subject.
    /// </summary>
    internal sealed class GenerateAsynchronousVisitorWhenSubjectVisited
        : ISubjectVisitor<Subject.Graph.Self, Source>
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Observe(Subject.Graph.Self instance)
        {
            Subject subject = instance._Value;

            if (subject.Mode != Model.Modes.Asynchronous)
            {
                yield break;
            }

            string name = string.Concat(InterfaceNamePrefix, subject.Name, VisitorTypeSuffix);
            var root = subject.Type.ToSymbol();
            Symbol instanceType = (Qualification)"T";
            Symbol result = (Qualification)"TResult";
            Constraint constraint = root.ToGraphConstraint();

            Declaration declaration = ((Declaration)name).WithArguments(
                Generic.Undefined.Named("T").WithVariance(Generic.Variances.In).WithConstraints(constraint),
                Generic.Undefined.Named("TResult").WithVariance(Generic.Variances.Out));

            Method observe = Method.Undefined.Named("Observe")
                .Accepts(parameter => parameter.Named("Instance").OfType(instanceType))
                .Returns(Result.Void.OfType(result.ToSequence(asynchronous: true)));

            observe = observe.Accepts(NavigatorDeclarations.Cancellation);

            var code = Interface.Undefined.Named(declaration)
                .WithScope(subject.Accessibility.ToScope())
                .IsPartial(false)
                .WithMethods(observe)
                .ToSnippet(Configuration.Options);

            yield return new Source(code.GuardAsync(), name);
        }
    }
}