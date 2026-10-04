namespace Graphify.TypeGeneratorTests
{
    using System.IO;
    using System.Reflection;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.Emit;

    public sealed class WhenInitializeIsCalled
    {
        private const int Amount = 42;
        private const string DependencyInjectionAssembly = "Microsoft.Extensions.DependencyInjection.Abstractions.dll";
        private const int FirstIndex = 0;

        [Theory]
        [InlineData("\"\"")]
        [InlineData("null")]
        public void GivenEmptyOrNullPropertyPrefixThenExistingSourceIsPreserved(string expression)
        {
            // Arrange
            const string source = """
                using Graphify;

                [Graphify]
                public sealed partial class Sample
                {
                    public int Number { get; set; }
                }
                """;
            GeneratorDriverRunResult expected = Generate(source, out _);
            string prefixedSource = source.Replace("[Graphify]", $"[Graphify(PropertyPrefix = {expression})]", StringComparison.Ordinal);

            // Act
            GeneratorDriverRunResult result = Generate(prefixedSource, out Compilation compilation);
            using var stream = new MemoryStream();
            EmitResult emitted = compilation.Emit(stream);

            // Assert
            result.Diagnostics.ShouldBeEmpty();
            emitted.Success.ShouldBeTrue(string.Join(Environment.NewLine, emitted.Diagnostics));
            result.GeneratedTrees.Select(tree => tree.ToString()).ShouldBe(expected.GeneratedTrees.Select(tree => tree.ToString()));
        }

        [Theory]
        [InlineData(false, "\"_\"", "_")]
        [InlineData(true, "\"_\"", "_")]
        [InlineData(false, "Prefixes.Graph", "Graph")]
        [InlineData(true, "Prefixes.Graph", "Graph")]
        [InlineData(false, "\"Gr\" + \"aph\"", "Graph")]
        [InlineData(true, "nameof(Prefixes.Graph)", "Graph")]
        [InlineData(false, "@\"_\"", "_")]
        [InlineData(true, "\"\\u005F\"", "_")]
        public async Task GivenPropertyPrefixWhenNamesCollideThenNodesCompileAndNavigationPreservesValues(bool asynchronous, string expression, string prefix)
        {
            // Arrange
            string source = CreateSource(asynchronous, expression, prefix);

            // Act
            GeneratorDriverRunResult result = Generate(source, out Compilation compilation);
            using var stream = new MemoryStream();
            EmitResult emitted = compilation.Emit(stream);

            // Assert
            result.Diagnostics.ShouldBeEmpty();
            emitted.Success.ShouldBeTrue(string.Join(Environment.NewLine, emitted.Diagnostics));
            var assembly = Assembly.Load(stream.ToArray());
            MethodInfo method = assembly.GetType("Graphify.Testing.Probe")!.GetMethod("Navigate")!;
            Func<Task<int[]>> navigate = method.CreateDelegate<Func<Task<int[]>>>();
            int[] observations = await navigate();
            observations.ShouldBe([FirstIndex, Amount]);
        }

        [Theory]
        [InlineData("$")]
        [InlineData("1")]
        [InlineData("Graph ")]
        [InlineData("Graph-")]
        public void GivenInvalidPropertyPrefixThenDiagnosticIsReported(string prefix)
        {
            // Arrange
            const string diagnosticIdentifier = "GRAFY06";
            string source = $$"""
                using Graphify;

                [Graphify(PropertyPrefix = "{{prefix}}")]
                public sealed partial class Sample
                {
                    public int Number { get; set; }
                }
                """;

            // Act
            GeneratorDriverRunResult result = Generate(source, out _);

            // Assert
            Diagnostic diagnostic = result.Diagnostics.ShouldHaveSingleItem();
            diagnostic.Id.ShouldBe(diagnosticIdentifier);
            diagnostic.Severity.ShouldBe(DiagnosticSeverity.Error);
            diagnostic.GetMessage().ShouldContain(prefix);
            result.Results.Single(generated => generated.Diagnostics.Any(candidate => candidate.Id == diagnosticIdentifier)).GeneratedSources.ShouldBeEmpty();
        }

        private static string CreateSource(bool asynchronous, string expression, string prefix)
        {
            string mode = asynchronous ? "Asynchronous" : "Synchronous";
            string returnType = asynchronous ? "IAsyncEnumerable<int>" : "IEnumerable<int>";
            string parameters = asynchronous ? ", CancellationToken cancellationToken" : string.Empty;
            string iteration = asynchronous ? "await foreach" : "foreach";
            string navigate = asynchronous
                ? "navigator.Navigate<int>(root, CancellationToken.None)"
                : "navigator.Navigate<int>(root)";

            return $$"""
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using System.Threading;
                    using System.Threading.Tasks;

                    public static class Prefixes
                    {
                        public const string Graph = "Graph";
                    }

                    [Graphify(Depth = 3, Mode = Modes.{{mode}}, PropertyPrefix = {{expression}})]
                    public sealed partial class Sample
                    {
                        public Index[] Children { get; set; }

                        public Model Root { get; set; }

                        public Model Value { get; set; }
                    }

                    public sealed class Index
                    {
                        public int Amount { get; set; }
                    }

                    public sealed class Model
                    {
                        public int Amount { get; set; }
                    }

                    public sealed class ElementVisitor : ISampleVisitor<Sample.Graph.Children.Index, int>
                    {
                        public {{returnType}} Observe(Sample.Graph.Children.Index instance{{parameters}})
                        {
                            if (!ReferenceEquals(instance.{{prefix}}Children.{{prefix}}Value[instance.{{prefix}}Index], instance.{{prefix}}Value)
                                || !ReferenceEquals(((IGraph<Sample>)instance).Root, instance.{{prefix}}Root))
                            {
                                throw new InvalidOperationException();
                            }

                            return Results(instance.{{prefix}}Index);
                        }

                        private static {{(asynchronous ? "async " : string.Empty)}}{{returnType}} Results(int value)
                        {
                            {{(asynchronous ? "await Task.CompletedTask;" : string.Empty)}}
                            yield return value;
                        }
                    }

                    public sealed class PropertyVisitor : ISampleVisitor<Sample.Graph.Children.Index.Amount, int>
                    {
                        public {{returnType}} Observe(Sample.Graph.Children.Index.Amount instance{{parameters}})
                        {
                            if (instance.{{prefix}}IndexParent.{{prefix}}Value.Amount != instance.{{prefix}}Value)
                            {
                                throw new InvalidOperationException();
                            }

                            return Results(instance.{{prefix}}Value + instance.{{prefix}}IndexParent.{{prefix}}Index);
                        }

                        private static {{(asynchronous ? "async " : string.Empty)}}{{returnType}} Results(int value)
                        {
                            {{(asynchronous ? "await Task.CompletedTask;" : string.Empty)}}
                            yield return value;
                        }
                    }

                    public sealed class Provider : IServiceProvider
                    {
                        public object GetService(Type serviceType)
                        {
                            if (serviceType == typeof(IEnumerable<ISampleVisitor<Sample.Graph.Children.Index, int>>))
                            {
                                return new ISampleVisitor<Sample.Graph.Children.Index, int>[] { new ElementVisitor() };
                            }

                            if (serviceType == typeof(IEnumerable<ISampleVisitor<Sample.Graph.Children.Index.Amount, int>>))
                            {
                                return new ISampleVisitor<Sample.Graph.Children.Index.Amount, int>[] { new PropertyVisitor() };
                            }

                            return null;
                        }
                    }

                    public static class Probe
                    {
                        public static async Task<int[]> Navigate()
                        {
                            var root = new Sample
                            {
                                Children = new Index[] { new Index { Amount = {{Amount}} } },
                                Root = new Model { Amount = {{Amount}} },
                                Value = new Model { Amount = {{Amount}} },
                            };
                            var rootNode = new Sample.Graph.Root(root, root.Root);
                            var rootAmount = new Sample.Graph.Root.Amount(rootNode, root, root.Root.Amount);
                            var valueNode = new Sample.Graph.Value(root, root.Value);
                            var valueAmount = new Sample.Graph.Value.Amount(valueNode, root, root.Value.Amount);

                            if (!ReferenceEquals(rootAmount.{{prefix}}RootParent, rootNode)
                                || !ReferenceEquals(valueAmount.{{prefix}}ValueParent, valueNode)
                                || !ReferenceEquals(((IGraph<Sample>)rootAmount).Root, root)
                                || !ReferenceEquals(((IGraph<Sample>)valueAmount).Root, root)
                                || rootAmount.{{prefix}}Value != {{Amount}}
                                || valueAmount.{{prefix}}Value != {{Amount}})
                            {
                                throw new InvalidOperationException();
                            }

                            var navigator = new SampleNavigator(new Provider());
                            var observations = new List<int>();

                            {{iteration}} (int observation in {{navigate}})
                            {
                                observations.Add(observation);
                            }

                            await Task.CompletedTask;
                            return observations.ToArray();
                        }
                    }
                }
                """;
        }

        private static GeneratorDriverRunResult Generate(string source, out Compilation compilation)
        {
            var options = new CSharpParseOptions(LanguageVersion.CSharp14, preprocessorSymbols: ["NET5_0_OR_GREATER"]);
            string[] assemblyPaths = ((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator);
            IEnumerable<PortableExecutableReference> references = assemblyPaths
                .Where(path => !string.Equals(Path.GetFileName(path), DependencyInjectionAssembly, StringComparison.OrdinalIgnoreCase))
                .Distinct()
                .Select(path => MetadataReference.CreateFromFile(path));

            var input = CSharpCompilation.Create(
                $"Graphify.Tests.PropertyPrefix.{Guid.NewGuid():N}",
                [CSharpSyntaxTree.ParseText(source, options)],
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, generalDiagnosticOption: ReportDiagnostic.Error));

            GeneratorDriver driver = CSharpGeneratorDriver.Create(
                [
                    new GraphifyAttributeGenerator().AsSourceGenerator(),
                    new GraphContractGenerator().AsSourceGenerator(),
                    new NavigatorExtensionsGenerator().AsSourceGenerator(),
                    new TraverseAttributeGenerator().AsSourceGenerator(),
                    new TypeGenerator().AsSourceGenerator(),
                ],
                parseOptions: options);

            driver = driver.RunGeneratorsAndUpdateCompilation(input, out compilation, out _);

            return driver.GetRunResult();
        }
    }
}