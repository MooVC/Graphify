namespace Graphify.Snippets.Declarations;

internal static partial class TraverseScopeSample
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
            Expected.NavigatorShallowChildrenTraverseScopeChild,
            Expected.NavigatorDeepChildren,
            Expected.NavigatorDeepChildrenTraverseScopeChild,
            Expected.NavigatorDeepChildrenTraverseScopeChildName,
            Expected.NavigatorDeepChildrenTraverseScopeChildNameLength,
            Expected.Title,
            Expected.Description,
            Expected.DescriptionLength,
            Expected.ShallowChildren,
            Expected.ShallowChildrenTraverseScopeChild,
            Expected.DeepChildren,
            Expected.DeepChildrenTraverseScopeChild,
            Expected.DeepChildrenTraverseScopeChildName,
            Expected.DeepChildrenTraverseScopeChildNameLength,
            Expected.Registration,
        ],
        nameof(TraverseScopeSample));
}