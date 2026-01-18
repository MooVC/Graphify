namespace Graphify.Snippets.Declarations;

internal static partial class Simple
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

                    partial class Simple
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Age
                            {
                                internal Age(global::Graphify.Testing.Simple root, int value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Simple Root { get; private set; }

                                public int Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Simple.Age");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public interface ISimpleNavigator
                    {
                        global::System.Threading.Tasks.Task Navigate(Simple simple, global::System.Threading.CancellationToken cancellationToken);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ISimpleNavigator");

        public static readonly Generated IsAdult = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public static partial class Graph
                        {
                            public sealed partial class IsAdult
                            {
                                internal IsAdult(global::Graphify.Testing.Simple root, bool value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Simple Root { get; private set; }

                                public bool Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Simple.IsAdult");

        public static readonly Generated Name = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Name
                            {
                                internal Name(global::Graphify.Testing.Simple root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Simple Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Simple.Name");

        public static readonly Generated NameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public static partial class Graph
                        {
                            partial class Name
                            {
                                public sealed partial class Length
                                {
                                    internal Length(global::Graphify.Testing.Simple root, string name, int value)
                                    {
                                        Name = name;

                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.Simple Root { get; private set; }

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
            "Graphify.Testing.Simple.Name.Length");
    }
}