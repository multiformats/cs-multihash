using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class SHAKE_128 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public SHAKE_128()
            : base(HashType.SHAKE_128, "shake-128", 16)
        {
            _algo = new ShakeDigest(128);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
