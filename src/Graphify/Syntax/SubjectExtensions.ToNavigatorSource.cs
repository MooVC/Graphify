namespace Graphify.Syntax
{
    using System;
    using Graphify.Model;
    using MooVC.Syntax;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;
    using static Graphify.Syntax.SubjectExtensions_ToNavigatorSource_Resources;

    /// <summary>
    /// Provides extensions for rendering a subject's navigator.
    /// </summary>
    internal static partial class SubjectExtensions
    {
        public static Source ToNavigatorSource(this Subject subject, string navigateBody, string invokeBody, string propertyCall, bool asynchronous)
        {
            string name = GetNavigatorName(subject.Name);
            var root = subject.Type.ToSymbol();
            var contract = subject.Qualify(GetNavigatorContractName(subject.Name)).ToSymbol();

            string calls = subject.Depth > 0
                ? subject.Properties.ToNavigatorCalls(string.Empty, string.Empty, propertyCall).Trim()
                : string.Empty;

            Method navigate = "Navigate".ToNavigationMethod(asynchronous)
                .Accepts(parameter => parameter.Named("Root").OfType(root))
                .WithBody(Snippet.From(Configuration.Options, string.Format(navigateBody, calls)));

            Method invoke = CreateInvoke(subject, root, invokeBody, asynchronous);

            if (asynchronous)
            {
                navigate = navigate.Accepts(NavigatorDeclarations.Cancellation);
                invoke = invoke.Accepts(NavigatorDeclarations.Cancellation);
            }

            var code = subject.ToNavigatorClass()
                .Implements(contract)
                .WithFields(provider => provider.Named("_provider").OfType(typeof(IServiceProvider)))
                .WithConstructors(constructor => constructor
                    .WithParameters(parameter => parameter.Named("Provider").OfType("global::System.IServiceProvider".ToSymbol()))
                    .WithBody(Snippet.From(Configuration.Options, GenerateConstructorBody)))
                .WithMethods(navigate, invoke)
                .ToSnippet(Configuration.Options);

            return new Source(asynchronous ? code.GuardAsync() : code, name);
        }

        private static Method CreateInvoke(Subject subject, Symbol root, string body, bool asynchronous)
        {
            const string InstanceName = "TInstance";
            const string ResultName = "TResult";
            Symbol instance = (Qualification)InstanceName;
            Symbol result = (Qualification)ResultName;
            Symbol observer = subject.ToObserverType(instance, result);
            Constraint constraint = root.ToGraphConstraint();

            Declaration declaration = ((Declaration)"Invoke").WithArguments(
                Generic.Undefined.Named(InstanceName).WithConstraints(constraint),
                Generic.Undefined.Named(ResultName));

            string visitor = subject.Qualify($"{InterfaceNamePrefix}{subject.Name}{VisitorTypeSuffix}");

            return Method.Undefined.Named(declaration)
                .WithScope(Scopes.Private)
                .Accepts(parameter => parameter.Named("Instance").OfType(instance))
                .Accepts(parameter => parameter.Named("Visitors").OfType(observer.ToSequence()))
                .Returns(Result.Void.OfType(result.ToSequence(asynchronous)))
                .WithBody(Snippet.From(Configuration.Options, string.Format(body, visitor)));
        }
    }
}