namespace Graphify.Snippets.Declarations.Synchronous;

internal static partial class DepthLimited
{
    public static readonly Snippets Declaration = new(
        [],
        Declarations.Main,
        [
            Boilerplate.Root(nameof(DepthLimited), "Graphify.Testing.Synchronous"),
            Expected.Child,
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorChild,
            Expected.Registration,
            Expected.Visitor,
        ],
        nameof(DepthLimited));
}