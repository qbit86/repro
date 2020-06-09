using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Repro
{
    internal static class Program
    {
        internal static T CombineWithDefault<T, TMonoid>(T left, T right)
            where TMonoid : struct, IMonoid<T>
        {
            TMonoid monoid = default;
            return monoid.Combine(left, right);
        }

        internal static T CombineWithNew<T, TMonoid>(T left, T right)
            where TMonoid : IMonoid<T>, new()
        {
            var monoid = new TMonoid();
            return monoid.Combine(left, right);
        }

        private static void Main()
        {
            Job job = new Job(Job.Default).ApplyAndFreeze(RunMode.Short);
            IConfig config = ManualConfig.Create(DefaultConfig.Instance).AddJob(job);
            Summary _ = BenchmarkRunner.Run<MyBenchmark>(config);
        }
    }
}
