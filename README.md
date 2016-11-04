# Multiformats.Hash

[![Build Status](https://travis-ci.org/tabrath/cs-multihash.svg?branch=master)](https://travis-ci.org/tabrath/cs-multihash)
[![Build status](https://ci.appveyor.com/api/projects/status/h1rd7s003rj2q1no?svg=true)](https://ci.appveyor.com/project/tabrath/cs-multihash)
[![NuGet Badge](https://buildstats.info/nuget/Multiformats.Hash)](https://www.nuget.org/packages/Multiformats.Hash/)

C# implementation of [multiformats/multihash](https://github.com/multiformats/multihash).

## Usage
``` cs
// decode a multihash formatted byte array
var mh = Multihash.Decode(bytes);
// decode a multihash formatted string
var mh = Multihash.Parse(str);
var ok = Multihash.TryParse(str, out mh);

// encode a digest to multiformat byte array
var bytes = Multihash.Encode(digest, HashType.SHA1);
// alternative
var bytes = Multihash.Encode<SHA1>(digest);

// calculate digest
var mh = Multihash.Sum<SHA1>(bytes);
```

## Supported hash codecs

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
* Blake2B
* Blake2S
