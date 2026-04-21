namespace Graphify.Snippets.Declarations.Synchronous;

internal static partial class DepthLimited
{
    public static readonly Snippets Declaration = new(
        [],
        Declarations.Main,
        [
            Expected.Child,
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorChild,
            Expected.Registration,
        ],
        nameof(DepthLimited));
}