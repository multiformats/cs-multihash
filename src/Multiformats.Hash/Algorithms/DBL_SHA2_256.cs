using System.Composition;

namespace Multiformats.Hash.Algorithms
{
    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.DBL_SHA2_256, "dbl-sha2-256", 32)]
    public class DBL_SHA2_256 : MultihashAlgorithm
    {
        private readonly System.Security.Cryptography.HashAlgorithm _algo;

        public DBL_SHA2_256() : base(HashType.DBL_SHA2_256, "dbl-sha2-256", 32)
        {
            _algo = System.Security.Cryptography.SHA256.Create();
        }

        public override byte[] ComputeHash(byte[] data, int length = -1) => _algo.ComputeHash(_algo.ComputeHash(data));
    }
}