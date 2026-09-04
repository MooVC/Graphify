namespace Graphify.Snippets.Declarations.Asynchronous;

internal static partial class Traversals
{
    public static readonly Snippets Declaration = new(
        [],
        Declarations.Main,
        [
            Expected.Contract,
            Expected.Navigator,
            Expected.NavigatorTitle,
            Expected.NavigatorDescription,
            Expected.NavigatorDescriptionLength,
            Expected.NavigatorShallowChildren,
            Expected.NavigatorShallowChildrenTraversalChild,
            Expected.NavigatorDeepChildren,
            Expected.NavigatorDeepChildrenTraversalChild,
            Expected.NavigatorDeepChildrenTraversalChildName,
            Expected.NavigatorDeepChildrenTraversalChildNameLength,
            Expected.Registration,
            Expected.Visitor,
            Expected.Title,
            Expected.Description,
            Expected.DescriptionLength,
            Expected.ShallowChildren,
            Expected.ShallowChildrenTraversalChild,
            Expected.DeepChildren,
            Expected.DeepChildrenTraversalChild,
            Expected.DeepChildrenTraversalChildName,
            Expected.DeepChildrenTraversalChildNameLength,
        ],
        nameof(Traversals));
}