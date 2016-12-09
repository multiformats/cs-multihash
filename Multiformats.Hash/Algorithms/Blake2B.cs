using Blake2Sharp;

namespace Multiformats.Hash.Algorithms
{
    public class BLAKE2B : MultihashAlgorithm
    {
        private readonly Hasher _algo;

        public BLAKE2B()
            : base(HashType.BLAKE2B, "blake2b", 64)
        {
            _algo = Blake2B.Create(new Blake2BConfig {OutputSizeInBytes = 64});
            _algo.Init();
        }

        public override byte[] ComputeHash(byte[] data) => _algo.AsHashAlgorithm().ComputeHash(data);
    }
}
