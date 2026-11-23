namespace Graphify.Syntax
{
    using System.Threading;
    using MooVC.Syntax.CSharp;

    /// <summary>
    /// Provides the cancellation parameter shared by generated navigators and visitors.
    /// </summary>
    internal static class NavigatorDeclarations
    {
        /// <summary>
        /// Gets the cancellation token parameter used in generated asynchronous declarations.
        /// </summary>
        public static Parameter Cancellation { get; } = Parameter.Undefined
            .Named(nameof(CancellationToken))
            .OfType(typeof(CancellationToken));
    }
}