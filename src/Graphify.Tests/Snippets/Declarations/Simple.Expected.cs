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
            "Graphify.Testing.Simple.Age.g.cs");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public partial interface ISimpleNavigator
                        : global::Graphify.INavigator<Simple>
                    {
                        //// Additional methods can be added as partial elements
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ISimpleNavigator.g.cs");

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
            "Graphify.Testing.Simple.IsAdult.g.cs");

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
            "Graphify.Testing.Simple.Name.g.cs");

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
                            public partial class Name
                            {
                                public sealed partial class Length
                                {
                                    internal Length(global::Graphify.Testing.Simple root, string param0, int value)
                                    {
                                        Name = param0;

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
            "Graphify.Testing.Simple.Name.Length.g.cs");

        public static readonly Generated NavigatorAge = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateAge<TResult>(global::Graphify.Testing.Simple root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Simple.Graph.Age, TResult>> observers))
                            {
                                var instance = new Simple.Graph.Age(root, value);

                                results = Concat(results, Invoke<Simple.Graph.Age, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.SimpleNavigator.Age.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class SimpleNavigator
                        : global::Graphify.Navigator<Simple>,
                          ISimpleNavigator
                    {
                        public SimpleNavigator(global::System.IServiceProvider provider)
                            : base(provider)
                        {
                        }

                        public override IAsyncEnumerable<TResult> Navigate<TResult>(Simple root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = Empty<TResult>();

                            if (HasObservers<Simple, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Simple, TResult>> observers))
                            {
                                results = Invoke<Simple, TResult>(root, observers, cancellationToken);
                            }

                            results = Concat(results, NavigateAge<TResult>(root, root.Age, cancellationToken), cancellationToken);
                            results = Concat(results, NavigateIsAdult<TResult>(root, root.IsAdult, cancellationToken), cancellationToken);
                            results = Concat(results, NavigateName<TResult>(root, root.Name, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.SimpleNavigator.g.cs");

        public static readonly Generated NavigatorIsAdult = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateIsAdult<TResult>(global::Graphify.Testing.Simple root, bool value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Simple.Graph.IsAdult, TResult>> observers))
                            {
                                var instance = new Simple.Graph.IsAdult(root, value);

                                results = Concat(results, Invoke<Simple.Graph.IsAdult, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.SimpleNavigator.IsAdult.g.cs");

        public static readonly Generated NavigatorName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateName<TResult>(global::Graphify.Testing.Simple root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Simple.Graph.Name, TResult>> observers))
                            {
                                var instance = new Simple.Graph.Name(root, value);

                                results = Concat(results, Invoke<Simple.Graph.Name, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateNameLength<TResult>(root, value, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.SimpleNavigator.Name.g.cs");

        public static readonly Generated NavigatorNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateNameLength<TResult>(global::Graphify.Testing.Simple root, string param0, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Simple.Graph.Name.Length, TResult>> observers))
                            {
                                var instance = new Simple.Graph.Name.Length(root, param0, value);

                                results = Concat(results, Invoke<Simple.Graph.Name.Length, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.SimpleNavigator.Name.Length.g.cs");

        public static readonly Generated Registration = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public static partial class ServiceCollectionExtensions
                    {
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddSimpleNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::Graphify.INavigator<Simple>>(
                                services, (global::System.IServiceProvider provider) => (global::Graphify.INavigator<Simple>)provider.GetService(typeof(SimpleNavigator)));

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<ISimpleNavigator>(
                                services, (global::System.IServiceProvider provider) => (ISimpleNavigator)provider.GetService(typeof(SimpleNavigator)));

                            return global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<SimpleNavigator>(services);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ServiceCollectionExtensions.AddSimpleNavigator.g.cs");
    }
}
