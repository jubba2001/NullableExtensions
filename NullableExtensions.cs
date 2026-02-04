
Test("", new object(), 1);
Test(null, new object(), 1);
Test("null", new object(), null);
Test("null", null, 1);
Test("null", new object(), 1);


static void Test(string? s, object? obj, int? i)
{
    Console.WriteLine($"Test(s: {(s == null ? "null" : $"\"{s}\"")}, obj: {(obj == null ? "null" : obj.ToString())}, i: {(i.HasValue ? i.Value.ToString() : "null")}):");


    Console.Write("\tif (s): ");
    if (s)
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine("false");
    }

    Console.Write("\tif (obj): ");
    if (obj)
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine("false");
    }

    Console.Write("\tif (i): ");
    if (i)
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine("false");
    }

    Console.WriteLine("\t(!i || !obj || !s): {0}",
        (!i || !obj || !s) ? "true"  : "false");

    Console.WriteLine("\t(!!i && !!obj && !!s): {0}",
        (!!i && !!obj && !!s) ? "true" : "false");

    Console.WriteLine();
}

static class NullableExtensions
{
    extension<T>(T?) where T : class
    {
        public static bool operator !(T? t) => t == null;
        public static bool operator true(T? t) => t != null;
        public static bool operator false(T? t) => t == null;
    }
    extension<T>(T?) where T : struct
    {
        public static bool operator !(T? t) => !t.HasValue;
        public static bool operator true(T? t) => t.HasValue;
        public static bool operator false(T? t) => !t.HasValue;
    }
    extension(string?)
    {
        public static bool operator !(string? s) => string.IsNullOrEmpty(s);
        public static bool operator true(string? s) => !string.IsNullOrEmpty(s);
        public static bool operator false(string? s) => string.IsNullOrEmpty(s);

        // Operator true/false sucks! Expecting this in C# 15:
        // public static implicit operator bool(string? s) => string.IsNullOrEmpty(s);
    }
}

