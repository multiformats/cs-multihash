using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class SHA3_512 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public SHA3_512()
            : base(HashType.SHA3_512, "sha3-512", 64)
        {
            _algo = new Sha3Digest(512);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
