using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public abstract class SHAKE : MultihashAlgorithm
    {
        private readonly Func<IDigest> _factory;

        protected SHAKE(HashType code, string name, int defaultLength, Func<IDigest> factory)
            : base(code, name, defaultLength)
        {
            _factory = factory;
        }

        public override byte[] ComputeHash(byte[] data) => _factory().ComputeHash(data);
    }

    [MultihashAlgorithmExport(HashType.SHAKE_128, "shake-128", 16)]
    public class SHAKE_128 : SHAKE
    {
        public SHAKE_128()
			: base(HashType.SHAKE_128, "shake-128", 16, () => new ShakeDigest(128))
        {
        }
    }
	    [MultihashAlgorithmExport(HashType.SHAKE_256, "shake-256", 32)]
    public class SHAKE_256 : SHAKE
    {
        public SHAKE_256()
			: base(HashType.SHAKE_256, "shake-256", 32, () => new ShakeDigest(256))
        {
        }
    }
	}
