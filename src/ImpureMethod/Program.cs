using System;
using System.IO;

namespace Repro
{
    internal readonly struct ReadOnlyStruct
    {
        private readonly TextWriter _output;

        public ReadOnlyStruct(TextWriter output)
        {
            _output = output ?? TextWriter.Null;
        }

        internal void WriteLine(string value)
        {
            _output.WriteLine(value);
        }
    }

    internal static class Program
    {
        private static readonly ReadOnlyStruct s_readOnlyField = new ReadOnlyStruct(Console.Out);

        private static void Main()
        {
            // Impure method is called for readonly field of value type
            s_readOnlyField.WriteLine(DateTime.Now.ToString("s"));
        }
    }
}
