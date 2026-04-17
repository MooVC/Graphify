namespace Graphify.Strategies
{
    using System;
    using System.Collections.Generic;
    using Graphify.Model;
    using static Graphify.Strategies.ImplementationStrategy_Resources;

    /// <summary>
    /// Provides a synchronous strategy for generating navigator implementations.
    /// </summary>
    internal sealed class SynchronousNavigatorStrategy
        : IStrategy
    {
        private static readonly AsynchronousNavigatorStrategy _asynchronous = new AsynchronousNavigatorStrategy();

        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.Mode != Modes.Synchronous)
            {
                yield break;
            }

            foreach (Source source in _asynchronous.GenerateCore(subject))
            {
                string code = source.Code
                    .Replace("global::System.Collections.Generic.IAsyncEnumerable", "global::System.Collections.Generic.IEnumerable", StringComparison.Ordinal)
                    .Replace("global::Graphify.IVisitor", "global::Graphify.IInspector", StringComparison.Ordinal)
                    .Replace("Observe(instance, cancellationToken)", "Observe(instance)", StringComparison.Ordinal)
                    .Replace(", global::System.Threading.CancellationToken cancellationToken", string.Empty, StringComparison.Ordinal)
                    .Replace(", cancellationToken", string.Empty, StringComparison.Ordinal)
                    .Replace("Empty<TResult>()", "global::System.Linq.Enumerable.Empty<TResult>()", StringComparison.Ordinal)
                    .Replace("Concat(results, ", "global::System.Linq.Enumerable.Concat(results, ", StringComparison.Ordinal)
                    .Replace("global::Graphify.NavigatorExtensions.Concat", "global::System.Linq.Enumerable.Concat", StringComparison.Ordinal);

                yield return new Source(code, source.Hint);
            }
        }
    }
}
