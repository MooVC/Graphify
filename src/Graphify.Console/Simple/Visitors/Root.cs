namespace Graphify.Console.Simple.Visitors;

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

internal sealed class Root
    : IVisitor<Simple, string>
{
    public async IAsyncEnumerable<string> Observe(Simple instance, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        yield return $"Simple: {instance.Name}";
    }
}