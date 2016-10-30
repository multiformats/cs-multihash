namespace Multiformats.Hash
{
    public class SHA2_256 : MultihashAlgorithm
    {
        private readonly System.Security.Cryptography.HashAlgorithm algo;

        public SHA2_256()
            : base(HashType.SHA2_256, "sha2-256", 32)
        {
            algo = System.Security.Cryptography.SHA256.Create();
        }

        public override byte[] ComputeHash(byte[] data) => algo.ComputeHash(data);
    }
}