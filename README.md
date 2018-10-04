# Multiformats.Hash (cs-multihash)

[![](https://img.shields.io/badge/project-multiformats-blue.svg?style=flat-square)](https://github.com/multiformats/multiformats)
[![](https://img.shields.io/badge/freenode-%23ipfs-blue.svg?style=flat-square)](https://webchat.freenode.net/?channels=%23ipfs)
[![Travis CI](https://img.shields.io/travis/multiformats/cs-multihash.svg?style=flat-square&branch=master)](https://travis-ci.org/multiformats/cs-multihash)
[![AppVeyor](https://img.shields.io/appveyor/ci/tabrath/cs-multihash/master.svg?style=flat-square)](https://ci.appveyor.com/project/tabrath/cs-multihash)
[![NuGet](https://buildstats.info/nuget/Multiformats.Hash)](https://www.nuget.org/packages/Multiformats.Hash/)
[![](https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square)](https://github.com/RichardLitt/standard-readme)
[![Codecov](https://img.shields.io/codecov/c/github/multiformats/cs-multihash/master.svg?style=flat-square)](https://codecov.io/gh/multiformats/cs-multihash)
[![Libraries.io](https://img.shields.io/librariesio/github/multiformats/cs-multihash.svg?style=flat-square)](https://libraries.io/github/multiformats/cs-multihash)

> [Multihash](https://github.com/multiformats/multihash) implementation in C# .NET Standard 1.6 compliant.

This is not a general purpose hashing library, but a library to encode/decode Multihashes which is a "container" describing what hash algorithm the digest is calculated with. The library also support calculating the digest, but that is not it's main purpose. If you're looking for a library that supports many algorithms and only want the raw digest, try BouncyCastle or the built-ins of the .net framework.

To be clear, when you calculate a digest (using Sum) with this library, you will get a byte array including a prefix with the properties of the algorithm used (type and length).

There's a CLI version that you can use to compute files or direct input from the command line.
This CLI tool passes the sharness tests [here](https://github.com/multiformats/multihash/tree/master/tests/sharness).

## Table of Contents

* [Install](#install)
* [Usage](#usage)
* [Supported hash algorithms](#supported-hash-algorithms)
* [Maintainers](#maintainers)
* [Contribute](#contribute)
* [License](#license)

## Install

    PM> Install-Package Multiformats.Hash

---

    dotnet add package Multiformats.Hash

## Usage

```csharp
// decode a multihash formatted byte array
Multihash mh = Multihash.Decode(bytes);

// decode a multihash formatted string
Multihash mh = Multihash.Parse(str);
bool ok = Multihash.TryParse(str, out mh);

// encode a digest to multiformat byte array
byte[] bytes = Multihash.Encode(digest, HashType.SHA1);
byte[] bytes = Multihash.Encode<SHA1>(digest);

// calculate digest
Multihash mh = Multihash.Sum<SHA1>(bytes);

// verify
bool isValid = mh.Verify(bytes);
```

## Supported hash algorithms

* ID
* MD4
* MD5
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
* BLAKE2B-(bits) (8-512)
* BLAKE2S-(bits) (8-256)
* DBL_SHA2_256
* MURMUR3_32/128
* SKEIN256-(bits) (8-256)
* SKEIN512-(bits) (8-512)
* SKEIN1024-(bits) (8-1024)

## Maintainers

Captain: [@tabrath](https://github.com/tabrath).

## Contribute

Contributions welcome. Please check out [the issues](https://github.com/multiformats/cs-multihash/issues).

Check out our [contributing document](https://github.com/multiformats/multiformats/blob/master/contributing.md) for more information on how we work, and about contributing in general. Please be aware that all interactions related to multiformats are subject to the IPFS [Code of Conduct](https://github.com/ipfs/community/blob/master/code-of-conduct.md).

Small note: If editing the README, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

[MIT](LICENSE) © 2017-2018 Trond Bråthen
