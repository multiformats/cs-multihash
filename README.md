# Multiformats.Hash
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
