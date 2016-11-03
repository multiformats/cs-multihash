using Blake2Sharp;

namespace Multiformats.Hash.Algorithms
{
    public class Blake2B : MultihashAlgorithm
    {
        private readonly Hasher _algo;

        public Blake2B()
            : base(HashType.BLAKE2B, "blake2b", 64)
        {
            _algo = Blake2Sharp.Blake2B.Create(new Blake2BConfig {OutputSizeInBits = 512});
        }

        public override byte[] ComputeHash(byte[] data)
        {
            _algo.Init();
            _algo.Update(data);
            return _algo.Finish();
        }
    }
}
