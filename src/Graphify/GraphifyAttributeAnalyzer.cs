namespace Graphify
{
    using System.Collections.Immutable;
    using Graphify.Semantics;
    using Graphify.Syntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using static Graphify.GraphifyAttributeAnalyzer_Resources;
    using Manager = System.Resources.ResourceManager;

    /// <summary>
    /// Analyzes types annotated with the Monify attribute.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class GraphifyAttributeAnalyzer
        : DiagnosticAnalyzer
    {
        private const string Branch = "master";

        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            CompatibleTargetTypeRule,
            PartialTypeRule);

        /// <summary>
        /// Gets the descriptor associated with the compatible target type rule (GRAFY01).
        /// </summary>
        /// <value>
        /// The descriptor associated with the compatible target type rule (GRAFY01).
        /// </value>
        internal static DiagnosticDescriptor CompatibleTargetTypeRule { get; } = new DiagnosticDescriptor(
            "GRAFY01",
            GetResourceString(ResourceManager, nameof(CompatibleTargetTypeRuleTitle)),
            GetResourceString(ResourceManager, nameof(CompatibleTargetTypeRuleMessageFormat)),
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(CompatibleTargetTypeRuleDescription)),
            helpLinkUri: GetHelpLinkUri("GRAFY01"));

        /// <summary>
        /// Gets the descriptor associated with the partial type rule (GRAFY02).
        /// </summary>
        /// <value>
        /// The descriptor associated with the partial type rule (GRAFY02).
        /// </value>
        internal static DiagnosticDescriptor PartialTypeRule { get; } = new DiagnosticDescriptor(
            "GRAFY02",
            GetResourceString(ResourceManager, nameof(PartialTypeRuleTitle)),
            GetResourceString(ResourceManager, nameof(PartialTypeRuleMessageFormat)),
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(PartialTypeRuleDescription)),
            helpLinkUri: GetHelpLinkUri("GRAFY02"));

        /// <inheritdoc/>
        public sealed override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.Attribute);
        }

        /// <summary>
        /// Analyses the location at which the matching attribute has been detected.
        /// </summary>
        /// <param name="attribute">
        /// The syntax for the detected attribute.
        /// </param>
        /// <param name="context">
        /// The analysis context, providing access to the semantic model and facilitating reporting.
        /// </param>
        /// <param name="location">
        /// The location at which the attribute was identified.
        /// </param>
        private static void Analyze(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, Location location)
        {
            if (IsViolatingCompatibleTargetTypeRule(attribute, out TypeDeclarationSyntax type))
            {
                Raise(context, CompatibleTargetTypeRule, location);

                return;
            }

            if (IsViolatingPartialTypeRule(type, out string identifier))
            {
                Raise(context, PartialTypeRule, location, identifier);
            }
        }

        private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            if (context.Node is AttributeSyntax attribute)
            {
                IMethodSymbol symbol = GetSymbol<IMethodSymbol>(context, attribute);

                if (symbol is null || !IsMatch(symbol))
                {
                    return;
                }

                Location location = attribute.GetLocation();

                Analyze(attribute, context, location);
            }
        }

        private static string GetHelpLinkUri(string ruleId)
        {
            return $"https://github.com/MooVC/Graphify/blob/{Branch}/docs/rules/{ruleId}.md";
        }

        private static LocalizableResourceString GetResourceString(Manager manager, string name)
        {
            return new LocalizableResourceString(name, manager, typeof(GraphifyAttributeAnalyzer_Resources));
        }

        private static TSymbol GetSymbol<TSymbol>(SyntaxNodeAnalysisContext context, SyntaxNode syntax)
            where TSymbol : class, ISymbol
        {
            if (syntax is null)
            {
                return default;
            }

            if (typeof(INamedTypeSymbol).IsAssignableFrom(typeof(TSymbol)))
            {
                return context
                    .SemanticModel
                    .GetDeclaredSymbol(syntax, cancellationToken: context.CancellationToken) as TSymbol;
            }

            return context
                .SemanticModel
                .GetSymbolInfo(syntax, cancellationToken: context.CancellationToken)
                .Symbol as TSymbol;
        }

        private static bool IsMatch(IMethodSymbol symbol)
        {
            return symbol.ContainingType is object
                && symbol.ContainingType.IsGraphify();
        }

        private static bool IsViolatingCompatibleTargetTypeRule(AttributeSyntax attribute, out TypeDeclarationSyntax type)
        {
            type = attribute.Parent?.Parent as TypeDeclarationSyntax;

            return type is null;
        }

        private static bool IsViolatingPartialTypeRule(TypeDeclarationSyntax parent, out string identifier)
        {
            identifier = default;

            while (parent is object)
            {
                if (!parent.IsPartial())
                {
                    identifier = parent.Identifier.Text;

                    return true;
                }

                parent = parent.Parent as TypeDeclarationSyntax;
            }

            return false;
        }

        private static void Raise(SyntaxNodeAnalysisContext context, DiagnosticDescriptor descriptor, Location location, params object[] messageArgs)
        {
            var diagnostic = Diagnostic.Create(descriptor, location, messageArgs);

            context.ReportDiagnostic(diagnostic);
        }
    }
}