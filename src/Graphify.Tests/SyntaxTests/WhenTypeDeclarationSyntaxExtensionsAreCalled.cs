namespace Graphify.SyntaxTests
{
    using System.Collections.Immutable;
    using System.Threading;
    using Graphify.Model;
    using Graphify.Syntax;
    using Graphify.Testing;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class WhenTypeDeclarationSyntaxExtensionsAreCalled
    {
        private const string Source = """
            using System;
            namespace Graphify
            {
                [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
                internal sealed class GraphifyAttribute : Attribute
                {
                    public byte Depth { get; set; }
                    public Modes Mode { get; set; }
                }

                internal enum Modes
                {
                    Synchronous,
                    Asynchronous,
                }
            }

            namespace Sample
            {
                [Graphify.Graphify(Depth = 2, Mode = Graphify.Modes.Synchronous)]
                public partial class Annotated
                {
                    public Node? Item { get; set; }
                }

                public class Node
                {
                    public Node? Next { get; set; }
                }

                public partial class Generic<T>
                {
                }

                public class NonPartial
                {
                }
            }
            """;

        [Fact]
        public void GivenTypeWithGenericParametersThenHasGenericsReturnsTrue()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            TypeDeclarationSyntax syntax = GetTypeDeclaration(context, "Generic");

            // Act
            bool hasGenerics = syntax.HasGenerics();

            // Assert
            hasGenerics.ShouldBeTrue();
        }

        [Fact]
        public void GivenTypeWithoutGenericParametersThenHasGenericsReturnsFalse()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            TypeDeclarationSyntax syntax = GetTypeDeclaration(context, "Annotated");

            // Act
            bool hasGenerics = syntax.HasGenerics();

            // Assert
            hasGenerics.ShouldBeFalse();
        }

        [Fact]
        public void GivenPartialTypeThenIsPartialReturnsTrue()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            TypeDeclarationSyntax syntax = GetTypeDeclaration(context, "Annotated");

            // Act
            bool isPartial = syntax.IsPartial();

            // Assert
            isPartial.ShouldBeTrue();
        }

        [Fact]
        public void GivenNonPartialTypeThenIsPartialReturnsFalse()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            TypeDeclarationSyntax syntax = GetTypeDeclaration(context, "NonPartial");

            // Act
            bool isPartial = syntax.IsPartial();

            // Assert
            isPartial.ShouldBeFalse();
        }

        [Fact]
        public void GivenGraphifyPartialTypeThenToSubjectMapsExpectedValues()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source, typeof(IServiceCollection).Assembly);
            TypeDeclarationSyntax syntax = GetTypeDeclaration(context, "Annotated");

            // Act
            Subject? subject = syntax.ToSubject(context.Compilation, CancellationToken.None);

            // Assert
            subject.ShouldNotBeNull();
            subject.Name.ShouldBe("Annotated");
            subject.Depth.ShouldBe((byte)2);
            subject.Mode.ShouldBe(Modes.Synchronous);
            subject.CanRegister.ShouldBeTrue();
            subject.Namespace.ShouldBe("Sample");
            subject.Nesting.ShouldBe(ImmutableArray<Nesting>.Empty);
        }

        [Fact]
        public void GivenTypeThatIsNotPartialThenToSubjectReturnsNull()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            TypeDeclarationSyntax syntax = GetTypeDeclaration(context, "NonPartial");

            // Act
            Subject? subject = syntax.ToSubject(context.Compilation, CancellationToken.None);

            // Assert
            subject.ShouldBeNull();
        }

        [Fact]
        public void GivenGenericTypeThenToSubjectReturnsNull()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            TypeDeclarationSyntax syntax = GetTypeDeclaration(context, "Generic");

            // Act
            Subject? subject = syntax.ToSubject(context.Compilation, CancellationToken.None);

            // Assert
            subject.ShouldBeNull();
        }

        [Fact]
        public async Task GivenNodeWithinATypeThenGetParentResolvesTheDeclaringSymbol()
        {
            // Arrange
            RoslynTestContext context = RoslynTestContext.Create(Source);
            var analyzer = new ParentAnalyzer();
            CompilationWithAnalyzers analyzers = context.Compilation.WithAnalyzers(ImmutableArray.Create<DiagnosticAnalyzer>(analyzer));

            // Act
            _ = await analyzers.GetAnalyzerDiagnosticsAsync();

            // Assert
            analyzer.ParentName.ShouldBe("Annotated");
            analyzer.SymbolName.ShouldBe("Annotated");
        }

        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        private sealed class ParentAnalyzer : DiagnosticAnalyzer
        {
            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray<DiagnosticDescriptor>.Empty;

            public string? ParentName { get; private set; }

            public string? SymbolName { get; private set; }

            public override void Initialize(AnalysisContext context)
            {
                context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
                context.EnableConcurrentExecution();
                context.RegisterSyntaxNodeAction(AnalyzeProperty, Microsoft.CodeAnalysis.CSharp.SyntaxKind.PropertyDeclaration);
            }

            private void AnalyzeProperty(SyntaxNodeAnalysisContext context)
            {
                ISymbol symbol = context.Node.GetParent<TypeDeclarationSyntax>(context, out TypeDeclarationSyntax? parent);

                ParentName = parent?.Identifier.ValueText;
                SymbolName = symbol?.Name;
            }
        }

        private static TypeDeclarationSyntax GetTypeDeclaration(RoslynTestContext context, string name)
        {
            return context.Tree.GetRoot()
                .DescendantNodes()
                .OfType<TypeDeclarationSyntax>()
                .First(node => node.Identifier.ValueText == name);
        }
    }
}