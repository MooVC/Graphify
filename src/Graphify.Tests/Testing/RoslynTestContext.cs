namespace Graphify.Testing;

using System.Collections.Immutable;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

internal sealed class RoslynTestContext
{
    private RoslynTestContext(CSharpCompilation compilation, SyntaxTree tree)
    {
        Compilation = compilation;
        Tree = tree;
        Model = compilation.GetSemanticModel(tree);
    }

    public CSharpCompilation Compilation { get; }

    public SemanticModel Model { get; }

    public SyntaxTree Tree { get; }

    public static RoslynTestContext Create(string source, params Assembly[] additionalAssemblies)
    {
        SyntaxTree tree = CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.CSharp14));
        List<MetadataReference> references =
        [
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Attribute).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
        ];

        references.AddRange(additionalAssemblies.Select(assembly => MetadataReference.CreateFromFile(assembly.Location)));

        var compilation = CSharpCompilation.Create(
            assemblyName: "Graphify.Tests.Dynamic",
            syntaxTrees: [tree],
            references: references.DistinctBy(reference => reference.Display).ToImmutableArray(),
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        return new RoslynTestContext(compilation, tree);
    }

    public INamedTypeSymbol GetTypeByMetadataName(string metadataName)
    {
        return Compilation.GetTypeByMetadataName(metadataName)
            ?? throw new InvalidOperationException($"Type '{metadataName}' was not found.");
    }
}