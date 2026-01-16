namespace Graphify
{
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    /// <summary>
    /// Generates the Graphify attribute, used to denote when a type should serve as a wrapper for a single value.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class GraphifyAttributeGenerator
        : IIncrementalGenerator
    {
        /// <summary>
        /// The name of the attribute (without the suffix).
        /// </summary>
        internal const string Name = "Graphify";

        /// <summary>
        /// Gets the generated source content as a formatted string.
        /// </summary>
        /// <value>
        /// The generated source content as a formatted string.
        /// </value>
        internal static string Content { get; } = string.Format(GraphifyAttributeGenerator_Resources.Content, Name);

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterSourceOutput(context.ParseOptionsProvider, (production, options) =>
            {
                var text = SourceText.From(Content, Encoding.UTF8);

                production.AddSource($"{Name}Attribute.g.cs", text);
            });
        }
    }
}