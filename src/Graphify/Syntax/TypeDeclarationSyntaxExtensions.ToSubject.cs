namespace Graphify.Syntax
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading;
    using Graphify.Model;
    using Graphify.Semantics;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using static Graphify.Names;

    /// <summary>
    /// Provides extensions relating to <see cref="TypeDeclarationSyntax"/>.
    /// </summary>
    internal static partial class TypeDeclarationSyntaxExtensions
    {
        private const string RegistrationContractName = "Microsoft.Extensions.DependencyInjection.IServiceCollection";

        /// <summary>
        /// Maps the required Semantics from the <paramref name="syntax"/>, using the <paramref name="compilation"/>
        /// and places it within an instance of <see cref="Subject"/>.
        ///
        /// The semantics will only be mapped if the <paramref name="syntax"/> is annotated with the Graphify attribute and it,
        /// along with its parents, are marked as partial.
        /// </summary>
        /// <param name="syntax">
        /// The syntax for the class to be mapped.
        /// </param>
        /// <param name="compilation">
        /// Information relating to the compilation, used to obtain the semantic model for <paramref name="syntax"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken" /> that can be used to cancel the operation.
        /// </param>
        /// <returns>
        /// When the <paramref name="syntax"/> is annotated with the Graphify attribute and it, and its parents are marked as partial,
        /// the required semantics mapped from <paramref name="syntax"/> using <paramref name="compilation"/>, otherwise <see langword="null"/>.
        /// </returns>
        public static Subject ToSubject(this TypeDeclarationSyntax syntax, Compilation compilation, CancellationToken cancellationToken)
        {
            var nesting = new Stack<Nesting>();

            if (syntax is null || !syntax.IsPartial() || syntax.HasGenerics())
            {
                return default;
            }

            SemanticModel model = compilation.GetSemanticModel(syntax.SyntaxTree);
            ISymbol symbol = model.GetDeclaredSymbol(syntax, cancellationToken: cancellationToken);

            if (!(symbol is INamedTypeSymbol type && type.HasGraphify(out byte depth, out Modes mode) && type.HasSupportedAccessibility()))
            {
                return default;
            }

            bool hasRegistration = GetRegistration(type.ContainingAssembly, compilation);
            string graphName = GetStringOption(type, model, nameof(Subject.GraphName), DefaultGraphTypeName, cancellationToken);
            string propertyPrefix = GetStringOption(type, model, nameof(Subject.PropertyPrefix), string.Empty, cancellationToken);

            return type.ToSubject(depth, mode, ImmutableArray.ToImmutableArray(nesting), hasRegistration, propertyPrefix, graphName);
        }

        private static string GetStringOption(INamedTypeSymbol type, SemanticModel model, string name, string defaultValue, CancellationToken cancellationToken)
        {
            AttributeData attribute = type.GetAttribute(GraphifyAttributeGenerator.Name);

            if (!(attribute?.ApplicationSyntaxReference?.GetSyntax(cancellationToken) is AttributeSyntax syntax)
                || syntax.ArgumentList is null)
            {
                return defaultValue;
            }

            foreach (AttributeArgumentSyntax argument in syntax.ArgumentList.Arguments)
            {
                if (argument.NameEquals?.Name.Identifier.ValueText != name)
                {
                    continue;
                }

                Optional<object> constant = model.GetConstantValue(argument.Expression, cancellationToken);

                return constant.HasValue && constant.Value is string value
                    ? value
                    : defaultValue;
            }

            return defaultValue;
        }

        private static bool GetRegistration(IAssemblySymbol assembly, Compilation compilation)
        {
            INamedTypeSymbol registration = compilation.GetTypeByMetadataName(RegistrationContractName);

            if (registration is null)
            {
                return false;
            }

            return CanReference(assembly, registration.ContainingAssembly);
        }

        private static bool CanReference(IAssemblySymbol source, IAssemblySymbol target)
        {
            if (SymbolEqualityComparer.Default.Equals(source, target))
            {
                return true;
            }

            return source
                .Modules
                .SelectMany(module => module.ReferencedAssemblySymbols)
                .Any(reference => SymbolEqualityComparer.Default.Equals(reference, target));
        }
    }
}