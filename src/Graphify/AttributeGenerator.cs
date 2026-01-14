namespace Graphify
{
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;
    using static Graphify.AttributeGenerator_Resources;

    /// <summary>
    /// Generates the Graphify attribute, used to denote when a type should serve as a wrapper for a single value.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class AttributeGenerator
        : IIncrementalGenerator
    {
        /// <summary>
        /// The name of the attribute (without the suffix).
        /// </summary>
        internal const string Name = "Graphify";

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            context.RegisterSourceOutput(context.ParseOptionsProvider, (production, options) =>
            {
                string code = string.Format(Content, Name);
                var text = SourceText.From(code, Encoding.UTF8);

                production.AddSource($"{Name}Attribute.g.cs", text);
            });
        }
    }
}