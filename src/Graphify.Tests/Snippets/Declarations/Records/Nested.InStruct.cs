namespace Graphify.Snippets.Declarations.Records;

using static Graphify.Snippets.Declarations.Attributes.Annotations;

internal static partial class Nested
{
    public static partial class InStruct
    {
        public static readonly Snippets Declaration = new(
            [Generic, NonGeneric],
            Declarations.Main,
            [
                Expected.ConstructorForEncapsulatedValue,
                Expected.ConversionFromValue,
                Expected.ConversionToValue,
                Expected.EquatableForValue,
                Expected.EqualityOperatorForValue,
                Expected.FieldForEncapsulatedValue,
                Expected.InequalityOperatorForValue,
                Expected.EquatableToValue,
            ],
            [
                new(Expected.ConstructorForEncapsulatedValue.Content, Extensions.HasConstructorForEncapsulatedValue),
                new(Expected.ConversionFromValue.Content, Extensions.HasConversionFrom),
                new(Expected.ConversionToValue.Content, Extensions.HasConversionTo),
                new(Expected.EquatableForValue.Content, Extensions.HasEquatableForValue),
                new(Expected.EqualityOperatorForValue.Content, Extensions.HasEqualityOperatorForValue),
                new(Expected.FieldForEncapsulatedValue.Content, Extensions.HasFieldForEncapsulatedValue),
                new(Expected.InequalityOperatorForValue.Content, Extensions.HasInequalityOperatorForValue),
                new(Expected.EquatableToValue.Content, Extensions.IsEquatableToValue),
            ],
            nameof(InStruct));
    }
}