namespace Graphify.Syntax
{
    using Microsoft.CodeAnalysis;
    using MooVC.Syntax.CSharp;

    internal static partial class AccessibilityExtensions
    {
        public static Scopes ToScope(this Accessibility accessibility)
        {
            return accessibility == Accessibility.Internal ? Scopes.Internal : Scopes.Public;
        }
    }
}