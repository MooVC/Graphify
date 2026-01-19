namespace Graphify.Semantics
{
    using System;
    using System.Linq;
    using Graphify.Strategies;
    using Microsoft.CodeAnalysis;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        private const int ExpectedArityForContract = 0;

        /// <summary>
        /// Determines whether the specified type symbol has an associated contract for the navigator in its containing namespace.
        /// </summary>
        /// <param name="symbol">The type symbol to check for an associated contract. Cannot be <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"> if a contract type with the expected arity exists in the same namespace as the specified symbol;
        /// otherwise, <see langword="false">.
        /// </returns>
        public static bool HasContract(this INamedTypeSymbol symbol)
        {
            string name = ContractStrategy.GetName(symbol.Name);

            return symbol.ContainingNamespace
                .GetTypeMembers(name)
                .Any(type => type.Arity == ExpectedArityForContract);
        }
    }
}