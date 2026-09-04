namespace Graphify.Snippets.Declarations.Synchronous;

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
            Expected.Age,
            Expected.IsAdult,
            Expected.Name,
            Expected.NameLength,
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorAge,
            Expected.NavigatorIsAdult,
            Expected.NavigatorName,
            Expected.NavigatorNameLength,
            Expected.Registration,
            Expected.Visitor,
        ],
        nameof(Simple));
}