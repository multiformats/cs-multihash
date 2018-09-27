using System;
using System.Composition;
using System.Linq;
using System.Security.Cryptography;
using Murmur;

namespace Multiformats.Hash.Algorithms
{
    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.MURMUR3_32, "murmur3-32", 4)]
    public class MURMUR3_32 : MultihashAlgorithm
    {
        private readonly Func<HashAlgorithm> _factory;

        public MURMUR3_32()
			: base(HashType.MURMUR3_32, "murmur3-32", 4)
        {
            _factory = () => MurmurHash.Create32(managed: false);
        }

        public override byte[] ComputeHash(byte[] data, int length = -1) => _factory().ComputeHash(data);
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.MURMUR3_128, "murmur3-128", 16)]
    public class MURMUR3_128 : MultihashAlgorithm
    {
        private readonly Func<HashAlgorithm> _factory;

        public MURMUR3_128()
			: base(HashType.MURMUR3_128, "murmur3-128", 16)
        {
            _factory = () => MurmurHash.Create128(managed: false, preference: AlgorithmPreference.X64);
        }

        public override byte[] ComputeHash(byte[] data, int length = -1)
        {
            var value = _factory().ComputeHash(data);

            Array.Reverse(value, 0, 8);
            Array.Reverse(value, 8, 8);

            return value;
        }
    }
}
