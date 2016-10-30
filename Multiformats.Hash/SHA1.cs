namespace Multiformats.Hash
{
    public class SHA1 : MultihashAlgorithm
    {
        private readonly System.Security.Cryptography.HashAlgorithm algo;

        public SHA1()
            : base(HashType.SHA1, "sha1", 20)
        {
            algo = System.Security.Cryptography.SHA1.Create();
        }

        public override byte[] ComputeHash(byte[] data) => algo.ComputeHash(data);
    }
}