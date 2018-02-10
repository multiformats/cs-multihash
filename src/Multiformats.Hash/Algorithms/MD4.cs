using System;
using System.Composition;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.MD4, "md4", 16)]
    public class MD4 : MultihashAlgorithm
    {
        private readonly Func<IDigest> _factory;

        public MD4()
            : base(HashType.MD4, "md4", 16)
        {
            _factory = () => new MD4Digest();
        }

        public override byte[] ComputeHash(byte[] data) => _factory().ComputeHash(data);
    }
}
