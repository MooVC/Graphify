namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides a visitor implementation for processing instances of Complex.Graph.Children and producing string results.
/// </summary>
internal sealed class Children
    : IVisitor<Complex.Graph.Children, string>
{
    /// <summary>
    /// Observes the specified graph children instance and produces a sequence of string values asynchronously.
    /// </summary>
    /// <param name="instance">The graph children instance to observe.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous observation operation.</param>
    /// <returns>An asynchronous sequence of strings representing observed values from the specified instance.</returns>
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Children instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Children: {instance.Value.Length}";
    }
}