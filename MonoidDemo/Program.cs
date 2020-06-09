using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Repro
{
    internal static class Program
    {
        internal static T Reduce<T, TMonoid>(this T[] items, TMonoid monoid)
            where TMonoid : IMonoid<T>
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            T result = monoid.Identity;
            for (int i = 0; i != items.Length; ++i)
                result = monoid.Combine(result, items[i]);

            return result;
        }

        internal static int ReduceInt32(this int[] items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            int result = 0;
            for (int i = 0; i != items.Length; ++i)
                result += items[i];

            return result;
        }

        private static void Main()
        {
            Job job = new Job(Job.Default).ApplyAndFreeze(RunMode.Short);
            IConfig config = ManualConfig.Create(DefaultConfig.Instance).AddJob(job);
            Summary _ = BenchmarkRunner.Run<MyBenchmark>(config);
        }
    }
}
