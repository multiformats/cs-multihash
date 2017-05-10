using System;
using System.Composition;

namespace Multiformats.Hash.Algorithms
{
    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.ID, "id", 32)]
    public class ID : MultihashAlgorithm
    {
        public ID()
            : base(HashType.ID, "id", 32)
        {
        }

        public override byte[] ComputeHash(byte[] data) => data;
    }
}
