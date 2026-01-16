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
            Expected.Age,
            Expected.Children,
            Expected.ChildrenChildAge,
            Expected.ChildrenChildName,
            Expected.ChildrenChildNameLength,
            Expected.Name,
            Expected.NameLength,
        ],
        nameof(Complex));
}