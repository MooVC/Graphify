namespace Graphify.Snippets.Declarations;

internal static partial class Complex
{
    public static class Expected
    {
        public static readonly Generated Age = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Age
                            {
                                internal Age(global::Graphify.Testing.Complex root, int value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Complex Root { get; private set; }

                                public int Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Age.g.cs");

        public static readonly Generated Children = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Children
                            {
                                internal Children(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Complex Root { get; private set; }

                                public global::Graphify.Testing.Child[] Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Children.g.cs");

        public static readonly Generated ChildrenChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                    internal Child(int index, global::Graphify.Testing.Complex root, global::Graphify.Testing.Child value)
                                    {
                                        Index = index;
                                        Root = root;
                                        Value = value;
                                    }

                                    public int Index { get; private set; }

                                    public global::Graphify.Testing.Complex Root { get; private set; }

                                    public global::Graphify.Testing.Child Value { get; private set; }
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Children.Child.g.cs");

        public static readonly Generated ChildrenChildAge = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                        internal Age(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] param0, global::Graphify.Testing.Child param1, int value)
                                        {
                                            Children = param0;
                                            Child = param1;

                                            Root = root;
                                            Value = value;
                                        }

                                        public global::Graphify.Testing.Complex Root { get; private set; }

                                        public global::Graphify.Testing.Child[] Children { get; private set; }

                                        public global::Graphify.Testing.Child Child { get; private set; }

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
            "Graphify.Testing.Complex.Children.Child.Age.g.cs");

        public static readonly Generated ChildrenChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                        internal Name(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] param0, global::Graphify.Testing.Child param1, string value)
                                        {
                                            Children = param0;
                                            Child = param1;

                                            Root = root;
                                            Value = value;
                                        }

                                        public global::Graphify.Testing.Complex Root { get; private set; }

                                        public global::Graphify.Testing.Child[] Children { get; private set; }

                                        public global::Graphify.Testing.Child Child { get; private set; }

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
            "Graphify.Testing.Complex.Children.Child.Name.g.cs");

        public static readonly Generated ChildrenChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                            internal Length(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] param0, global::Graphify.Testing.Child param1, string param2, int value)
                                            {
                                                Children = param0;
                                                Child = param1;
                                                Name = param2;

                                                Root = root;
                                                Value = value;
                                            }

                                            public global::Graphify.Testing.Complex Root { get; private set; }

                                            public global::Graphify.Testing.Child[] Children { get; private set; }

