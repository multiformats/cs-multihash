# Multiformats.Hash (cs-multihash)

[![](https://img.shields.io/badge/project-multiformats-blue.svg?style=flat-square)](https://github.com/multiformats/multiformats)
[![](https://img.shields.io/badge/freenode-%23ipfs-blue.svg?style=flat-square)](https://webchat.freenode.net/?channels=%23ipfs)
[![Travis CI](https://img.shields.io/travis/multiformats/cs-multihash.svg?style=flat-square&branch=master)](https://travis-ci.org/multiformats/cs-multihash)
[![AppVeyor](https://img.shields.io/appveyor/ci/tabrath/cs-multihash/master.svg?style=flat-square)](https://ci.appveyor.com/project/tabrath/cs-multihash)
[![NuGet](https://buildstats.info/nuget/Multiformats.Hash)](https://www.nuget.org/packages/Multiformats.Hash/)
[![](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)
[![Codecov](https://img.shields.io/codecov/c/github/multiformats/cs-multihash/master.svg?style=flat-square)](https://codecov.io/gh/multiformats/cs-multihash)
[![Libraries.io](https://img.shields.io/librariesio/github/multiformats/cs-multihash.svg?style=flat-square)](https://libraries.io/github/multiformats/cs-multibase)

> [Multihash](https://github.com/multiformats/multihash) implementation in C#

Beware that some of the supported algorithms may be dropped as the specs are not complete yet.

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Supported hash algorithms](#supported-hash-algorithms)
- [Benchmarks](#benchmarks)
- [Maintainers](#maintainers)
- [Contribute](#contribute)
- [License](#license)

## Install

    PM> Install-Package Multiformats.Hash

## Usage
``` cs
// decode a multihash formatted byte array
var mh = Multihash.Decode(bytes);

// decode a multihash formatted string
var mh = Multihash.Parse(str);
var ok = Multihash.TryParse(str, out mh);

// encode a digest to multiformat byte array
var bytes = Multihash.Encode(digest, HashType.SHA1);
// or
var bytes = Multihash.Encode<SHA1>(digest);

// calculate digest
var mh = Multihash.Sum<SHA1>(bytes);

// verify
var isValid = mh.Verify(bytes);
```

## Supported hash algorithms

* SHA1
* SHA2_256
* SHA2_512
* SHA3_224
* SHA3_256
* SHA3_384
* SHA3_512
* SHAKE_128
* SHAKE_256
* KECCAK_224
* KECCAK_256
* KECCAK_384
* KECCAK_512
* Blake2B - *deprecated*
* BLAKE2B-(bits) (8-64)
* Blake2S - *deprecated*
* BLAKE2S-(bits) (8-32)
* DBL_SHA2_256

## Benchmarks

```ini

Host Process Environment Information:
BenchmarkDotNet.Core=v0.9.9.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-2630QM CPU 2.00GHz, ProcessorCount=8
Frequency=1948697 ticks, Resolution=513.1634 ns, Timer=TSC
CLR=MS.NET 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1586.0

Type=SumBenchmarks  Mode=Throughput  

```
         Method | Platform |       Jit |     Median |    StdDev |
--------------- |--------- |---------- |----------- |---------- |
       Sum_SHA1 |      X64 |    RyuJit |  9.1503 us | 0.1075 us |
   Sum_SHA2_256 |      X64 |    RyuJit |  7.0815 us | 0.0510 us |
   Sum_SHA2_512 |      X64 |    RyuJit |  9.7133 us | 0.1525 us |
   Sum_SHA3_224 |      X64 |    RyuJit | 21.2179 us | 0.2223 us |
   Sum_SHA3_256 |      X64 |    RyuJit | 22.0460 us | 0.3383 us |
   Sum_SHA3_384 |      X64 |    RyuJit | 22.1800 us | 0.3213 us |
   Sum_SHA3_512 |      X64 |    RyuJit | 23.1906 us | 0.3396 us |
 Sum_KECCAK_224 |      X64 |    RyuJit | 21.5256 us | 0.1972 us |
 Sum_KECCAK_256 |      X64 |    RyuJit | 21.7882 us | 0.1917 us |
 Sum_KECCAK_384 |      X64 |    RyuJit | 22.4997 us | 0.0699 us |
 Sum_KECCAK_512 |      X64 |    RyuJit | 23.1189 us | 0.1670 us |
  Sum_SHAKE_128 |      X64 |    RyuJit | 20.8904 us | 0.2302 us |
  Sum_SHAKE_256 |      X64 |    RyuJit | 22.1505 us | 0.4701 us |
    Sum_BLAKE2B |      X64 |    RyuJit |  7.0249 us | 0.1477 us |
    Sum_BLAKE2S |      X64 |    RyuJit |  5.0688 us | 0.0636 us |
       Sum_SHA1 |      X86 | LegacyJit |  9.9044 us | 0.0899 us |
   Sum_SHA2_256 |      X86 | LegacyJit |  7.1929 us | 0.0591 us |
   Sum_SHA2_512 |      X86 | LegacyJit | 14.9935 us | 0.3445 us |
   Sum_SHA3_224 |      X86 | LegacyJit | 33.7344 us | 4.4472 us |
   Sum_SHA3_256 |      X86 | LegacyJit | 34.7081 us | 0.1415 us |
   Sum_SHA3_384 |      X86 | LegacyJit | 35.2440 us | 0.2666 us |
   Sum_SHA3_512 |      X86 | LegacyJit | 36.1128 us | 0.3537 us |
 Sum_KECCAK_224 |      X86 | LegacyJit | 34.4592 us | 1.3811 us |
 Sum_KECCAK_256 |      X86 | LegacyJit | 34.1948 us | 0.6163 us |
 Sum_KECCAK_384 |      X86 | LegacyJit | 35.1147 us | 0.2113 us |
 Sum_KECCAK_512 |      X86 | LegacyJit | 35.5780 us | 0.1600 us |
  Sum_SHAKE_128 |      X86 | LegacyJit | 33.6440 us | 0.3200 us |
  Sum_SHAKE_256 |      X86 | LegacyJit | 34.7667 us | 0.4644 us |
    Sum_BLAKE2B |      X86 | LegacyJit |  9.3866 us | 0.1349 us |
    Sum_BLAKE2S |      X86 | LegacyJit |  5.7486 us | 0.0533 us |

## Maintainers

Captain: [@tabrath](https://github.com/tabrath).

## Contribute

Contributions welcome. Please check out [the issues](https://github.com/multiformats/cs-multihash/issues).

Check out our [contributing document](https://github.com/multiformats/multiformats/blob/master/contributing.md) for more information on how we work, and about contributing in general. Please be aware that all interactions related to multiformats are subject to the IPFS [Code of Conduct](https://github.com/ipfs/community/blob/master/code-of-conduct.md).

Small note: If editing the README, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

[MIT](LICENSE) © 2016 Trond Bråthen
