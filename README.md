# CLabs.Core

Reusable, engine-agnostic gameplay packages for Unity 6+, by Crumpet Labs.

Packages here are published by Crumpet Labs — don't edit them in this repo
directly; open an issue or discussion instead. This repo is **engine-agnostic**:
engine-specific adapters live in their own repos (e.g.
[CLabs.Unity](https://github.com/Crumpet-Labs/CLabs.Unity)).

## Install

CLabs.Core packages depend on **Buttr.Core** for dependency injection, so you
install two things: **Buttr.Core first, then the CLabs.Core package you want**.

### Step by step

1. Open your Unity project (Unity 6 or newer), then open **Window → Package
   Manager**.
2. Click the **+** button in the top-left, then choose **Add package from git
   URL…**.
3. Paste this URL and press Enter — **Buttr.Core**:
   `https://github.com/Crumpet-Labs/Buttr.Core.git?path=package#v1.3.3`
4. Once it finishes importing, add the **CLabs.Core package** you want — for
   example, Utility:
   `https://github.com/Crumpet-Labs/CLabs.Core.git?path=packages/com.clabs.utility#v0.1.0`

Swap `utility` for whichever package you need. Each package is also published to
its own repo for a shorter URL — e.g.
`https://github.com/Crumpet-Labs/CLabs.Dough.git#v0.1.0`.

### Or edit your manifest directly

Add the entries to your project's `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.crumpetlabs.buttr": "https://github.com/Crumpet-Labs/Buttr.Core.git?path=package#v1.3.3",
    "com.clabs.utility": "https://github.com/Crumpet-Labs/CLabs.Core.git?path=packages/com.clabs.utility#v0.1.0"
  }
}
```

Unity-specific adapters (ScriptableObject wrappers, MonoBehaviour controllers,
editor tooling) live in **[CLabs.Unity](https://github.com/Crumpet-Labs/CLabs.Unity)**.

## Layout

| Path | What |
|------|------|
| `packages/` | engine-agnostic packages (`com.clabs.*`) |
| `bridges/` | cross-package integration (`com.clabs.bridge.*`) |

Unity adapters are **not** in this repo — they live in
[CLabs.Unity](https://github.com/Crumpet-Labs/CLabs.Unity).

## Requirements

Unity 6+. Depends on [Buttr](https://github.com/Crumpet-Labs/Buttr.Core) for
dependency injection.

## License

See [LICENSE](LICENSE).
