using System;
using System.Collections.Generic;
using System.Globalization;

namespace Repro
{
    internal static class Program
    {
        private static void Main()
        {
            List<Exception> exceptions = null;
            for (int i = 0; i != 1; ++i)
            {
                try
                {
                    ThrowInvalidOperationException(i.ToString(CultureInfo.InvariantCulture));
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
                {
                    // 'exceptions is null' is always 'true'. Remove or refactor the condition(s) to avoid dead code.
                    if (exceptions is null)
                        exceptions = new List<Exception>();

                    exceptions.Add(ex);
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }

            Console.WriteLine($"{nameof(exceptions.Count)}: {exceptions?.Count}");
        }

        private static void ThrowInvalidOperationException(string message)
        {
            throw new InvalidOperationException(message);
        }
    }
}
