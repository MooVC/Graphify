namespace Graphify.Snippets.Declarations.Synchronous;

internal static partial class Traversals
{
    public static class Expected
    {
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

                    public partial interface ITraversalsNavigator
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Traversals root);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ITraversalsNavigator.g.cs");

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

                    public interface ITraversalsVisitor<in T, out TResult>
                        where T : class
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Observe(T instance);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ITraversalsVisitor.g.cs");

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

                    public sealed partial class TraversalsNavigator
                        : ITraversalsNavigator
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

                        public global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Traversals root)
                        {
                            var results = global::System.Linq.Enumerable.Empty<TResult>();

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals, TResult>> visitors))
                            {
                                results = Invoke<Traversals, TResult>(root, visitors);
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateTitle<TResult>(root, root.Title));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateDescription<TResult>(root, root.Description));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateShallowChildren<TResult>(root, root.ShallowChildren));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildren<TResult>(root, root.DeepChildren));

                            return results;
                        }

                        private global::System.Collections.Generic.IEnumerable<TResult> Invoke<TInstance, TResult>(
                            TInstance instance,
                            global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<TInstance, TResult>> visitors)
                            where TInstance : class
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            foreach (ITraversalsVisitor<TInstance, TResult> visitor in visitors)
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
            "Graphify.Testing.Synchronous.TraversalsNavigator.g.cs");

        public static readonly Generated NavigatorTitle = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateTitle<TResult>(global::Graphify.Testing.Synchronous.Traversals root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var title = new Traversals.Graph.Title(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.Title, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.Title, TResult>(title, visitors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.Title.g.cs");

        public static readonly Generated NavigatorDescription = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDescription<TResult>(global::Graphify.Testing.Synchronous.Traversals root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var description = new Traversals.Graph.Description(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.Description, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.Description, TResult>(description, visitors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateDescriptionLength<TResult>(description, root, value.Length));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.Description.g.cs");

        public static readonly Generated NavigatorDescriptionLength = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDescriptionLength<TResult>(Traversals.Graph.Description description, global::Graphify.Testing.Synchronous.Traversals root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var length = new Traversals.Graph.Description.Length(description, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.Description.Length, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.Description.Length, TResult>(length, visitors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.Description.Length.g.cs");

        public static readonly Generated NavigatorShallowChildren = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateShallowChildren<TResult>(global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var shallowChildren = new Traversals.Graph.ShallowChildren(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.ShallowChildren, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.ShallowChildren, TResult>(shallowChildren, visitors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateShallowChildrenTraversalChild<TResult>(shallowChildren, root, value));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.ShallowChildren.g.cs");

        public static readonly Generated NavigatorShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateShallowChildrenTraversalChild<TResult>(Traversals.Graph.ShallowChildren shallowChildren, global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            _ = _provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.ShallowChildren.TraversalChild, TResult>> visitors);

                            int index = 0;

                            foreach (global::Graphify.Testing.Synchronous.TraversalChild element in value)
                            {
                                var traversalChild = new Traversals.Graph.ShallowChildren.TraversalChild(shallowChildren, index, root, element);

                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.ShallowChildren.TraversalChild, TResult>(traversalChild, visitors));

                                index++;
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildren = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildren<TResult>(global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var deepChildren = new Traversals.Graph.DeepChildren(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.DeepChildren, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.DeepChildren, TResult>(deepChildren, visitors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildrenTraversalChild<TResult>(deepChildren, root, value));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.DeepChildren.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildrenTraversalChild<TResult>(Traversals.Graph.DeepChildren deepChildren, global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            _ = _provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.DeepChildren.TraversalChild, TResult>> visitors);

                            int index = 0;

                            foreach (global::Graphify.Testing.Synchronous.TraversalChild element in value)
                            {
                                var traversalChild = new Traversals.Graph.DeepChildren.TraversalChild(deepChildren, index, root, element);

                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.DeepChildren.TraversalChild, TResult>(traversalChild, visitors));

                                results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildrenTraversalChildName<TResult>(traversalChild, root, element.Name));

                                index++;
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildrenTraversalChildName<TResult>(Traversals.Graph.DeepChildren.TraversalChild traversalChild, global::Graphify.Testing.Synchronous.Traversals root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var name = new Traversals.Graph.DeepChildren.TraversalChild.Name(traversalChild, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>(name, visitors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildrenTraversalChildNameLength<TResult>(name, root, value.Length));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildrenTraversalChildNameLength<TResult>(Traversals.Graph.DeepChildren.TraversalChild.Name name, global::Graphify.Testing.Synchronous.Traversals root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var length = new Traversals.Graph.DeepChildren.TraversalChild.Name.Length(name, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<ITraversalsVisitor<Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>> visitors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, Invoke<Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>(length, visitors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.TraversalsNavigator.DeepChildren.TraversalChild.Name.Length.g.cs");

        public static readonly Generated Title = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Title
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                            {
                                internal Title(global::Graphify.Testing.Synchronous.Traversals root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Traversals.Title.g.cs");

        public static readonly Generated Description = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Description
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                            {
                                internal Description(global::Graphify.Testing.Synchronous.Traversals root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Traversals.Description.g.cs");

        public static readonly Generated DescriptionLength = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

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
                                    : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                                {
                                    internal Length(Traversals.Graph.Description description, global::Graphify.Testing.Synchronous.Traversals root, int value)
                                    {
                                        Description = description;

                                        Root = root;
                                        Value = value;
                                    }

                                    public Traversals.Graph.Description Description { get; private set; }

                                    public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

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
            "Graphify.Testing.Synchronous.Traversals.Description.Length.g.cs");

        public static readonly Generated ShallowChildren = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class ShallowChildren
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                            {
                                internal ShallowChildren(global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

                                public global::Graphify.Testing.Synchronous.TraversalChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Traversals.ShallowChildren.g.cs");

        public static readonly Generated ShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

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
                                    : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                                {
                                    internal TraversalChild(Traversals.Graph.ShallowChildren shallowChildren, int index, global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild value)
                                    {
                                        ShallowChildren = shallowChildren;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public Traversals.Graph.ShallowChildren ShallowChildren { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.Synchronous.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Traversals.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildren = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class DeepChildren
                                : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                            {
                                internal DeepChildren(global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

                                public global::Graphify.Testing.Synchronous.TraversalChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Traversals.DeepChildren.g.cs");

        public static readonly Generated DeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

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
                                    : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                                {
                                    internal TraversalChild(Traversals.Graph.DeepChildren deepChildren, int index, global::Graphify.Testing.Synchronous.Traversals root, global::Graphify.Testing.Synchronous.TraversalChild value)
                                    {
                                        DeepChildren = deepChildren;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public Traversals.Graph.DeepChildren DeepChildren { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.Synchronous.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Traversals.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

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
                                        : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                                    {
                                        internal Name(Traversals.Graph.DeepChildren.TraversalChild traversalChild, global::Graphify.Testing.Synchronous.Traversals root, string value)
                                        {
                                            TraversalChild = traversalChild;

                                            Root = root;
                                            Value = value;
                                        }

                                        public Traversals.Graph.DeepChildren.TraversalChild TraversalChild { get; private set; }

                                        public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

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
            "Graphify.Testing.Synchronous.Traversals.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated DeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

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
                                            : global::Graphify.IGraph<global::Graphify.Testing.Synchronous.Traversals>
                                        {
                                            internal Length(Traversals.Graph.DeepChildren.TraversalChild.Name name, global::Graphify.Testing.Synchronous.Traversals root, int value)
                                            {
                                                Name = name;

                                                Root = root;
                                                Value = value;
                                            }

                                            public Traversals.Graph.DeepChildren.TraversalChild.Name Name { get; private set; }

                                            public global::Graphify.Testing.Synchronous.Traversals Root { get; private set; }

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
            "Graphify.Testing.Synchronous.Traversals.DeepChildren.TraversalChild.Name.Length.g.cs");

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
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddTraversalsNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<ITraversalsNavigator>(
                                services, (global::System.IServiceProvider provider) => (ITraversalsNavigator)provider.GetService(typeof(TraversalsNavigator)));

                            return global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<TraversalsNavigator>(services);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ServiceCollectionExtensions.AddTraversalsNavigator.g.cs");
    }
}