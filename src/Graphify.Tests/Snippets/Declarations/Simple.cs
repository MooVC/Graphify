namespace Graphify.Snippets.Declarations;

internal static partial class Simple
{
    public static readonly Snippets Declaration = new(
        [
            Declarations.CSharp1Body,
            Declarations.CSharp3Body,
            Declarations.CSharp6Body,
            Declarations.CSharp9Body,
        ],
        Declarations.Main,
        [
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorAge,
            Expected.NavigatorIsAdult,
            Expected.NavigatorName,
            Expected.NavigatorNameLength,
            Expected.Age,
            Expected.IsAdult,
            Expected.Name,
            Expected.NameLength,
            Expected.Registration,
        ],
        nameof(Simple));
}