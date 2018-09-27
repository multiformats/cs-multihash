using System;
using System.Composition;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.MD5, "md5", 16)]
    public class MD5 : MultihashAlgorithm
    {
        private readonly Func<IDigest> _factory;

        public MD5()
            : base(HashType.MD5, "md5", 16)
        {
            _factory = () => new MD5Digest();
        }

        public override byte[] ComputeHash(byte[] data, int length = -1) => _factory().ComputeHash(data);
    }
}