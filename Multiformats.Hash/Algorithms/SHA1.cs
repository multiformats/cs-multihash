using System;
using System.ComponentModel.Composition;
using System.Security.Cryptography;

namespace Multiformats.Hash.Algorithms
{
    [MultihashAlgorithmExport(HashType.SHA1, "sha1", 20)]
    public class SHA1 : MultihashAlgorithm
    {
        private readonly Func<HashAlgorithm> _factory;

        public SHA1()
            : base(HashType.SHA1, "sha1", 20)
        {
            _factory = System.Security.Cryptography.SHA1.Create;
        }

        public override byte[] ComputeHash(byte[] data) => _factory().ComputeHash(data);
    }
}