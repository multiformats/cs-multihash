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

There's a CLI version that you can use to compute files or direct input from the command line.
This CLI tool passes the sharness tests [here](https://github.com/multiformats/multihash/tree/master/tests/sharness).

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Supported hash algorithms](#supported-hash-algorithms)
- [Maintainers](#maintainers)
- [Contribute](#contribute)
- [License](#license)

## Install

    PM> Install-Package Multiformats.Hash

---

    dotnet add package Multiformats.Hash

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
* BLAKE2B-(bits) (8-64)
* BLAKE2S-(bits) (8-32)
* DBL_SHA2_256
* MURMUR3_32/128

## Maintainers

Captain: [@tabrath](https://github.com/tabrath).

## Contribute

Contributions welcome. Please check out [the issues](https://github.com/multiformats/cs-multihash/issues).

Check out our [contributing document](https://github.com/multiformats/multiformats/blob/master/contributing.md) for more information on how we work, and about contributing in general. Please be aware that all interactions related to multiformats are subject to the IPFS [Code of Conduct](https://github.com/ipfs/community/blob/master/code-of-conduct.md).

Small note: If editing the README, please conform to the [standard-readme](https://github.com/RichardLitt/standard-readme) specification.

## License

[MIT](LICENSE) © 2017-2018 Trond Bråthen

[Blake2B](https://github.com/metadings/Blake2B.cs) © 2017 [Uli Riehm](https://github.com/metadings)
