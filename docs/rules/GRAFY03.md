# GRAFY03: Type does not utilize Graphify

<table>
<tr>
  <td>Type Name</td>
  <td>GRAFY03_TraverseAttributeAnalyzer</td>
</tr>
<tr>
  <td>Diagnostic Id</td>
  <td>GRAFY03</td>
</tr>
<tr>
  <td>Category</td>
  <td>Usage</td>
</tr>
<tr>
  <td>Severity</td>
  <td>Info</td>
</tr>
<tr>
  <td>Is Enabled By Default</td>
  <td>Yes</td>
</tr>
</table>

## Cause

The property is not considered by Graphify because the type has not been annotated with the `Graphify` attribute.

## Rule Description

A violation of this rule occurs when a property is marked with the `Traverse` attribute, but the containing `class` is not annotated with the `Graphify` attribute. Therefore, no extension methods will be generated, making use of the `Traverse` attribute redundant.

For example:

```csharp
public class Example
{
    [Traverse]
    public string Property { get; set; }
}
```

In this example, the `Traverse` attribute on `Property`, and the `class` itself, will be ignored by `Graphify`, suggesting a misunderstanding by the engineer as to its intended usage.

## How to Fix Violations

Reevaluate the decision to apply the `Traverse` attribute. If the `Traverse` attribute usage is deemed correct, annotate the type with the `Graphify` attribute, otherwise remove the `Traverse` attribute.

For example:

```csharp
[Graphify]
public class Example
{
    [Traverse]
    public string Property { get; set; }
}
```
or alternatively:

```csharp
public class Example
{
    public string Property { get; set; }
}
```

## When to Suppress Warnings

Warnings from this rule should be suppressed only if there is a strong justification for not using the `Graphify` attribute on the containing type when the `Traverse` attribute is applied.

If suppression is desired, one of the following approaches can be used:

```csharp
[Graphify]
public class Example
{
    #pragma warning disable GRAFY03 // Type does not utilize Graphify
    
    [Traverse]
    public string Property { get; set; }
    
    #pragma warning restore GRAFY03 // Type does not utilize Graphify
}
```

or alternatively:

```csharp
public class Example
{
    [Traverse]
    [SuppressMessage("Usage", "GRAFY03:Type does not utilize Graphify", Justification = "Explanation for suppression")]
    public string Property { get; set; }
}
```

## How to Disable GRAFY03

It is not recommended to disable the rule, as this may result in some confusion if expected extension methods are not present.

```ini
# Disable GRAFY03: Type does not utilize Graphify
[*.cs]
dotnet_diagnostic.GRAFY03.severity = none
```