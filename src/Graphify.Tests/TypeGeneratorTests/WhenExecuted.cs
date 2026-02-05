namespace Graphify.TypeGeneratorTests;

using System.Collections.Immutable;
using System.IO;
using Graphify.Snippets;
using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Testing;

public sealed class WhenExecuted
{
    private const string ConflictingServiceCollectionContract =
        """
        namespace Microsoft.Extensions.DependencyInjection
        {
            public interface IServiceCollection
            {
            }
        }
        """;

    private static readonly Generated[] _simpleWithoutRegistration =
    [
        Simple.Expected.Contract,
        Simple.Expected.Navigator,
        Simple.Expected.NavigatorAge,
        Simple.Expected.NavigatorIsAdult,
        Simple.Expected.NavigatorName,
        Simple.Expected.NavigatorNameLength,
        Simple.Expected.Age,
        Simple.Expected.IsAdult,
        Simple.Expected.Name,
        Simple.Expected.NameLength,
    ];

    private static readonly Type[] _generators =
    [
        typeof(GraphifyAttributeGenerator),
        typeof(NavigatorContractGenerator),
        typeof(NavigatorGenerator),
        typeof(TraverseAttributeGenerator),
        typeof(TypeGenerator),
        typeof(VisitorContractGenerator),
    ];

    [Theory]
    [Snippets(exclusions: [typeof(Unannotated)])]
    public async Task GivenAClassTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, Expectations expectations, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<TypeGenerator>(assembly, language, _generators);

        Boilerplate.Graphify.IsExpectedIn(test.TestState);
        Boilerplate.Navigator.IsExpectedIn(test.TestState);
        Boilerplate.Base.IsExpectedIn(test.TestState);
        Boilerplate.Traverse.IsExpectedIn(test.TestState);
        expectations.IsDeclaredIn(test.TestState);
        Boilerplate.Visitor.IsExpectedIn(test.TestState);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    [Theory]
    [Frameworks]
    public async Task GivenAConflictingServiceCollectionContractInAReferencedAssemblyThenTheExpectedSourceIsGenerated(ReferenceAssemblies assembly, LanguageVersion language)
    {
        // Arrange
        var test = new GeneratorTest<TypeGenerator>(assembly, language, includeDependencyInjection: false, _generators);

        Boilerplate.Graphify.IsExpectedIn(test.TestState);
        Boilerplate.Navigator.IsExpectedIn(test.TestState);
        Boilerplate.Base.IsExpectedIn(test.TestState);
        Boilerplate.Traverse.IsExpectedIn(test.TestState);

        string declaration = Simple.Declarations.Main.Body.Replace(Snippets.BodyTag, Simple.Declarations.CSharp6Body.Body);
        var expectations = new Expectations(declaration, _simpleWithoutRegistration, LanguageVersion.CSharp8);
        expectations.IsDeclaredIn(test.TestState);

        Boilerplate.Visitor.IsExpectedIn(test.TestState);

        MetadataReference conflictingReference = CreateReference(ConflictingServiceCollectionContract, language, "Graphify");
        test.TestState.AdditionalReferences.Add(conflictingReference);

        // Act
        Func<Task> act = () => test.RunAsync();

        // Assert
        await act.ShouldNotThrowAsync();
    }

    private static MetadataReference CreateReference(string source, LanguageVersion language, string assemblyName)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(language));
        var compilation = CSharpCompilation.Create(
            assemblyName: assemblyName,
            syntaxTrees: [syntaxTree],
            references: [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)],
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var stream = new MemoryStream();

        EmitResult result = compilation.Emit(stream);
        result.Success.ShouldBeTrue();

        _ = stream.Seek(offset: 0, loc: SeekOrigin.Begin);

        return MetadataReference.CreateFromImage(ImmutableArray.Create(stream.ToArray()));
    }
}