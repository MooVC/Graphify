namespace Graphify.Testing.SampleNavigatorTests;

using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenNavigateIsCalled
{
    private const string DefaultGraphName = "Graph";
    private const string DefaultPropertyPrefix = "";
    private const int FirstAge = 10;
    private const int RootObservation = -1;
    private const int RootPropertyValue = 30;
    private const int SecondAge = 20;

    private delegate Task<int[]> Navigation(bool emptyVisitors, bool elementVisitors, bool propertyVisitors, bool rootVisitor = false);

    [Test]
    [Arguments(false, "N")]
    [Arguments(true, "N")]
    [Arguments(false, "ObjectGraph")]
    [Arguments(true, "ObjectGraph")]
    public async Task GivenGraphNameThenDescendantsAreVisitedInOrder(bool asynchronous, string graphName)
    {
        // Arrange
        const int firstIndex = 0;
        const int secondIndex = 1;
        Navigation navigate = CreateNavigation(asynchronous, graphName);

        // Act
        int[] results = await navigate(false, true, true);

        // Assert
        results.ShouldBe([firstIndex, FirstAge + firstIndex, secondIndex, SecondAge + secondIndex]);
    }

    [Test]
    [Arguments(false, false)]
    [Arguments(false, true)]
    [Arguments(true, false)]
    [Arguments(true, true)]
    public async Task GivenNoVisitorsThenResultsAreEmpty(bool asynchronous, bool emptyVisitors)
    {
        // Arrange
        Navigation navigate = CreateNavigation(asynchronous);

        // Act
        int[] results = await navigate(emptyVisitors, false, false);

        // Assert
        results.ShouldBeEmpty();
    }

    [Test]
    [Arguments(false, false)]
    [Arguments(false, true)]
    [Arguments(true, false)]
    [Arguments(true, true)]
    public async Task GivenPropertyVisitorsThenDescendantsAreVisitedInOrder(bool asynchronous, bool elementVisitors)
    {
        // Arrange
        const int firstIndex = 0;
        const int secondIndex = 1;
        Navigation navigate = CreateNavigation(asynchronous);
        int[] expected = elementVisitors
            ? [firstIndex, FirstAge + firstIndex, secondIndex, SecondAge + secondIndex]
            : [FirstAge + firstIndex, SecondAge + secondIndex];

        // Act
        int[] results = await navigate(false, elementVisitors, true);

        // Assert
        results.ShouldBe(expected);
    }

    [Test]
    [Arguments(false, DefaultGraphName, DefaultPropertyPrefix)]
    [Arguments(true, DefaultGraphName, DefaultPropertyPrefix)]
    [Arguments(false, "ObjectGraph", "_")]
    [Arguments(true, "ObjectGraph", "_")]
    public async Task GivenRootVisitorThenRootIsVisitedBeforeDescendants(bool asynchronous, string graphName, string propertyPrefix)
    {
        // Arrange
        const int firstIndex = 0;
        const int secondIndex = 1;
        Navigation navigate = CreateNavigation(asynchronous, graphName, propertyPrefix);

        // Act
        int[] results = await navigate(emptyVisitors: false, elementVisitors: true, propertyVisitors: true, rootVisitor: true);

        // Assert
        results.ShouldBe([RootObservation, firstIndex, FirstAge + firstIndex, secondIndex, SecondAge + secondIndex, RootPropertyValue]);
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task GivenRootVisitorWhenThereAreNoDescendantsThenRootIsVisited(bool asynchronous)
    {
        // Arrange
        Navigation navigate = CreateNavigation(asynchronous, hasDescendants: false);

        // Act
        int[] results = await navigate(emptyVisitors: false, elementVisitors: false, propertyVisitors: false, rootVisitor: true);

        // Assert
        results.ShouldBe([RootObservation]);
    }

    private static Navigation CreateNavigation(
        bool asynchronous,
        string graphName = DefaultGraphName,
        string propertyPrefix = DefaultPropertyPrefix,
        bool hasDescendants = true)
    {
        string mode = asynchronous ? "Asynchronous" : "Synchronous";
        string returnType = asynchronous ? "IAsyncEnumerable<int>" : "IEnumerable<int>";
        string parameters = asynchronous ? ", CancellationToken cancellationToken" : string.Empty;
        string iteratorParameters = asynchronous ? ", [EnumeratorCancellation] CancellationToken cancellationToken" : string.Empty;
        string navigate = asynchronous
            ? "navigator.Navigate<int>(root, CancellationToken.None)"
            : "navigator.Navigate<int>(root)";
        string iteration = asynchronous ? "await foreach" : "foreach";
        string asyncModifier = asynchronous ? "async " : string.Empty;
        string asyncAwait = asynchronous ? "await Task.CompletedTask;" : string.Empty;
        string source = $$"""
            namespace Graphify.Testing
            {
                using System;
                using System.Collections.Generic;
                using System.Runtime.CompilerServices;
                using System.Threading;
                using System.Threading.Tasks;

                [Graphify(GraphName = "{{graphName}}", Mode = Modes.{{mode}}, PropertyPrefix = "{{propertyPrefix}}")]
                public sealed partial class Sample
                {
            #if DESCENDANTS
                    public Child[] Children { get; set; }
            #else
                    [Traverse(Scope = TraverseScope.None)]
            #endif
                    public int Root { get; set; }
                }

                public sealed class RootVisitor : ISampleVisitor<Sample.{{graphName}}, int>
                {
                    private readonly Sample _expectedRoot;

                    public RootVisitor(Sample expectedRoot)
                    {
                        _expectedRoot = expectedRoot;
                    }

                    public {{asyncModifier}}{{returnType}} Observe(Sample.{{graphName}} instance{{iteratorParameters}})
                    {
                        if (!ReferenceEquals(((IGraph<Sample>)instance).Root, _expectedRoot))
                        {
                            throw new InvalidOperationException("Root visitor received the wrong model.");
                        }

                        {{asyncAwait}}
                        yield return {{RootObservation}};
                    }
                }

            #if DESCENDANTS
                public sealed class Child
                {
                    public int Age { get; set; }
                }

                public sealed class ElementVisitor : ISampleVisitor<Sample.{{graphName}}.Children.Child, int>
                {
                    public {{returnType}} Observe(Sample.{{graphName}}.Children.Child instance{{parameters}})
                    {
                        return Results(instance.{{propertyPrefix}}Index);
                    }

                    private static {{asyncModifier}}{{returnType}} Results(int value)
                    {
                        {{asyncAwait}}
                        yield return value;
                    }
                }

                public sealed class PropertyVisitor : ISampleVisitor<Sample.{{graphName}}.Children.Child.Age, int>
                {
                    public {{returnType}} Observe(Sample.{{graphName}}.Children.Child.Age instance{{parameters}})
                    {
                        return Results(instance.{{propertyPrefix}}Value + instance.Child.{{propertyPrefix}}Index);
                    }

                    private static {{asyncModifier}}{{returnType}} Results(int value)
                    {
                        {{asyncAwait}}
                        yield return value;
                    }
                }

                public sealed class RootPropertyVisitor : ISampleVisitor<Sample.{{graphName}}.Root, int>
                {
                    public {{asyncModifier}}{{returnType}} Observe(Sample.{{graphName}}.Root instance{{iteratorParameters}})
                    {
                        {{asyncAwait}}
                        yield return instance.{{propertyPrefix}}Value;
                    }
                }
            #endif

                public sealed class Provider : IServiceProvider
                {
                    public bool EmptyVisitors { get; set; }

                    public bool ElementVisitors { get; set; }

                    public bool PropertyVisitors { get; set; }

                    public Sample Root { get; set; }

                    public bool RootVisitor { get; set; }

                    public object GetService(Type serviceType)
                    {
                        if (RootVisitor && serviceType == typeof(IEnumerable<ISampleVisitor<Sample.{{graphName}}, int>>))
                        {
                            return new ISampleVisitor<Sample.{{graphName}}, int>[] { new RootVisitor(Root) };
                        }

            #if DESCENDANTS
                        if (RootVisitor && PropertyVisitors && serviceType == typeof(IEnumerable<ISampleVisitor<Sample.{{graphName}}.Root, int>>))
                        {
                            return new ISampleVisitor<Sample.{{graphName}}.Root, int>[] { new RootPropertyVisitor() };
                        }

                        if (ElementVisitors && serviceType == typeof(IEnumerable<ISampleVisitor<Sample.{{graphName}}.Children.Child, int>>))
                        {
                            return new ISampleVisitor<Sample.{{graphName}}.Children.Child, int>[] { new ElementVisitor() };
                        }

                        if (PropertyVisitors && serviceType == typeof(IEnumerable<ISampleVisitor<Sample.{{graphName}}.Children.Child.Age, int>>))
                        {
                            return new ISampleVisitor<Sample.{{graphName}}.Children.Child.Age, int>[] { new PropertyVisitor() };
                        }
            #endif

                        return EmptyVisitors ? Array.CreateInstance(serviceType.GenericTypeArguments[0], 0) : null;
                    }
                }

                public static class Probe
                {
                    public static async Task<int[]> Navigate(bool emptyVisitors, bool elementVisitors, bool propertyVisitors, bool rootVisitor)
                    {
                        var root = new Sample
                        {
            #if DESCENDANTS
                            Children = new Child[] { new Child { Age = {{FirstAge}} }, new Child { Age = {{SecondAge}} } },
            #endif
                            Root = {{RootPropertyValue}},
                        };
                        var provider = new Provider
                        {
                            EmptyVisitors = emptyVisitors,
                            ElementVisitors = elementVisitors,
                            PropertyVisitors = propertyVisitors,
                            Root = root,
                            RootVisitor = rootVisitor,
                        };
                        var navigator = new SampleNavigator(provider);
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

        string[] symbols = hasDescendants ? ["NET5_0_OR_GREATER", "DESCENDANTS"] : ["NET5_0_OR_GREATER"];
        var options = new CSharpParseOptions(LanguageVersion.CSharp14, preprocessorSymbols: symbols);
        string[] assemblyPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator);
        string generatorPath = typeof(TypeGenerator).Assembly.Location;

        IEnumerable<PortableExecutableReference> references = assemblyPaths
            .Where(path => !string.Equals(path, generatorPath, StringComparison.OrdinalIgnoreCase))
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

        return method.CreateDelegate<Navigation>();
    }
}