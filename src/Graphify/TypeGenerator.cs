namespace Graphify
{
    using System;
    using System.Linq;
    using System.Threading;
    using Graphify.Model;
    using Graphify.Syntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using MooVC.Syntax;
    using static Graphify.Names;
    using static Graphify.TypeGenerator_Resources;

    /// <summary>
    /// Generates source for a type that is annotated with the Graphify attribute.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class TypeGenerator
        : IIncrementalGenerator
    {
        private const string GeneratedSourceSuffix = ".g.cs";
        private const string GraphNameRuleIdentifier = "GRAFY07";
        private const string PropertyPrefixRuleIdentifier = "GRAFY06";
        private const string UsageCategoryName = "Usage";

        private static readonly IServiceProvider _services = new GenerationServices();

        /// <summary>
        /// Gets the descriptor associated with the graph name rule (GRAFY07).
        /// </summary>
        /// <value>
        /// The descriptor associated with the graph name rule (GRAFY07).
        /// </value>
        internal static DiagnosticDescriptor GraphNameRule { get; } = new DiagnosticDescriptor(
            GraphNameRuleIdentifier,
            new LocalizableResourceString(nameof(GenerateGraphNameRuleTitle), ResourceManager, typeof(TypeGenerator_Resources)),
            new LocalizableResourceString(nameof(GenerateGraphNameRuleMessageFormat), ResourceManager, typeof(TypeGenerator_Resources)),
            UsageCategoryName,
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// Gets the descriptor associated with the property prefix rule (GRAFY06).
        /// </summary>
        /// <value>
        /// The descriptor associated with the property prefix rule (GRAFY06).
        /// </value>
        internal static DiagnosticDescriptor PropertyPrefixRule { get; } = new DiagnosticDescriptor(
            PropertyPrefixRuleIdentifier,
            new LocalizableResourceString(nameof(GeneratePropertyPrefixRuleTitle), ResourceManager, typeof(TypeGenerator_Resources)),
            new LocalizableResourceString(nameof(GeneratePropertyPrefixRuleMessageFormat), ResourceManager, typeof(TypeGenerator_Resources)),
            UsageCategoryName,
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <inheritdoc/>
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            IncrementalValuesProvider<TypeDeclarationSyntax> classes = context
                .SyntaxProvider
                .CreateSyntaxProvider(predicate: IsMatch, transform: Transform);

            IncrementalValuesProvider<Subject> subjects = classes
                .Combine(context.CompilationProvider)
                .Select((match, cancellationToken) => Parse(match.Left, match.Right, cancellationToken));

            context.RegisterSourceOutput(subjects, (production, subject) => Generate(production, subject));
        }

        private static void Generate(SourceProductionContext context, Subject subject)
        {
            if (subject is null)
            {
                return;
            }

            if (!SyntaxFacts.IsValidIdentifier(subject.GraphName) || SyntaxFacts.GetKeywordKind(subject.GraphName) != SyntaxKind.None)
            {
                context.ReportDiagnostic(Diagnostic.Create(GraphNameRule, Location.None, subject.GraphName));

                return;
            }

            if (!SyntaxFacts.IsValidIdentifier(string.Concat(subject.PropertyPrefix, RootPropertyName)))
            {
                context.ReportDiagnostic(Diagnostic.Create(PropertyPrefixRule, Location.None, subject.PropertyPrefix));

                return;
            }

            var navigator = new SubjectNavigator(_services);

            foreach (Source source in navigator.Navigate<Source>(subject))
            {
                Snippet code = Wrap(source.Code, subject);
                string hint = GetHint(source, subject);
                context.AddSource(hint, code.ToString());
            }
        }

        private static string GetHint(Source source, Subject subject)
        {
            string name = subject.Nesting
                .Select(parent => parent.Name)
                .Aggregate(
                    string.Empty,
                    (current, next) => string.IsNullOrEmpty(current)
                        ? next
                        : $"{current}.{next}");

            name = $"{subject.Namespace}.{name}";

            string separator = name.EndsWith(".")
                ? string.Empty
                : ".";

            return string.Concat(name, separator, source.Hint, GeneratedSourceSuffix);
        }

        private static bool IsMatch(SyntaxNode node, CancellationToken cancellationToken)
        {
            return node is TypeDeclarationSyntax type && type.AttributeLists.Count > 0;
        }

        private static Subject Parse(TypeDeclarationSyntax syntax, Compilation compilation, CancellationToken cancellationToken)
        {
            return syntax.ToSubject(compilation, cancellationToken);
        }

        private static TypeDeclarationSyntax Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
        {
            return context.Node as TypeDeclarationSyntax;
        }

        private static Snippet Nest(Snippet code, Subject subject)
        {
            foreach (Nesting parent in subject.Nesting.Reverse())
            {
                code = code.Block(Configuration.Options, $"{parent.Declaration} {parent.Qualification}");
            }

            return code;
        }

        private static Snippet Wrap(Snippet code, Subject subject)
        {
            code = Nest(code, subject);
            code = Snippet.From(Configuration.Options, string.Format(WrapContent, code));

            if (subject.IsGlobal)
            {
                return code;
            }

            return code.Block(Configuration.Options, $"namespace {subject.Namespace}");
        }
    }
}