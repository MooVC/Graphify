namespace Graphify.Syntax
{
    using Graphify.Model;
    using static Graphify.Names;

    /// <summary>
    /// Provides extensions for rendering a subject's navigator.
    /// </summary>
    internal static partial class SubjectExtensions
    {
        public static Source ToNavigatorSource(this Subject subject, string template, string propertyCall)
        {
            string name = GetNavigatorName(subject.Name);
            string contract = subject.Qualify(GetNavigatorContractName(subject.Name));
            string visitor = subject.Qualify($"{InterfaceNamePrefix}{subject.Name}{VisitorTypeSuffix}");
            string body = subject.Depth > 0
                ? subject.Properties.ToNavigatorCalls(string.Empty, string.Empty, propertyCall).Indent(skip: 0, times: 2, trim: false)
                : string.Empty;
            string accessibility = subject.Accessibility.ToString().ToLowerInvariant();
            string code = string.Format(template, accessibility, name, contract, subject.Type, body, visitor);

            return new Source(code, name);
        }
    }
}