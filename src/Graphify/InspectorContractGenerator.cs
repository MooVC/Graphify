namespace Graphify
{
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    /// <summary>
    /// Generates the inspector contract.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class InspectorContractGenerator
        : IIncrementalGenerator
    {
        internal const string Hint = "Inspector.g.cs";
        internal const string Name = "Inspector";

        private const string InspectorMetadataName = "Graphify.IInspector`2";

        internal static string Content { get; } = string.Format(InspectorContractGenerator_Resources.Content, Name);

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterSourceOutput(context.CompilationProvider, Generate);
        }

        private static void Generate(SourceProductionContext context, Compilation compilation)
        {
            if (compilation.GetTypeByMetadataName(InspectorMetadataName) is null)
            {
                var text = SourceText.From(Content, Encoding.UTF8);

                context.AddSource(Hint, text);
            }
        }
    }
}