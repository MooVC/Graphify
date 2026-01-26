# Graphify [![NuGet](https://img.shields.io/nuget/v/Graphify?logo=nuget)](https://www.nuget.org/packages/Graphify/) [![GitHub](https://img.shields.io/github/license/MooVC/Graphify)](LICENSE.md)

Graphify is a .NET Roslyn source generator that turns your object models into navigable graphs. It enables engineers to scan an object hierarchy and observe values at different levels without reflection by generating strongly-typed nodes.

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

## Quick Start

Annotate a `partial` type with the `Graphify` attribute to generate graph nodes and visitor hooks.

```csharp
using Graphify;

[Graphify]
public sealed partial class Order
{
    public Customer Customer { get; init; } = new();

    public decimal Total { get; init; }
}
```

With generated graph nodes, you can register visitors for specific paths (for example, observing the Total or Customer) without using reflection. The generated APIs give you strongly-typed entry points into the object graph.

## Key Concepts

Graphify generates a few key building blocks. Understanding these makes it easier to wire up scanning and observation in your application.

### Model

The model is your domain object graph annotated with the `Graphify` attribute. Any public instance properties become navigation points in the graph. The model is generated within the scope of the annotated type, within a subclass named `Graph`. Each tier within the object graph is nested within the definition of the previous, providing an intuitive structure.

So when using `Order` as defined above and we define `Customer` as:

```csharp
public sealed class Customer
{
    public string Email { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;
}
```

Taking the `Name` node for brevity, the following structure is generated to allow observation:

```csharp
partial class Order
{
    public sealed partial class Graph
    {
        public sealed partial class Customer
        {
            public sealed partial class Name
            {
                internal Name(Order root, Customer customer, string Value)
                {
                    Root = root;
                    Customer = customer;
                    Value = Value;
                }

                public Order Root { get; private set; }

                public Customer Customer { get; private set; }

                public string Value { get; private set; }
            }
        }
    }
}
```

### Visitors

Visitors allows for the observation of specific nodes within the heirarchy. You implement a visitor by targeting the node type you care about and returning the appropriate observation(s). This makes it easy to capture the exact data points you need without manual tree-walking.

The following demonstrates a visitor that observes the `Email` value from the `Customer` node:

```csharp
using Graphify;

public sealed class CustomerEmailVisitor(IBlacklist blacklist)
    : IVisitor<Order.Graph.Customer.Email>
{
    public async IAsyncEnumerable<string> Observe(Order.Graph.Customer.Email instance, [EnumeratorCancellation] CancellationToken cancellationToken))
    {
        if (blacklist.Contains(instance.Value))
        {
            yield return instance.Value;
        }
    }
}
```

### Navigator

The navigator is the generated entry point for scanning the graph. It coordinates traversal from the root node through child nodes, invoking any visitors registered for each node. Because the traversal logic is generated, there is no reflection and no runtime discovery cost. The navigator is specific to the type annotated with `Graphify` with an `interface` and implementation generated alongside the annotated type.

For the `Order` example, the following navigator `interface` will be `IOrderNavigator` with the internal implementation being `OrderNavigator`. The implementation uses the `IServiceProvider` to resolve visitors as it traverses the graph.

```csharp
public sealed class OrderVerificationService(IOrderNavigator navigator)
{
    public async IAsyncEnumerable<string> Verify(Order[] orders, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (Order order in orders)
        {
            await foreach (string email in navigator.Navigate<string>(order, cancellationToken))
            {
                yield return email;
            }
        }
    }
}
```

### IoC registration

Graphify generates an extension method to support registration of the navigator for dependency injection whenever the project within which the annotated type references `IServiceCollection` from `Microsoft.Extensions.DependencyInjection`. This allows you to compose the navigator with your existing application services and control their lifetime centrally.

For the `Order` example, the navigator can be registered as follows:

```csharp
_ = services.AddOrderNavigator();
```

The service will be registered as a singleton on `IOrderNavigator` and `INavigator<Order>`.

## Typical usage flow

1. **Annotate a Model** with `Graphify` to generate the graph nodes and navigator.
2. **Register Navigator** using the generated IoC extension methods.
3. **Implement Visitors** for nodes you want to observe.
4. **Register Visitors** using the same container that the navigator.
5. **Scan the Graph** using the navigator to gather observations.

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