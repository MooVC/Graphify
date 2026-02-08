# GRAFY02: Type is not Partial

<table>
<tr>
  <td>Type Name</td>
  <td>GRAFY02_AttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>GRAFY02</td>
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

The declaration for a type annotated with the `Graphify` attribute is not marked as partial.

## Rule Description

A violation of this rule occurs when a type is not marked with the `partial` keyword when the `Graphify` attribute is applied. The `partial` keyword is needed to facilitate the generation of additional content within the assembly for the type.

For example:

```csharp
[Graphify]
public record Age(int Value);
```

In this example, `Age` is excluded from Graphify's consideration as the declaration is not `partial` and as a result, no additional content can be generated without resulting in an compilation failure.

## How to Fix Violations

Reevaluate the decision to apply the `Graphify` attribute. If the intention is correct, add the `partial` keyword to the declaration, otherwise remove the `Graphify` attribute.

For example:

```csharp
[Graphify]
public partial record Age(int Value);
```
or alternatively:

```csharp
public record Age(int Value);
```

## When to Suppress Warnings

It is not recommended to suppress the rule. Instead, it is suggested that the usage of the `Graphify` attribute be reevaluated.

If suppression is desired, one of the following approaches can be used:

```csharp
#pragma warning disable GRAFY02 // Type is not Partial
[Graphify]
public record Age(int Value);
#pragma warning restore GRAFY02 // Type is not Partial
```

or alternatively:

```csharp
[Graphify]
[SuppressMessage("Design", "GRAFY02:Type is not Partial", Justification = "Explanation for suppression")]
public record Age(int Value);
```

## How to Disable GRAFY02

It is not recommended to disable the rule, as this may result in some confusion if the expected equality behavior is not observed.

```ini
# Disable GRAFY02: Descriptor is disregarded from consideration by Graphify
[*.cs]
dotnet_diagnostic.GRAFY02.severity = none
```