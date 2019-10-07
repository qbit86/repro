using System;
using System.Text;

namespace Repro
{
    internal static class Program
    {
        private static void Main()
        {
            var vsb = new ValueStringBuilder(DateTime.Now.Month);
            try
            {
                Foo(ref vsb);
            }
            finally
            {
                vsb.Dispose();
            }
        }

        private static void Foo(ref ValueStringBuilder vsb)
        {
            Bar(vsb.UnsafeArray);
        }

        private static void Bar(char[] array)
        {
            Console.WriteLine(array.Length);
        }
    }
}
