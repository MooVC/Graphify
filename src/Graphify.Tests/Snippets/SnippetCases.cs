namespace Graphify.Snippets;

using System.Reflection;
using Graphify.Snippets.Declarations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

internal static class SnippetCases
{
    private static readonly string _declarationsNamespace = typeof(Boilerplate).Namespace!;

    private static readonly Type[] _declarations =
    [
        .. typeof(SnippetCases).Assembly.GetTypes()
            .Where(type => type.Namespace == _declarationsNamespace || type.Namespace?.StartsWith(_declarationsNamespace + ".", StringComparison.Ordinal) == true),
    ];

    public static IEnumerable<TestDataRow<(ReferenceAssemblies Assembly, Expectations Expectations, LanguageVersion Language)>> Create(
        Type[]? inclusions = null,
        Type[]? exclusions = null)
    {
        IEnumerable<Type> declarations = inclusions is null ? _declarations : inclusions.Intersect(_declarations);

        if (exclusions is not null)
        {
            declarations = declarations.Except(exclusions);
        }

        IEnumerable<FieldInfo> fields = declarations
            .SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))
            .Where(field => field.FieldType == typeof(Snippets));

        foreach (FieldInfo field in fields)
        {
            if (field.GetValue(null) is Snippets snippets)
            {
                string declaration = field.DeclaringType!.FullName![(_declarationsNamespace.Length + 1)..].Replace('+', '.');
                int variant = 0;

                foreach (Expectations expectation in snippets.Render())
                {
                    variant++;

                    foreach ((ReferenceAssemblies assembly, LanguageVersion language) in Frameworks.Cases(expectation.Minimum))
                    {
                        yield return new(
                            (assembly, expectation, language),
                            DisplayName: $"{declaration}.{field.Name} [{variant}] ({assembly.TargetFramework}, {language})");
                    }
                }
            }
        }
    }
}