namespace Graphify.Snippets.Declarations.Classes;

internal static partial class Nested
{
    public static partial class InStruct
    {
        public static class Expected
        {
            public static readonly Generated ConstructorForEncapsulatedValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public Inner(int value)
                            {
                                _value = value;
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasConstructorForEncapsulatedValue,
                "Graphify.Testing.Classes.Outter.Inner.ctor");

            public static readonly Generated ConversionFromValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public static implicit operator int(Inner subject)
                            {
                                if (ReferenceEquals(subject, null))
                                {
                                    throw new ArgumentNullException("subject");
                                }

                                return subject._value;
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasConversionFrom,
                "Graphify.Testing.Classes.Outter.Inner.ConvertFrom");

            public static readonly Generated ConversionToValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public static implicit operator Inner(int value)
                            {
                                return new Inner(value);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasConversionTo,
                "Graphify.Testing.Classes.Outter.Inner.ConvertTo");

            public static readonly Generated EquatableForSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner : IEquatable<Inner>
                        {
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatableForSelf,
                "Graphify.Testing.Classes.Outter.Inner.IEquatable.Self");

            public static readonly Generated EquatableForValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner : IEquatable<int>
                        {
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatableForValue,
                "Graphify.Testing.Classes.Outter.Inner.IEquatable.Value");

            public static readonly Generated EqualityOperatorForSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public static bool operator ==(Inner left, Inner right)
                            {
                                if (ReferenceEquals(left, right))
                                {
                                    return true;
                                }

                                if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                                {
                                    return false;
                                }

                                return left.Equals(right);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualityOperatorForSelf,
                "Graphify.Testing.Classes.Outter.Inner.Equality.Self");

            public static readonly Generated EqualityOperatorForValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public static bool operator ==(Inner left, int right)
                            {
                                if (ReferenceEquals(left, right))
                                {
                                    return true;
                                }

                                if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                                {
                                    return false;
                                }

                                return left.Equals(right);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualityOperatorForValue,
                "Graphify.Testing.Classes.Outter.Inner.Equality.Value");

            public static new readonly Generated Equals = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public override bool Equals(object other)
                            {
                                if (other is Inner)
                                {
                                    return Equals((Inner)other);
                                }

                                return false;
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualsOverride,
                "Graphify.Testing.Classes.Outter.Inner.Equals");

            public static readonly Generated FieldForEncapsulatedValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            private readonly int _value;
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasFieldForEncapsulatedValue,
                "Graphify.Testing.Classes.Outter.Inner._value");

            public static new readonly Generated GetHashCode = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public override int GetHashCode()
                            {
                                return global::Graphify.Internal.HashCode.Combine(_value);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasGetHashCodeOverride,
                "Graphify.Testing.Classes.Outter.Inner.GetHashCode");

            public static readonly Generated InequalityOperatorForSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public static bool operator !=(Inner left, Inner right)
                            {
                                return !(left == right);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasInequalityOperatorForSelf,
                "Graphify.Testing.Classes.Outter.Inner.Inequality.Self");

            public static readonly Generated InequalityOperatorForValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public static bool operator !=(Inner left, int right)
                            {
                                return !(left == right);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasInequalityOperatorForValue,
                "Graphify.Testing.Classes.Outter.Inner.Inequality.Value");

            public static new readonly Generated ToString = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public override string ToString()
                            {
                                return string.Format("Inner {{ {0} }}", _value);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasToStringOverride,
                "Graphify.Testing.Classes.Outter.Inner.ToString");

            public static readonly Generated EquatableToSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public bool Equals(Inner other)
                            {
                                if (ReferenceEquals(this, other))
                                {
                                    return true;
                                }

                                if (ReferenceEquals(other, null))
                                {
                                    return false;
                                }

                                return Equals(other._value);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.IsEquatableToSelf,
                "Graphify.Testing.Classes.Outter.Inner.IEquatable.Self.Equals");

            public static readonly Generated EquatableToValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    readonly ref partial struct Outter<T>
                    {
                        sealed partial class Inner
                        {
                            public bool Equals(int other)
                            {
                                if (ReferenceEquals(this, other))
                                {
                                    return true;
                                }

                                if (ReferenceEquals(other, null))
                                {
                                    return false;
                                }

                                return global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(_value, other);
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.IsEquatableToValue,
                "Graphify.Testing.Classes.Outter.Inner.IEquatable.Value.Equals");
        }
    }
}