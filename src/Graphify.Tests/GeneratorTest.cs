namespace Graphify;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;

public sealed class GeneratorTest<TGenerator>
    : CSharpSourceGeneratorTest<TGenerator, DefaultVerifier>
    where TGenerator : new()
{
    private readonly Type[] _generators;
    private readonly LanguageVersion _language;

    public GeneratorTest(ReferenceAssemblies assembly, LanguageVersion language, bool includeDependencyInjection, params Type[] generators)
    {
        _generators = generators.Length == 0
            ? [typeof(TGenerator)]
            : generators;

        _language = language;
        ReferenceAssemblies = assembly;

        if (includeDependencyInjection)
        {
            SolutionTransforms.Add(AddDependencyInjectionReference);
        }
    }

    public GeneratorTest(ReferenceAssemblies assembly, LanguageVersion language, params Type[] generators)
        : this(assembly, language, includeDependencyInjection: true, generators)
    {
    }

    protected sealed override ParseOptions CreateParseOptions()
    {
        return new CSharpParseOptions(_language);
    }

    protected sealed override IEnumerable<Type> GetSourceGenerators()
    {
        return _generators;
    }

    private static Solution AddDependencyInjectionReference(Solution solution, ProjectId projectId)
    {
        const string FileName = "Microsoft.Extensions.DependencyInjection.Abstractions.dll";
        Project project = solution.GetProject(projectId)!;

        if (project.MetadataReferences.OfType<PortableExecutableReference>().Any(reference =>
            string.Equals(Path.GetFileName(reference.FilePath), FileName, StringComparison.OrdinalIgnoreCase)))
        {
            return solution;
        }

        string path = Path.Combine(AppContext.BaseDirectory, "ReferenceAssemblies", FileName);

        return solution.AddMetadataReference(projectId, MetadataReference.CreateFromFile(path));
    }
}