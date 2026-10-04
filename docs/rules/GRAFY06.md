# GRAFY06: Property prefix is not valid

| Setting | Value |
|---|---|
| Category | Usage |
| Severity | Error |
| Enabled by default | Yes |
| Code fix provided | No |

## Cause

`GraphifyAttribute.PropertyPrefix` cannot form a valid C# identifier when prepended to a generated property name.

## Rule description

Graphify prepends `PropertyPrefix` to generated graph properties, including `Root`, `Value`, `Index`, and parent references. A prefix containing unsupported characters, such as `$`, spaces, or hyphens, or beginning with a digit, makes these declarations invalid. The source generator reports this error and skips generation for the annotated type.

## How to fix violations

Use a prefix such as `_` or `Graph`, or omit `PropertyPrefix` to preserve existing property names.

```csharp
[Graphify(PropertyPrefix = "_")]
public sealed partial class Order
{
    public decimal Total { get; init; }
}
```

The generated `Order.Graph.Total` node exposes `_Root` and `_Value`. Access through `IGraph<Order>.Root` remains supported.