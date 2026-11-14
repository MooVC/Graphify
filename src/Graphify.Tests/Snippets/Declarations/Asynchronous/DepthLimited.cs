namespace Graphify.Snippets.Declarations.Asynchronous;

internal static partial class DepthLimited
{
    public static readonly Snippets Declaration = new(
        [],
        Declarations.Main,
        [
            Boilerplate.Root(nameof(DepthLimited), "Graphify.Testing.Asynchronous"),
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorChild,
            Expected.Registration,
            Expected.Visitor,
            Expected.Child,
        ],
        nameof(DepthLimited));
}