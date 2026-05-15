# CLabs.Core

A .NET-native distribution of the **CLabs** game-development standard library — a curated, opinionated set of packages and bridges for building games in plain C#, designed to compose cleanly with the [Buttr](https://github.com/Crumpet-Labs/Buttr.Core) dependency-injection framework.

This is the **.NET-native monorepo**. It contains every public CLabs package, bridge, and adapter as a project, wired together via a root `CLabs.Core.sln`. Build it with `dotnet build`, reference the projects you want from your own solution, and you have a complete CLabs runtime.

If you're building a Unity project, you don't want this repo — use [CLabs.Unity](https://github.com/Crumpet-Labs/CLabs.Unity) instead. CLabs.Core is for non-Unity .NET work.

## What's in here

```
CLabs.Core
+- packages/      domain packages (Belfry, Tickets, Utility, ...)  -- the building blocks
+- bridges/       cross-package wiring (e.g. dough-prep, stats-bell)
+- adapters/      where engine adapters would live for non-Unity engines
+- CLabs.Core.sln root solution referencing every project
```

Each package has its own `Documentation~/README.md` with package-specific install, usage, and dependency details.

## What CLabs is for

Building games — across engines, across teams, with stable conventions. The library was extracted from years of shipping commercial Unity games; it's deliberately concrete (no abstract-framework navel-gazing), Buttr-first (DI everywhere, no static singletons), and engine-pluggable (cores are pure C#, engine specifics live in adapters).

Highlights of the public surface in this repo:

- **Belfry** — type-safe key-scoped pub/sub messaging (Tower / Rope / Ring).
- **Tickets** — cross-engine async/await primitive (hard fork of UniTask 2.5.10).
- **Utility** — foundation utilities: `OwnerId`, `Color`, `Registry<,>`, `Disposable`, resource providers, reflection + I/O helpers.

More packages will land here as they're promoted from the private development monorepo. The list of live packages is the manifest of what's stable enough to use in production.

## Installation

### Whole-monorepo install (recommended for evaluation)

```bash
git clone https://github.com/Crumpet-Labs/CLabs.Core.git
cd CLabs.Core
dotnet build CLabs.Core.sln
```

Then reference the projects you want from your own `.csproj`:

```xml
<ItemGroup>
  <ProjectReference Include="path/to/CLabs.Core/packages/com.clabs.belfry/CLabs.Belfry.csproj" />
  <ProjectReference Include="path/to/CLabs.Core/packages/com.clabs.tickets/CLabs.Tickets.csproj" />
  <ProjectReference Include="path/to/CLabs.Core/packages/com.clabs.utility/CLabs.Utility.csproj" />
</ItemGroup>
```

### Single-package install (production)

Each package also ships in its own repo. Use those when you want to depend on just one package without pulling the rest:

- [CLabs.Belfry](https://github.com/Crumpet-Labs/CLabs.Belfry) — pub/sub messaging
- [CLabs.Tickets](https://github.com/Crumpet-Labs/CLabs.Tickets) — async/await primitive
- [CLabs.Utility](https://github.com/Crumpet-Labs/CLabs.Utility) — foundation utilities

Each package's README lists its CLabs dependencies — install them in dependency order.

### Buttr dependency

Every CLabs package that does dependency injection (most of them) requires [Buttr.Core](https://github.com/Crumpet-Labs/Buttr.Core). Install Buttr first, then CLabs packages register their services on its `ApplicationBuilder`:

```csharp
using Buttr.Core;
using CLabs.Belfry;

var builder = new ApplicationBuilder();
builder.UseBelfry();
var app = builder.Build();
```

## Versioning

CLabs.Core ships **unified versions** — a single semver per release covering every package in the monorepo. Per-package repos carry their own per-package semver (PATCH on fix, MINOR on feat, MAJOR on breaking change) and the unified version is `max()` across them.

Every release is tagged `v<X.Y.Z>` and gets a GitHub Release with grouped notes (Breaking changes / Features / Fixes) — see the [Releases](https://github.com/Crumpet-Labs/CLabs.Core/releases) tab.

## License

MIT, unless a package's own `LICENSE.md` says otherwise (e.g. CLabs.Tickets preserves Cysharp's original UniTask copyright). See each package directory for specifics.

## Project status

CLabs is in active development. The public surface is intentionally small while we get the publishing pipeline solid; expect more packages to be promoted as they're stabilised.
