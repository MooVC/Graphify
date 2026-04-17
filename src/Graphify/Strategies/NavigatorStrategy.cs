namespace Graphify.Strategies
{
    /// <summary>
    /// Provides shared naming for generated navigator implementations.
    /// </summary>
    internal static class NavigatorStrategy
    {
        /// <summary>
        /// Generates a standardized navigator name for the specified subject.
        /// </summary>
        /// <param name="subject">The name of the subject for which to generate the navigator name. Cannot be <see langword="null"/>.</param>
        /// <returns>A string representing the navigator name in the format "{subject}Navigator".</returns>
        public static string GetName(string subject)
        {
            return $"{subject}Navigator";
        }
    }
}
