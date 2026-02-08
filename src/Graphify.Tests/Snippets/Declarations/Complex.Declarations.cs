namespace Graphify.Snippets.Declarations;

using Microsoft.CodeAnalysis.CSharp;

internal static partial class Complex
{
    public static class Declarations
    {
        public static readonly Content CSharp1Body = new(
            """
                {
                    private int _age;
                    private Child[] _children;
                    private string _name;

                    public int Age
                    {
                        get { return _age; }
                        set { _age = value; }
                    }
            
                    public Child[] Children
                    {
                        get { return _children; }
                        set { _children = value; }
                    }

                    public string Name
                    {
                        get { return _name; }
                        set { _name = value; }
                    }
                }
            """,
            LanguageVersion.CSharp1);

        public static readonly Content CSharp3Body = new(
            """
                {
                    public int Age { get; set; }

                    public Child[] Children { get; set; }

                    public string Name { get; set; }
                }
            """,
            LanguageVersion.CSharp3);

        public static readonly Content CSharp6Body = new(
            """
                {
                    public int Age { get; }
            
                    public Child[] Children { get; }

                    public string Name { get; }
                }
            """,
            LanguageVersion.CSharp6);

        public static readonly Content CSharp9Body = new(
            """
                {
                    public int Age { get; init; }
            
                    public Child[] Children { get; init; }

                    public string Name { get; init; }
                }
            """,
            LanguageVersion.CSharp9);

        public static readonly Content Main = new(
            """
            namespace Graphify.Testing
            {
                public sealed partial class Child
                {
                    public int Age { get; set; }

                    public string Name { get; set; }
                }

                [Graphify]
                public sealed partial class Complex
            __BODY__
            }
            """,
            LanguageVersion.CSharp8);
    }
}