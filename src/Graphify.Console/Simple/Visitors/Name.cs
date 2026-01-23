namespace Graphify.Console.Simple.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Represents a visitor that operates on <see cref="Simple.Graph.Name"/> instances and produces string results.
/// </summary>
internal sealed class Name
    : IVisitor<Simple.Graph.Name, string>
{
    /// <summary>
    /// Asynchronously observes changes related to the specified graph name and yields updates as they occur.
    /// </summary>
    /// <param name="instance">The graph name instance to observe for changes. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the observation operation.</param>
    /// <returns>An asynchronous stream of strings representing updates related to the specified graph name. The stream completes
    /// when observation ends or is canceled.</returns>
    public async IAsyncEnumerable<string> Observe(Simple.Graph.Name instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Simple.Graph.Name: {instance.Value}";
    }
}