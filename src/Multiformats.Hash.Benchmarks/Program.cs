using BenchmarkDotNet.Running;

namespace Multiformats.Hash.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args) => new BenchmarkSwitcher(new[] { typeof(SumBenchmarks) }).Run(args);
    }
}
