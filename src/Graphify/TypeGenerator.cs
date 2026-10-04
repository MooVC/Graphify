namespace Graphify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Graphify.Model;
    using Graphify.Strategies;
    using Graphify.Syntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Graphify.GeneratedNames;
    using static Graphify.TypeGenerator_Resources;

    /// <summary>
    /// Generates source for a type that is annotated with the Graphify attribute.
    /// </summary>
    [Generator(LanguageNames.CSharp)]
    public sealed class TypeGenerator
        : IIncrementalGenerator
    {
        private const string GeneratedSourceSuffix = ".g.cs";
        private const string PropertyPrefixRuleIdentifier = "GRAFY06";
        private const string UsageCategoryName = "Usage";

        private static readonly IStrategy[] _strategies = new IStrategy[]
        {
            new AsynchronousContractStrategy(),
            new AsynchronousNavigatorStrategy(),
            new AsynchronousRegistrationStrategy(),
            new AsynchronousVisitorStrategy(),
            new ModelStrategy(),
            new SynchronousContractStrategy(),
            new SynchronousNavigatorStrategy(),
            new SynchronousRegistrationStrategy(),
            new SynchronousVisitorStrategy(),
        };

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

            if (!SyntaxFacts.IsValidIdentifier(string.Concat(subject.PropertyPrefix, RootPropertyName)))
            {
                context.ReportDiagnostic(Diagnostic.Create(PropertyPrefixRule, Location.None, subject.PropertyPrefix));

                return;
            }
#if DEBUG
            var files = new Dictionary<string, string>();
#endif

            foreach (IStrategy strategy in _strategies)
            {
                IEnumerable<Source> sources = strategy.Generate(subject);

                foreach (Source source in sources)
                {
                    string code = Wrap(source.Code, subject);
                    string hint = GetHint(source, subject);

#if DEBUG
                    files[hint] = code;
#endif

                    context.AddSource(hint, code);
                }
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

        private static string Nest(string code, Subject subject)
        {
            foreach (Nesting parent in subject.Nesting.Reverse())
            {
                code = code.Indent();
                code = string.Format(NestContent, parent.Declaration, parent.Qualification, code);
            }

            return code;
        }

        private static string Wrap(string code, Subject subject)
        {
            code = Nest(code, subject);
            code = string.Format(WrapContent, code);

            if (subject.IsGlobal)
            {
                return code;
            }

            return string.Format(WrapNamespace, subject.Namespace, code.Indent());
        }
    }
}