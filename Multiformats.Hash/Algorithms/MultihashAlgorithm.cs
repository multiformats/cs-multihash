using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace Multiformats.Hash.Algorithms
{
    public interface IMultihashAlgorithm
    {
        HashType Code { get; }
        string Name { get; }
        int DefaultLength { get; }
        byte[] ComputeHash(byte[] data);
        Task<byte[]> ComputeHashAsync(byte[] data);
    }

    public abstract class MultihashAlgorithm : IMultihashAlgorithm
    {
        public HashType Code { get; }
        public string Name { get; }
        public int DefaultLength { get; }

        protected MultihashAlgorithm(HashType code, string name, int defaultLength)
        {
            Code = code;
            Name = name;
            DefaultLength = defaultLength;
        }

        public abstract byte[] ComputeHash(byte[] data);
        public virtual Task<byte[]> ComputeHashAsync(byte[] data) => Task.Factory.StartNew(() => ComputeHash(data));
    }

    public interface IMultihashAlgorithmMetadata
    {
        HashType Code { get; }
        string Name { get; }
        int DefaultLength { get; }
    }
    
    [AttributeUsage(AttributeTargets.Class)]
    [MetadataAttribute]
    public class MultihashAlgorithmExportAttribute : ExportAttribute, IMultihashAlgorithmMetadata
    {
        public HashType Code { get; }
        public string Name { get; }
        public int DefaultLength { get; }

        public MultihashAlgorithmExportAttribute(HashType code, string name, int defaultLength)
            : base(typeof(IMultihashAlgorithm))
        {
            Code = code;
            Name = name;
            DefaultLength = defaultLength;
        }
    }
}