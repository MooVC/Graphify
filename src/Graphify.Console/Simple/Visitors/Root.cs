namespace Graphify.Console.Simple.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Visits the simple root graph node.
/// </summary>
internal sealed class Root
    : IVisitor<Simple, string>
{
    /// <summary>
    /// Observes the simple root instance and yields a formatted message.
    /// </summary>
    /// <param name="instance">The graph node instance to observe.</param>
    /// <param name="cancellationToken">The cancellation token for the observation.</param>
    /// <returns>The formatted observation messages.</returns>
    public async IAsyncEnumerable<string> Observe(Simple instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Simple: {instance.Name}";
    }
}