namespace Graphify.Console.Complex.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

internal sealed class Root
    : IVisitor<Complex, string>
{
    public async IAsyncEnumerable<string> Observe(Complex instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Complex: {instance.Name}";
    }
}