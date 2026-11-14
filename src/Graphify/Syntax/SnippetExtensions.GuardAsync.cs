namespace Graphify.Syntax
{
    using MooVC.Syntax;

    /// <summary>
    /// Provides extensions for generated snippets.
    /// </summary>
    internal static partial class SnippetExtensions
    {
        private const string AsyncCondition = "#if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER";

        /// <summary>
        /// Wraps generated code in the conditional compilation guard for asynchronous declarations.
        /// </summary>
        /// <param name="code">The generated code to guard.</param>
        /// <returns>The code enclosed by the asynchronous framework condition.</returns>
        public static Snippet GuardAsync(this Snippet code)
        {
            return code
                .Prepend(Configuration.Options, AsyncCondition)
                .Append(Configuration.Options, "#endif");
        }
    }
}