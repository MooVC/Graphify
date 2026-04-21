namespace Graphify.Snippets.Declarations.Asynchronous;

internal static partial class DepthLimited
{
    public static readonly Snippets Declaration = new(
        [],
        Declarations.Main,
        [
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorChild,
            Expected.Registration,
            Expected.Child,
        ],
        nameof(DepthLimited));
}