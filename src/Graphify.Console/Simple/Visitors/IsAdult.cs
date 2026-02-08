namespace Graphify.Console.Simple.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Provides a visitor that observes instances of the Simple.Graph.IsAdult type and yields their type name as a string.
/// </summary>
internal sealed class IsAdult
    : IVisitor<Simple.Graph.IsAdult, string>
{
    /// <summary>
    /// Observes the specified IsAdult instance and returns a sequence of related string identifiers.
    /// </summary>
    /// <param name="instance">The IsAdult instance to observe. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous observation operation.</param>
    /// <returns>An asynchronous sequence of strings representing identifiers related to the observed IsAdult instance.</returns>
    public async IAsyncEnumerable<string> Observe(Simple.Graph.IsAdult instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Simple.Graph.IsAdult: {instance.Value}";
    }
}