namespace Graphify.Model;

using System.Collections.Immutable;
using Valuify;

/// <summary>
/// The definition of the <see cref="Subject"/> type, which is used to capture information relating to a subject
/// upon which the Graphify attribute has been placed.
/// </summary>
[Valuify]
internal sealed partial class Subject
{
    /// <summary>
    /// Gets a value indicating whether or not the subject implements <see cref="ICloneable.Clone"/>.
    /// </summary>
    /// <value>
    /// A value indicating whether or not the subject implements <see cref="ICloneable.Clone"/>.
    /// </value>
    public bool HasClonable { get; set; }

    /// <summary>
    /// Gets a value indicating whether or not the subject declares that it implements <see cref="ICloneable"/>.
    /// </summary>
    /// <value>
    /// A value indicating whether or not the subject declares that it implements <see cref="ICloneable"/>.
    /// </value>
    public bool IsClonable { get; set; }

    /// <summary>
    /// Gets a value indicating whether or not the subject belongs to the global namespace.
    /// </summary>
    /// <value>
    /// A value indicating whether or not the subject belongs to the global namespace.
    /// </value>
    public bool IsGlobal => string.IsNullOrEmpty(Namespace);

    /// <summary>
    /// Gets or sets the name of the subject.
    /// </summary>
    /// <value>
    /// The name of the subject.
    /// </value>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the globally qualified namespace for the subject.
    /// </summary>
    /// <value>
    /// The globally qualified namespace for the subject.
    /// </value>
    public string Namespace { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the declarations associated with the parent types in order of declaration.
    /// </summary>
    /// <value>
    /// The declarations associated with the parent types in order of declaration.
    /// </value>
    public ImmutableArray<Nesting> Nesting { get; set; } = ImmutableArray<Nesting>.Empty;

    /// <summary>
    /// Gets or sets the qualified name of the subject, which includes any generic arguments.
    /// </summary>
    /// <value>
    /// The qualified name of the subject, which includes any generic arguments.
    /// </value>
    public string Qualification { get; set; } = string.Empty;
}