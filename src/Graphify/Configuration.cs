namespace Graphify
{
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;

    internal static class Configuration
    {
        private static readonly Qualification.Options _qualifications = Qualification.Options.Default
            .WithFormat(Qualification.Options.Formats.Global);

        public static Options Options { get; } = new Options()
            .WithNamespace(Qualifier.Options.Block)
            .WithTypes(types => types
                .WithQualifications(_qualifications)
                .WithMethods(methods => methods.WithQualifications(_qualifications))
                .WithProperties(properties => properties.WithQualifications(_qualifications)));
    }
}