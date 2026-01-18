namespace Graphify
{
    using System.Text;

    /// <summary>
    /// Represents a formatting helper string extensions.
    /// </summary>
    internal static partial class StringExtensions
    {
        /// <summary>
        /// Performs the to camel case operation for the formatting helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The string.</returns>
        public static string ToCamelCase(this string value)
        {
            const int FirstCharacterIndex = 0;
            const int RemainingCharactersOffset = 1;

            int length = value.Length;
            var builder = new StringBuilder(length);

            char firstCharacter = char.ToLower(value[FirstCharacterIndex]);

            builder = builder.Append(firstCharacter);

            if (length > RemainingCharactersOffset)
            {
                builder = builder.Append(value, RemainingCharactersOffset, length - RemainingCharactersOffset);
            }

            return builder.ToString();
        }
    }
}