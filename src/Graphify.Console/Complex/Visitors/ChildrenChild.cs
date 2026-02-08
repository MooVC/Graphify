namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// Provides a visitor implementation for processing <see cref="Complex.Graph.Children.Child"/> instances and producing
/// string results.
/// </summary>
internal sealed class ChildrenChild
    : IVisitor<Complex.Graph.Children.Child, string>
{
    /// <summary>
    /// Observes the specified child instance and produces a sequence of string values representing observation results.
    /// </summary>
    /// <param name="instance">The child instance to observe. Cannot be null.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the observation operation.</param>
    /// <returns>An asynchronous sequence of strings containing observation results for the specified child instance.</returns>
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Children.Child instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Children.Child: {instance.Value.Name}";
    }
}