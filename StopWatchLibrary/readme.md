# About

Provides a single point for accurately measure elapsed time for task.

The following line in StopWatcher class provides thread safe usage.
```csharp
private static readonly Lazy<StopWatcher> Lazy = new(() => new StopWatcher());
```

Access point to methods and properties in StopWatcher.

```csharp
public static StopWatcher Instance => Lazy.Value;
```