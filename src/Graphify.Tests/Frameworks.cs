namespace Graphify;

using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

internal static class Frameworks
{
    private static readonly IReadOnlyList<(ReferenceAssemblies Assembly, LanguageVersion Maximum, DateOnly SupportTo)> _inScope =
    [
        (ReferenceAssemblies.Net.Net60, LanguageVersion.CSharp10, new DateOnly(2024, 11, 12)),
        (ReferenceAssemblies.Net.Net70, LanguageVersion.CSharp11, new DateOnly(2024, 5, 14)),
        (ReferenceAssemblies.Net.Net80, LanguageVersion.CSharp12, new DateOnly(2026, 11, 10)),
        (ReferenceAssemblies.Net.Net90, LanguageVersion.CSharp13, new DateOnly(2026, 11, 10)),
        (ReferenceAssemblies.Net.Net100, LanguageVersion.CSharp14, new DateOnly(2028, 11, 14)),
        (ReferenceAssemblies.NetStandard.NetStandard21, LanguageVersion.CSharp8, DateOnly.MaxValue),
    ];

#if CI
    private static readonly LanguageVersion[] _languages;

    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "The removal suggestion is a false positive.")]
    [SuppressMessage("Minor Code Smell", "S3963:\"static\" fields should be initialized inline", Justification = "It cannot be initialized inline.")]
    static Frameworks()
    {
        _languages = Enum.GetValues<LanguageVersion>();
    }
#endif

    public static IEnumerable<(ReferenceAssemblies Assembly, LanguageVersion Language)> Cases(LanguageVersion minimum)
    {
#if CI
        return Filter(_inScope, maximum => _languages.Where(language => language >= minimum && language <= maximum));
#else
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        return Filter(_inScope.Where(framework => framework.SupportTo >= today && framework.Maximum >= minimum), maximum => [maximum]);
#endif
    }

    public static IEnumerable<(ReferenceAssemblies Assembly, LanguageVersion Language)> DefaultCases()
    {
        return Cases(LanguageVersion.CSharp8);
    }

    private static IEnumerable<(ReferenceAssemblies Assembly, LanguageVersion Language)> Filter(
        IEnumerable<(ReferenceAssemblies Assembly, LanguageVersion Maximum, DateOnly SupportedTo)> frameworks,
        Func<LanguageVersion, IEnumerable<LanguageVersion>> languages)
    {
        foreach ((ReferenceAssemblies assembly, LanguageVersion maximum, DateOnly _) in frameworks)
        {
            foreach (LanguageVersion language in languages(maximum))
            {
                yield return (assembly, language);
            }
        }
    }
}