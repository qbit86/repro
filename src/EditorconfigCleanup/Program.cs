using System.IO;

namespace Repro
{
    internal static class Program
    {
        private static void Main()
        {
            using (TextWriter output = TextWriter.Null)
            {
                if (string.IsNullOrEmpty(string.Empty))
                    output.WriteLine();
            }
        }
    }
}
