using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class SHA3_256 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public SHA3_256()
            : base(HashType.SHA3_256, "sha3-256", 32)
        {
            _algo = new Sha3Digest(256);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
