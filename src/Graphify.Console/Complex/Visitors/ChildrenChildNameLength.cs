namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

internal sealed class ChildrenChildNameLength
    : IVisitor<Complex.Graph.Children.Child.Name.Length, string>
{
    public async IAsyncEnumerable<string> Observe(Complex.Graph.Children.Child.Name.Length instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex.Graph.Children.Child.Name.Length: {instance.Value}";
    }
}