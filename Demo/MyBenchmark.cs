using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Repro
{
    [DisassemblyDiagnoser(1, true, true, true, true, true)]
    public abstract class MyBenchmark
    {
        [Benchmark(Baseline = true)]
        public int CombineWithDefault() => Program.CombineWithDefault<int, AdditiveInt32Monoid>(2, 3);

        [Benchmark]
        public int CombineWithNew() => Program.CombineWithNew<int, AdditiveInt32Monoid>(2, 3);
    }
}
