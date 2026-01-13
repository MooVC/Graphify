namespace Graphify.Snippets.Declarations.Classes;

using static Graphify.Snippets.Declarations.Attributes.Annotations;

internal static partial class Nested
{
    public static partial class InRecordStruct
    {
        public static readonly Snippets Declaration = new(
            [Generic, NonGeneric],
            Declarations.Main,
            [
                Expected.ConstructorForEncapsulatedValue,
                Expected.ConversionFromValue,
                Expected.ConversionToValue,
                Expected.EquatableForSelf,
                Expected.EquatableForValue,
                Expected.EqualityOperatorForSelf,
                Expected.EqualityOperatorForValue,
                Expected.Equals,
                Expected.FieldForEncapsulatedValue,
                Expected.GetHashCode,
                Expected.InequalityOperatorForSelf,
                Expected.InequalityOperatorForValue,
                Expected.ToString,
                Expected.EquatableToSelf,
                Expected.EquatableToValue,
            ],
            [
                new(Expected.ConstructorForEncapsulatedValue.Content, Extensions.HasConstructorForEncapsulatedValue),
                new(Expected.ConversionFromValue.Content, Extensions.HasConversionFrom),
                new(Expected.ConversionToValue.Content, Extensions.HasConversionTo),
                new(Expected.EquatableForSelf.Content, Extensions.HasEquatableForSelf),
                new(Expected.EquatableForValue.Content, Extensions.HasEquatableForValue),
                new(Expected.EqualityOperatorForSelf.Content, Extensions.HasEqualityOperatorForSelf),
                new(Expected.EqualityOperatorForValue.Content, Extensions.HasEqualityOperatorForValue),
                new(Expected.Equals.Content, Extensions.HasEqualsOverride),
                new(Expected.FieldForEncapsulatedValue.Content, Extensions.HasFieldForEncapsulatedValue),
                new(Expected.GetHashCode.Content, Extensions.HasGetHashCodeOverride),
                new(Expected.InequalityOperatorForSelf.Content, Extensions.HasInequalityOperatorForSelf),
                new(Expected.InequalityOperatorForValue.Content, Extensions.HasInequalityOperatorForValue),
                new(Expected.ToString.Content, Extensions.HasToStringOverride),
                new(Expected.EquatableToSelf.Content, Extensions.IsEquatableToSelf),
                new(Expected.EquatableToValue.Content, Extensions.IsEquatableToValue),
            ],
            nameof(InRecordStruct));
    }
}