using System;
using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Repro
{
    internal static class Program
    {
        internal static T Reduce<T, TMonoid>(this IEnumerable<T> items, TMonoid monoid)
            where TMonoid : IMonoid<T>
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            T result = monoid.Identity;
            foreach (T item in items)
                result = monoid.Combine(result, item);

            return result;
        }

        internal static int ReduceInt32(this IEnumerable<int> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            int result = 0;
            foreach (int item in items)
                result += item;

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
