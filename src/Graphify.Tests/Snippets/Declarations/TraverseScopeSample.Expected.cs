namespace Graphify.Snippets.Declarations;

internal static partial class TraverseScopeSample
{
    public static class Expected
    {
        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public partial interface ITraverseScopeSampleNavigator
                        : global::Graphify.INavigator<TraverseScopeSample>
                    {
                        //// Additional methods can be added as partial elements
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ITraverseScopeSampleNavigator.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                        : global::Graphify.Navigator<TraverseScopeSample>,
                          ITraverseScopeSampleNavigator
                    {
                        public TraverseScopeSampleNavigator(global::System.IServiceProvider provider)
                            : base(provider)
                        {
                        }

                        public override IAsyncEnumerable<TResult> Navigate<TResult>(TraverseScopeSample root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = Empty<TResult>();

                            if (HasObservers<TraverseScopeSample, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample, TResult>> observers))
                            {
                                results = Invoke<TraverseScopeSample, TResult>(root, observers, cancellationToken);
                            }

                            results = Concat(results, NavigateTitle<TResult>(root, root.Title, cancellationToken), cancellationToken);
                            results = Concat(results, NavigateDescription<TResult>(root, root.Description, cancellationToken), cancellationToken);
                            results = Concat(results, NavigateShallowChildren<TResult>(root, root.ShallowChildren, cancellationToken), cancellationToken);
                            results = Concat(results, NavigateDeepChildren<TResult>(root, root.DeepChildren, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.g.cs");

        public static readonly Generated NavigatorTitle = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateTitle<TResult>(global::Graphify.Testing.TraverseScopeSample root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.Title, TResult>> observers))
                            {
                                var instance = new TraverseScopeSample.Graph.Title(root, value);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.Title, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.Title.g.cs");

        public static readonly Generated NavigatorDescription = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDescription<TResult>(global::Graphify.Testing.TraverseScopeSample root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.Description, TResult>> observers))
                            {
                                var instance = new TraverseScopeSample.Graph.Description(root, value);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.Description, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateDescriptionLength<TResult>(root, value, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.Description.g.cs");

        public static readonly Generated NavigatorDescriptionLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDescriptionLength<TResult>(global::Graphify.Testing.TraverseScopeSample root, string description, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.Description.Length, TResult>> observers))
                            {
                                var instance = new TraverseScopeSample.Graph.Description.Length(root, description, value);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.Description.Length, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.Description.Length.g.cs");

        public static readonly Generated NavigatorShallowChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateShallowChildren<TResult>(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.ShallowChildren, TResult>> observers))
                            {
                                var instance = new TraverseScopeSample.Graph.ShallowChildren(root, value);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.ShallowChildren, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateShallowChildrenTraverseScopeChild<TResult>(root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.ShallowChildren.g.cs");

        public static readonly Generated NavigatorShallowChildrenTraverseScopeChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateShallowChildrenTraverseScopeChild<TResult>(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            _ = HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.ShallowChildren.TraverseScopeChild, TResult>> observers);

                            int index = 0;

                            foreach (TraverseScopeChild element in value)
                            {
                                var instance = new TraverseScopeSample.Graph.ShallowChildren.TraverseScopeChild(index, root, element);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.ShallowChildren.TraverseScopeChild, TResult>(instance, observers, cancellationToken), cancellationToken);

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
            "Graphify.Testing.TraverseScopeSampleNavigator.ShallowChildren.TraverseScopeChild.g.cs");

        public static readonly Generated NavigatorDeepChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildren<TResult>(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.DeepChildren, TResult>> observers))
                            {
                                var instance = new TraverseScopeSample.Graph.DeepChildren(root, value);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.DeepChildren, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateDeepChildrenTraverseScopeChild<TResult>(root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.DeepChildren.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraverseScopeChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraverseScopeChild<TResult>(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            _ = HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild, TResult>> observers);

                            int index = 0;

                            foreach (TraverseScopeChild element in value)
                            {
                                var instance = new TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild(index, root, element);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild, TResult>(instance, observers, cancellationToken), cancellationToken);

                                results = Concat(results, NavigateDeepChildrenTraverseScopeChildName<TResult>(root, value, element, element.Name, cancellationToken), cancellationToken);

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
            "Graphify.Testing.TraverseScopeSampleNavigator.DeepChildren.TraverseScopeChild.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraverseScopeChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraverseScopeChildName<TResult>(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] deepChildren, global::Graphify.Testing.TraverseScopeChild traverseScopeChild, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild.Name, TResult>> observers))
                            {
                                var instance = new TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild.Name(root, deepChildren, traverseScopeChild, value);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild.Name, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateDeepChildrenTraverseScopeChildNameLength<TResult>(root, deepChildren, traverseScopeChild, value, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.DeepChildren.TraverseScopeChild.Name.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraverseScopeChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraverseScopeSampleNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraverseScopeChildNameLength<TResult>(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] deepChildren, global::Graphify.Testing.TraverseScopeChild traverseScopeChild, string name, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild.Name.Length, TResult>> observers))
                            {
                                var instance = new TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild.Name.Length(root, deepChildren, traverseScopeChild, name, value);

                                results = Concat(results, Invoke<TraverseScopeSample.Graph.DeepChildren.TraverseScopeChild.Name.Length, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSampleNavigator.DeepChildren.TraverseScopeChild.Name.Length.g.cs");

        public static readonly Generated Title = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Title
                            {
                                internal Title(global::Graphify.Testing.TraverseScopeSample root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSample.Title.g.cs");

        public static readonly Generated Description = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Description
                            {
                                internal Description(global::Graphify.Testing.TraverseScopeSample root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSample.Description.g.cs");

        public static readonly Generated DescriptionLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public partial class Description
                            {
                                public sealed partial class Length
                                {
                                    internal Length(global::Graphify.Testing.TraverseScopeSample root, string description, int value)
                                    {
                                        Description = description;

                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                    public string Description { get; private set; }

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
            "Graphify.Testing.TraverseScopeSample.Description.Length.g.cs");

        public static readonly Generated ShallowChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public sealed partial class ShallowChildren
                            {
                                internal ShallowChildren(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                public global::Graphify.Testing.TraverseScopeChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSample.ShallowChildren.g.cs");

        public static readonly Generated ShallowChildrenTraverseScopeChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public partial class ShallowChildren
                            {
                                public sealed partial class TraverseScopeChild
                                {
                                    internal TraverseScopeChild(int index, global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild value)
                                    {
                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                    public global::Graphify.Testing.TraverseScopeChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSample.ShallowChildren.TraverseScopeChild.g.cs");

        public static readonly Generated DeepChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public sealed partial class DeepChildren
                            {
                                internal DeepChildren(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                public global::Graphify.Testing.TraverseScopeChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSample.DeepChildren.g.cs");

        public static readonly Generated DeepChildrenTraverseScopeChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public partial class DeepChildren
                            {
                                public sealed partial class TraverseScopeChild
                                {
                                    internal TraverseScopeChild(int index, global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild value)
                                    {
                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                    public global::Graphify.Testing.TraverseScopeChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraverseScopeSample.DeepChildren.TraverseScopeChild.g.cs");

        public static readonly Generated DeepChildrenTraverseScopeChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public partial class DeepChildren
                            {
                                public partial class TraverseScopeChild
                                {
                                    public sealed partial class Name
                                    {
                                        internal Name(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] deepChildren, global::Graphify.Testing.TraverseScopeChild traverseScopeChild, string value)
                                        {
                                            DeepChildren = deepChildren;
                                            TraverseScopeChild = traverseScopeChild;

                                            Root = root;
                                            Value = value;
                                        }

                                        public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                        public global::Graphify.Testing.TraverseScopeChild[] DeepChildren { get; private set; }

                                        public global::Graphify.Testing.TraverseScopeChild TraverseScopeChild { get; private set; }

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
            "Graphify.Testing.TraverseScopeSample.DeepChildren.TraverseScopeChild.Name.g.cs");

        public static readonly Generated DeepChildrenTraverseScopeChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class TraverseScopeSample
                    {
                        public static partial class Graph
                        {
                            public partial class DeepChildren
                            {
                                public partial class TraverseScopeChild
                                {
                                    public partial class Name
                                    {
                                        public sealed partial class Length
                                        {
                                            internal Length(global::Graphify.Testing.TraverseScopeSample root, global::Graphify.Testing.TraverseScopeChild[] deepChildren, global::Graphify.Testing.TraverseScopeChild traverseScopeChild, string name, int value)
                                            {
                                                DeepChildren = deepChildren;
                                                TraverseScopeChild = traverseScopeChild;
                                                Name = name;

                                                Root = root;
                                                Value = value;
                                            }

                                            public global::Graphify.Testing.TraverseScopeSample Root { get; private set; }

                                            public global::Graphify.Testing.TraverseScopeChild[] DeepChildren { get; private set; }

                                            public global::Graphify.Testing.TraverseScopeChild TraverseScopeChild { get; private set; }

                                            public string Name { get; private set; }

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
            "Graphify.Testing.TraverseScopeSample.DeepChildren.TraverseScopeChild.Name.Length.g.cs");

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
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddTraverseScopeSampleNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::Graphify.INavigator<TraverseScopeSample>>(
                                services, (global::System.IServiceProvider provider) => (global::Graphify.INavigator<TraverseScopeSample>)provider.GetService(typeof(TraverseScopeSampleNavigator)));

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<ITraverseScopeSampleNavigator>(
                                services, (global::System.IServiceProvider provider) => (ITraverseScopeSampleNavigator)provider.GetService(typeof(TraverseScopeSampleNavigator)));

                            return global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<TraverseScopeSampleNavigator>(services);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ServiceCollectionExtensions.AddTraverseScopeSampleNavigator.g.cs");
    }
}