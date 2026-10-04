namespace Graphify
{
    /// <summary>
    /// Defines the fixed names used when generating graph members and related types.
    /// </summary>
    internal static class GeneratedNames
    {
        /// <summary>
        /// The node variable name used to avoid collisions with model member names.
        /// </summary>
        internal const string CollisionSafeNodeVariableName = "graph";

        /// <summary>
        /// The parent parameter name used to avoid collisions with traversal parameter names.
        /// </summary>
        internal const string CollisionSafeParentParameterName = "parent";

        /// <summary>
        /// The namespace qualifier preceding a nested graph node's name.
        /// </summary>
        internal const string GraphNamespaceQualifier = GraphNamespaceSegment + ".";

        /// <summary>
        /// The namespace segment used to enter the generated graph type.
        /// </summary>
        internal const string GraphNamespaceSegment = "." + GraphTypeName;

        /// <summary>
        /// The name of the type containing generated graph nodes.
        /// </summary>
        internal const string GraphTypeName = "Graph";

        /// <summary>
        /// The name of the property containing a collection element's position.
        /// </summary>
        internal const string IndexPropertyName = "Index";

        /// <summary>
        /// The prefix used for generated interface names.
        /// </summary>
        internal const string InterfaceNamePrefix = "I";

        /// <summary>
        /// The suffix used for generated navigator type names.
        /// </summary>
        internal const string NavigatorTypeSuffix = "Navigator";

        /// <summary>
        /// The suffix distinguishing parent references from graph metadata properties.
        /// </summary>
        internal const string ParentReferenceSuffix = "Parent";

        /// <summary>
        /// The name of the class containing navigator registration methods.
        /// </summary>
        internal const string RegistrationClassName = "ServiceCollectionExtensions";

        /// <summary>
        /// The prefix used for navigator registration method names.
        /// </summary>
        internal const string RegistrationMethodPrefix = "Add";

        /// <summary>
        /// The name of the property referencing the original annotated instance.
        /// </summary>
        internal const string RootPropertyName = "Root";

        /// <summary>
        /// The name of the property containing the value represented by a graph node.
        /// </summary>
        internal const string ValuePropertyName = "Value";

        /// <summary>
        /// The suffix used for generated visitor interface names.
        /// </summary>
        internal const string VisitorTypeSuffix = "Visitor";
    }
}