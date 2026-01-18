namespace Graphify.Snippets.Declarations;

internal static partial class Complex
{
    public static class Expected
    {
        public static readonly Generated Age = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Age
                            {
                                internal Age(global::Graphify.Testing.Complex root, int value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Complex Root { get; private set; }

                                public int Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Age");

        public static readonly Generated Children = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Children
                            {
                                internal Children(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Complex Root { get; private set; }

                                public global::Graphify.Testing.Child[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Children");

        public static readonly Generated ChildrenChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Child
                            {
                                internal Child(int index, global::Graphify.Testing.Complex root, global::Graphify.Testing.Child value)
                                {
                                    Index = index;
                                    Root = root;
                                    Value = value;
                                }

                                public int Index { get; private set; }

                                public global::Graphify.Testing.Complex Root { get; private set; }

                                public global::Graphify.Testing.Child Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Children.Child");

        public static readonly Generated ChildrenChildAge = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            partial class Children
                            {
                                partial class Child
                                {
                                    public sealed partial class Age
                                    {
                                        internal Age(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] children, global::Graphify.Testing.Child child, int value)
                                        {
                                            Children = children;
                                            Child = child;

                                            Root = root;
                                            Value = value;
                                        }

                                        public global::Graphify.Testing.Complex Root { get; private set; }

                                        public global::Graphify.Testing.Child[] Children { get; private set; }

                                        public global::Graphify.Testing.Child Child { get; private set; }

                                        public int Value { get; private set; }
                                    }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Children.Child.Age");

        public static readonly Generated ChildrenChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            partial class Children
                            {
                                partial class Child
                                {
                                    public sealed partial class Name
                                    {
                                        internal Name(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] children, global::Graphify.Testing.Child child, string value)
                                        {
                                            Children = children;
                                            Child = child;

                                            Root = root;
                                            Value = value;
                                        }

                                        public global::Graphify.Testing.Complex Root { get; private set; }

                                        public global::Graphify.Testing.Child[] Children { get; private set; }

                                        public global::Graphify.Testing.Child Child { get; private set; }

                                        public string Value { get; private set; }
                                    }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Children.Child.Name");

        public static readonly Generated ChildrenChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            partial class Children
                            {
                                partial class Child
                                {
                                    partial class Name
                                    {
                                        public sealed partial class Length
                                        {
                                            internal Length(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] children, global::Graphify.Testing.Child child, string name, int value)
                                            {
                                                Children = children;
                                                Child = child;
                                                Name = name;

                                                Root = root;
                                                Value = value;
                                            }

                                            public global::Graphify.Testing.Complex Root { get; private set; }

                                            public global::Graphify.Testing.Child[] Children { get; private set; }

                                            public global::Graphify.Testing.Child Child { get; private set; }

                                            public string Name { get; private set; }

                                            public int Value { get; private set; }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Children.Child.Name.Length");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public interface IComplexNavigator
                    {
                        global::System.Threading.Tasks.Task Navigate(Complex complex, global::System.Threading.CancellationToken cancellationToken);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.IComplexNavigator");

        public static readonly Generated Name = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Name
                            {
                                internal Name(global::Graphify.Testing.Complex root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Complex Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Name");

        public static readonly Generated NameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            partial class Name
                            {
                                public sealed partial class Length
                                {
                                    internal Length(global::Graphify.Testing.Complex root, string name, int value)
                                    {
                                        Name = name;

                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.Complex Root { get; private set; }

                                    public string Name { get; private set; }

                                    public int Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Name.Length");
    }
}