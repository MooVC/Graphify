namespace Graphify.Snippets.Declarations.Synchronous;

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
                    using Graphify;

                    #nullable disable

                    public partial interface ITraversalsNavigator
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Traversals root);
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.ITraversalsNavigator.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                        : ITraversalsNavigator
                    {
                        private readonly global::System.IServiceProvider _provider;

                        public TraversalsNavigator(global::System.IServiceProvider provider)
                        {
                            if (global::System.Object.ReferenceEquals(provider, null))
                            {
                                throw new global::System.ArgumentNullException(nameof(provider));
                            }

                            _provider = provider;
                        }

                        public global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Traversals root)
                        {
                            var results = global::System.Linq.Enumerable.Empty<TResult>();

                            if (_provider.HasInspectors<Traversals, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals, TResult>> inspectors))
                            {
                                results = _provider.Invoke<Traversals, TResult>(root, inspectors);
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateTitle<TResult>(root, root.Title));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateDescription<TResult>(root, root.Description));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateShallowChildren<TResult>(root, root.ShallowChildren));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildren<TResult>(root, root.DeepChildren));

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.g.cs");

        public static readonly Generated NavigatorTitle = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateTitle<TResult>(global::Graphify.Testing.Traversals root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var title = new Traversals.Graph.Title(root, value);

                            if (_provider.HasInspectors<Traversals.Graph.Title, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.Title, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.Title, TResult>(title, inspectors));
                            }

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.Title.g.cs");

        public static readonly Generated NavigatorDescription = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDescription<TResult>(global::Graphify.Testing.Traversals root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var description = new Traversals.Graph.Description(root, value);

                            if (_provider.HasInspectors<Traversals.Graph.Description, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.Description, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.Description, TResult>(description, inspectors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateDescriptionLength<TResult>(description, root, value.Length));

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.Description.g.cs");

        public static readonly Generated NavigatorDescriptionLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDescriptionLength<TResult>(Traversals.Graph.Description description, global::Graphify.Testing.Traversals root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var length = new Traversals.Graph.Description.Length(description, root, value);

                            if (_provider.HasInspectors<Traversals.Graph.Description.Length, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.Description.Length, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.Description.Length, TResult>(length, inspectors));
                            }

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.Description.Length.g.cs");

        public static readonly Generated NavigatorShallowChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateShallowChildren<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var shallowChildren = new Traversals.Graph.ShallowChildren(root, value);

                            if (_provider.HasInspectors<Traversals.Graph.ShallowChildren, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.ShallowChildren, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.ShallowChildren, TResult>(shallowChildren, inspectors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateShallowChildrenTraversalChild<TResult>(shallowChildren, root, value));

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.ShallowChildren.g.cs");

        public static readonly Generated NavigatorShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateShallowChildrenTraversalChild<TResult>(Traversals.Graph.ShallowChildren shallowChildren, global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            _ = _provider.HasInspectors<Traversals.Graph.ShallowChildren.TraversalChild, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.ShallowChildren.TraversalChild, TResult>> inspectors);

                            int index = 0;

                            foreach (global::Graphify.Testing.TraversalChild element in value)
                            {
                                var traversalChild = new Traversals.Graph.ShallowChildren.TraversalChild(shallowChildren, index, root, element);

                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.ShallowChildren.TraversalChild, TResult>(traversalChild, inspectors));

                                index++;
                            }

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildren<TResult>(global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var deepChildren = new Traversals.Graph.DeepChildren(root, value);

                            if (_provider.HasInspectors<Traversals.Graph.DeepChildren, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.DeepChildren, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.DeepChildren, TResult>(deepChildren, inspectors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildrenTraversalChild<TResult>(deepChildren, root, value));

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.DeepChildren.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildrenTraversalChild<TResult>(Traversals.Graph.DeepChildren deepChildren, global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            _ = _provider.HasInspectors<Traversals.Graph.DeepChildren.TraversalChild, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.DeepChildren.TraversalChild, TResult>> inspectors);

                            int index = 0;

                            foreach (global::Graphify.Testing.TraversalChild element in value)
                            {
                                var traversalChild = new Traversals.Graph.DeepChildren.TraversalChild(deepChildren, index, root, element);

                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.DeepChildren.TraversalChild, TResult>(traversalChild, inspectors));

                                results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildrenTraversalChildName<TResult>(traversalChild, root, element.Name));

                                index++;
                            }

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildrenTraversalChildName<TResult>(Traversals.Graph.DeepChildren.TraversalChild traversalChild, global::Graphify.Testing.Traversals root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var name = new Traversals.Graph.DeepChildren.TraversalChild.Name(traversalChild, root, value);

                            if (_provider.HasInspectors<Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.DeepChildren.TraversalChild.Name, TResult>(name, inspectors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateDeepChildrenTraversalChildNameLength<TResult>(name, root, value.Length));

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated NavigatorDeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    public sealed partial class TraversalsNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateDeepChildrenTraversalChildNameLength<TResult>(Traversals.Graph.DeepChildren.TraversalChild.Name name, global::Graphify.Testing.Traversals root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var length = new Traversals.Graph.DeepChildren.TraversalChild.Name.Length(name, root, value);

                            if (_provider.HasInspectors<Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Traversals.Graph.DeepChildren.TraversalChild.Name.Length, TResult>(length, inspectors));
                            }

                            return results;
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.TraversalsNavigator.DeepChildren.TraversalChild.Name.Length.g.cs");

        public static readonly Generated Title = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

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

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.Title.g.cs");

        public static readonly Generated Description = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

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

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.Description.g.cs");

        public static readonly Generated DescriptionLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class Description
                            {
                                public sealed partial class Length
                                {
                                    internal Length(Traversals.Graph.Description description, global::Graphify.Testing.Traversals root, int value)
                                    {
                                        Description = description;

                                        Root = root;
                                        Value = value;
                                    }

                                    public Traversals.Graph.Description Description { get; private set; }

                                    public global::Graphify.Testing.Traversals Root { get; private set; }

                                    public int Value { get; private set; }
                                }
                            }
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.Description.Length.g.cs");

        public static readonly Generated ShallowChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

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

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.ShallowChildren.g.cs");

        public static readonly Generated ShallowChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class ShallowChildren
                            {
                                public sealed partial class TraversalChild
                                {
                                    internal TraversalChild(Traversals.Graph.ShallowChildren shallowChildren, int index, global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild value)
                                    {
                                        ShallowChildren = shallowChildren;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public Traversals.Graph.ShallowChildren ShallowChildren { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.ShallowChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

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

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.DeepChildren.g.cs");

        public static readonly Generated DeepChildrenTraversalChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

                    partial class Traversals
                    {
                        public static partial class Graph
                        {
                            public partial class DeepChildren
                            {
                                public sealed partial class TraversalChild
                                {
                                    internal TraversalChild(Traversals.Graph.DeepChildren deepChildren, int index, global::Graphify.Testing.Traversals root, global::Graphify.Testing.TraversalChild value)
                                    {
                                        DeepChildren = deepChildren;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public Traversals.Graph.DeepChildren DeepChildren { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Traversals Root { get; private set; }

                                    public global::Graphify.Testing.TraversalChild Value { get; private set; }
                                }
                            }
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.DeepChildren.TraversalChild.g.cs");

        public static readonly Generated DeepChildrenTraversalChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

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
                                        internal Name(Traversals.Graph.DeepChildren.TraversalChild traversalChild, global::Graphify.Testing.Traversals root, string value)
                                        {
                                            TraversalChild = traversalChild;

                                            Root = root;
                                            Value = value;
                                        }

                                        public Traversals.Graph.DeepChildren.TraversalChild TraversalChild { get; private set; }

                                        public global::Graphify.Testing.Traversals Root { get; private set; }

                                        public string Value { get; private set; }
                                    }
                                }
                            }
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.DeepChildren.TraversalChild.Name.g.cs");

        public static readonly Generated DeepChildrenTraversalChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #nullable disable

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
                                            internal Length(Traversals.Graph.DeepChildren.TraversalChild.Name name, global::Graphify.Testing.Traversals root, int value)
                                            {
                                                Name = name;

                                                Root = root;
                                                Value = value;
                                            }

                                            public Traversals.Graph.DeepChildren.TraversalChild.Name Name { get; private set; }

                                            public global::Graphify.Testing.Traversals Root { get; private set; }

                                            public int Value { get; private set; }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    #nullable restore
                }
                """,
            "Graphify.Testing.Traversals.DeepChildren.TraversalChild.Name.Length.g.cs");

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

                    #nullable restore
                }
                """,
            "Graphify.Testing.ServiceCollectionExtensions.AddTraversalsNavigator.g.cs");
    }
}