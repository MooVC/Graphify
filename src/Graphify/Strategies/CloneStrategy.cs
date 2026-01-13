namespace Graphify.Strategies;

using Graphify.Model;

/// <summary>
/// Generates the source needed to support <see cref="object.ToString()"/>.
/// </summary>
internal sealed class CloneStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        throw new NotImplementedException();
    }
}