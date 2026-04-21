namespace Graphify.Snippets.Declarations.Synchronous;

internal static partial class Complex
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

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Age
                            {
                                internal Age(global::Graphify.Testing.Synchronous.Complex root, int value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

                                public int Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Complex.Age.g.cs");

        public static readonly Generated Children = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Children
                            {
                                internal Children(global::Graphify.Testing.Synchronous.Complex root, global::Graphify.Testing.Synchronous.Child[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

                                public global::Graphify.Testing.Synchronous.Child[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Complex.Children.g.cs");

        public static readonly Generated ChildrenChild = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public partial class Children
                            {
                                public sealed partial class Child
                                {
                                    internal Child(Complex.Graph.Children children, int index, global::Graphify.Testing.Synchronous.Complex root, global::Graphify.Testing.Synchronous.Child value)
                                    {
                                        Children = children;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public Complex.Graph.Children Children { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

                                    public global::Graphify.Testing.Synchronous.Child Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Complex.Children.Child.g.cs");

        public static readonly Generated ChildrenChildAge = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public partial class Children
                            {
                                public partial class Child
                                {
                                    public sealed partial class Age
                                    {
                                        internal Age(Complex.Graph.Children.Child child, global::Graphify.Testing.Synchronous.Complex root, int value)
                                        {
                                            Child = child;

                                            Root = root;
                                            Value = value;
                                        }

                                        public Complex.Graph.Children.Child Child { get; private set; }

                                        public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

                                        public int Value { get; private set; }
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
            "Graphify.Testing.Synchronous.Complex.Children.Child.Age.g.cs");

        public static readonly Generated ChildrenChildName = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public partial class Children
                            {
                                public partial class Child
                                {
                                    public sealed partial class Name
                                    {
                                        internal Name(Complex.Graph.Children.Child child, global::Graphify.Testing.Synchronous.Complex root, string value)
                                        {
                                            Child = child;

                                            Root = root;
                                            Value = value;
                                        }

                                        public Complex.Graph.Children.Child Child { get; private set; }

                                        public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

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
            "Graphify.Testing.Synchronous.Complex.Children.Child.Name.g.cs");

        public static readonly Generated ChildrenChildNameLength = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public partial class Children
                            {
                                public partial class Child
                                {
                                    public partial class Name
                                    {
                                        public sealed partial class Length
                                        {
                                            internal Length(Complex.Graph.Children.Child.Name name, global::Graphify.Testing.Synchronous.Complex root, int value)
                                            {
                                                Name = name;

                                                Root = root;
                                                Value = value;
                                            }

                                            public Complex.Graph.Children.Child.Name Name { get; private set; }

                                            public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

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
            "Graphify.Testing.Synchronous.Complex.Children.Child.Name.Length.g.cs");

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

                    public partial interface IComplexNavigator
                    {
                        global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Complex root);
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.IComplexNavigator.g.cs");

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

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Name
                            {
                                internal Name(global::Graphify.Testing.Synchronous.Complex root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.Complex.Name.g.cs");

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

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public partial class Name
                            {
                                public sealed partial class Length
                                {
                                    internal Length(Complex.Graph.Name name, global::Graphify.Testing.Synchronous.Complex root, int value)
                                    {
                                        Name = name;

                                        Root = root;
                                        Value = value;
                                    }

                                    public Complex.Graph.Name Name { get; private set; }

                                    public global::Graphify.Testing.Synchronous.Complex Root { get; private set; }

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
            "Graphify.Testing.Synchronous.Complex.Name.Length.g.cs");

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

                    public sealed partial class ComplexNavigator
                        : IComplexNavigator
                    {
                        private readonly global::System.IServiceProvider _provider;

                        public ComplexNavigator(global::System.IServiceProvider provider)
                        {
                            if (global::System.Object.ReferenceEquals(provider, null))
                            {
                                throw new global::System.ArgumentNullException(nameof(provider));
                            }

                            _provider = provider;
                        }

                        public global::System.Collections.Generic.IEnumerable<TResult> Navigate<TResult>(Complex root)
                        {
                            var results = global::System.Linq.Enumerable.Empty<TResult>();

                            if (_provider.HasInspectors<Complex, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex, TResult>> inspectors))
                            {
                                results = _provider.Invoke<Complex, TResult>(root, inspectors);
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateAge<TResult>(root, root.Age));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateChildren<TResult>(root, root.Children));
                            results = global::System.Linq.Enumerable.Concat(results, NavigateName<TResult>(root, root.Name));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ComplexNavigator.g.cs");

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

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateAge<TResult>(global::Graphify.Testing.Synchronous.Complex root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var age = new Complex.Graph.Age(root, value);

                            if (_provider.HasInspectors<Complex.Graph.Age, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Age, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Age, TResult>(age, inspectors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ComplexNavigator.Age.g.cs");

        public static readonly Generated NavigatorChildren = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateChildren<TResult>(global::Graphify.Testing.Synchronous.Complex root, global::Graphify.Testing.Synchronous.Child[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var children = new Complex.Graph.Children(root, value);

                            if (_provider.HasInspectors<Complex.Graph.Children, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Children, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Children, TResult>(children, inspectors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateChildrenChild<TResult>(children, root, value));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ComplexNavigator.Children.g.cs");

        public static readonly Generated NavigatorChildrenChild = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateChildrenChild<TResult>(Complex.Graph.Children children, global::Graphify.Testing.Synchronous.Complex root, global::Graphify.Testing.Synchronous.Child[] value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();

                            _ = _provider.HasInspectors<Complex.Graph.Children.Child, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Children.Child, TResult>> inspectors);

                            int index = 0;

                            foreach (global::Graphify.Testing.Synchronous.Child element in value)
                            {
                                var child = new Complex.Graph.Children.Child(children, index, root, element);

                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Children.Child, TResult>(child, inspectors));

                                results = global::System.Linq.Enumerable.Concat(results, NavigateChildrenChildAge<TResult>(child, root, element.Age));
                                results = global::System.Linq.Enumerable.Concat(results, NavigateChildrenChildName<TResult>(child, root, element.Name));

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
            "Graphify.Testing.Synchronous.ComplexNavigator.Children.Child.g.cs");

        public static readonly Generated NavigatorChildrenChildAge = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateChildrenChildAge<TResult>(Complex.Graph.Children.Child child, global::Graphify.Testing.Synchronous.Complex root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var age = new Complex.Graph.Children.Child.Age(child, root, value);

                            if (_provider.HasInspectors<Complex.Graph.Children.Child.Age, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Children.Child.Age, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Children.Child.Age, TResult>(age, inspectors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ComplexNavigator.Children.Child.Age.g.cs");

        public static readonly Generated NavigatorChildrenChildName = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateChildrenChildName<TResult>(Complex.Graph.Children.Child child, global::Graphify.Testing.Synchronous.Complex root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var name = new Complex.Graph.Children.Child.Name(child, root, value);

                            if (_provider.HasInspectors<Complex.Graph.Children.Child.Name, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Children.Child.Name, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Children.Child.Name, TResult>(name, inspectors));
                            }

                            results = global::System.Linq.Enumerable.Concat(results, NavigateChildrenChildNameLength<TResult>(name, root, value.Length));

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ComplexNavigator.Children.Child.Name.g.cs");

        public static readonly Generated NavigatorChildrenChildNameLength = new(
            """
                namespace Graphify.Testing.Synchronous
                {
                    using System;
                    using System.Collections.Generic;
                    using Graphify;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateChildrenChildNameLength<TResult>(Complex.Graph.Children.Child.Name name, global::Graphify.Testing.Synchronous.Complex root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var length = new Complex.Graph.Children.Child.Name.Length(name, root, value);

                            if (_provider.HasInspectors<Complex.Graph.Children.Child.Name.Length, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Children.Child.Name.Length, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Children.Child.Name.Length, TResult>(length, inspectors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ComplexNavigator.Children.Child.Name.Length.g.cs");

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

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateName<TResult>(global::Graphify.Testing.Synchronous.Complex root, string value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var name = new Complex.Graph.Name(root, value);

                            if (_provider.HasInspectors<Complex.Graph.Name, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Name, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Name, TResult>(name, inspectors));
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
            "Graphify.Testing.Synchronous.ComplexNavigator.Name.g.cs");

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

                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IEnumerable<TResult> NavigateNameLength<TResult>(Complex.Graph.Name name, global::Graphify.Testing.Synchronous.Complex root, int value)
                        {
                            global::System.Collections.Generic.IEnumerable<TResult> results = global::System.Linq.Enumerable.Empty<TResult>();
                            var length = new Complex.Graph.Name.Length(name, root, value);

                            if (_provider.HasInspectors<Complex.Graph.Name.Length, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IInspector<Complex.Graph.Name.Length, TResult>> inspectors))
                            {
                                results = global::System.Linq.Enumerable.Concat(results, _provider.Invoke<Complex.Graph.Name.Length, TResult>(length, inspectors));
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ComplexNavigator.Name.Length.g.cs");

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
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddComplexNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<IComplexNavigator>(
                                services, (global::System.IServiceProvider provider) => (IComplexNavigator)provider.GetService(typeof(ComplexNavigator)));

                            return global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<ComplexNavigator>(services);
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Synchronous.ServiceCollectionExtensions.AddComplexNavigator.g.cs");
    }
}