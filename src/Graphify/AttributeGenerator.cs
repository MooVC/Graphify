namespace Graphify;

using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

/// <summary>
/// Generates the Graphify attribute, used to denote when a type should serve as a wrapper for a single value.
/// </summary>
[Generator(LanguageNames.CSharp)]
public sealed class AttributeGenerator
    : IIncrementalGenerator
{
    /// <summary>
    /// The source code for the attribute that will be output by the generator.
    /// </summary>
    internal const string Content = $$"""
        namespace Graphify
        {
            using System;
            using System.Diagnostics.CodeAnalysis;

            [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
            internal sealed class {{Name}}Attribute
                : Attribute
            {
            }
        }
        """;

    /// <summary>
    /// The name of the attribute (without the suffix).
    /// </summary>
    internal const string Name = "Graphify";

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(context.ParseOptionsProvider, (context, options) =>
        {
            var text = SourceText.From(Content, Encoding.UTF8);

            context.AddSource($"{Name}Attribute.g.cs", text);
        });
    }
}