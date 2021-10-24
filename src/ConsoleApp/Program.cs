using System;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]

namespace Repro
{
    internal static class Program
    {
        private static async Task Main()
        {
            if (true)
                await Console.Out.WriteLineAsync("Lorem ipsum dolor sit amet, consectetur adipiscing elit").ConfigureAwait(false);
        }
    }
}
