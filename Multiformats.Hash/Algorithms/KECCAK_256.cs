using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class KECCAK_256 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public KECCAK_256()
            : base(HashType.KECCAK_256, "keccak-256", 32)
        {
            _algo = new KeccakDigest(256);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
