# Changelog
All notable changes to Graphify will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# [1.0.0] - TBC

- Initial Release
- Restricted Graphify generation to `public` and `internal` annotated types, aligned navigator accessibility with target type accessibility, and added analyzer warning `GRAFY05` for unsupported accessibility.
- Removed generated `INavigator<T>` and `Navigator<T>` base contracts, introduced synchronous generation mode via `GraphifyAttribute.Mode`, and added generated `IInspector<T, TResult>` support for Roslyn-compatible synchronous traversal.