                                            public global::Graphify.Testing.Child Child { get; private set; }

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
            "Graphify.Testing.Complex.Children.Child.Name.Length.g.cs");

        public static readonly Generated Contract = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    public partial interface IComplexNavigator
                        : global::Graphify.INavigator<Complex>
                    {
                        //// Additional methods can be added as partial elements
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.IComplexNavigator.g.cs");

        public static readonly Generated Name = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Complex
                    {
                        public static partial class Graph
                        {
                            public sealed partial class Name
                            {
                                internal Name(global::Graphify.Testing.Complex root, string value)
                                {
                                    Root = root;
                                    Value = value;
                                }

                                public global::Graphify.Testing.Complex Root { get; private set; }

                                public string Value { get; private set; }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.Complex.Name.g.cs");

        public static readonly Generated NameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

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
                                    internal Length(global::Graphify.Testing.Complex root, string param0, int value)
                                    {
                                        Name = param0;

                                        Root = root;
                                        Value = value;
                                    }

                                    public global::Graphify.Testing.Complex Root { get; private set; }

                                    public string Name { get; private set; }

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
            "Graphify.Testing.Complex.Name.Length.g.cs");

        public static readonly Generated Navigator = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                        : global::Graphify.Navigator<Complex>,
                          IComplexNavigator
                    {
                        public ComplexNavigator(global::System.IServiceProvider provider)
                            : base(provider)
                        {
                        }

                        public override IAsyncEnumerable<TResult> Navigate<TResult>(Complex root, global::System.Threading.CancellationToken cancellationToken)
                        {
                            var results = Empty<TResult>();

                            if (HasObservers<Complex, TResult>(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex, TResult>> observers))
                            {
                                results = Invoke<Complex, TResult>(root, observers, cancellationToken);
                            }

                            results = Concat(results, NavigateAge<TResult>(root, root.Age, cancellationToken), cancellationToken);
                            results = Concat(results, NavigateChildren<TResult>(root, root.Children, cancellationToken), cancellationToken);
                            results = Concat(results, NavigateName<TResult>(root, root.Name, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.g.cs");

        public static readonly Generated NavigatorAge = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateAge<TResult>(global::Graphify.Testing.Complex root, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Age, TResult>> observers))
                            {
                                var instance = new Complex.Graph.Age(root, value);

                                results = Concat(results, Invoke<Complex.Graph.Age, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.Age.g.cs");

        public static readonly Generated NavigatorChildren = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildren<TResult>(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Children, TResult>> observers))
                            {
                                var instance = new Complex.Graph.Children(root, value);

                                results = Concat(results, Invoke<Complex.Graph.Children, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateChildrenChild<TResult>(root, value, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.Children.g.cs");

        public static readonly Generated NavigatorChildrenChild = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChild<TResult>(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            _ = HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Children.Child, TResult>> observers);

                            int index = 0;

                            foreach (global::Graphify.Testing.Child element in value)
                            {
                                var instance = new Complex.Graph.Children.Child(index, root, element);

                                results = Concat(results, Invoke<Complex.Graph.Children.Child, TResult>(instance, observers, cancellationToken), cancellationToken);

                                results = Concat(results, NavigateChildrenChildAge<TResult>(root, value, element, element.Age, cancellationToken), cancellationToken);
                                results = Concat(results, NavigateChildrenChildName<TResult>(root, value, element, element.Name, cancellationToken), cancellationToken);

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
            "Graphify.Testing.ComplexNavigator.Children.Child.g.cs");

        public static readonly Generated NavigatorChildrenChildAge = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChildAge<TResult>(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] param0, global::Graphify.Testing.Child param1, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Children.Child.Age, TResult>> observers))
                            {
                                var instance = new Complex.Graph.Children.Child.Age(root, param0, param1, value);

                                results = Concat(results, Invoke<Complex.Graph.Children.Child.Age, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.Children.Child.Age.g.cs");

        public static readonly Generated NavigatorChildrenChildName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChildName<TResult>(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] param0, global::Graphify.Testing.Child param1, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Children.Child.Name, TResult>> observers))
                            {
                                var instance = new Complex.Graph.Children.Child.Name(root, param0, param1, value);

                                results = Concat(results, Invoke<Complex.Graph.Children.Child.Name, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateChildrenChildNameLength<TResult>(root, param0, param1, value, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.Children.Child.Name.g.cs");

        public static readonly Generated NavigatorChildrenChildNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateChildrenChildNameLength<TResult>(global::Graphify.Testing.Complex root, global::Graphify.Testing.Child[] param0, global::Graphify.Testing.Child param1, string param2, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Children.Child.Name.Length, TResult>> observers))
                            {
                                var instance = new Complex.Graph.Children.Child.Name.Length(root, param0, param1, param2, value);

                                results = Concat(results, Invoke<Complex.Graph.Children.Child.Name.Length, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.Children.Child.Name.Length.g.cs");

        public static readonly Generated NavigatorName = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateName<TResult>(global::Graphify.Testing.Complex root, string value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Name, TResult>> observers))
                            {
                                var instance = new Complex.Graph.Name(root, value);

                                results = Concat(results, Invoke<Complex.Graph.Name, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            results = Concat(results, NavigateNameLength<TResult>(root, value, value.Length, cancellationToken), cancellationToken);

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.Name.g.cs");

        public static readonly Generated NavigatorNameLength = new(
            """
                namespace Graphify.Testing
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    internal sealed partial class ComplexNavigator
                    {
                        private global::System.Collections.Generic.IAsyncEnumerable<TResult> NavigateNameLength<TResult>(global::Graphify.Testing.Complex root, string param0, int value, global::System.Threading.CancellationToken cancellationToken)
                        {
                            global::System.Collections.Generic.IAsyncEnumerable<TResult> results = Empty<TResult>();

                            if (HasObservers(out global::System.Collections.Generic.IEnumerable<global::Graphify.IVisitor<Complex.Graph.Name.Length, TResult>> observers))
                            {
                                var instance = new Complex.Graph.Name.Length(root, param0, value);

                                results = Concat(results, Invoke<Complex.Graph.Name.Length, TResult>(instance, observers, cancellationToken), cancellationToken);
                            }

                            return results;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
            "Graphify.Testing.ComplexNavigator.Name.Length.g.cs");

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
                        public static global::Microsoft.Extensions.DependencyInjection.IServiceCollection AddComplexNavigator(this global::Microsoft.Extensions.DependencyInjection.IServiceCollection services)
                        {
                            if (ReferenceEquals(services, null))
                            {
                                throw new global::System.ArgumentNullException("services");
                            }

                            _ = global::Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<global::Graphify.INavigator<Complex>>(
                                services, (global::System.IServiceProvider provider) => (global::Graphify.INavigator<Complex>)provider.GetService(typeof(ComplexNavigator)));

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
            "Graphify.Testing.ServiceCollectionExtensions.AddComplexNavigator.g.cs");
    }
}