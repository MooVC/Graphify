namespace Graphify.Syntax
{
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;

    /// <summary>
    /// Builds blocks for generated graph declarations.
    /// </summary>
    internal static class GenerationSyntax
    {
        private static readonly Options _options = new Options()
            .WithNamespace(Qualifier.Options.Block)
            .WithTypes(types => types.WithQualifications(qualifications => qualifications
                .WithFormat(Qualification.Options.Formats.Global)));

        public static string Block(string body, string declaration)
        {
            return Snippet.From(body.Replace("\r\n", "\n").Split('\n')).Block(_options, declaration).ToString();
        }
    }
}