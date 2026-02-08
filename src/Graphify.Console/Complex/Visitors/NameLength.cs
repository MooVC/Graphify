namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Provides a visitor that observes and returns the name of the length component in a simple graph name structure.
/// </summary>
internal sealed class NameLength
    : IVisitor<Complex.Graph.Name.Length, string>
{
    /// <summary>
    /// Observes the specified instance and asynchronously yields related string values.
    /// </summary>
    /// <param name="instance">The instance of <see cref="Complex.Graph.Name.Length"/> to observe.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous observation operation.</param>
    /// <returns>An asynchronous stream of strings related to the observed instance.</returns>
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Name.Length instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Name.Length: {instance.Value}";
    }
}