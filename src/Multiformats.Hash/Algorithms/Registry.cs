using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Multiformats.Hash.Algorithms
{
    internal class Registry : IDisposable
    {
        private readonly CompositionHost _container;
        private readonly IEnumerable<ExportFactory<IMultihashAlgorithm, MultihashAlgorithmMetadata>> _algorithms;
        private readonly ConcurrentDictionary<int, Export<IMultihashAlgorithm>> _cache;

        public HashType[] SupportedHashTypes => _algorithms.Select(a => a.Metadata.Code).OrderBy(x => x.ToString()).ToArray();

        public Registry()
        {
            _container = new ContainerConfiguration()
                .WithAssembly(typeof(Registry).GetTypeInfo().Assembly)
                .CreateContainer();
            
            _algorithms = _container.GetExports<ExportFactory<IMultihashAlgorithm, MultihashAlgorithmMetadata>>();
            _cache = new ConcurrentDictionary<int, Export<IMultihashAlgorithm>>();
        }

        public IMultihashAlgorithm Get(HashType type)
        {
            var algo = _algorithms.SingleOrDefault(a => a.Metadata.Code.Equals(type));
            if (algo == null)
                throw new NotSupportedException($"{type} is not supported.");

            var export = algo.CreateExport();

            _cache.TryAdd(algo.GetHashCode(), export);

            return export.Value;
        }

        public IMultihashAlgorithm Get<TAlgorithm>()
            where TAlgorithm : IMultihashAlgorithm
        {
            var code = GetHashType<TAlgorithm>();
            if (!code.HasValue || !Enum.IsDefined(typeof(HashType), code.Value))
                throw new NotSupportedException($"{typeof(TAlgorithm)} is not supported.");

            return Get(code.Value);
        }

        public void Return(IMultihashAlgorithm algo)
        {
            Export<IMultihashAlgorithm> export;
            if (_cache.TryRemove(algo.GetHashCode(), out export))
            {
                export?.Dispose();
            }
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

        public static HashType? GetHashType<TAlgorithm>()
            where TAlgorithm : IMultihashAlgorithm
        {
            return typeof(TAlgorithm).GetTypeInfo().GetCustomAttribute<MultihashAlgorithmExportAttribute>()?.Code;
        }

        public void Dispose()
        {
            _container?.Dispose();
        }
    }
}
