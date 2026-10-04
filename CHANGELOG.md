# Changelog
All notable changes to Graphify will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# [Unreleased]

## Added

- Add `GraphifyAttribute.GraphName` to customize the type containing generated graph nodes, preserving `Graph` as the default and supporting configuration alongside `PropertyPrefix`.
- Add `GraphifyAttribute.PropertyPrefix` to customize generated graph property names while preserving existing names by default and the `IGraph<T>.Root` contract. Nonempty prefixes also distinguish parent references named `Root`, `Value`, or `Index` with a `Parent` suffix.
- Report `GRAFY06` when a property prefix cannot form valid C# identifiers.
- Report `GRAFY07` when a graph name is empty, is a reserved keyword, or cannot form a valid C# identifier.

# [1.0.3] - 2026-09-09

## Fixed

- Updated `System.Collections.Immutable` from `10.0.11` to `10.0.12`.

# [1.0.2] - 2026-09-07

## Fixed

- Prevent null reference exceptions when synchronous or asynchronous navigators traverse collection elements without registered visitors, while continuing to visit their properties.

# [1.0.1] - 2026-09-04

## Fixed

- Rerelease of 1.0.0 due to issue during merge.

# [1.0.0] - 2026-09-04

- Initial Release