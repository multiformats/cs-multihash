using System;
using System.Security.Cryptography;

namespace Multiformats.Hash.Algorithms
{
    public abstract class SHA2 : MultihashAlgorithm
    {
        private readonly Func<HashAlgorithm> _factory;

        protected SHA2(HashType code, string name, int defaultLength, Func<HashAlgorithm> factory)
            : base(code, name, defaultLength)
        {
            _factory = factory;
        }

        public override byte[] ComputeHash(byte[] data) => _factory().ComputeHash(data);
    }

    [MultihashAlgorithmExport(HashType.SHA2_256, "sha2-256", 32)]
    public class SHA2_256 : SHA2
    {
        public SHA2_256()
			: base(HashType.SHA2_256, "sha2-256", 32, SHA256.Create)
        {
        }
    }
	    [MultihashAlgorithmExport(HashType.SHA2_512, "sha2-512", 64)]
    public class SHA2_512 : SHA2
    {
        public SHA2_512()
			: base(HashType.SHA2_512, "sha2-512", 64, SHA512.Create)
        {
        }
    }
	}
