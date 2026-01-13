namespace Graphify.Snippets;

[Flags]
public enum Extensions
    : ushort
{
    None = 0,
    HasConstructorForEncapsulatedValue = 0b0000_0000_0001,
    HasConversionFrom = 0b0000_0000_0000_0010,
    HasConversionTo = 0b0000_0000_0000_0100,
    HasEquatableForSelf = 0b0000_0000_0000_1000,
    HasEquatableForValue = 0b0000_0000_0001_0000,
    HasEqualityOperatorForSelf = 0b0000_0000_0010_0000,
    HasEqualityOperatorForValue = 0b0000_0000_0100_0000,
    HasEqualsOverride = 0b0000_0000_1000_0000,
    HasFieldForEncapsulatedValue = 0b0000_0001_0000_0000,
    HasGetHashCodeOverride = 0b0000_0010_0000_0000,
    HasInequalityOperatorForSelf = 0b0000_0100_0000_0000,
    HasInequalityOperatorForValue = 0b0000_1000_0000_0000,
    HasToStringOverride = 0b0001_0000_0000_0000,
    IsEquatableToSelf = 0b0010_0000_0000_0000,
    IsEquatableToValue = 0b0100_0000_0000_0000,
    All = 0b0111_1111_1111_1111,
}