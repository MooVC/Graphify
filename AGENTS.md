# Root Instructions for Codex

This repository hosts **Graphify**, a .NET source generator and analyzers solution.

> **Note**
> This file provides quick instructions for Codex. Human contributors should refer to the
> [README](README.md) and [CONTRIBUTING guide](.github/CONTRIBUTING.md) for a fuller picture.

## Build and Test

- Use the .NET SDK **10.0**. The latest SDK can be found at [dotnet.microsoft.com](https://dotnet.microsoft.com/).
- Restore packages with `dotnet restore`.
- Run `dotnet test` to execute the test suite. This is the primary check before committing.
- Tests are configured via `.runsettings` and use TUnit.
- Treat warnings as errors to maintain code quality.
- If `dotnet` is not available in the current container/session, install SDKs before running checks.
  - Linux/macOS bootstrap:
    - `curl -fsSL https://dot.net/v1/dotnet-install.sh -o /tmp/dotnet-install.sh`
    - `bash /tmp/dotnet-install.sh --channel 8.0 --install-dir "$HOME/.dotnet"`
    - `bash /tmp/dotnet-install.sh --channel 9.0 --install-dir "$HOME/.dotnet"`
    - `bash /tmp/dotnet-install.sh --channel 10.0 --install-dir "$HOME/.dotnet"`
    - `export PATH="$HOME/.dotnet:$PATH"`
    - `dotnet --list-sdks`
  - Match CI SDK coverage (`8.0.x`, `9.0.x`, `10.0.x`) when validating the full solution.

## Coding Style

The project enforces strong C# coding conventions through `.editorconfig`, [StyleCop Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers), and [SonarAnalyzer for C#](https://github.com/SonarSource/sonar-dotnet). Key points from the [Contributing guide](.github/CONTRIBUTING.md):

- Avoid `#region` pragmas.
- Avoid abrieviations in names, except for well-known acronyms (e.g., `Http`, `Xml`).
- Avoid placing a newline character at the end of files.
- Avoid qualified types, use `using` directives instead or an alias if necessary.
- Avoid single-letter names, even for loop variables.
- File may not end with a newline character
- Follow Microsoft naming guidelines (PascalCase for types and members, camelCase for locals/parameters, prefix interfaces with `I`).
- Organize extension methods so each file is named `{TypeName}Extensions.{MethodName}.cs`.
- Prefer **block-scoped namespaces**.
- Seal classes when extension is not intended.
- Use `nameof` for member names in exceptions and logging.
- Use `string.Empty` instead of `""` for empty strings.
- Use `var` for local variables when the type is clear from the right-hand side.
- Use discards (`_`) for unused values.
- Use resource files for all user-facing strings with names `{TypeName}.Resources.{locale}.resx` and keys formatted as `{Context}{Subject}{Purpose}`.
- When possible, place declarations in alphabetical order (e.g. fields, parameters, properties, methods).

### Unit Testing Conventions

- Follow **Arrange-Act-Assert** structure.
- Name test classes `When{MethodName}IsCalled` and test methods `Given{Condition}When{State}Then{Expectation}`. If no {State} is needed, use `Given{Condition}Then{Expectation}`. Do not use the MethodName in the test name, as all tests in the class relate to the same method and the class name identified the method name.
- Place tests for a class under a matching namespace `{Class Namespace}.{Class Name}Tests`.
- Use [`Shouldy`](https://docs.shouldly.org/) and `NSubstitute` for assertions and mocks.
- Use constants for test data, especially for strings and numbers, to avoid magic values.

## Project Structure

- Production code resides in `src/Graphify`.
- Tests live in `src/Graphify.Tests` and mirror the main project layout.
- Documentation for analyzers is under `docs/rules`.

## Pull Requests

The [PR template](.github/pull_request_template.md) requires that you:

- Add or update tests when necessary.
- Ensure tests pass locally.
- Follow the coding style.
- Update `CHANGELOG.md` when consumer-facing changes occur.