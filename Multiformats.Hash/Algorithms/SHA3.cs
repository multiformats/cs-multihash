using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public abstract class SHA3 : MultihashAlgorithm
    {
        private readonly Func<IDigest> _factory;

        protected SHA3(HashType code, string name, int defaultLength, Func<IDigest> factory)
            : base(code, name, defaultLength)
        {
            _factory = factory;
        }

        public override byte[] ComputeHash(byte[] data) => _factory().ComputeHash(data);
    }

    [MultihashAlgorithmExport(HashType.SHA3_224, "sha3-224", 28)]
    public class SHA3_224 : SHA3
    {
        public SHA3_224()
			: base(HashType.SHA3_224, "sha3-224", 28, () => new Sha3Digest(224))
        {
        }
    }
	    [MultihashAlgorithmExport(HashType.SHA3_256, "sha3-256", 32)]
    public class SHA3_256 : SHA3
    {
        public SHA3_256()
			: base(HashType.SHA3_256, "sha3-256", 32, () => new Sha3Digest(256))
        {
        }
    }
	    [MultihashAlgorithmExport(HashType.SHA3_384, "sha3-384", 48)]
    public class SHA3_384 : SHA3
    {
        public SHA3_384()
			: base(HashType.SHA3_384, "sha3-384", 48, () => new Sha3Digest(384))
        {
        }
    }
	    [MultihashAlgorithmExport(HashType.SHA3_512, "sha3-512", 64)]
    public class SHA3_512 : SHA3
    {
        public SHA3_512()
			: base(HashType.SHA3_512, "sha3-512", 64, () => new Sha3Digest(512))
        {
        }
    }
	}
