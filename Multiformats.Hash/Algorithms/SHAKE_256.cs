using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class SHAKE_256 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public SHAKE_256()
            : base(HashType.SHAKE_256, "shake-256", 32)
        {
            _algo = new ShakeDigest(256);
        }

        public override byte[] ComputeHash(byte[] data) => _algo.ComputeHash(data);
    }
}
