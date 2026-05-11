namespace Graphify.Snippets.Declarations.Asynchronous;

internal static partial class Simple
{
    public static class Expected
    {
        public static readonly Generated Age = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Age
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Simple>
                            {
                                internal Age(global::Graphify.Testing.Asynchronous.Simple root, int value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Simple Root { get; private set; }

                                public int Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Simple.Age.g.cs");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public partial interface ISimpleNavigator
                    {
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(Simple root, global::System.Threading.CancellationToken cancellationToken);
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ISimpleNavigator.g.cs");

        public static readonly Generated Visitor = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public interface ISimpleVisitor<in T, out TResult>
                        where T : class
                    {
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> Observe(T instance, global::System.Threading.CancellationToken cancellationToken);
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ISimpleVisitor.g.cs");

        public static readonly Generated IsAdult = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public static partial class Graph
                        {
                            public sealed partial class IsAdult
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Simple>
                            {
                                internal IsAdult(global::Graphify.Testing.Asynchronous.Simple root, bool value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Simple Root { get; private set; }

                                public bool Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Simple.IsAdult.g.cs");

        public static readonly Generated Name = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Simple
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Name
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Simple>
                            {
                                internal Name(global::Graphify.Testing.Asynchronous.Simple root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Simple Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Simple.Name.g.cs");

        public static readonly Generated NameLength = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

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
                                    : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Simple>
                                {
                                    internal Length(Simple.Graph.Name name, global::Graphify.Testing.Asynchronous.Simple root, int value)
                                    {
                                        Name = name;

                                        Root = root;
                                        Value = value;
                                    }

                                    public Simple.Graph.Name Name { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.Simple Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Simple.Name.Length.g.cs");

        public static readonly Generated NavigatorAge = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateAge<TResult>(global::Graphify.Testing.Asynchronous.Simple root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var age = new Simple.Graph.Age(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.Age, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Simple.Graph.Age, TResult>(age, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.SimpleNavigator.Age.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class SimpleNavigator
                        : ISimpleNavigator
                    {
                        private readonly global::System.IServiceProvider _provider;

                        public SimpleNavigator(global::System.IServiceProvider provider)
                        {
                            if (global::System.Object.ReferenceEquals(provider, null))
                            {
                                throw new global::System.ArgumentNullException("provider");
                            }

                            _provider = provider;
                        }

                        public global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(Simple root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = _provider.Empty<TResult>();

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple, TResult>> observers))
                            {
                                results = Invoke<Simple, TResult>(root, observers, cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateAge<TResult>(root, root.Age, cancellationToken), cancellationToken);
                            results = _provider.Concat(results, NavigateIsAdult<TResult>(root, root.IsAdult, cancellationToken), cancellationToken);
                            results = _provider.Concat(results, NavigateName<TResult>(root, root.Name, cancellationToken), cancellationToken);

                            return results;
                        }

                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> Invoke<TInstance, TResult>(
                            TInstance instance,
                            global::System.Collections.Generic.IEnumerable<ISimpleVisitor<TInstance, TResult>> visitors,
                            global::System.Threading.CancellationToken cancellationToken)
                            where TInstance : class
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();

                            foreach (ISimpleVisitor<TInstance, TResult> visitor in visitors)
                            {
                                results = _provider.Concat(results, visitor.Observe(instance, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.SimpleNavigator.g.cs");

        public static readonly Generated NavigatorIsAdult = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateIsAdult<TResult>(global::Graphify.Testing.Asynchronous.Simple root, bool value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var isAdult = new Simple.Graph.IsAdult(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.IsAdult, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Simple.Graph.IsAdult, TResult>(isAdult, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.SimpleNavigator.IsAdult.g.cs");

        public static readonly Generated NavigatorName = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateName<TResult>(global::Graphify.Testing.Asynchronous.Simple root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var name = new Simple.Graph.Name(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.Name, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Simple.Graph.Name, TResult>(name, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateNameLength<TResult>(name, root, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.SimpleNavigator.Name.g.cs");

        public static readonly Generated NavigatorNameLength = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateNameLength<TResult>(Simple.Graph.Name name, global::Graphify.Testing.Asynchronous.Simple root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var length = new Simple.Graph.Name.Length(name, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.Name.Length, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Simple.Graph.Name.Length, TResult>(length, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.SimpleNavigator.Name.Length.g.cs");

        public static readonly Generated Registration = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public static partial class ServiceCollectionExtensions
                    {
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddSimpleNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<ISimpleNavigator>(
                                services, (global::System.IServiceProvider provider) => (ISimpleNavigator)provider.GetService(typeof(SimpleNavigator)));

                            return global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<SimpleNavigator>(services);
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ServiceCollectionExtensions.AddSimpleNavigator.g.cs");
    }
}