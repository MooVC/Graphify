namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Represents a visitor that observes changes or events for an Age instance and produces a stream of string results.
/// </summary>
internal sealed class Age
    : IVisitor<Complex.Graph.Age, string>
{
    /// <summary>
    /// Observes changes or events related to the specified Age instance as an asynchronous stream of strings.
    /// </summary>
    /// <param name="instance">The Age instance to observe for changes or events. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the observation operation.</param>
    /// <returns>An asynchronous stream of strings representing observed changes or events for the specified Age instance.</returns>
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Age instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Age: {instance.Value}";
    }
}