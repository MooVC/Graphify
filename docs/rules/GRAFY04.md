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

A type declaration annotated with the `Graphify` attribute has one or more generic type parameters.

## Rule Description

A violation of this rule occurs when the `Graphify` attribute is applied to a generic type declaration. Graphify does not support generic root model declarations, so no graph, navigator, or visitor source can be generated for the type.

For example:

```csharp
[Graphify]
public partial class Page<TItem>
{
    public TItem Value { get; set; }
}
```

In this example, `Page<TItem>` is excluded from Graphify's consideration because the declaration contains generic parameters.

## How to Fix Violations

Remove the generic parameters from the annotated type, or remove the `Graphify` attribute from the generic declaration.

For example:

```csharp
[Graphify]
public partial class Page
{
    public string Value { get; set; }
}
```

or alternatively:

```csharp
public partial class Page<TItem>
{
    public TItem Value { get; set; }
}
```

## How to Suppress Violations

It is not recommended to suppress the rule. Instead, either make the annotated model non-generic or remove the `Graphify` attribute.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable GRAFY04 // Type has generic parameters
[Graphify]
public partial class Page<TItem>
{
    public TItem Value { get; set; }
}
#pragma warning restore GRAFY04 // Type has generic parameters
```

or alternatively:

```csharp
[Graphify]
[SuppressMessage("Design", "GRAFY04:Type has generic parameters", Justification = "Explanation for suppression")]
public partial class Page<TItem>
{
    public TItem Value { get; set; }
}
```

## How to Disable GRAFY04

It is not recommended to disable the rule, as Graphify will not generate source for generic model declarations.

```ini
# Disable GRAFY04: Type has generic parameters
[*.cs]
dotnet_diagnostic.GRAFY04.severity = none
```