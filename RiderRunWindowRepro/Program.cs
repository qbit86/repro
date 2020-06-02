using System;
using System.Globalization;

namespace Repro
{
    internal static class Program
    {
        private static void Main()
        {
            for (int i = 0; i != 32; ++i)
            {
                string linePrefix = (i & 1) == 0 ? "██ " : "░░ ";
                Console.WriteLine(linePrefix + i.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
