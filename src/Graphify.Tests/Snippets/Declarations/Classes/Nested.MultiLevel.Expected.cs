namespace Graphify.Snippets.Declarations.Classes;

internal static partial class Nested
{
    public static partial class MultiLevel
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

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public InlineStyle(int value)
                                {
                                    _value = value;
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasConstructorForEncapsulatedValue,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.ctor");

            public static readonly Generated ConversionFromValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public static implicit operator int(InlineStyle subject)
                                {
                                    if (ReferenceEquals(subject, null))
                                    {
                                        throw new ArgumentNullException("subject");
                                    }

                                    return subject._value;
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasConversionFrom,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.ConvertFrom");

            public static readonly Generated ConversionToValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public static implicit operator InlineStyle(int value)
                                {
                                    return new InlineStyle(value);
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasConversionTo,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.ConvertTo");

            public static readonly Generated EquatableForSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle : IEquatable<InlineStyle>
                            {
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatableForSelf,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.IEquatable.Self");

            public static readonly Generated EquatableForValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle : IEquatable<int>
                            {
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEquatableForValue,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.IEquatable.Value");

            public static readonly Generated EqualityOperatorForSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public static bool operator ==(InlineStyle left, InlineStyle right)
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
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualityOperatorForSelf,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.Equality.Self");

            public static readonly Generated EqualityOperatorForValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public static bool operator ==(InlineStyle left, int right)
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
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualityOperatorForValue,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.Equality.Value");

            public static readonly Generated EqualsOverride = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public override bool Equals(object other)
                                {
                                    if (other is InlineStyle)
                                    {
                                        return Equals((InlineStyle)other);
                                    }

                                    return false;
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasEqualsOverride,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.Equals");

            public static readonly Generated FieldForEncapsulatedValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                private readonly int _value;
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasFieldForEncapsulatedValue,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle._value");

            public static new readonly Generated GetHashCode = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public override int GetHashCode()
                                {
                                    return global::Graphify.Internal.HashCode.Combine(_value);
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasGetHashCodeOverride,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.GetHashCode");

            public static readonly Generated InequalityOperatorForSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public static bool operator !=(InlineStyle left, InlineStyle right)
                                {
                                    return !(left == right);
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasInequalityOperatorForSelf,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.Inequality.Self");

            public static readonly Generated InequalityOperatorForValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public static bool operator !=(InlineStyle left, int right)
                                {
                                    return !(left == right);
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasInequalityOperatorForValue,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.Inequality.Value");

            public static new readonly Generated ToString = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public override string ToString()
                                {
                                    return string.Format("InlineStyle {{ {0} }}", _value);
                                }
                            }
                        }
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.HasToStringOverride,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.ToString");

            public static readonly Generated EquatableToSelf = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
                            {
                                public bool Equals(InlineStyle other)
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
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.IsEquatableToSelf,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.IEquatable.Self.Equals");

            public static readonly Generated EquatableToValue = new(
                """
                namespace Graphify.Testing.Classes
                {
                    using System;
                    using System.Collections.Generic;

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable disable
                    #endif

                    partial class Snippet
                    {
                        partial class BlockOptions
                        {
                            sealed partial class InlineStyle
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
                    }

                    #if NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                    #nullable restore
                    #endif
                }
                """,
                Extensions.IsEquatableToValue,
                "Graphify.Testing.Classes.Snippet.BlockOptions.InlineStyle.IEquatable.Value.Equals");
        }
    }
}