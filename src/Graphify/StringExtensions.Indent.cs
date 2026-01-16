namespace Graphify
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// Provides extensions relating to <see cref="string"/>.
    /// </summary>
    internal static partial class StringExtensions
    {
        private const string Default = "    ";

        /// <summary>
        /// Adds the specified <paramref name="whitespace"/> to the beginning of each non-blank line in the input string.
        /// </summary>
        /// <param name="input">
        /// The input string to process.
        /// </param>
        /// <param name="skip">
        /// The number of initial lines to skip when considering the application of whitespace.
        /// </param>
        /// <param name="times">
        /// Specifies the number of times indentation should be applied.
        /// </param>
        /// <param name="whitespace">
        /// The whitespace to apply when indenting.
        /// </param>
        /// <returns>
        /// A new string with <paramref name="whitespace"/> added to the start of each non-blank line.
        /// </returns>
        public static string Indent(this string input, int skip = 1, int times = 1, string whitespace = Default)
        {
            if (times <= 0)
            {
                return input;
            }

            if (times > 1)
            {
                whitespace = GenerateWhitespace(times, whitespace);
            }

            var reader = new StringReader(input);
            var builder = new StringBuilder();
            string line = reader.ReadLine();
            int offset = 0;

            while (line is object)
            {
                if (++offset > skip && !string.IsNullOrWhiteSpace(line))
                {
                    builder = builder.Append(whitespace);
                }

                builder = builder.Append(line);
                builder = builder.AppendLine();
                line = reader.ReadLine();
            }

            return builder
                .ToString()
                .TrimEnd();
        }

        private static string GenerateWhitespace(int times, string whitespace)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                builder = builder.Append(whitespace);
            }

            whitespace = builder.ToString();
            return whitespace;
        }
    }
}