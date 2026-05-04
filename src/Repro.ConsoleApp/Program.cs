using System;
using System.Diagnostics;

namespace Repro;

internal static class Program
{
    private static void Main()
    {
        if (!Debugger.IsAttached)
        {
            Console.WriteLine($"Waiting for debugger to attach. ProcessId: {Environment.ProcessId}");
#if REPRO_ATTACH_MANUALLY
            do
            {
                System.Threading.Thread.Sleep(1000);
            } while (!Debugger.IsAttached);
#else
            Debugger.Launch();
#endif
        }

        Console.WriteLine($"IsAttached: {Debugger.IsAttached}");
        Debugger.Break();
        if (!Console.IsInputRedirected)
        {
            Console.WriteLine("Press any key to continue...");
            _ = Console.ReadKey();
        }
    }
}
