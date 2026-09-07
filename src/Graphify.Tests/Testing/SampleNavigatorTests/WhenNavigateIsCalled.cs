namespace Graphify.Testing.SampleNavigatorTests;

using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenNavigateIsCalled
{
    private const int FirstAge = 10;
    private const int SecondAge = 20;

    [Theory]
    [InlineData(false, false)]
    [InlineData(false, true)]
    [InlineData(true, false)]
    [InlineData(true, true)]
    public async Task GivenNoVisitorsThenResultsAreEmpty(bool asynchronous, bool emptyVisitors)
    {
        // Arrange
        Func<bool, bool, bool, Task<int[]>> navigate = CreateNavigation(asynchronous);

        // Act
        int[] results = await navigate(emptyVisitors, false, false);

        // Assert
        results.ShouldBeEmpty();
    }

    [Theory]
    [InlineData(false, false)]
    [InlineData(false, true)]
    [InlineData(true, false)]
    [InlineData(true, true)]
    public async Task GivenPropertyVisitorsThenDescendantsAreVisitedInOrder(bool asynchronous, bool elementVisitors)
    {
        // Arrange
        const int firstIndex = 0;
        const int secondIndex = 1;
        Func<bool, bool, bool, Task<int[]>> navigate = CreateNavigation(asynchronous);
        int[] expected = elementVisitors
            ? [firstIndex, FirstAge + firstIndex, secondIndex, SecondAge + secondIndex]
            : [FirstAge + firstIndex, SecondAge + secondIndex];

        // Act
        int[] results = await navigate(false, elementVisitors, true);

        // Assert
        results.ShouldBe(expected);
    }

    private static Func<bool, bool, bool, Task<int[]>> CreateNavigation(bool asynchronous)
    {
        string mode = asynchronous ? "Asynchronous" : "Synchronous";
        string returnType = asynchronous ? "IAsyncEnumerable<int>" : "IEnumerable<int>";
        string parameters = asynchronous ? ", CancellationToken cancellationToken" : string.Empty;
        string navigate = asynchronous
            ? "navigator.Navigate<int>(root, CancellationToken.None)"
            : "navigator.Navigate<int>(root)";
        string iteration = asynchronous ? "await foreach" : "foreach";
        string source = $$"""
            namespace Graphify.Testing
            {
                using System;
                using System.Collections.Generic;
                using System.Threading;
                using System.Threading.Tasks;

                [Graphify(Mode = Modes.{{mode}})]
                public sealed partial class Sample
                {
                    public Child[] Children { get; set; }
                }

                public sealed class Child
                {
                    public int Age { get; set; }
                }

                public sealed class ElementVisitor : ISampleVisitor<Sample.Graph.Children.Child, int>
                {
                    public {{returnType}} Observe(Sample.Graph.Children.Child instance{{parameters}})
                    {
                        return Results(instance.Index);
                    }

                    private static {{(asynchronous ? "async " : string.Empty)}}{{returnType}} Results(int value)
                    {
                        {{(asynchronous ? "await Task.CompletedTask;" : string.Empty)}}
                        yield return value;
                    }
                }

                public sealed class PropertyVisitor : ISampleVisitor<Sample.Graph.Children.Child.Age, int>
                {
                    public {{returnType}} Observe(Sample.Graph.Children.Child.Age instance{{parameters}})
                    {
                        return Results(instance.Value + instance.Child.Index);
                    }

                    private static {{(asynchronous ? "async " : string.Empty)}}{{returnType}} Results(int value)
                    {
                        {{(asynchronous ? "await Task.CompletedTask;" : string.Empty)}}
                        yield return value;
                    }
                }

                public sealed class Provider : IServiceProvider
                {
                    public bool EmptyVisitors { get; set; }

                    public bool ElementVisitors { get; set; }

                    public bool PropertyVisitors { get; set; }

                    public object GetService(Type serviceType)
                    {
                        if (ElementVisitors && serviceType == typeof(IEnumerable<ISampleVisitor<Sample.Graph.Children.Child, int>>))
                        {
                            return new ISampleVisitor<Sample.Graph.Children.Child, int>[] { new ElementVisitor() };
                        }

                        if (PropertyVisitors && serviceType == typeof(IEnumerable<ISampleVisitor<Sample.Graph.Children.Child.Age, int>>))
                        {
                            return new ISampleVisitor<Sample.Graph.Children.Child.Age, int>[] { new PropertyVisitor() };
                        }

                        return EmptyVisitors ? Array.CreateInstance(serviceType.GenericTypeArguments[0], 0) : null;
                    }
                }

                public static class Probe
                {
                    public static async Task<int[]> Navigate(bool emptyVisitors, bool elementVisitors, bool propertyVisitors)
                    {
                        var provider = new Provider
                        {
                            EmptyVisitors = emptyVisitors,
                            ElementVisitors = elementVisitors,
                            PropertyVisitors = propertyVisitors,
                        };
                        var navigator = new SampleNavigator(provider);
                        var root = new Sample
                        {
                            Children = new Child[] { new Child { Age = {{FirstAge}} }, new Child { Age = {{SecondAge}} } },
                        };
                        var results = new List<int>();

                        {{iteration}} (int result in {{navigate}})
                        {
                            results.Add(result);
                        }

                        await Task.CompletedTask;
                        return results.ToArray();
                    }
                }
            }
            """;

        var options = new CSharpParseOptions(LanguageVersion.CSharp14, preprocessorSymbols: ["NET5_0_OR_GREATER"]);
        string[] assemblyPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator);

        IEnumerable<PortableExecutableReference> references = assemblyPaths
            .Append(typeof(IServiceCollection).Assembly.Location)
            .Distinct()
            .Select(path => MetadataReference.CreateFromFile(path));

        var compilation = CSharpCompilation.Create(
            $"Graphify.Tests.Navigation.{Guid.NewGuid():N}",
            [CSharpSyntaxTree.ParseText(source, options)],
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        GeneratorDriver driver = CSharpGeneratorDriver.Create(
            [
                new GraphifyAttributeGenerator().AsSourceGenerator(),
                new GraphContractGenerator().AsSourceGenerator(),
                new NavigatorExtensionsGenerator().AsSourceGenerator(),
                new TraverseAttributeGenerator().AsSourceGenerator(),
                new TypeGenerator().AsSourceGenerator(),
            ],
            parseOptions: options);

        _ = driver.RunGeneratorsAndUpdateCompilation(compilation, out Compilation generated, out _);
        using var stream = new MemoryStream();
        EmitResult emitted = generated.Emit(stream);
        emitted.Success.ShouldBeTrue(string.Join(Environment.NewLine, emitted.Diagnostics));
        var assembly = Assembly.Load(stream.ToArray());
        MethodInfo method = assembly.GetType("Graphify.Testing.Probe")!.GetMethod("Navigate")!;

        return method.CreateDelegate<Func<bool, bool, bool, Task<int[]>>>();
    }
}