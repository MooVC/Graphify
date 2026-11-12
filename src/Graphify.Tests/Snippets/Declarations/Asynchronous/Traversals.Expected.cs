namespace Graphify.Snippets.Declarations.Asynchronous;

internal static partial class Traversals
{
    public static class Expected
    {
        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public partial interface ITraversalsNavigator
                    {
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(global::Graphify.Testing.Asynchronous.Traversals root, global::System.Threading.CancellationToken cancellationToken);
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ITraversalsNavigator.g.cs");

        public static readonly Generated Visitor = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public interface ITraversalsVisitor<in T, out TResult>
                        where T : class, global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                    {
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> Observe(T instance, global::System.Threading.CancellationToken cancellationToken);
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ITraversalsVisitor.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                        : global::Graphify.Testing.Asynchronous.ITraversalsNavigator
                    {
                        private readonly global::System.IServiceProvider _provider;

                        public TraversalsNavigator(global::System.IServiceProvider provider)
                        {
                            if (global::System.Object.ReferenceEquals(provider, null))
                            {
                                throw new global::System.ArgumentNullException("provider");
                            }

                            _provider = provider;
                        }

                        public global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(global::Graphify.Testing.Asynchronous.Traversals root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = _provider.Empty<TResult>();


                            results = _provider.Concat(results, NavigateTitle<TResult>(root, root.Title, cancellationToken), cancellationToken);
                            results = _provider.Concat(results, NavigateDescription<TResult>(root, root.Description, cancellationToken), cancellationToken);
                            results = _provider.Concat(results, NavigateShallowChildren<TResult>(root, root.ShallowChildren, cancellationToken), cancellationToken);
                            results = _provider.Concat(results, NavigateDeepChildren<TResult>(root, root.DeepChildren, cancellationToken), cancellationToken);

                            return results;
                        }

                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> Invoke<TInstance, TResult>(
                            TInstance instance,
                            global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<TInstance, TResult>> visitors,
                            global::System.Threading.CancellationToken cancellationToken)
                            where TInstance : class, global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();

                            foreach (global::Graphify.Testing.Asynchronous.ITraversalsVisitor<TInstance, TResult> visitor in visitors)
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
            "Graphify.Testing.Asynchronous.TraversalsNavigator.g.cs");

        public static readonly Generated NavigatorTitle = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateTitle<TResult>(global::Graphify.Testing.Asynchronous.Traversals root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var title = new global::Graphify.Testing.Asynchronous.Traversals.Graph.Title(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.Title, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.Title, TResult>(title, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.TraversalsNavigator.Title.g.cs");

        public static readonly Generated NavigatorDescription = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDescription<TResult>(global::Graphify.Testing.Asynchronous.Traversals root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var description = new global::Graphify.Testing.Asynchronous.Traversals.Graph.Description(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.Description, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.Description, TResult>(description, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateDescriptionLength<TResult>(description, root, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.TraversalsNavigator.Description.g.cs");

        public static readonly Generated NavigatorDescriptionLength = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDescriptionLength<TResult>(global::Graphify.Testing.Asynchronous.Traversals.Graph.Description description, global::Graphify.Testing.Asynchronous.Traversals root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var length = new global::Graphify.Testing.Asynchronous.Traversals.Graph.Description.Length(description, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.Description.Length, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.Description.Length, TResult>(length, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.TraversalsNavigator.Description.Length.g.cs");

        public static readonly Generated NavigatorShallowChildren = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateShallowChildren<TResult>(global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var shallowChildren = new global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren, TResult>(shallowChildren, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateShallowChildrenTraversalChild<TResult>(shallowChildren, root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.TraversalsNavigator.ShallowChildren.g.cs");

        public static readonly Generated NavigatorShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateShallowChildrenTraversalChild<TResult>(global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren shallowChildren, global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();

                            bool hasVisitors = _provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren.TraversalChild, TResult>> observers);

                            int index = 0;

                            foreach (global::Graphify.Testing.Asynchronous.TraversalChild element in value)
                            {
                                var traversalChild = new global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren.TraversalChild(shallowChildren, index, root, element);

                                if (hasVisitors)
                                {
                                    results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren.TraversalChild, TResult>(traversalChild, observers, cancellationToken), cancellationToken);
                                }

                                index++;
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
            "Graphify.Testing.Asynchronous.TraversalsNavigator.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildren = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildren<TResult>(global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var deepChildren = new global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren, TResult>(deepChildren, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateDeepChildrenTraversalChild<TResult>(deepChildren, root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.TraversalsNavigator.DeepChildren.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraversalChild<TResult>(global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren deepChildren, global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();

                            bool hasVisitors = _provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild, TResult>> observers);

                            int index = 0;

                            foreach (global::Graphify.Testing.Asynchronous.TraversalChild element in value)
                            {
                                var traversalChild = new global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild(deepChildren, index, root, element);

                                if (hasVisitors)
                                {
                                    results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild, TResult>(traversalChild, observers, cancellationToken), cancellationToken);
                                }

                                results = _provider.Concat(results, NavigateDeepChildrenTraversalChildName<TResult>(traversalChild, root, element.Name, cancellationToken), cancellationToken);

                                index++;
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
            "Graphify.Testing.Asynchronous.TraversalsNavigator.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraversalChildName<TResult>(global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild traversalChild, global::Graphify.Testing.Asynchronous.Traversals root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var name = new global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name(traversalChild, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>(name, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateDeepChildrenTraversalChildNameLength<TResult>(name, root, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.TraversalsNavigator.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraversalChildNameLength<TResult>(global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name name, global::Graphify.Testing.Asynchronous.Traversals root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var length = new global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name.Length(name, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<global::Graphify.Testing.Asynchronous.ITraversalsVisitor<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>(length, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.TraversalsNavigator.DeepChildren.TraversalChild.Name.Length.g.cs");

        public static readonly Generated Title = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Title
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                            {
                                internal Title(global::Graphify.Testing.Asynchronous.Traversals root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Traversals.Title.g.cs");

        public static readonly Generated Description = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Description
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                            {
                                internal Description(global::Graphify.Testing.Asynchronous.Traversals root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Traversals.Description.g.cs");

        public static readonly Generated DescriptionLength = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class Description
                            {
                                public sealed partial class Length
                                    : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                                {
                                    internal Length(global::Graphify.Testing.Asynchronous.Traversals.Graph.Description description, global::Graphify.Testing.Asynchronous.Traversals root, int value)
                                    {
                                        Description = description;

                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.Asynchronous.Traversals.Graph.Description Description { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Traversals.Description.Length.g.cs");

        public static readonly Generated ShallowChildren = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class ShallowChildren
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                            {
                                internal ShallowChildren(global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

                                public global::Graphify.Testing.Asynchronous.TraversalChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Traversals.ShallowChildren.g.cs");

        public static readonly Generated ShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class ShallowChildren
                            {
                                public sealed partial class TraversalChild
                                    : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                                {
                                    internal TraversalChild(global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren shallowChildren, int index, global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild value)
                                    {
                                        ShallowChildren = shallowChildren;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.Asynchronous.Traversals.Graph.ShallowChildren ShallowChildren { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Traversals.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildren = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class DeepChildren
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                            {
                                internal DeepChildren(global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

                                public global::Graphify.Testing.Asynchronous.TraversalChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Traversals.DeepChildren.g.cs");

        public static readonly Generated DeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class DeepChildren
                            {
                                public sealed partial class TraversalChild
                                    : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                                {
                                    internal TraversalChild(global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren deepChildren, int index, global::Graphify.Testing.Asynchronous.Traversals root, global::Graphify.Testing.Asynchronous.TraversalChild value)
                                    {
                                        DeepChildren = deepChildren;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren DeepChildren { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Traversals.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class DeepChildren
                            {
                                public partial class TraversalChild
                                {
                                    public sealed partial class Name
                                        : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                                    {
                                        internal Name(global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild traversalChild, global::Graphify.Testing.Asynchronous.Traversals root, string value)
                                        {
                                            TraversalChild = traversalChild;

                                            Root = root;
                                            Value = value;
                                        }

                                        public global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild TraversalChild { get; private set; }

                                        public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Traversals.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated DeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class DeepChildren
                            {
                                public partial class TraversalChild
                                {
                                    public partial class Name
                                    {
                                        public sealed partial class Length
                                            : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Traversals>
                                        {
                                            internal Length(global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name name, global::Graphify.Testing.Asynchronous.Traversals root, int value)
                                            {
                                                Name = name;

                                                Root = root;
                                                Value = value;
                                            }

                                            public global::Graphify.Testing.Asynchronous.Traversals.Graph.DeepChildren.TraversalChild.Name Name { get; private set; }

                                            public global::Graphify.Testing.Asynchronous.Traversals Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Traversals.DeepChildren.TraversalChild.Name.Length.g.cs");

        public static readonly Generated Registration = new(
            """
                namespace Graphify.Testing.Asynchronous
                {
                    using global::Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    public static partial class ServiceCollectionExtensions
                    {
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddTraversalsNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (global::System.Object.ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::Graphify.Testing.Asynchronous.ITraversalsNavigator>(
                                services, (global::System.IServiceProvider provider) => (global::Graphify.Testing.Asynchronous.ITraversalsNavigator)provider.GetService(typeof(global::Graphify.Testing.Asynchronous.TraversalsNavigator)));

                            return global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::Graphify.Testing.Asynchronous.TraversalsNavigator>(services);
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ServiceCollectionExtensions.AddTraversalsNavigator.g.cs");
    }
}