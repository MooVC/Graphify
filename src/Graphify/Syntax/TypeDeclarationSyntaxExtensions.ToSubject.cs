namespace Graphify.Syntax
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Threading;
    using Graphify.Model;
    using Graphify.Semantics;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Provides extensions relating to <see cref="TypeDeclarationSyntax"/>.
    /// </summary>
    internal static partial class TypeDeclarationSyntaxExtensions
    {
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
        /// <param name="registration">
        /// The symbol representing the registration contract from Microsoft.Extensions.DependencyInjection. Can be <see langword="null"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken" /> that can be used to cancel the operation.
        /// </param>
        /// <returns>
        /// When the <paramref name="syntax"/> is annotated with the Graphify attribute and it, and its parents are marked as partial,
        /// the required semantics mapped from <paramref name="syntax"/> using <paramref name="compilation"/>, otherwise <see langword="null"/>.
        /// </returns>
        public static Subject ToSubject(
            this TypeDeclarationSyntax syntax,
            Compilation compilation,
            INamedTypeSymbol registration,
            CancellationToken cancellationToken)
        {
            var nesting = new Stack<Nesting>();

            if (syntax is null || !syntax.IsPartial())
            {
                return default;
            }

            SemanticModel model = compilation.GetSemanticModel(syntax.SyntaxTree);
            ISymbol symbol = model.GetDeclaredSymbol(syntax, cancellationToken: cancellationToken);

            if (!(symbol is INamedTypeSymbol type && type.HasGraphify()))
            {
                return default;
            }

            return type.ToSubject(ImmutableArray.ToImmutableArray(nesting), registration);
        }
    }
}