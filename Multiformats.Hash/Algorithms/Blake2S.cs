using Blake2s;

namespace Multiformats.Hash.Algorithms
{
    public class Blake2S : MultihashAlgorithm
    {
        private readonly Hasher _algo;

        public Blake2S()
            : base(HashType.BLAKE2S, "blake2s", 32)
        {
            _algo = Blake2s.Blake2S.Create();
        }

        public override byte[] ComputeHash(byte[] data)
        {
            _algo.Init();
            _algo.Update(data);
            return _algo.Finish();
        }
    }
}
