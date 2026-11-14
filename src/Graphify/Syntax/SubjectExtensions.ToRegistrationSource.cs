namespace Graphify.Syntax
{
    using Graphify.Model;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;
    using static Graphify.Syntax.SubjectExtensions_ToRegistrationSource_Resources;

    /// <summary>
    /// Provides extensions for rendering a subject's navigator registration.
    /// </summary>
    internal static partial class SubjectExtensions
    {
        public static Source ToRegistrationSource(this Subject subject, bool asynchronous)
        {
            string name = GetNavigatorName(subject.Name);
            string contract = subject.Qualify(GetNavigatorContractName(subject.Name));
            string method = string.Concat(RegistrationMethodPrefix, name);
            Symbol collection = (Name: "IServiceCollection", Qualifier: "Microsoft.Extensions.DependencyInjection");
            var body = Snippet.From(Configuration.Options, string.Format(GenerateBody, contract, subject.Qualify(name)));

            var code = Class.Undefined.Named(RegistrationClassName)
                .IsStatic(true)
                .WithMethods(registration => registration
                    .Named(method)
                    .WithExtensibility(Modifiers.Static)
                    .Accepts(parameter => parameter.Named("Services").OfType(collection).WithModifier(Parameter.Modes.This))
                    .Returns(Result.Void.OfType(collection))
                    .WithBody(body))
                .ToSnippet(Configuration.Options);

            return new Source(asynchronous ? code.GuardAsync() : code, $"{RegistrationClassName}.{method}");
        }
    }
}