using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multiformats.Base;

namespace Multiformats.Hash
{
    public class Multihash
    {
        public HashType Code { get; protected set; }
        public string Name { get; protected set; }
        public int Length { get; protected set; }
        public byte[] Digest { get; protected set; }

        private readonly byte[] _bytes;

        protected Multihash(byte[] bytes)
        {
            _bytes = bytes;
        }

        protected Multihash(HashType code, byte[] digest)
        {
            Code = code;
            Name = GetName((int) code);
            Length = digest.Length;
            Digest = digest;

            _bytes = Encode(digest, code);
        }

        public string ToHexString() => Multibase.EncodeRaw(Multibase.Base16, _bytes);

        public override string ToString() => ToHexString();

        public override bool Equals(object obj)
        {
            var other = (Multihash) obj;
            if (other == null)
                return false;

            return _bytes.SequenceEqual(other._bytes);
        }

        public static Multihash FromHexString(string s) => Cast(Multibase.DecodeRaw(Multibase.Base16, s));

        public string B58String() => Multibase.EncodeRaw(Multibase.Base58, _bytes);

        public static Multihash FromB58String(string s) => Cast(Multibase.DecodeRaw(Multibase.Base58, s));

        public static Multihash Cast(byte[] buf) => Decode(buf);

        public static Multihash Decode(byte[] buf)
        {
            if (buf == null)
                throw new ArgumentNullException(nameof(buf));

            if (buf.Length < 3)
                throw new Exception("Too short");

            if (buf.Length > 129)
                throw new Exception("Too long");

            var dm = new Multihash(buf)
            {
                Code = (HashType)buf[0],
                Name = GetName(buf[0]),
                Length = buf[1],
                Digest = buf.Skip(2).ToArray()
            };

            if (dm.Digest.Length != dm.Length)
                throw new Exception("Incosistent length");

            return dm;
        }

        public static byte[] Encode(byte[] data, HashType code)
        {
            if (data.Length > 127)
                throw new Exception("Length not supported");

            return new[] {(byte) code, (byte) data.Length}.Concat(data).ToArray();
        }

        public static Multihash Encode(string s, HashType code) => Encode(Multibase.DecodeRaw(Multibase.Base32, s), code);

        private static readonly ConcurrentDictionary<Type, MultihashAlgorithm> _algorithms = new ConcurrentDictionary<Type, MultihashAlgorithm>();

        public static Multihash Sum<TAlgorithm>(byte[] data, int length = -1) where TAlgorithm : MultihashAlgorithm
        {
            MultihashAlgorithm algo;
            if (!_algorithms.TryGetValue(typeof(TAlgorithm), out algo))
            {
                algo = Activator.CreateInstance<TAlgorithm>();
                _algorithms.TryAdd(typeof(TAlgorithm), algo);
            }

            return new Multihash(algo.Code, algo.ComputeHash(data).Take(length != -1 ? length : algo.DefaultLength).ToArray());
        }

        public static async Task<Multihash> SumAsync<TAlgorithm>(byte[] data, int length = -1) where TAlgorithm : MultihashAlgorithm
        {
            MultihashAlgorithm algo;
            if (!_algorithms.TryGetValue(typeof(TAlgorithm), out algo))
            {
                algo = Activator.CreateInstance<TAlgorithm>();
                _algorithms.TryAdd(typeof(TAlgorithm), algo);
            }

            return new Multihash(algo.Code, (await algo.ComputeHashAsync(data)).Take(length != -1 ? length : algo.DefaultLength).ToArray());
        }

        public static implicit operator Multihash(byte[] buf) => Cast(buf);
        public static implicit operator byte[](Multihash mh) => mh._bytes;
        public static implicit operator Multihash(string s) => FromHexString(s);
        public static implicit operator string(Multihash mh) => mh.ToHexString();

        public static string GetName(int code) => Enum.IsDefined(typeof(HashType), (HashType)code) ? ((HashType)code).ToString().Replace("_", "-").ToLower() : "unsupported";

        public static HashType GetCode(string name)
        {
            HashType result;
            return HashType.TryParse(name.Replace("-", "_"), true, out result) ? result : HashType.UNKNOWN;
        }
    }
}
