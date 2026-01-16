namespace Graphify.Snippets;

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;
using Xunit.Sdk;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class SnippetsAttribute
    : DataAttribute
{
#if CI

    private static readonly GetFrameworks _frameworks = Frameworks.All;

#else

    private static readonly GetFrameworks _frameworks = Frameworks.Supported;

#endif

    private static readonly ReferenceAssemblies[] _assemblies = FindAssemblies();
    private static readonly Type[] _declarations = FindDeclarations();
    private static readonly LanguageVersion[] _languages = FindLanguages();

    public SnippetsAttribute(Type[]? exclusions = default, Type[]? inclusions = default)
    {
        Assemblies = _assemblies;

        Declarations = inclusions is null
            ? _declarations
            : [.. inclusions.Intersect(_declarations)];

        if (exclusions is not null)
        {
            Declarations = [.. Declarations.Except(exclusions)];
        }

        Languages = _languages;
    }

    private delegate IEnumerable<object[]> GetFrameworks(LanguageVersion minimum, Func<ReferenceAssemblies, LanguageVersion, object[]?>? prepare);

    public IReadOnlyList<ReferenceAssemblies> Assemblies { get; }

    public IReadOnlyList<Type> Declarations { get; }

    public IReadOnlyList<LanguageVersion> Languages { get; }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        FieldInfo[] fields = [.. Declarations.SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static))];

        foreach (FieldInfo field in fields.Where(field => field.FieldType == typeof(Snippets)))
        {
            object? value = field.GetValue(default);

            if (value is Snippets snippets)
            {
                IEnumerable<Expectations> expectations = snippets.Render();

                foreach (Expectations expectation in expectations)
                {
                    object[]? Prepare(ReferenceAssemblies assembly, LanguageVersion language)
                    {
                        if (Languages.Contains(language) && Assemblies.Contains(assembly))
                        {
                            return [assembly, expectation, language];
                        }

                        return default;
                    }

                    foreach (object[] theory in _frameworks(expectation.Minimum, Prepare))
                    {
                        yield return theory;
                    }
                }
            }
        }
    }

    private static ReferenceAssemblies[] FindAssemblies()
    {
        return [.. Frameworks.InScope.Select(framework => framework.Assembly)];
    }

    private static Type[] FindDeclarations()
    {
        return [.. Assembly
            .GetAssembly(typeof(SnippetsAttribute))!
            .GetTypes()
            .Where(type => type.Namespace == "Graphify.Snippets.Declarations")];
    }

    private static LanguageVersion[] FindLanguages()
    {
        return Enum.GetValues<LanguageVersion>();
    }
}