namespace Graphify.Snippets.Declarations.Records;

internal static partial class Nested
{
    public static partial class InRecord
    {
        public static class Expected
        {
            public static readonly Generated ConstructorForEncapsulatedValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.ctor");

            public static readonly Generated ConversionFromValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.ConvertFrom");

            public static readonly Generated ConversionToValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.ConvertTo");

            public static readonly Generated EquatableForSelf = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner : IEquatable<Inner>
                        {
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatableForSelf,
                "Graphify.Testing.Records.Outter.Inner.IEquatable.Self");

            public static readonly Generated EquatableForValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner : IEquatable<int>
                        {
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatableForValue,
                "Graphify.Testing.Records.Outter.Inner.IEquatable.Value");

            public static readonly Generated EqualityOperatorForSelf = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.Equality.Self");

            public static readonly Generated EqualityOperatorForValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.Equality.Value");

            public static new readonly Generated Equals = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.Equals");

            public static readonly Generated FieldForEncapsulatedValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner._value");

            public static new readonly Generated GetHashCode = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.GetHashCode");

            public static readonly Generated InequalityOperatorForSelf = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.Inequality.Self");

            public static readonly Generated InequalityOperatorForValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.Inequality.Value");

            public static new readonly Generated ToString = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.ToString");

            public static readonly Generated EquatableToSelf = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.IEquatable.Self.Equals");

            public static readonly Generated EquatableToValue = new(
                """
                namespace Graphify.Testing.Records
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial record Outter<T>
                    {
                        sealed partial record Inner
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
                "Graphify.Testing.Records.Outter.Inner.IEquatable.Value.Equals");
        }
    }
}