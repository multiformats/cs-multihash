``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i5-6400 CPU 2.70GHz (Skylake), ProcessorCount=4
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
dotnet cli version=1.0.3
  [Host]    : .NET Core 4.6.25009.03, 64bit RyuJITDEBUG
  RyuJitX64 : .NET Core 4.6.25009.03, 64bit RyuJIT

Job=RyuJitX64  Jit=RyuJit  Platform=X64  

```
 |           Method |     Mean |     Error |    StdDev |
 |----------------- |---------:|----------:|----------:|
 |         Sum_SHA1 | 11.81 us | 0.0802 us | 0.0626 us |
 |     Sum_SHA2_256 | 13.42 us | 0.2687 us | 0.3767 us |
 | Sum_DBL_SHA2_256 | 14.42 us | 0.2299 us | 0.2150 us |
 |     Sum_SHA2_512 | 13.07 us | 0.2512 us | 0.2688 us |
 |     Sum_SHA3_224 | 24.07 us | 0.4630 us | 0.4547 us |
 |     Sum_SHA3_256 | 23.81 us | 0.3963 us | 0.3513 us |
 |     Sum_SHA3_384 | 23.87 us | 0.3174 us | 0.2814 us |
 |     Sum_SHA3_512 | 24.49 us | 0.4705 us | 0.4832 us |
 |   Sum_KECCAK_224 | 24.13 us | 0.5251 us | 0.4912 us |
 |   Sum_KECCAK_256 | 24.07 us | 0.3277 us | 0.2905 us |
 |   Sum_KECCAK_384 | 23.87 us | 0.3095 us | 0.2895 us |
 |   Sum_KECCAK_512 | 23.76 us | 0.3271 us | 0.3060 us |
 |    Sum_SHAKE_128 | 23.93 us | 0.4678 us | 0.6559 us |
 |    Sum_SHAKE_256 | 23.48 us | 0.1275 us | 0.1130 us |
 |      Sum_BLAKE2B |       NA |        NA |        NA |
 |      Sum_BLAKE2S |       NA |        NA |        NA |

Benchmarks with issues:
  SumBenchmarks.Sum_BLAKE2B: RyuJitX64(Jit=RyuJit, Platform=X64)
  SumBenchmarks.Sum_BLAKE2S: RyuJitX64(Jit=RyuJit, Platform=X64)
