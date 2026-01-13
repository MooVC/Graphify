namespace Graphify.Semantics;

using Microsoft.CodeAnalysis;

/// <summary>
/// Provides extensions relating to <see cref="ISymbol"/>.
/// </summary>
internal static partial class ISymbolExtensions
{
    private static readonly SymbolDisplayFormat _fullyQualifiedFormat = new(
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
        genericsOptions: SymbolDisplayGenericsOptions.None);

    private static readonly SymbolDisplayFormat _minimallyQualifiedFormat = new(
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly,
        genericsOptions: SymbolDisplayGenericsOptions.None);

    /// <summary>
    /// Determines whether or not the <paramref name="subject"/> represents the attribute specified using <paramref name="name"/>.
    /// </summary>
    /// <param name="subject">
    /// The symbol to check.
    /// </param>
    /// <param name="name">
    /// The name of the attribute (without the suffix).
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the <paramref name="subject"/> is the Graphify attribute, otherwise <see langword="false"/>.
    /// </returns>
    public static bool IsAttribute(this ISymbol? subject, string name)
    {
        string qualifiedName = $"{name}Attribute";
        string fullyQualifiedName = $"Graphify.{qualifiedName}";
        string globalQualifiedName = $"global::{fullyQualifiedName}";

        bool IsGlobal()
        {
            return subject.ContainingNamespace.IsGlobalNamespace && subject.ToDisplayString(_minimallyQualifiedFormat) == name;
        }

        bool IsQualified()
        {
            string name = subject.ToDisplayString(_fullyQualifiedFormat);

            return name == qualifiedName || name == fullyQualifiedName || name == globalQualifiedName;
        }

        return subject is not null
            && (IsQualified() || IsGlobal() || subject.Name == name);
    }
}