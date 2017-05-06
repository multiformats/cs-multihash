using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using Multiformats.Hash.Algorithms;

namespace Multiformats.Hash.Benchmarks
{
    [RyuJitX64Job]
    public class SumBenchmarks
    {
        private byte[] _bytes;

        [Setup]
        public void Setup()
        {
            _bytes = new byte[64];
            new Random(Environment.TickCount).NextBytes(_bytes);
        }

        public Multihash Sum<TAlgorithm>() where TAlgorithm : MultihashAlgorithm => Multihash.Sum<TAlgorithm>(_bytes);

        [Benchmark]
        public Multihash Sum_SHA1() => Sum<SHA1>();

        [Benchmark]
        public Multihash Sum_SHA2_256() => Sum<SHA2_256>();
        [Benchmark]
        public Multihash Sum_DBL_SHA2_256() => Sum<DBL_SHA2_256>();
        [Benchmark]
        public Multihash Sum_SHA2_512() => Sum<SHA2_512>();
        [Benchmark]
        public Multihash Sum_SHA3_224() => Sum<SHA3_224>();
        [Benchmark]
        public Multihash Sum_SHA3_256() => Sum<SHA3_256>();
        [Benchmark]
        public Multihash Sum_SHA3_384() => Sum<SHA3_384>();
        [Benchmark]
        public Multihash Sum_SHA3_512() => Sum<SHA3_512>();

        [Benchmark]
        public Multihash Sum_KECCAK_224() => Sum<KECCAK_224>();
        [Benchmark]
        public Multihash Sum_KECCAK_256() => Sum<KECCAK_256>();
        [Benchmark]
        public Multihash Sum_KECCAK_384() => Sum<KECCAK_384>();
        [Benchmark]
        public Multihash Sum_KECCAK_512() => Sum<KECCAK_512>();

        [Benchmark]
        public Multihash Sum_SHAKE_128() => Sum<SHAKE_128>();
        [Benchmark]
        public Multihash Sum_SHAKE_256() => Sum<SHAKE_256>();

        [Benchmark]
        public Multihash Sum_BLAKE2B() => Sum<BLAKE2B_512>();
        [Benchmark]
        public Multihash Sum_BLAKE2S() => Sum<BLAKE2S_256>();
    }
}
