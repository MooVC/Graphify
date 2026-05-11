namespace Graphify
{
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

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
        internal static string Content { get; } = GraphContractGenerator_Resources.Content;

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterSourceOutput(context.CompilationProvider, Generate);
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