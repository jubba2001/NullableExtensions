# New C# 14 Extension declaration is awesome!


```
dotnet run NullableExtensions.cs
```

```
static class NullableExtensions
{
    extension(object?)
    {
        public static bool operator !(object? obj) => obj == null;
        public static bool operator true(object? obj) => obj != null;
        public static bool operator false(object? obj) => obj == null;
    }
    extension(string?)
    {
        public static bool operator !(string? s) => string.IsNullOrEmpty(s);
        public static bool operator true(string? s) => !string.IsNullOrEmpty(s);
        public static bool operator false(string? s) => string.IsNullOrEmpty(s);

        // Operator true/false sucks! Expecting this in C# 15:
        // public static implicit operator bool(string? s) => string.IsNullOrEmpty(s);
    }
    extension<T>(T?) where T : struct
    {
        public static bool operator !(T? t) => !t.HasValue;
        public static bool operator true(T? t) => t.HasValue;
        public static bool operator false(T? t) => !t.HasValue;
    }
}
```
