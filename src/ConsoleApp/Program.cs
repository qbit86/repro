// ReSharper disable UnusedVariable

namespace Repro
{
    internal static class Program
    {
        private static void Main()
        {
            // Expected: green squiggle on `var`, light bulb “Roslyn Code Fixes” with “Use explicit type” command.
            // Observed: as expected.
            var xs = new[] { "Uno", "Dos", "Tres" };
        }
    }
}
