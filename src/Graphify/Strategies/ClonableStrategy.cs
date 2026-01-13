namespace Graphify.Strategies;

using Graphify.Model;

/// <summary>
/// Generates the source needed to ensure the type implements <see cref="ICloneable"/>.
/// </summary>
internal sealed class ClonableStrategy
    : IStrategy
{
    /// <inheritdoc/>
    public IEnumerable<Source> Generate(Subject subject)
    {
        throw new NotImplementedException();
    }
}