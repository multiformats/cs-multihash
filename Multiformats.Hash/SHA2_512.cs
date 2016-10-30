namespace Multiformats.Hash
{
    public class SHA2_512 : MultihashAlgorithm
    {
        private readonly System.Security.Cryptography.HashAlgorithm algo;

        public SHA2_512()
            : base(HashType.SHA2_512, "sha2-512", 64)
        {
            algo = System.Security.Cryptography.SHA512.Create();
        }

        public override byte[] ComputeHash(byte[] data) => algo.ComputeHash(data);
    }
}