using System;

namespace Repro
{
    internal static class Program
    {
        private static void Main()
        {
            Foo("Hello World!");
            Foo(null);
        }

        private static void Foo(string? s)
        {
            Console.WriteLine($"“{s}”");
        }
    }
}
