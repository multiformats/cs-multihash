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

        public override byte[] ComputeHash(byte[] data, int length = -1)
        {
            if (length >= 0 && length != data.Length)
                throw new Exception($"The length of the identity hash ({length}) must be equal to the length of the data ({data.Length})");

            return data;
        }
    }
}
