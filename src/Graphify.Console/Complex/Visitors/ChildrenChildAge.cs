namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

internal sealed class ChildrenChildAge
    : IVisitor<Complex.Graph.Children.Child.Age, string>
{
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Children.Child.Age instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Children.Child.Age: {instance.Value}";
    }
}