using System;
using System.Composition;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public abstract class SHA2 : MultihashAlgorithm
    {
        private readonly Func<IDigest> _factory;

        protected SHA2(HashType code, string name, int defaultLength, Func<IDigest> factory)
            : base(code, name, defaultLength)
        {
            _factory = factory;
        }

        public override byte[] ComputeHash(byte[] data) => _factory().ComputeHash(data);
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SHA2_256, "sha2-256", 32)]
    public class SHA2_256 : SHA2
    {
        public SHA2_256()
			: base(HashType.SHA2_256, "sha2-256", 32, () => new Sha256Digest())
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SHA2_512, "sha2-512", 64)]
    public class SHA2_512 : SHA2
    {
        public SHA2_512()
			: base(HashType.SHA2_512, "sha2-512", 64, () => new Sha512Digest())
        {
        }
    }
}
