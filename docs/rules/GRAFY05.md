# GRAFY05: Type has unsupported accessibility

<table>
  <tr>
    <td>Category</td>
    <td>Usage</td>
  </tr>
  <tr>
    <td>Enabled By Default</td>
    <td>Yes</td>
  </tr>
  <tr>
    <td>Code Fix Provided</td>
    <td>No</td>
  </tr>
</table>

## Cause

A type declaration annotated with the `Graphify` attribute is neither `public` nor `internal`.

## Rule Description

Graphify only generates output for `public` and `internal` types. Applying the `Graphify` attribute to a type with any other accessibility (for example, `private`, `protected`, or `protected internal`) causes the annotation to be ignored.

## How to Fix Violations

Change the annotated type to `public` or `internal`, or remove the `Graphify` attribute.

## Example

### Violates GRAFY05

```csharp
[Graphify]
private sealed partial class Hidden
{
    public int Value { get; set; }
}
```

### Compliant

```csharp
[Graphify]
internal sealed partial class Hidden
{
    public int Value { get; set; }
}
```

## How to Suppress GRAFY05

```csharp
#pragma warning disable GRAFY05 // Type has unsupported accessibility
[Graphify]
private sealed partial class Hidden
{
    public int Value { get; set; }
}
#pragma warning restore GRAFY05 // Type has unsupported accessibility
```

Or use `.editorconfig`:

```ini
dotnet_diagnostic.GRAFY05.severity = none
```