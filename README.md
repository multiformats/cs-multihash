# Multiformats.Hash

[![Build Status](https://travis-ci.org/tabrath/cs-multihash.svg?branch=master)](https://travis-ci.org/tabrath/cs-multihash)
[![Build status](https://ci.appveyor.com/api/projects/status/h1rd7s003rj2q1no?svg=true)](https://ci.appveyor.com/project/tabrath/cs-multihash)
[![NuGet Badge](https://buildstats.info/nuget/Multiformats.Hash)](https://www.nuget.org/packages/Multiformats.Hash/)

C# implementation of [multiformats/multihash](https://github.com/multiformats/multihash).

## Usage
``` cs
var mh = Multihash.Decode(bytes)
var bytes = Multihash.Encode(digest, HashType.SHA1);
var mh = Multihash.Sum<SHA1>(bytes);
```

## Supported base encodings

* SHA1
* SHA2_256
* SHA2_512
* SHA3
* Blake2B
