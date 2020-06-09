using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Repro
{
    public abstract class MyBenchmark
    {
        private static readonly int[] s_integers = { 2, 3, 5, 8, 13, 21, 34, 55, 89 };
        private static readonly decimal[] s_decimals = { 2m, 3m, 5m, 8m, 13m, 21m, 34m, 55m, 89m };

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
