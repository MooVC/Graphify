namespace Graphify.Snippets.Declarations;

internal static partial class Complex
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
            Expected.NavigatorChildren,
            Expected.NavigatorChildrenChild,
            Expected.NavigatorChildrenChildAge,
            Expected.NavigatorChildrenChildName,
            Expected.NavigatorChildrenChildNameLength,
            Expected.NavigatorName,
            Expected.NavigatorNameLength,
            Expected.Age,
            Expected.Children,
            Expected.ChildrenChild,
            Expected.ChildrenChildAge,
            Expected.ChildrenChildName,
            Expected.ChildrenChildNameLength,
            Expected.Name,
            Expected.NameLength,
            Expected.Registration,
        ],
        nameof(Complex));
}