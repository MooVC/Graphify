namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Visits the complex root graph node.
/// </summary>
internal sealed class Root
    : IVisitor<Complex, string>
{
    /// <summary>
    /// Observes the complex root instance and yields a formatted message.
    /// </summary>
    /// <param name="instance">The graph node instance to observe.</param>
    /// <param name="cancellationToken">The cancellation token for the observation.</param>
    /// <returns>The formatted observation messages.</returns>
    public async IAsyncEnumerable<string> Observe(Complex instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex: {instance.Name}";
    }
}