namespace Graphify.Semantics
{
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
        public static bool HasContract(this INamedTypeSymbol symbol)
        {
            string asynchronous = AsynchronousContractStrategy.GetName(symbol.Name);
            string synchronous = SynchronousContractStrategy.GetName(symbol.Name);

            return symbol.ContainingNamespace
                .GetTypeMembers()
                .Any(type =>
                    type.Arity == ExpectedArityForContract &&
                    (type.Name == asynchronous || type.Name == synchronous));
        }
    }
}
