namespace Graphify.Snippets.Declarations.Synchronous;

internal static partial class DepthLimited
{
    public static class Expected
    {
        public static readonly Generated Child = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class DepthLimited
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Child
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.DepthLimited>
                            {
                                internal Child(global::Graphify.Testing.Synchronous.DepthLimited root, global::Graphify.Testing.Synchronous.DepthChild value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.DepthLimited Root { get; private set; }

                                public global::Graphify.Testing.Synchronous.DepthChild Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.DepthLimited.Child.g.cs");

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

                    public partial interface IDepthLimitedNavigator
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(DepthLimited root);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.IDepthLimitedNavigator.g.cs");

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

                    public interface IDepthLimitedVisitor<in T, out TResult>
                        where T : class, global::Graphify.IGraph<global::Graphify.Testing.Synchronous.DepthLimited>
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Observe(T instance);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.IDepthLimitedVisitor.g.cs");

        public static readonly Generated NavigatorChild = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class DepthLimitedNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateChild<TResult>(global::Graphify.Testing.Synchronous.DepthLimited root, global::Graphify.Testing.Synchronous.DepthChild value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var child = new DepthLimited.Graph.Child(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IDepthLimitedVisitor<DepthLimited.Graph.Child, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<DepthLimited.Graph.Child, TResult>(child, visitors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.DepthLimitedNavigator.Child.g.cs");

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

                    public sealed partial class DepthLimitedNavigator
                        : IDepthLimitedNavigator
                    {
                        private readonly global::System.IServiceProvider _provider;

                        public DepthLimitedNavigator(global::System.IServiceProvider provider)
                        {
                            if (global::System.Object.ReferenceEquals(provider, null))
                            {
                                throw new global::System.ArgumentNullException("provider");
                            }

                            _provider = provider;
                        }

                        public global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(DepthLimited root)
                        {
                            var results = global::System.Linq.Enumerable.Empty<TResult>();


                            results = global::System.Linq.Enumerable.Concat(results, NavigateChild<TResult>(root, root.Child));

                            return results;
                        }

                        private global::System.Collections.Generic.IEnumerable<TResult> Invoke<TInstance, TResult>(
                            TInstance instance,
                            global::System.Collections.Generic.IEnumerable<IDepthLimitedVisitor<TInstance, TResult>> visitors)
                            where TInstance : class, global::Graphify.IGraph<DepthLimited>
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            foreach (IDepthLimitedVisitor<TInstance, TResult> visitor in visitors)
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
            "Graphify.Testing.Synchronous.DepthLimitedNavigator.g.cs");

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
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddDepthLimitedNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<IDepthLimitedNavigator>(
                                services, (global::System.IServiceProvider provider) => (IDepthLimitedNavigator)provider.GetService(typeof(DepthLimitedNavigator)));

                            return global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<DepthLimitedNavigator>(services);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ServiceCollectionExtensions.AddDepthLimitedNavigator.g.cs");
    }
}