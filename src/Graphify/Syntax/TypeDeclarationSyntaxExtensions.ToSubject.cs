namespace Graphify.Syntax
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
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
        private const string RegistrationContractName = "Microsoft.Extensions.DependencyInjection.IServiceCollection";

        private static readonly ConcurrentDictionary<IAssemblySymbol, bool> _cache = new ConcurrentDictionary<IAssemblySymbol, bool>(SymbolEqualityComparer.Default);

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

            if (!(symbol is INamedTypeSymbol type && type.HasGraphify(out byte depth)))
            {
                return default;
            }

            bool hasRegistration = _cache.GetOrAdd(type.ContainingAssembly, assembly => GetRegistration(assembly, compilation));

            return type.ToSubject(depth, ImmutableArray.ToImmutableArray(nesting), hasRegistration);
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