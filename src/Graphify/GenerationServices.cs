namespace Graphify
{
    using System;
    using System.Collections.Generic;
    using Graphify.Model;
    using Graphify.Visitors;

    /// <summary>
    /// Provides the source generation visitors to the model navigator.
    /// </summary>
    internal sealed class GenerationServices
        : IServiceProvider
    {
        private static readonly IReadOnlyDictionary<Type, object> _visitors = CreateVisitors();

        /// <inheritdoc/>
        public object GetService(Type serviceType)
        {
            _ = _visitors.TryGetValue(serviceType, out object visitors);
            return visitors;
        }

        private static IReadOnlyDictionary<Type, object> CreateVisitors()
        {
            var visitors = new Dictionary<Type, object>();

            Register<Subject.Graph>(
                visitors,
                new GenerateAsynchronousContractWhenSubjectVisited(),
                new GenerateAsynchronousNavigatorWhenSubjectVisited(),
                new GenerateAsynchronousRegistrationWhenSubjectVisited(),
                new GenerateAsynchronousVisitorWhenSubjectVisited(),
                new GenerateGraphRootWhenSubjectVisited(),
                new GenerateSynchronousContractWhenSubjectVisited(),
                new GenerateSynchronousNavigatorWhenSubjectVisited(),
                new GenerateSynchronousRegistrationWhenSubjectVisited(),
                new GenerateSynchronousVisitorWhenSubjectVisited());
            Register<Subject.Graph.Nodes.Node>(
                visitors,
                new GenerateAsynchronousNavigatorWhenNodeVisited(),
                new GenerateGraphNodeWhenNodeVisited(),
                new GenerateSynchronousNavigatorWhenNodeVisited());

            return visitors;
        }

        private static void Register<TNode>(Dictionary<Type, object> services, params ISubjectVisitor<TNode, Source>[] visitors)
            where TNode : class, IGraph<Subject>
        {
            services.Add(typeof(IEnumerable<ISubjectVisitor<TNode, Source>>), visitors);
        }
    }
}