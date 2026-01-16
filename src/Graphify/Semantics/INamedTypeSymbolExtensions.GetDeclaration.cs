namespace Graphify.Semantics
{
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        /// <summary>
        /// Determines whether or not the <paramref name="subject"/> provided is supported by Graphify.
        /// </summary>
        /// <param name="subject">
        /// The symbol for the type to be checked for Graphify support.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the type is annotated and partial, otherwise <see langword="false"/>.
        /// </returns>
        public static string GetDeclaration(this INamedTypeSymbol subject)
        {
            string prefix = subject.IdentifyPrefix();
            string type = subject.IdentifyType();

            return string
                .Join(" ", prefix, "partial", type)
                .TrimStart();
        }

        private static string IdentifyPrefix(this INamedTypeSymbol symbol)
        {
            string @ref = symbol.IsRefLikeType
                ? "ref"
                : string.Empty;

            string @readonly = symbol.IsReadOnly
                ? "readonly"
                : string.Empty;

            return string
                .Join(" ", @readonly, @ref)
                .Trim();
        }

        private static string IdentifyType(this INamedTypeSymbol symbol)
        {
            switch (symbol.TypeKind)
            {
                case TypeKind.Class:
                    return symbol.IsRecord ? "record" : "class";

                case TypeKind.Struct:
                    return symbol.IsRecord ? "record struct" : "struct";

                case TypeKind.Interface:
                    return "interface";

                default:
                    return string.Empty;
            }
        }
    }
}