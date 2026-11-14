namespace Graphify.Syntax
{
    using MooVC.Syntax.CSharp;

    internal static partial class StringExtensions
    {
        private const string ResultName = "TResult";
        private static readonly Symbol _resultType = (Qualification)ResultName;

        /// <summary>
        /// Creates a generic navigation method that returns a sequence of results.
        /// </summary>
        /// <param name="name">The generated method name.</param>
        /// <param name="asynchronous">Whether the method returns an asynchronous sequence.</param>
        /// <returns>The method declaration with its result type parameter and return type.</returns>
        public static Method ToNavigationMethod(this string name, bool asynchronous)
        {
            return Method.Undefined
                .Named(((Declaration)name).WithArguments(Generic.Undefined.Named(ResultName)))
                .Returns(Result.Void.OfType(_resultType.ToSequence(asynchronous)));
        }
    }
}