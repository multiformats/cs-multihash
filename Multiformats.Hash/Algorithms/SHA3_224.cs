using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class SHA3_224 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public SHA3_224()
            : base(HashType.SHA3_224, "sha3-224", 28)
        {
            _algo = new Sha3Digest(224);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
