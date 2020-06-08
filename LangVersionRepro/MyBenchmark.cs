using System;
using BenchmarkDotNet.Attributes;

namespace Repro
{
    public abstract class MyBenchmark
    {
        [Benchmark(Baseline = true)]
        public long Foo() => Environment.TickCount64;

        [Benchmark]
        public long Bar() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}
