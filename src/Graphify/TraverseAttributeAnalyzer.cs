namespace Graphify
{
    using System;
    using System.Collections.Immutable;
    using Graphify.Semantics;
    using Graphify.Syntax;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using static Graphify.TraverseAttributeAnalyzer_Resources;

    /// <summary>
    /// Analyzes usage of the TraverseAttribute when applied to a property, ensuring the property adheres to the known constraints.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class TraverseAttributeAnalyzer
        : AttributeAnalyzer<TraverseAttributeAnalyzer_Resources>
    {
        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(MissingGraphifyRule);

        /// <summary>
        /// Gets the descriptor associated with the missing Graphify rule (GRAFY03).
        /// </summary>
        /// <value>
        /// The descriptor associated with the missing Graphify rule (GRAFY03).
        /// </value>
        internal static DiagnosticDescriptor MissingGraphifyRule { get; } = new DiagnosticDescriptor(
            "GRAFY04",
            GetResourceString(ResourceManager, nameof(MissingGraphifyRuleTitle)),
            GetResourceString(ResourceManager, nameof(MissingGraphifyRuleMessageFormat)),
            "Usage",
            DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: GetResourceString(ResourceManager, nameof(MissingGraphifyRuleDescription)),
            helpLinkUri: GetHelpLinkUri("GRAFY04"));

        /// <inheritdoc/>
        protected override void Analyze(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, Location location)
        {
            if (IsViolatingMissingGraphifyRule(attribute, context, out string property))
            {
                Raise(context, MissingGraphifyRule, location, property);
            }
        }

        /// <inheritdoc/>
        protected override bool IsMatch(IMethodSymbol symbol)
        {
            return symbol.ContainingType is object
                && symbol.ContainingType.IsTraverse();
        }

        private static bool IsViolatingMissingGraphifyRule(AttributeSyntax attribute, SyntaxNodeAnalysisContext context, out string property)
        {
            if (attribute is null)
            {
                throw new ArgumentNullException(nameof(attribute));
            }

            ISymbol parent = attribute.GetParent<TypeDeclarationSyntax>(context);

            property = string.Empty;

            if (parent is INamedTypeSymbol type)
            {
                PropertyDeclarationSyntax declaration = attribute.FirstAncestorOrSelf<PropertyDeclarationSyntax>();

                property = declaration is null
                    ? type.Name
                    : declaration.Identifier.ValueText;

                if (type.HasGraphify(out _))
                {
                    return false;
                }
            }

            return true;
        }
    }
}