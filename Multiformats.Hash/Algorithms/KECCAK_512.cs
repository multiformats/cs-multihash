using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class KECCAK_512 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public KECCAK_512()
            : base(HashType.KECCAK_512, "keccak-512", 64)
        {
            _algo = new KeccakDigest(512);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
