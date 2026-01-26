namespace Graphify.Snippets.Declarations;

internal static partial class DepthLimited
{
    public static class Expected
    {
        public static readonly Generated Child = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class DepthLimited
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Child
                            {
                                internal Child(global::Graphify.Testing.DepthLimited root, global::Graphify.Testing.DepthChild value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.DepthLimited Root { get; private set; }

                                public global::Graphify.Testing.DepthChild Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.DepthLimited.Child.g.cs");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public partial interface IDepthLimitedNavigator
                        : global::Graphify.INavigator<DepthLimited>
                    {
                        //// Additional methods can be added as partial elements
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.IDepthLimitedNavigator.g.cs");

        public static readonly Generated NavigatorChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class DepthLimitedNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChild<TResult>(global::Graphify.Testing.DepthLimited root, global::Graphify.Testing.DepthChild value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<DepthLimited.Graph.Child, TResult>> observers))
                            {
                                var instance = new DepthLimited.Graph.Child(root, value);

                                results = Concat(results, Invoke<DepthLimited.Graph.Child, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.DepthLimitedNavigator.Child.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class DepthLimitedNavigator
                        : global::Graphify.Navigator<DepthLimited>,
                          IDepthLimitedNavigator
                    {
                        public DepthLimitedNavigator(global::System.IServiceProvider provider)
                            : base(provider)
                        {
                        }

                        public override IAsyncEnumerable<TResult> Navigate<TResult>(DepthLimited root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = Empty<TResult>();

                            if (HasObservers<DepthLimited, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<DepthLimited, TResult>> observers))
                            {
                                results = Invoke<DepthLimited, TResult>(root, observers, cancellationToken);
                            }

                            results = Concat(results, NavigateChild<TResult>(root, root.Child, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.DepthLimitedNavigator.g.cs");

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
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddDepthLimitedNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::Graphify.INavigator<DepthLimited>>(
                                services, (global::System.IServiceProvider provider) => (global::Graphify.INavigator<DepthLimited>)provider.GetService(typeof(DepthLimitedNavigator)));

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
            "Graphify.Testing.ServiceCollectionExtensions.AddDepthLimitedNavigator.g.cs");
    }
}