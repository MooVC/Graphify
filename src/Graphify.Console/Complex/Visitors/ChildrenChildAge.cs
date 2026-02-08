namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Visits the complex child age graph node.
/// </summary>
internal sealed class ChildrenChildAge
    : IVisitor<Complex.Graph.Children.Child.Age, string>
{
    /// <summary>
    /// Observes a child age value and yields a formatted message.
    /// </summary>
    /// <param name="instance">The graph node instance to observe.</param>
    /// <param name="cancellationToken">The cancellation token for the observation.</param>
    /// <returns>The formatted observation messages.</returns>
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Children.Child.Age instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Children.Child.Age: {instance.Value}";
    }
}