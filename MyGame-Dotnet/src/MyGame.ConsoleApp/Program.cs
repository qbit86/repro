using System;
using NumericsVector = System.Numerics.Vector3;
using UnityVector = UnityEngine.Vector3;

namespace MyGame
{
    internal static class Program
    {
        private static void Main()
        {
            var numericsVector = UnityAgnosticExample.CrossProduct(NumericsVector.UnitX, NumericsVector.UnitY);
            Console.WriteLine(numericsVector); // <0, 0, 1>

            var unityVector = UnityAwareExample.CrossProduct(UnityVector.forward, UnityVector.right);
            Console.WriteLine(unityVector); // (0.00, 1.00, 0.00)
        }
    }
}
