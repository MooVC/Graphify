namespace Graphify.Model
{
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Valuify;
    using static Graphify.Names;

    /// <summary>
    /// The definition of the <see cref="Subject"/> type, which is used to capture information relating to a subject
    /// upon which the Graphify attribute has been placed.
    /// </summary>
    [Graphify(Depth = 2, Mode = global::Graphify.Modes.Synchronous, PropertyPrefix = "_")]
    [Valuify]
    internal sealed partial class Subject
    {
        /// <summary>
        /// Gets or sets the accessibility level of the type.
        /// </summary>
        /// <value>
        /// The accessibility level of the type.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public Accessibility Accessibility { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether registration is possible, meaning the required libraries are referenced.
        /// </summary>
        /// <value>
        /// A value indicating whether registration is possible, meaning the required libraries are referenced.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public bool CanRegister { get; set; }

        /// <summary>
        /// Gets or sets the kind associated with the type, be it a class, record etc.
        /// </summary>
        /// <value>
        /// The kind associated with the type, be it a class, record etc.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string Declaration { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the maximum depth to which graph generation should proceed.
        /// </summary>
        /// <value>
        /// The maximum depth to which graph generation should proceed.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public byte Depth { get; set; }

        /// <summary>
        /// Gets or sets the name of the type containing generated graph nodes.
        /// </summary>
        /// <value>
        /// The name of the type containing generated graph nodes.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string GraphName { get; set; } = DefaultGraphTypeName;

        /// <summary>
        /// Gets the qualified name of the type containing generated graph nodes.
        /// </summary>
        /// <value>
        /// The qualified name of the type containing generated graph nodes.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string GraphQualification => string.Concat(Type, ".", GraphName);

        /// <summary>
        /// Gets or sets a value indicating whether a contract is associated with the current entity.
        /// </summary>
        /// <value>
        /// A value indicating whether a contract is associated with the current entity.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public bool HasContract { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a registration extension exists for the current instance.
        /// </summary>
        /// <value>
        /// A value indicating whether a registration extension exists for the current instance.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public bool HasRegistration { get; set; }

        /// <summary>
        /// Gets or sets the configured generation mode.
        /// </summary>
        /// <value>
        /// The configured generation mode.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public Modes Mode { get; set; } = Modes.Asynchronous;

        /// <summary>
        /// Gets a value indicating whether or not the subject belongs to the global namespace.
        /// </summary>
        /// <value>
        /// A value indicating whether or not the subject belongs to the global namespace.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public bool IsGlobal => string.IsNullOrEmpty(Namespace);

        /// <summary>
        /// Gets or sets the name of the subject.
        /// </summary>
        /// <value>
        /// The name of the subject.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the globally qualified namespace for the subject.
        /// </summary>
        /// <value>
        /// The globally qualified namespace for the subject.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string Namespace { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the declarations associated with the parent types in order of declaration.
        /// </summary>
        /// <value>
        /// The declarations associated with the parent types in order of declaration.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public ImmutableArray<Nesting> Nesting { get; set; } = ImmutableArray<Nesting>.Empty;

        /// <summary>
        /// Gets the graph nodes in traversal order.
        /// </summary>
        [Traverse(Scope = global::Graphify.TraverseScope.Property)]
        [Valuify.Ignore]
        public ImmutableArray<Node> Nodes => Node.Create(Properties, Depth);

        /// <summary>
        /// Gets or sets the collection of properties associated with the current instance.
        /// </summary>
        /// <value>
        /// The collection of properties associated with the current instance.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public ImmutableArray<Property> Properties { get; set; } = ImmutableArray<Property>.Empty;

        /// <summary>
        /// Gets or sets the prefix applied to fixed graph properties.
        /// </summary>
        /// <value>
        /// The prefix applied to fixed graph properties.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string PropertyPrefix { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the qualified name of the subject, which includes any generic arguments.
        /// </summary>
        /// <value>
        /// The qualified name of the subject, which includes any generic arguments.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string Qualification { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the fully qualified name of the property type.
        /// </summary>
        /// <value>
        /// The fully qualified name of the property type.
        /// </value>
        [Traverse(Scope = global::Graphify.TraverseScope.None)]
        public string Type { get; set; } = string.Empty;

        public string Qualify(string name)
        {
            return IsGlobal ? $"global::{name}" : $"global::{Namespace}.{name}";
        }
    }
}