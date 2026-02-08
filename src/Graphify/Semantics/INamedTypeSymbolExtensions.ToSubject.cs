namespace Graphify.Semantics
{
    using System.Collections.Immutable;
    using Graphify.Model;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        /// <summary>
        /// Maps the required Semantics from the <paramref name="subject"/> and places it within an instance of <see cref="Subject"/>.
        /// </summary>
        /// <param name="subject">
        /// The subject from which the semantics are identified.
        /// </param>
        /// <param name="depth">
        /// The depth configured on the Graphify attribute.
        /// </param>
        /// <param name="nesting">
        /// The declaration syntax for the parents of the <paramref name="syntax"/>.
        /// </param>
        /// <param name="hasRegistration">
        /// Indictaes whether or not the assembly within which <paramref name="subject"/> resides has registration references.
        /// </param>
        /// <returns>
        /// An instance of <see cref="Subject"/> containing the required semantics.
        /// </returns>
        /// <remarks>
        /// If the declaration associated with the type cannot be determined, the method will return <see langword="null" />.
        /// </remarks>
        public static Subject ToSubject(this INamedTypeSymbol subject, byte depth, in ImmutableArray<Nesting> nesting, bool hasRegistration)
        {
            string @namespace = subject.ContainingNamespace.IsGlobalNamespace
               ? string.Empty
               : subject.ContainingNamespace.ToDisplayString();

            string declaration = subject.GetDeclaration();

            if (declaration is null)
            {
                return default;
            }

            return new Subject
            {
                Accessibility = subject.DeclaredAccessibility,
                CanRegister = hasRegistration,
                Declaration = subject.GetDeclaration(),
                Depth = depth,
                HasContract = subject.HasContract(),
                HasRegistration = subject.HasRegistration(),
                Name = subject.Name,
                Namespace = @namespace,
                Nesting = nesting,
                Properties = subject.GetProperties(depth),
                Qualification = subject.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat),
                Type = subject.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat),
            };
        }
    }
}