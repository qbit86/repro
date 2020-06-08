using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Repro
{
    internal static class Program
    {
        private static void Main()
        {
            Job job = new Job(Job.Default).ApplyAndFreeze(RunMode.Short);
            IConfig config = ManualConfig.Create(DefaultConfig.Instance).AddJob(job);
            Summary _ = BenchmarkRunner.Run<MyBenchmark>(config);
        }
    }
}
