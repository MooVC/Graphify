namespace Graphify.Snippets.Declarations.Asynchronous;

internal static partial class Complex
{
    public static class Expected
    {
        public static readonly Generated Age = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                            {
                                internal Age(global::Graphify.Testing.Asynchronous.Complex root, int value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

                                public int Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Complex.Age.g.cs");

        public static readonly Generated Children = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                            {
                                internal Children(global::Graphify.Testing.Asynchronous.Complex root, global::Graphify.Testing.Asynchronous.Child[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

                                public global::Graphify.Testing.Asynchronous.Child[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Complex.Children.g.cs");

        public static readonly Generated ChildrenChild = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                    : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                                {
                                    internal Child(Complex.Graph.Children children, int index, global::Graphify.Testing.Asynchronous.Complex root, global::Graphify.Testing.Asynchronous.Child value)
                                    {
                                        Children = children;

                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public Complex.Graph.Children Children { get; private set; }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.Child Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Complex.Children.Child.g.cs");

        public static readonly Generated ChildrenChildAge = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                        : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                                    {
                                        internal Age(Complex.Graph.Children.Child child, global::Graphify.Testing.Asynchronous.Complex root, int value)
                                        {
                                            Child = child;

                                            Root = root;
                                            Value = value;
                                        }

                                        public Complex.Graph.Children.Child Child { get; private set; }

                                        public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Complex.Children.Child.Age.g.cs");

        public static readonly Generated ChildrenChildName = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                        : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                                    {
                                        internal Name(Complex.Graph.Children.Child child, global::Graphify.Testing.Asynchronous.Complex root, string value)
                                        {
                                            Child = child;

                                            Root = root;
                                            Value = value;
                                        }

                                        public Complex.Graph.Children.Child Child { get; private set; }

                                        public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Complex.Children.Child.Name.g.cs");

        public static readonly Generated ChildrenChildNameLength = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                            : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                                        {
                                            internal Length(Complex.Graph.Children.Child.Name name, global::Graphify.Testing.Asynchronous.Complex root, int value)
                                            {
                                                Name = name;

                                                Root = root;
                                                Value = value;
                                            }

                                            public Complex.Graph.Children.Child.Name Name { get; private set; }

                                            public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Complex.Children.Child.Name.Length.g.cs");

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
                    public partial interface IComplexNavigator
                    {
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(Complex root, global::System.Threading.CancellationToken cancellationToken);
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.IComplexNavigator.g.cs");

        public static readonly Generated Visitor = new(
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
                    public interface IComplexVisitor<in T, out TResult>
                        where T : class
                    {
                        global::System.Collections.Generic.IAsyncEnumerable<TResult> Observe(T instance, global::System.Threading.CancellationToken cancellationToken);
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.IComplexVisitor.g.cs");

        public static readonly Generated Name = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                            {
                                internal Name(global::Graphify.Testing.Asynchronous.Complex root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.Complex.Name.g.cs");

        public static readonly Generated NameLength = new(
            """
                namespace Graphify.Testing.Asynchronous
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
                                    : global::Graphify.IGraph<global::Graphify.Testing.Asynchronous.Complex>
                                {
                                    internal Length(Complex.Graph.Name name, global::Graphify.Testing.Asynchronous.Complex root, int value)
                                    {
                                        Name = name;

                                        Root = root;
                                        Value = value;
                                    }

                                    public Complex.Graph.Name Name { get; private set; }

                                    public global::Graphify.Testing.Asynchronous.Complex Root { get; private set; }

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
            "Graphify.Testing.Asynchronous.Complex.Name.Length.g.cs");

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
                    public sealed partial class ComplexNavigator
                        : IComplexNavigator
                    {
                        private readonly global::System.IServiceProvider _provider;

                        public ComplexNavigator(global::System.IServiceProvider provider)
                        {
                            if (global::System.Object.ReferenceEquals(provider, null))
                            {
                                throw new global::System.ArgumentNullException("provider");
                            }

                            _provider = provider;
                        }

                        public global::System.Collections.Generic.IAsyncEnumerable<TResult> Navigate<TResult>(Complex root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = _provider.Empty<TResult>();

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex, TResult>> observers))
                            {
                                results = Invoke<Complex, TResult>(root, observers, cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateAge<TResult>(root, root.Age, cancellationToken), cancellationToken);
                            results = _provider.Concat(results, NavigateChildren<TResult>(root, root.Children, cancellationToken), cancellationToken);
                            results = _provider.Concat(results, NavigateName<TResult>(root, root.Name, cancellationToken), cancellationToken);

                            return results;
                        }

                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> Invoke<TInstance, TResult>(
                            TInstance instance,
                            global::System.Collections.Generic.IEnumerable<IComplexVisitor<TInstance, TResult>> visitors,
                            global::System.Threading.CancellationToken cancellationToken)
                            where TInstance : class
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();

                            foreach (IComplexVisitor<TInstance, TResult> visitor in visitors)
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
            "Graphify.Testing.Asynchronous.ComplexNavigator.g.cs");

        public static readonly Generated NavigatorAge = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateAge<TResult>(global::Graphify.Testing.Asynchronous.Complex root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var age = new Complex.Graph.Age(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Age, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Complex.Graph.Age, TResult>(age, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.ComplexNavigator.Age.g.cs");

        public static readonly Generated NavigatorChildren = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildren<TResult>(global::Graphify.Testing.Asynchronous.Complex root, global::Graphify.Testing.Asynchronous.Child[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var children = new Complex.Graph.Children(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Children, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Complex.Graph.Children, TResult>(children, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateChildrenChild<TResult>(children, root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ComplexNavigator.Children.g.cs");

        public static readonly Generated NavigatorChildrenChild = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChild<TResult>(Complex.Graph.Children children, global::Graphify.Testing.Asynchronous.Complex root, global::Graphify.Testing.Asynchronous.Child[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();

                            _ = _provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Children.Child, TResult>> observers);

                            int index = 0;

                            foreach (global::Graphify.Testing.Asynchronous.Child element in value)
                            {
                                var child = new Complex.Graph.Children.Child(children, index, root, element);

                                results = _provider.Concat(results, Invoke<Complex.Graph.Children.Child, TResult>(child, observers, cancellationToken), cancellationToken);

                                results = _provider.Concat(results, NavigateChildrenChildAge<TResult>(child, root, element.Age, cancellationToken), cancellationToken);
                                results = _provider.Concat(results, NavigateChildrenChildName<TResult>(child, root, element.Name, cancellationToken), cancellationToken);

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
            "Graphify.Testing.Asynchronous.ComplexNavigator.Children.Child.g.cs");

        public static readonly Generated NavigatorChildrenChildAge = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChildAge<TResult>(Complex.Graph.Children.Child child, global::Graphify.Testing.Asynchronous.Complex root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var age = new Complex.Graph.Children.Child.Age(child, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Children.Child.Age, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Complex.Graph.Children.Child.Age, TResult>(age, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.ComplexNavigator.Children.Child.Age.g.cs");

        public static readonly Generated NavigatorChildrenChildName = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChildName<TResult>(Complex.Graph.Children.Child child, global::Graphify.Testing.Asynchronous.Complex root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var name = new Complex.Graph.Children.Child.Name(child, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Children.Child.Name, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Complex.Graph.Children.Child.Name, TResult>(name, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateChildrenChildNameLength<TResult>(name, root, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ComplexNavigator.Children.Child.Name.g.cs");

        public static readonly Generated NavigatorChildrenChildNameLength = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChildNameLength<TResult>(Complex.Graph.Children.Child.Name name, global::Graphify.Testing.Asynchronous.Complex root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var length = new Complex.Graph.Children.Child.Name.Length(name, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Children.Child.Name.Length, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Complex.Graph.Children.Child.Name.Length, TResult>(length, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.ComplexNavigator.Children.Child.Name.Length.g.cs");

        public static readonly Generated NavigatorName = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateName<TResult>(global::Graphify.Testing.Asynchronous.Complex root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var name = new Complex.Graph.Name(root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Name, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Complex.Graph.Name, TResult>(name, observers, cancellationToken), cancellationToken);
                            }

                            results = _provider.Concat(results, NavigateNameLength<TResult>(name, root, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ComplexNavigator.Name.g.cs");

        public static readonly Generated NavigatorNameLength = new(
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
                    public sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateNameLength<TResult>(Complex.Graph.Name name, global::Graphify.Testing.Asynchronous.Complex root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = _provider.Empty<TResult>();
                            var length = new Complex.Graph.Name.Length(name, root, value);

                            if (_provider.HasVisitors(out global::System.Collections.Generic.IEnumerable<IComplexVisitor<Complex.Graph.Name.Length, TResult>> observers))
                            {
                                results = _provider.Concat(results, Invoke<Complex.Graph.Name.Length, TResult>(length, observers, cancellationToken), cancellationToken);
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
            "Graphify.Testing.Asynchronous.ComplexNavigator.Name.Length.g.cs");

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
                    #endif

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Asynchronous.ServiceCollectionExtensions.AddComplexNavigator.g.cs");
    }
}