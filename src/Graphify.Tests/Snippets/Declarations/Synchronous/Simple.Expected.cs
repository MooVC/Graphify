namespace Graphify.Snippets.Declarations.Synchronous;

internal static partial class Simple
{
    public static class Expected
    {
        public static readonly Generated Age = new(
            """
                namespace Graphify.Testing.Synchronous
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
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Simple>
                            {
                                internal Age(global::Graphify.Testing.Synchronous.Simple root, int value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Simple Root { get; private set; }

                                public int Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Simple.Age.g.cs");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public partial interface ISimpleNavigator
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Simple root);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ISimpleNavigator.g.cs");

        public static readonly Generated Visitor = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public interface ISimpleVisitor<in T, out TResult>
                        where T : class, global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Simple>
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Observe(T instance);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ISimpleVisitor.g.cs");

        public static readonly Generated IsAdult = new(
            """
                namespace Graphify.Testing.Synchronous
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
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Simple>
                            {
                                internal IsAdult(global::Graphify.Testing.Synchronous.Simple root, bool value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Simple Root { get; private set; }

                                public bool Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Simple.IsAdult.g.cs");

        public static readonly Generated Name = new(
            """
                namespace Graphify.Testing.Synchronous
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
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Simple>
                            {
                                internal Name(global::Graphify.Testing.Synchronous.Simple root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Simple Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Simple.Name.g.cs");

        public static readonly Generated NameLength = new(
            """
                namespace Graphify.Testing.Synchronous
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
                                    : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Simple>
                                {
                                    internal Length(Simple.Graph.Name name, global::Graphify.Testing.Synchronous.Simple root, int value)
                                    {
                                        Name = name;

                                        Root = root;
                                        Value = value;
                                    }

                                    public Simple.Graph.Name Name { get; private set; }

                                    public global::Graphify.Testing.Synchronous.Simple Root { get; private set; }

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
            "Graphify.Testing.Synchronous.Simple.Name.Length.g.cs");

        public static readonly Generated NavigatorAge = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateAge<TResult>(global::Graphify.Testing.Synchronous.Simple root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var age = new Simple.Graph.Age(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.Age, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Simple.Graph.Age, TResult>(age, visitors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.SimpleNavigator.Age.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

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

                        public global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Simple root)
                        {
                            var results = global::System.Linq.Enumerable.Empty<TResult>();


                            results = global::System.Linq.Enumerable.Concat(results, NavigateAge<TResult>(root, root.Age));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateIsAdult<TResult>(root, root.IsAdult));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateName<TResult>(root, root.Name));

                            return results;
                        }

                        private global::System.Collections.Generic.IEnumerable<TResult> Invoke<TInstance, TResult>(
                            TInstance instance,
                            global::System.Collections.Generic.IEnumerable<ISimpleVisitor<TInstance, TResult>> visitors)
                            where TInstance : class, global::Graphify.IGraph<Simple>
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            foreach (ISimpleVisitor<TInstance, TResult> visitor in visitors)
                            {
                                results = global::System.Linq.Enumerable.Concat(results, visitor.Observe(instance));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.SimpleNavigator.g.cs");

        public static readonly Generated NavigatorIsAdult = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateIsAdult<TResult>(global::Graphify.Testing.Synchronous.Simple root, bool value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var isAdult = new Simple.Graph.IsAdult(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.IsAdult, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Simple.Graph.IsAdult, TResult>(isAdult, visitors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.SimpleNavigator.IsAdult.g.cs");

        public static readonly Generated NavigatorName = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateName<TResult>(global::Graphify.Testing.Synchronous.Simple root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var name = new Simple.Graph.Name(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.Name, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Simple.Graph.Name, TResult>(name, visitors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateNameLength<TResult>(name, root, value.Length));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.SimpleNavigator.Name.g.cs");

        public static readonly Generated NavigatorNameLength = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class SimpleNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateNameLength<TResult>(Simple.Graph.Name name, global::Graphify.Testing.Synchronous.Simple root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var length = new Simple.Graph.Name.Length(name, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ISimpleVisitor<Simple.Graph.Name.Length, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Simple.Graph.Name.Length, TResult>(length, visitors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.SimpleNavigator.Name.Length.g.cs");

        public static readonly Generated Registration = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

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
            "Graphify.Testing.Synchronous.ServiceCollectionExtensions.AddSimpleNavigator.g.cs");
    }
}