namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

internal sealed class ChildrenChildName
    : IVisitor<Complex.Graph.Children.Child.Name, string>
{
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Children.Child.Name instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Children.Child.Name: {instance.Value}";
    }
}