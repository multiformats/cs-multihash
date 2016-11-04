using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class KECCAK_224 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public KECCAK_224()
            : base(HashType.KECCAK_224, "keccak-224", 28)
        {
            _algo = new KeccakDigest(224);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
