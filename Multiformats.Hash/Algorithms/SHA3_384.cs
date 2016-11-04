using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class SHA3_384 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public SHA3_384()
            : base(HashType.SHA3_384, "sha3-384", 48)
        {
            _algo = new Sha3Digest(384);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
