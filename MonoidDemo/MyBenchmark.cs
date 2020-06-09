using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Repro
{
    [DisassemblyDiagnoser(1, true, true, true, true, true)]
    public abstract class MyBenchmark
    {
        private static int[] s_integers;
        private static decimal[] s_decimals;

        [GlobalSetup]
        public void GlobalSetup()
        {
            const int count = 10000;
            const int maxValue = 100;
            var prng = new Random(1729);
            s_integers = new int[count];
            s_decimals = new decimal[count];
            for (int i = 0; i < count; ++i)
            {
                int item = prng.Next(maxValue);
                s_integers[i] = item;
                s_decimals[i] = decimal.Divide(item + 1, maxValue);
            }
        }

        [Benchmark(Baseline = true)]
        public int ReduceIntegersBaseline() => s_integers.ReduceInt32();

        [Benchmark]
        public int ReduceIntegers() => s_integers.Reduce(default(AdditiveInt32Monoid));

        [Benchmark]
        public int AggregateIntegers() => s_integers.Aggregate(0, (left, right) => left + right);

        [Benchmark]
        public decimal ReduceDecimals() => s_decimals.Reduce(default(MultiplicativeDecimalMonoid));

        [Benchmark]
        public decimal AggregateDecimals() => s_decimals.Aggregate(1m, (left, right) => left * right);
    }
}
