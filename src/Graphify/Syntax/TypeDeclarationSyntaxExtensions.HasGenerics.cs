namespace Graphify.Syntax
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    /// <summary>
    /// Provides extensions relating to <see cref="TypeDeclarationSyntax"/>.
    /// </summary>
    internal static partial class TypeDeclarationSyntaxExtensions
    {
        /// <summary>
        /// Determines whether or not the <paramref name="syntax"/> provided is defines generic parameters.
        /// </summary>
        /// <param name="syntax">
        /// The declaration for the type to be checked for the presence of generics.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the type defines generics, otherwise <see langword="false"/>.
        /// </returns>
        public static bool HasGenerics(this TypeDeclarationSyntax syntax)
        {
            return syntax.TypeParameterList is object && syntax.TypeParameterList.Parameters.Count > 0;
        }
    }
}