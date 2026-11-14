namespace Graphify
{
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;

    /// <summary>
    /// Generates the graph contract.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class GraphContractGenerator
        : IIncrementalGenerator
    {
        /// <summary>
        /// The hint name used for the generated graph contract.
        /// </summary>
        internal const string Hint = "Graph.g.cs";

        private const string GraphMetadataName = "Graphify.IGraph`1";

        /// <summary>
        /// Gets the generated graph contract content.
        /// </summary>
        internal static string Content { get; } = CreateContent();

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterSourceOutput(context.CompilationProvider, Generate);
        }

        private static string CreateContent()
        {
            Declaration name = ((Declaration)"IGraph").WithArguments(
                Generic.Undefined.Named("T")
                    .WithVariance(Generic.Variances.Out)
                    .WithConstraints(Constraint.Unspecified.WithNature(Natures.Class)));

            return Definition.Undefined.From("Graphify")
                .For<Interface>(contract => contract
                    .Named(name)
                    .IsPartial(false)
                    .WithProperties(property => property
                        .Named(RootPropertyName)
                        .OfType((Qualification)"T")
                        .WithBehaviours(accessors => accessors.WithSet(setter => setter.WithMode(Property.Methods.Setter.Modes.ReadOnly)))))
                .ToSnippet(Configuration.Options)
                .ToString();
        }

        private static void Generate(SourceProductionContext context, Compilation compilation)
        {
            if (compilation.GetTypeByMetadataName(GraphMetadataName) is null)
            {
                var text = SourceText.From(Content, Encoding.UTF8);
                context.AddSource(Hint, text);
            }
        }
    }
}