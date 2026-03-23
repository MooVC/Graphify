namespace Graphify
{
    /// <summary>
    /// Provides extensions relating to <see cref="string"/>.
    /// </summary>
    internal static partial class StringExtensions
    {
        /// <summary>
        /// Converts the first character of the specified string to lowercase, returning the result in camel case format.
        /// </summary>
        /// <param name="name">
        /// The string to convert to camel case. If null, empty, or consists only of white-space characters, an empty string is returned.
        /// </param>
        /// <returns>
        /// A string with the first character converted to lowercase. Returns an empty string if the input is null, empty, or white space.
        /// </returns>
        public static string ToCamelCase(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return string.Empty;
            }

            return string.Concat(char.ToLowerInvariant(name[0]), name.Substring(1));
        }
    }
}