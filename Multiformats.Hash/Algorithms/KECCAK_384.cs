using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class KECCAK_384 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public KECCAK_384()
            : base(HashType.KECCAK_384, "keccak-384", 48)
        {
            _algo = new KeccakDigest(384);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
