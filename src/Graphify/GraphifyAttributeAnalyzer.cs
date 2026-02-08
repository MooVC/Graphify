namespace Graphify
{
    using System.Collections.Immutable;
    using Graphify.Semantics;
    using Graphify.Syntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using static Graphify.GraphifyAttributeAnalyzer_Resources;

    /// <summary>
    /// Analyzes types annotated with the Monify attribute.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class GraphifyAttributeAnalyzer
        : AttributeAnalyzer<GraphifyAttributeAnalyzer_Resources>
    {
        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            CompatibleTargetTypeRule,
            GenericTypeRule,
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

        /// <summary>
        /// Gets the descriptor associated with the generic type rule (GRAFY04).
        /// </summary>
        /// <value>
        /// The descriptor associated with the generic type rule (GRAFY04).
        /// </value>
        internal static DiagnosticDescriptor GenericTypeRule { get; } = new DiagnosticDescriptor(
            "GRAFY04",
            GetResourceString(ResourceManager, nameof(GenericTypeRuleTitle)),
            GetResourceString(ResourceManager, nameof(GenericTypeRuleMessageFormat)),
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(GenericTypeRuleDescription)),
            helpLinkUri: GetHelpLinkUri("GRAFY04"));

        /// <inheritdoc/>
        protected override void Analyze(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, Location location)
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

            if (IsViolatingGenericTypeRule(type, out identifier))
            {
                Raise(context, GenericTypeRule, location, identifier);
            }
        }

        protected override bool IsMatch(IMethodSymbol symbol)
        {
            return symbol.ContainingType is object
                && symbol.ContainingType.IsGraphify();
        }

        private static bool IsViolatingCompatibleTargetTypeRule(AttributeSyntax attribute, out TypeDeclarationSyntax type)
        {
            type = attribute.Parent?.Parent as TypeDeclarationSyntax;

            return type is null;
        }

        private static bool IsViolatingGenericTypeRule(TypeDeclarationSyntax parent, out string identifier)
        {
            identifier = parent.Identifier.Text;

            return parent.HasGenerics();
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
    }
}