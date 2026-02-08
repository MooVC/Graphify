namespace Graphify.Snippets.Declarations;

internal static partial class Traversals
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

                    public partial interface ITraversalsNavigator
                        : global::Graphify.INavigator<Traversals>
                    {
                        //// Additional methods can be added as partial elements
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ITraversalsNavigator.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                        : global::Graphify.Navigator<Traversals>,
                          ITraversalsNavigator
                    {
                        public TraversalsNavigator(global::System.IServiceProvider provider)
                            : base(provider)
                        {
                        }

                        public override IAsyncEnumerable<TResult> Navigate<TResult>(Traversals root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = Empty<TResult>();

                            if (HasObservers<Traversals, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals, TResult>> observers))
                            {
                                results = Invoke<Traversals, TResult>(root, observers, cancellationToken);
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
            "Graphify.Testing.TraversalsNavigator.g.cs");

        public static readonly Generated NavigatorTitle = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateTitle<TResult>(global::Graphify.Testing.Traversals root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.Title, TResult>> observers))
                            {
                                var instance = new Traversals.Graph.Title(root, value);

                                results = Concat(results, Invoke<Traversals.Graph.Title, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraversalsNavigator.Title.g.cs");

        public static readonly Generated NavigatorDescription = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDescription<TResult>(global::Graphify.Testing.Traversals root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.Description, TResult>> observers))
                            {
                                var instance = new Traversals.Graph.Description(root, value);

                                results = Concat(results, Invoke<Traversals.Graph.Description, TResult>(instance, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.TraversalsNavigator.Description.g.cs");

        public static readonly Generated NavigatorDescriptionLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDescriptionLength<TResult>(global::Graphify.Testing.Traversals root, string param0, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.Description.Length, TResult>> observers))
                            {
                                var instance = new Traversals.Graph.Description.Length(root, param0, value);

                                results = Concat(results, Invoke<Traversals.Graph.Description.Length, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraversalsNavigator.Description.Length.g.cs");

        public static readonly Generated NavigatorShallowChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateShallowChildren<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.ShallowChildren, TResult>> observers))
                            {
                                var instance = new Traversals.Graph.ShallowChildren(root, value);

                                results = Concat(results, Invoke<Traversals.Graph.ShallowChildren, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateShallowChildrenTraversalChild<TResult>(root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraversalsNavigator.ShallowChildren.g.cs");

        public static readonly Generated NavigatorShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateShallowChildrenTraversalChild<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            _ = HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.ShallowChildren.TraversalChild, TResult>> observers);

                            int index = 0;

                            foreach (TraversalChild element in value)
                            {
                                var instance = new Traversals.Graph.ShallowChildren.TraversalChild(index, root, element);

                                results = Concat(results, Invoke<Traversals.Graph.ShallowChildren.TraversalChild, TResult>(instance, observers, cancellationToken), cancellationToken);

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
            "Graphify.Testing.TraversalsNavigator.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildren<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.DeepChildren, TResult>> observers))
                            {
                                var instance = new Traversals.Graph.DeepChildren(root, value);

                                results = Concat(results, Invoke<Traversals.Graph.DeepChildren, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateDeepChildrenTraversalChild<TResult>(root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraversalsNavigator.DeepChildren.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraversalChild<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            _ = HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.DeepChildren.TraversalChild, TResult>> observers);

                            int index = 0;

                            foreach (TraversalChild element in value)
                            {
                                var instance = new Traversals.Graph.DeepChildren.TraversalChild(index, root, element);

                                results = Concat(results, Invoke<Traversals.Graph.DeepChildren.TraversalChild, TResult>(instance, observers, cancellationToken), cancellationToken);

                                results = Concat(results, NavigateDeepChildrenTraversalChildName<TResult>(root, value, element, element.Name, cancellationToken), cancellationToken);

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
            "Graphify.Testing.TraversalsNavigator.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraversalChildName<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] param0, global::Graphify.Testing.TraversalChild param1, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>> observers))
                            {
                                var instance = new Traversals.Graph.DeepChildren.TraversalChild.Name(root, param0, param1, value);

                                results = Concat(results, Invoke<Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateDeepChildrenTraversalChildNameLength<TResult>(root, param0, param1, value, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraversalsNavigator.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateDeepChildrenTraversalChildNameLength<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] param0, global::Graphify.Testing.TraversalChild param1, string param2, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>> observers))
                            {
                                var instance = new Traversals.Graph.DeepChildren.TraversalChild.Name.Length(root, param0, param1, param2, value);

                                results = Concat(results, Invoke<Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.TraversalsNavigator.DeepChildren.TraversalChild.Name.Length.g.cs");

        public static readonly Generated Title = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Title
                            {
                                internal Title(global::Graphify.Testing.Traversals root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Traversals Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Traversals.Title.g.cs");

        public static readonly Generated Description = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Description
                            {
                                internal Description(global::Graphify.Testing.Traversals root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Traversals Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Traversals.Description.g.cs");

        public static readonly Generated DescriptionLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                {
                                    internal Length(global::Graphify.Testing.Traversals root, string param0, int value)
                                    {
                                        Description = param0;

                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.Traversals Root { get; private set; }

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
            "Graphify.Testing.Traversals.Description.Length.g.cs");

        public static readonly Generated ShallowChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class ShallowChildren
                            {
                                internal ShallowChildren(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Traversals Root { get; private set; }

                                public global::Graphify.Testing.TraversalChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Traversals.ShallowChildren.g.cs");

        public static readonly Generated ShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                {
                                    internal TraversalChild(int index, global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild value)
                                    {
                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Traversals.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public sealed partial class DeepChildren
                            {
                                internal DeepChildren(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Traversals Root { get; private set; }

                                public global::Graphify.Testing.TraversalChild[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Traversals.DeepChildren.g.cs");

        public static readonly Generated DeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                {
                                    internal TraversalChild(int index, global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild value)
                                    {
                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Traversals.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                    {
                                        internal Name(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] param0, global::Graphify.Testing.TraversalChild param1, string value)
                                        {
                                            DeepChildren = param0;
                                            TraversalChild = param1;

                                            Root = root;
                                            Value = value;
                                        }

                                        public global::Graphify.Testing.Traversals Root { get; private set; }

                                        public global::Graphify.Testing.TraversalChild[] DeepChildren { get; private set; }

                                        public global::Graphify.Testing.TraversalChild TraversalChild { get; private set; }

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
            "Graphify.Testing.Traversals.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated DeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                        {
                                            internal Length(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] param0, global::Graphify.Testing.TraversalChild param1, string param2, int value)
                                            {
                                                DeepChildren = param0;
                                                TraversalChild = param1;
                                                Name = param2;

                                                Root = root;
                                                Value = value;
                                            }

                                            public global::Graphify.Testing.Traversals Root { get; private set; }

                                            public global::Graphify.Testing.TraversalChild[] DeepChildren { get; private set; }

                                            public global::Graphify.Testing.TraversalChild TraversalChild { get; private set; }

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
            "Graphify.Testing.Traversals.DeepChildren.TraversalChild.Name.Length.g.cs");

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
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddTraversalsNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::Graphify.INavigator<Traversals>>(
                                services, (global::System.IServiceProvider provider) => (global::Graphify.INavigator<Traversals>)provider.GetService(typeof(TraversalsNavigator)));

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
            "Graphify.Testing.ServiceCollectionExtensions.AddTraversalsNavigator.g.cs");
    }
}
