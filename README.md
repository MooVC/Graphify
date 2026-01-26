# Graphify [![NuGet](https://img.shields.io/nuget/v/Graphify?logo=nuget)](https://www.nuget.org/packages/Graphify/) [![GitHub](https://img.shields.io/github/license/MooVC/Graphify)](LICENSE.md)

Graphify is a .NET Roslyn source generator that turns your object models into navigable graphs. It enables engineers to scan an object hierarchy and observe values at different levels without reflection by generating strongly-typed nodes and visitor helpers.

## Why Graphify

- **Graph scanning without reflection**: Traverse and observe your object graphs with generated, strongly-typed nodes.
- **Type-safe visitors**: Register and compose visitors for specific nodes in the graph.
- **Generator-backed performance**: Build-time code generation avoids runtime discovery costs.
- **Analyzer guardrails**: Diagnostics catch misconfiguration early.

## Requirements

- .NET SDK with a Roslyn-capable compiler (Visual Studio 2022, Rider, or VS Code with the C# extension).
- A C# language version that supports source generators (C# 9.0 or later).

## Installation

Add the package reference to your project:

```xml
<ItemGroup>
  <PackageReference Include="Graphify" Version="<LATEST_VERSION>" />
</ItemGroup>
```

Or via the package manager console:

```shell
Install-Package Graphify
```

## Quick start

Annotate a partial type with the `Graphify` attribute to generate graph nodes and visitor hooks.

```csharp
using Graphify;

[Graphify]
public partial class Order
{
    public Customer Customer { get; init; } = new();
    public decimal Total { get; init; }
}
```

With generated graph nodes, you can register visitors for specific paths (for example, observing totals or customer data) without using reflection. The generated APIs give you strongly-typed entry points into the object graph.

## Key concepts

Graphify generates a few key building blocks. Understanding these makes it easier to wire up scanning and observation in your application.

### Model

The model is your domain object graph annotated with the `Graphify` attribute. Any public instance properties become navigation points in the graph. Keep the type `partial` so Graphify can extend it with generated nodes.

### Graph nodes

Graphify emits a typed graph node hierarchy that mirrors your model. Each node represents a path through the object graph. For example, `Order` becomes a root node, with child nodes representing `Order.Customer`, `Order.Total`, and so on. These nodes act as the strongly-typed targets for navigation and observation.

### Navigator

The navigator is the generated entry point for scanning the graph. It coordinates traversal from the root node through child nodes, invoking any visitors registered for each node. Because the traversal logic is generated, there is no reflection and no runtime discovery cost.

### Visitors

Visitors observe values at specific nodes. You implement a visitor by targeting the node type you care about and returning observations, such as strings or domain events. This makes it easy to capture the exact data points you need without manual tree-walking.

### IoC registration

Graphify generates extension methods for dependency injection registration so visitors and navigators can be resolved by your IoC container. This allows you to compose visitors with your existing application services and control their lifetime centrally.

## Typical usage flow

1. **Annotate a model** with `Graphify` to generate the graph nodes and navigator.
2. **Implement visitors** for nodes you want to observe.
3. **Register visitors** using the generated IoC extension methods.
4. **Scan the graph** using the navigator to gather observations.

This flow keeps traversal explicit, type-safe, and discoverable in IntelliSense.

## Analyzers

Graphify ships analyzers to keep your graph models consistent and safe:

Rule ID                         | Category | Severity | Description
:------------------------------|:---------|:---------|:---------------------------------------------------------------
[GRAFY01](docs/rules/GRAFY01.md) | Usage    | Warning  | Type is not compatible with Graphify
[GRAFY02](docs/rules/GRAFY02.md) | Usage    | Warning  | Type is not Partial
[GRAFY03](docs/rules/GRAFY03.md) | Usage    | Info     | Type does not utilize Graphify

## Contributing

Contributions are welcome. See [CONTRIBUTING.md](/.github/CONTRIBUTING.md) for build instructions and coding guidelines.

## License

This project is licensed under the MIT License. See [LICENSE.md](LICENSE.md) for details.