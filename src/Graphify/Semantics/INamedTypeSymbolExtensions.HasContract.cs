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

        public static bool HasContract(this INamedTypeSymbol symbol)
        {
            string name = ContractStrategy.GetName(symbol.Name);

            return symbol.ContainingNamespace
                .GetTypeMembers(name)
                .Any(type => type.Arity == ExpectedArityForContract);
        }
    }
}