using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public class SHA3 : MultihashAlgorithm
    {
        private readonly IDigest _algo;

        public SHA3()
            : base(HashType.SHA3, "sha3", 64)
        {
            _algo = new Sha3Digest(512);
        }

        public override byte[] ComputeHash(byte[] data)
        {
            _algo.Reset();
            _algo.BlockUpdate(data, 0, data.Length);
            var hash = new byte[_algo.GetByteLength()];
            _algo.DoFinal(hash, 0);
            return hash;
        }
    }
}
