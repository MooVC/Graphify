namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Visits the complex child name graph node.
/// </summary>
internal sealed class ChildrenChildName
    : IVisitor<Complex.Graph.Children.Child.Name, string>
{
    /// <summary>
    /// Observes a child name value and yields a formatted message.
    /// </summary>
    /// <param name="instance">The graph node instance to observe.</param>
    /// <param name="cancellationToken">The cancellation token for the observation.</param>
    /// <returns>The formatted observation messages.</returns>
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Children.Child.Name instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Children.Child.Name: {instance.Value}";
    }
}