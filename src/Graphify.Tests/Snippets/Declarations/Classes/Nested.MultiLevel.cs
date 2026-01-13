namespace Graphify.Snippets.Declarations.Classes;

using static Graphify.Snippets.Declarations.Attributes.Annotations;

internal static partial class Nested
{
    public static partial class MultiLevel
    {
        public static readonly Snippets Declaration = new(
            [NonGeneric],
            Declarations.Main,
            [
                Expected.ConstructorForEncapsulatedValue,
                Expected.ConversionFromValue,
                Expected.ConversionToValue,
                Expected.EqualityOperatorForSelf,
                Expected.EqualityOperatorForValue,
                Expected.EqualsOverride,
                Expected.EquatableForSelf,
                Expected.EquatableToSelf,
                Expected.EquatableForValue,
                Expected.EquatableToValue,
                Expected.FieldForEncapsulatedValue,
                Expected.GetHashCode,
                Expected.InequalityOperatorForSelf,
                Expected.InequalityOperatorForValue,
                Expected.ToString,
            ],
            [
                new(Expected.ConstructorForEncapsulatedValue.Content, Extensions.HasConstructorForEncapsulatedValue),
                new(Expected.ConversionFromValue.Content, Extensions.HasConversionFrom),
                new(Expected.ConversionToValue.Content, Extensions.HasConversionTo),
                new(Expected.EqualityOperatorForSelf.Content, Extensions.HasEqualityOperatorForSelf),
                new(Expected.EqualityOperatorForValue.Content, Extensions.HasEqualityOperatorForValue),
                new(Expected.EqualsOverride.Content, Extensions.HasEqualsOverride),
                new(Expected.EquatableForSelf.Content, Extensions.HasEquatableForSelf),
                new(Expected.EquatableToSelf.Content, Extensions.IsEquatableToSelf),
                new(Expected.EquatableForValue.Content, Extensions.HasEquatableForValue),
                new(Expected.EquatableToValue.Content, Extensions.IsEquatableToValue),
                new(Expected.FieldForEncapsulatedValue.Content, Extensions.HasFieldForEncapsulatedValue),
                new(Expected.GetHashCode.Content, Extensions.HasGetHashCodeOverride),
                new(Expected.InequalityOperatorForSelf.Content, Extensions.HasInequalityOperatorForSelf),
                new(Expected.InequalityOperatorForValue.Content, Extensions.HasInequalityOperatorForValue),
                new(Expected.ToString.Content, Extensions.HasToStringOverride),
            ],
            nameof(MultiLevel));
    }
}