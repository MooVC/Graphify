namespace Graphify.Model
{
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Valuify;

    /// <summary>
    /// The definition of the <see cref="Subject"/> type, which is used to capture information relating to a subject
    /// upon which the Graphify attribute has been placed.
    /// </summary>
    [Valuify]
    internal sealed partial class Subject
    {
        /// <summary>
        /// Gets or sets the accessibility level of the type.
        /// </summary>
        /// <value>
        /// The accessibility level of the type.
        /// </value>
        public Accessibility Accessibility { get; set; }

        /// <summary>
        /// Gets or sets the kind associated with the type, be it a class, record etc.
        /// </summary>
        /// <value>
        /// The kind associated with the type, be it a class, record etc.
        /// </value>
        public string Declaration { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether a contract is associated with the current entity.
        /// </summary>
        /// <value>
        /// A value indicating whether a contract is associated with the current entity.
        /// </value>
        public bool HasContract { get; set; }

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
        /// Gets or sets the collection of properties associated with the current instance.
        /// </summary>
        /// <value>
        /// The collection of properties associated with the current instance.
        /// </value>
        public ImmutableArray<Property> Properties { get; set; } = ImmutableArray<Property>.Empty;

        /// <summary>
        /// Gets or sets the qualified name of the subject, which includes any generic arguments.
        /// </summary>
        /// <value>
        /// The qualified name of the subject, which includes any generic arguments.
        /// </value>
        public string Qualification { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the fully qualified name of the property type.
        /// </summary>
        /// <value>
        /// The fully qualified name of the property type.
        /// </value>
        public string Type { get; set; } = string.Empty;
    }
}