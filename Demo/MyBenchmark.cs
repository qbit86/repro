using BenchmarkDotNet.Attributes;

namespace Repro
{
    [DisassemblyDiagnoser(1, true, true, true, true, true)]
    public abstract class MyBenchmark
    {
        [Benchmark(Baseline = true)]
        public decimal CombineWithDefault() => Program.CombineWithDefault<decimal, MultiplicativeDecimalMonoid>(2m, 3m);

        [Benchmark]
        public decimal CombineWithNew() => Program.CombineWithNew<decimal, MultiplicativeDecimalMonoid>(2m, 3m);
    }
}
