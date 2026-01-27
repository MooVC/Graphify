namespace Graphify.Snippets.Declarations;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;

internal static class Generic
{
    public static readonly Snippets Declaration = new(
        [],
        new(
            """
            using Graphify;

            [Graphify]
            public sealed partial class Generic<TElement>
            {
                public TElement Value { get; set; }
            }
            """,
            LanguageVersion.CSharp8),
        [],
        "Generic.g.cs");
}