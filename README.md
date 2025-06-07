# NonAlloc Physics Wrapper

Wraps the allocation-free versions of Unity's intersection functions —
`Physics.RaycastNonAlloc`, `Physics.OverlapBoxNonAlloc`, and so forth — so that
you can avoid allocating and managing result arrays yourself.


## Installation

Add the package to your project via
[UPM](https://docs.unity3d.com/Manual/upm-ui.html) using the Git URL:

```
https://github.com/mminer/nonalloc-physics-wrapper.git
```

1. Open the Package Manager window in Unity (*Window > Package Manager*)
2. Click the "+" button in the top-left corner
3. Select "Install package from git URL..."
4. Enter the above Git URL
5. Click "Install"

Alternatively, add the following line to your `Packages/manifest.json` file:

```json
{
  "dependencies": {
    "com.matthewminer.nonalloc-physics-wrapper": "https://github.com/mminer/nonalloc-physics-wrapper.git",
    // Other dependencies
  }
}
```

You can also clone the repository and point UPM to your local copy.


## Motivation

Using the `NonAlloc` physics functions reduces garbage collection overhead in
your game, particularly if you call them every frame. A typical implementation
looks like this:

```csharp
RaycastHit[] hits = new RaycastHit[10];

void Update()
{
    var hitCount = Physics.RaycastNonAlloc(transform.position, transform.forward, hits);

    for (var i = 0; i < hitCount; i++)
    {
        var hit = hits[i];
        Debug.Log("Hit: " + hit.collider.name);
    }
}
```

This is straightforward, but it requires you to manage an array of `RaycastHit`
and exposes potential bugs if you misuse `hitCount`. A simpler option using this
package:

```csharp
void Update()
{
    var hits = NonAllocPhysics.RaycastAll(transform.position, transform.forward);

    foreach (var hit in hits)
    {
        Debug.Log("Hit: " + hit.collider.name);
    }
}
```

The return type is
[`ReadOnlySpan`](https://learn.microsoft.com/en-us/dotnet/api/system.readonlyspan-1),
a lightweight container that allows you to iterate over the raycast hits in a
foreach loop. The signature of `NonAllocPhysics.RaycastAll` resembles
`Physics.RaycastAll`, but produces no memory allocations. The underlying results
buffer is reused across calls.


## Usage

Any time you use a `Physics` intersection function, prefix it with `NonAlloc`
and iterate over the return value as before.

```diff
- var hits = Physics.RaycastAll(ray);
+ var hits = NonAllocPhysics.RaycastAll(ray);

- var colliders = Physics.OverlapBox(center, halfExtents);
+ var colliders = NonAllocPhysics.OverlapBox(center, halfExtents);

... and so on.
```

### Results Buffer Size

How large the internal results buffer needs to be depends on your game's
specific needs. The default size is 64, but increase or decrease this as needed.

```csharp
NonAllocPhysics.resultsBufferSize = 100;
```

### Warning Logs

By default, `NonAllocPhysics` logs a warning to the console if the results
buffer is too small to hold all the results, in which case you may want to
increase the buffer size. It does so only when your game is running in the
editor.

To customize this behaviour, either to disable the warnings entirely or to log
warnings in builds, set `NonAllocPhysics.logger`.

```csharp
// Never log warnings.
NonAllocPhysics.logger = null;

// Always log warnings, even in builds.
NonAllocPhysics.logger = Debug.unityLogger;
```


## API

All function signatures match their `Physics` and `Physics2D` counterparts.

```csharp
NonAllocPhysics.BoxCastAll
NonAllocPhysics.CapsuleCastAll
NonAllocPhysics.OverlapBox
NonAllocPhysics.OverlapCapsule
NonAllocPhysics.OverlapSphere
NonAllocPhysics.RaycastAll
NonAllocPhysics.SphereCastAll
NonAllocPhysics2D.GetRayIntersectionAll
```
