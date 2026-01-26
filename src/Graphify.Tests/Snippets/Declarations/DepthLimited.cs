namespace Graphify.Snippets.Declarations;

internal static partial class DepthLimited
{
    public static readonly Snippets Declaration = new(
        [],
        Declarations.Main,
        [
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorChild,
            Expected.Child,
            Expected.Registration,
        ],
        nameof(DepthLimited));
}