namespace Graphify.Snippets.Declarations.Asynchronous;

internal static partial class DepthLimited
{
    public static class Expected
    {
        public static readonly Generated Child = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                            {
                                internal Child(global::Graphify.Testing.Asynchronous.DepthLimited root, global::Graphify.Testing.Asynchronous.DepthChild value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.DepthLimited Root { get; private set; }

                                public global::Graphify.Testing.Asynchronous.DepthChild Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.DepthLimited.Child.g.cs");

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
                    public partial interface IDepthLimitedNavigator
                    {
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(DepthLimited root, global::System.Threading.CancellationToken cancellationToken);
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.IDepthLimitedNavigator.g.cs");

        public static readonly Generated NavigatorChild = new(
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
                    public sealed partial class DepthLimitedNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChild<TResult>(global::Graphify.Testing.Asynchronous.DepthLimited root, global::Graphify.Testing.Asynchronous.DepthChild value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var child = new DepthLimited.Graph.Child(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<DepthLimited.Graph.Child, TResult>> observers))
                            {
                                results = _provider.Concat(results, _provider.Invoke<DepthLimited.Graph.Child, TResult>(child, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.DepthLimitedNavigator.Child.g.cs");

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

                        public global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(DepthLimited root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = _provider.Empty<TResult>();

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<DepthLimited, TResult>> observers))
                            {
                                results = _provider.Invoke<DepthLimited, TResult>(root, observers, cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateChild<TResult>(root, root.Child, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.DepthLimitedNavigator.g.cs");

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
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ServiceCollectionExtensions.AddDepthLimitedNavigator.g.cs");
    }
}