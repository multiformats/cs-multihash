using System.Threading.Tasks;

namespace Multiformats.Hash.Algorithms
{
    public abstract class MultihashAlgorithm
    {
        public HashType Code { get; }
        public string Name { get; }
        public int DefaultLength { get; } = 1;

        protected MultihashAlgorithm(HashType code, string name, int defaultLength)
        {
            Code = code;
            Name = name;
            DefaultLength = defaultLength;
        }

        public abstract byte[] ComputeHash(byte[] data);
        public virtual Task<byte[]> ComputeHashAsync(byte[] data) => Task.Factory.StartNew(() => ComputeHash(data));
    }
}