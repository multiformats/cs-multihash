using System;
using System.Composition;
using System.Threading.Tasks;

namespace Multiformats.Hash.Algorithms
{
    public interface IMultihashAlgorithm
    {
        HashType Code { get; }

        string Name { get; }

        int DefaultLength { get; }

        byte[] ComputeHash(byte[] data, int length = -1);

        Task<byte[]> ComputeHashAsync(byte[] data, int length = -1);
    }

    public abstract class MultihashAlgorithm : IMultihashAlgorithm
    {
        private static readonly Lazy<Random> _random = new(() => new Random(Environment.TickCount));

        private readonly Lazy<int> _hashCode;

        public HashType Code { get; }

        public string Name { get; }

        public int DefaultLength { get; }

        protected MultihashAlgorithm(HashType code, string name, int defaultLength)
        {
            Code = code;
            Name = name;
            DefaultLength = defaultLength;

            _hashCode = new Lazy<int>(() => (int)Code ^ Name.GetHashCode() ^ DefaultLength ^ _random.Value.Next());
        }

        public abstract byte[] ComputeHash(byte[] data, int length = -1);
        
        public virtual Task<byte[]> ComputeHashAsync(byte[] data, int length = -1) => 
            Task.Run(() => ComputeHash(data, length));

        public override int GetHashCode() => _hashCode.Value;
    }

    public interface IMultihashAlgorithmMetadata
    {
        HashType Code { get; }
        string Name { get; }
        int DefaultLength { get; }
    }

    public class MultihashAlgorithmMetadata : IMultihashAlgorithmMetadata
    {
        public HashType Code { get; set; }
        public string Name { get; set; }
        public int DefaultLength { get; set; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    [MetadataAttribute]
    public class MultihashAlgorithmExportAttribute : Attribute, IMultihashAlgorithmMetadata
    {
        public HashType Code { get; }
        public string Name { get; }
        public int DefaultLength { get; }

        public MultihashAlgorithmExportAttribute(HashType code, string name, int defaultLength)
        {
            Code = code;
            Name = name;
            DefaultLength = defaultLength;
        }
    }
}
