namespace Graphify;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.Extensions.DependencyInjection;

public sealed class GeneratorTest<TGenerator>
    : CSharpSourceGeneratorTest<TGenerator, DefaultVerifier>
    where TGenerator : new()
{
    private readonly Type[] _generators;
    private readonly LanguageVersion _language;

    public GeneratorTest(ReferenceAssemblies assembly, LanguageVersion language, params Type[] generators)
    {
        _generators = generators.Length == 0
            ? [typeof(TGenerator)]
            : generators;

        _language = language;
        ReferenceAssemblies = assembly;
        TestState.AdditionalReferences.Add(typeof(IServiceCollection).Assembly);
    }

    protected sealed override ParseOptions CreateParseOptions()
    {
        return new CSharpParseOptions(_language);
    }

    protected sealed override IEnumerable<Type> GetSourceGenerators()
    {
        return _generators;
    }
}