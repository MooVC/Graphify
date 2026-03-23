namespace Graphify
{
    internal static partial class StringExtensions
    {
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