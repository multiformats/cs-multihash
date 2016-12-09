using System.Security.Cryptography;
using Blake2s;

namespace Multiformats.Hash.Algorithms
{
    public class BLAKE2S : MultihashAlgorithm
    {
        private readonly Hasher _algo;

        public BLAKE2S()
            : base(HashType.BLAKE2S, "blake2s", 32)
        {
            _algo = Blake2S.Create(new Blake2sConfig {OutputSizeInBytes = 32});
            _algo.Init();
        }

        public override byte[] ComputeHash(byte[] data) => _algo.AsHashAlgorithm().ComputeHash(data);
    }
}
