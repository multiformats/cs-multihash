using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multiformats.Hash.Algorithms
{
    internal class Registry
    {
        private readonly Dictionary<HashType, Type> _mappings;
        private readonly ConcurrentDictionary<HashType, ConcurrentQueue<MultihashAlgorithm>> _algorithms;

        public Registry()
        {
            _mappings = new Dictionary<HashType, Type>
            {
                {HashType.SHA1, typeof(SHA1)},
                {HashType.SHA2_256, typeof(SHA2_256)},
                {HashType.SHA2_512, typeof(SHA2_512)},
                {HashType.SHA3_224, typeof(SHA3_224)},
                {HashType.SHA3_256, typeof(SHA3_256)},
                {HashType.SHA3_384, typeof(SHA3_384)},
                {HashType.SHA3_512, typeof(SHA3_512)},
                {HashType.KECCAK_224, typeof(KECCAK_224)},
                {HashType.KECCAK_256, typeof(KECCAK_256)},
                {HashType.KECCAK_384, typeof(KECCAK_384)},
                {HashType.KECCAK_512, typeof(KECCAK_512)},
                {HashType.SHAKE_128, typeof(SHAKE_128)},
                {HashType.SHAKE_256, typeof(SHAKE_256)},
                {HashType.BLAKE2B, typeof(BLAKE2B)},
                {HashType.BLAKE2S, typeof(BLAKE2S)},
                {HashType.DBL_SHA2_256, typeof(DBL_SHA2_256)}
            };
            _algorithms = new ConcurrentDictionary<HashType, ConcurrentQueue<MultihashAlgorithm>>(Environment.ProcessorCount, _mappings.Count);
        }

        public MultihashAlgorithm Rent(HashType type)
        {
            var queue = _algorithms.GetOrAdd(type, _ => new ConcurrentQueue<MultihashAlgorithm>());

            MultihashAlgorithm algo;
            if (!queue.TryDequeue(out algo))
                algo = (MultihashAlgorithm) Activator.CreateInstance(_mappings[type]);

            return algo;
        }

        public MultihashAlgorithm Rent<TAlgorithm>()
            where TAlgorithm : MultihashAlgorithm
        {
            var code = _mappings.SingleOrDefault(x => x.Value == typeof(TAlgorithm)).Key;
            return Rent(code);
        }

        public void Return(MultihashAlgorithm algo)
        {
            var queue = _algorithms.GetOrAdd(algo.Code, _ => new ConcurrentQueue<MultihashAlgorithm>());

            queue.Enqueue(algo);
        }

        public T Use<T>(HashType code, Func<MultihashAlgorithm, T> func)
        {
            var algorithm = Rent(code);
            try
            {
                return func(algorithm);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public async Task<T> UseAsync<T>(HashType code, Func<MultihashAlgorithm, Task<T>> func)
        {
            var algorithm = Rent(code);
            try
            {
                return await func(algorithm).ConfigureAwait(false);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public TResult Use<TAlgorithm, TResult>(Func<MultihashAlgorithm, TResult> func)
            where TAlgorithm : MultihashAlgorithm
        {
            var algorithm = Rent<TAlgorithm>();
            try
            {
                return func(algorithm);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public async Task<TResult> UseAsync<TAlgorithm, TResult>(Func<MultihashAlgorithm, Task<TResult>> func)
            where TAlgorithm : MultihashAlgorithm
        {
            var algorithm = Rent<TAlgorithm>();
            try
            {
                return await func(algorithm);
            }
            finally
            {
                Return(algorithm);
            }
        }

        public HashType GetHashType<TAlgorithm>()
            where TAlgorithm : MultihashAlgorithm
        {
            return _mappings.SingleOrDefault(x => x.Value == typeof(TAlgorithm)).Key;
        }
    }
}
