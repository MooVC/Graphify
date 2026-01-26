# GRAFY01: Type is not compatible with Graphify

<table>
<tr>
  <td>Type Name</td>
  <td>GRAFY01_AttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>GRAFY01</td>
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

A type declaration upon which the `Graphify` attribute is placed is not a `class`, `record` or `struct`.

## Rule Description

A violation of this rule occurs when the `Graphify` attribute is placed on a type declaration that is not a `class`, `record` or `struct`. This occurs most commonly when placed upon a `interface` declaration.

## How to Fix Violations

To fix a violation of this rule, determine if the declaration type is correct for the intended usage. If the type is correct, remove the `Graphify` attribute from the declaration, otherwise change the declaration for the type to a `class`, `record` or `struct`.

For example:

```csharp
[Graphify]
public partial interface IAge
{
	bool IsAdult { get; }
}
```

## How to Suppress Violations

It is not recommended to suppress the rule. Instead, it is suggested that the usage of the `Graphify` attribute be reevaluated.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable GRAFY01 // Type is not compatible with Graphify
[Graphify]
public partial interface IAge
{
	bool IsAdult { get; }
}
#pragma warning restore GRAFY01 // Type is not compatible with Graphify
```

or alternatively:

```csharp
[Graphify]
[SuppressMessage("Design", "GRAFY01:Type is not compatible with Graphify", Justification = "Explanation for suppression")]
public partial interface IAge
{
	bool IsAdult { get; }
}
```

## How to Disable GRAFY01

It is not recommended to disable the rule, as this may result in some confusion if the expected equality behavior is not observed.

```ini
# Disable GRAFY01: Type is not compatible with Graphify
[*.cs]
dotnet_diagnostic.GRAFY01.severity = none
```