namespace Graphify.Snippets.Declarations.Synchronous;

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
                    using Graphify;

                    #nullable disable

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

                    #nullable restore
                }
                """,
            "Graphify.Testing.DepthLimited.Child.g.cs");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public partial interface IDepthLimitedNavigator
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(DepthLimited root);
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.IDepthLimitedNavigator.g.cs");

        public static readonly Generated NavigatorChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class DepthLimitedNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateChild<TResult>(global::Graphify.Testing.DepthLimited root, global::Graphify.Testing.DepthChild value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var child = new DepthLimited.Graph.Child(root, value);

                            if (_provider.HasInspectors<DepthLimited.Graph.Child, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<DepthLimited.Graph.Child, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<DepthLimited.Graph.Child, TResult>(child, inspectors));
                            }

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.DepthLimitedNavigator.Child.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class DepthLimitedNavigator
                        : IDepthLimitedNavigator
                    {
                        private readonly global::System.IServiceProvider _provider;

                        public DepthLimitedNavigator(global::System.IServiceProvider provider)
                        {
                            if (global::System.Object.ReferenceEquals(provider, null))
                            {
                                throw new global::System.ArgumentNullException(nameof(provider));
                            }

                            _provider = provider;
                        }

                        public global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(DepthLimited root)
                        {
                            var results = global::System.Linq.Enumerable.Empty<TResult>();

                            if (_provider.HasInspectors<DepthLimited, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<DepthLimited, TResult>> inspectors))
                            {
                                results = _provider.Invoke<DepthLimited, TResult>(root, inspectors);
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateChild<TResult>(root, root.Child));

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.DepthLimitedNavigator.g.cs");

        public static readonly Generated Registration = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

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

                    #nullable restore
                }
                """,
            "Graphify.Testing.ServiceCollectionExtensions.AddDepthLimitedNavigator.g.cs");
    }
}