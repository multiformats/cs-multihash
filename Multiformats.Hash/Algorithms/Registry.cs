using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Multiformats.Hash.Algorithms
{
    internal class Registry : IDisposable
    {
        private readonly AggregateCatalog _catalog;
        private readonly CompositionContainer _container;
        private readonly IEnumerable<Lazy<IMultihashAlgorithm, IMultihashAlgorithmMetadata>> _algorithms;

        public HashType[] SupportedHashTypes => _algorithms.Select(a => a.Metadata.Code).OrderBy(x => x.ToString()).ToArray();

        public Registry()
        {
            _catalog = new AggregateCatalog(new AssemblyCatalog(typeof(Multihash).Assembly)/*, new DirectoryCatalog(Environment.CurrentDirectory)*/);
            _container = new CompositionContainer(_catalog);
            _algorithms = _container.GetExports<IMultihashAlgorithm, IMultihashAlgorithmMetadata>();
        }

        private static HashType TypeToHashType(Type type) => (HashType) Enum.Parse(typeof(HashType), type.Name);

        public IMultihashAlgorithm Get(HashType type)
        {
            var algo = _algorithms.SingleOrDefault(a => a.Metadata.Code.Equals(type));
            if (algo == null)
                throw new NotSupportedException($"{type} is not supported.");

            return algo.Value;
        }

        public IMultihashAlgorithm Get<TAlgorithm>()
            where TAlgorithm : IMultihashAlgorithm
        {
            var code = GetHashType<TAlgorithm>();
            if (code == HashType.UNKNOWN)
                throw new NotSupportedException($"{typeof(TAlgorithm)} is not supported.");

            return Get(code);
        }

        public void Return(IMultihashAlgorithm algo)
        {
        }

        public T Use<T>(HashType code, Func<IMultihashAlgorithm, T> func)
        {
            var algorithm = Get(code);
            try
            {
                return func(algorithm);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public async Task<T> UseAsync<T>(HashType code, Func<IMultihashAlgorithm, Task<T>> func)
        {
            var algorithm = Get(code);
            try
            {
                return await func(algorithm).ConfigureAwait(false);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public TResult Use<TAlgorithm, TResult>(Func<IMultihashAlgorithm, TResult> func)
            where TAlgorithm : IMultihashAlgorithm
        {
            var algorithm = Get<TAlgorithm>();
            try
            {
                return func(algorithm);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public async Task<TResult> UseAsync<TAlgorithm, TResult>(Func<IMultihashAlgorithm, Task<TResult>> func)
            where TAlgorithm : IMultihashAlgorithm
        {
            var algorithm = Get<TAlgorithm>();
            try
            {
                return await func(algorithm);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public static HashType GetHashType<TAlgorithm>()
            where TAlgorithm : IMultihashAlgorithm
        {
            var attr = typeof(TAlgorithm).GetCustomAttribute<MultihashAlgorithmExportAttribute>();
            return attr?.Code ?? HashType.UNKNOWN;
        }

        public void Dispose()
        {
            _catalog?.Dispose();
            _container?.Dispose();
        }
    }
}
