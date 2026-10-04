# GRAFY07: Graph name is not valid

| Setting | Value |
|---|---|
| Category | Usage |
| Severity | Error |
| Enabled by default | Yes |
| Code fix provided | No |

## Cause

`GraphifyAttribute.GraphName` is not a valid C# identifier or is a reserved keyword.

## Rule description

Graphify uses `GraphName` for the nested type containing generated graph nodes. Empty names, reserved keywords, names starting with a digit, and names containing unsupported characters such as `$`, spaces, dots, or hyphens make these declarations invalid. The source generator reports this error and skips generation for the annotated type.

## How to fix violations

Use a name such as `Nodes` or `ObjectGraph`, or omit `GraphName` to use the default name, `Graph`. An explicit `null` also uses the default name.

```csharp
[Graphify(GraphName = "Nodes")]
public sealed partial class Order
{
    public decimal Total { get; init; }
}
```

The generated node is `Order.Nodes.Total`. Configure `PropertyPrefix` separately to customize generated property names.