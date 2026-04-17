namespace Graphify.Strategies
{
    using System.Collections.Generic;
    using Graphify.Model;

    /// <summary>
    /// Provides asynchronous helper extensions used by generated navigator implementations.
    /// </summary>
    internal sealed class AsynchronousNavigatorExtensionsStrategy
        : IStrategy
    {
        /// <inheritdoc/>
        public IEnumerable<Source> Generate(Subject subject)
        {
            if (subject.Mode == Mode.Synchronous)
            {
                yield break;
            }

            string name = $"{ImplementationStrategy.GetName(subject.Name)}Extensions";
            string content = $$"""
                internal static class {{name}}
                {
                    internal static async global::System.Collections.Generic.IAsyncEnumerable<TResult> Concat<TResult>(
                        this global::System.Collections.Generic.IAsyncEnumerable<TResult> first,
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> second,
                        [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken)
                    {
                        if (!global::System.Object.ReferenceEquals(first, null))
                        {
                            var firstResults = global::System.Threading.Tasks.TaskAsyncEnumerableExtensions.WithCancellation(first, cancellationToken);

                            await foreach (var result in firstResults)
                            {
                                yield return result;
                            }
                        }

                        if (!global::System.Object.ReferenceEquals(second, null))
                        {
                            var secondResults = global::System.Threading.Tasks.TaskAsyncEnumerableExtensions.WithCancellation(second, cancellationToken);

                            await foreach (var result in secondResults)
                            {
                                yield return result;
                            }
                        }
                    }
                }
                """;

            yield return new Source(content, name);
        }
    }
}
