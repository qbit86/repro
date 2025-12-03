using System;
using System.Numerics;

namespace MyGame
{
    internal static class Program
    {
        private static void Main()
        {
            var numericsVector = UnityAgnosticExample.CrossProduct(Vector3.UnitX, Vector3.UnitY);
            Console.WriteLine(numericsVector);
        }
    }
}
