namespace Graphify;

using System;
using System.Linq;
using Graphify.Model;
using Graphify.Strategies;
using Graphify.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

/// <summary>
/// Generates source for a type that is annotated with the Graphify attribute.
/// </summary>
[Generator(LanguageNames.CSharp)]
public sealed class TypeGenerator
    : IIncrementalGenerator
{
    private static readonly IStrategy[] _strategies = new IStrategy[]
    {
        new CloneStrategy(),
    };

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<TypeDeclarationSyntax?> classes = context
            .SyntaxProvider
            .CreateSyntaxProvider(predicate: IsMatch, transform: Transform)
            .Where(record => record is not null);

        IncrementalValuesProvider<Subject?> subjects = classes
           .Combine(context.CompilationProvider)
           .Select(static (match, cancellationToken) => Parse(match.Left, match.Right, cancellationToken))
           .Where(subject => subject is not null);

        context.RegisterSourceOutput(subjects, Generate);
    }

    private static void Generate(SourceProductionContext context, Subject? subject)
    {
        if (subject is not null)
        {
#if DEBUG
            Dictionary<string, string> files = new();
#endif

            foreach (IStrategy strategy in _strategies)
            {
                IEnumerable<Source> sources = strategy.Generate(subject);

                foreach (Source source in sources)
                {
                    string code = Wrap(source.Code, subject);
                    string hint = GetHint(source, subject);

#if DEBUG
                    files[hint] = code;
#endif

                    context.AddSource(hint, code);
                }
            }
        }
    }

    private static string GetHint(Source source, Subject subject)
    {
        string name = subject.Nesting
            .Select(parent => parent.Name)
            .Concat(new[] { subject.Name })
            .Aggregate(
                string.Empty,
                (current, next) => string.IsNullOrEmpty(current)
                    ? next
                    : $"{current}.{next}");

        string separator = source.Hint.StartsWith(".")
            ? string.Empty
            : ".";

        return $"{subject.Namespace}.{name}{separator}{source.Hint}.g.cs";
    }

    private static bool IsMatch(SyntaxNode node, CancellationToken cancellationToken)
    {
        return node is TypeDeclarationSyntax type && type.AttributeLists.Count > 0;
    }

    private static Subject? Parse(TypeDeclarationSyntax? syntax, Compilation compilation, CancellationToken cancellationToken)
    {
        return syntax.ToSubject(compilation, cancellationToken);
    }

    private static TypeDeclarationSyntax? Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        return context.Node as TypeDeclarationSyntax;
    }

    private static string Nest(string code, Subject subject)
    {
        foreach (Nesting parent in subject.Nesting.Reverse())
        {
            code = code.Indent();

            code = $$"""
                {{parent.Declaration}} {{parent.Qualification}}
                {
                    {{code}}
                }
                """;
        }

        return code;
    }

    private static string Wrap(string code, Subject subject)
    {
        code = Nest(code, subject);

        code = $"""
            using System;
            using System.Collections.Generic;

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable disable
            #endif

            {code}

            #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            #nullable restore
            #endif
            """;

        if (subject.IsGlobal)
        {
            return code;
        }

        return $$"""
            namespace {{subject.Namespace}}
            {
                {{code.Indent()}}
            }
            """;
    }
}