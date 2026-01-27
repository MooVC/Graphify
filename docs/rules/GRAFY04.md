# GRAFY04: Type has generic parameters

<table>
<tr>
  <td>Type Name</td>
  <td>GRAFY04_AttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>GRAFY04</td>
</tr>
<tr>
  <td>Category</td>
  <td>Usage</td>
</tr>
<tr>
  <td>Severity</td>
  <td>Warning</td>
</tr>
<tr>
  <td>Is Enabled By Default</td>
  <td>Yes</td>
</tr>
</table>

## Cause

The `Graphify` attribute is applied to a type declaration that declares generic parameters.

## Rule Description

Graphify does not support generic type declarations. A violation of this rule occurs when the `Graphify` attribute is applied to a `class`, `record`, or `struct` that declares generic parameters.

For example:

```csharp
using Graphify;

[Graphify]
public sealed partial class Example<TElement>
{
    public TElement Value { get; set; }
}
```

## How to Fix Violations

Remove the generic parameters from the type declaration, or remove the `Graphify` attribute if the type must remain generic.

For example:

```csharp
using Graphify;

[Graphify]
public sealed partial class Example
{
    public string Value { get; set; }
}
```

or alternatively:

```csharp
public sealed partial class Example<TElement>
{
    public TElement Value { get; set; }
}
```

## How to Suppress Violations

It is not recommended to suppress the rule. Instead, the type should be adjusted to be non-generic.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable GRAFY04 // Type has generic parameters
[Graphify]
public sealed partial class Example<TElement>
{
    public TElement Value { get; set; }
}
#pragma warning restore GRAFY04 // Type has generic parameters
```

or alternatively:

```csharp
[Graphify]
[SuppressMessage("Usage", "GRAFY04:Type has generic parameters", Justification = "Explanation for suppression")]
public sealed partial class Example<TElement>
{
    public TElement Value { get; set; }
}
```

## How to Disable GRAFY04

It is not recommended to disable the rule, as this may result in missing Graphify code generation.

```ini
# Disable GRAFY04: Type has generic parameters
[*.cs]
dotnet_diagnostic.GRAFY04.severity = none
```