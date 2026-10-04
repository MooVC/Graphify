namespace Graphify.Semantics
{
    using System.Collections.Immutable;
    using System.Linq;
    using Graphify.Strategies;
    using Microsoft.CodeAnalysis;
    using static Graphify.Names;

    /// <summary>
    /// Provides extensions relating to <see cref="INamedTypeSymbol"/>.
    /// </summary>
    internal static partial class INamedTypeSymbolExtensions
    {
        private const int ExpectedParametersForRegistration = 1;

        /// <summary>
        /// Determines whether the specified type symbol has an associated registration extension method for the navigator in its containing namespace.
        /// </summary>
        /// <param name="symbol">The type symbol to check for an associated extension. Cannot be <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"> if a extension exists in the same namespace as the specified symbol;
        /// otherwise, <see langword="false">.
        /// </returns>
        /// <remarks>
        /// It doesn't matter if the method actually performs registration; only that a method exists that conflicts with the expected signature.
        /// </remarks>
        public static bool HasRegistration(this INamedTypeSymbol symbol)
        {
            string asynchronousName = string.Concat(RegistrationMethodPrefix, AsynchronousNavigatorStrategy.GetName(symbol.Name));
            string synchronousName = string.Concat(RegistrationMethodPrefix, SynchronousNavigatorStrategy.GetName(symbol.Name));
            ImmutableArray<INamedTypeSymbol> types = symbol.ContainingNamespace.GetTypeMembers(RegistrationClassName);

            foreach (INamedTypeSymbol type in types)
            {
                if (!type.IsStatic)
                {
                    return false;
                }

                bool hasMatch = type
                                        .GetMembers()
                    .OfType<IMethodSymbol>()
                    .Any(method =>
                        method.Parameters.Length == ExpectedParametersForRegistration &&
                        (method.Name == asynchronousName || method.Name == synchronousName));

                if (hasMatch)
                {
                    return true;
                }
            }

            return false;
        }
    }
}