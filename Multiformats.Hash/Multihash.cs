using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multiformats.Base;
using Multiformats.Hash.Algorithms;
using Org.BouncyCastle.Tsp;

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

        public string ToString(MultibaseEncoding encoding) => Multibase.EncodeRaw(encoding, _bytes);
        public override string ToString() => ToString(Multibase.Base16);

        [Obsolete("Use ToString() instead")]
        public string B58String() => ToString(Multibase.Base58);

        [Obsolete("Use ToString() instead")]
        public string ToHexString() => ToString(Multibase.Base16);

        public override bool Equals(object obj)
        {
            var other = (Multihash) obj;
            if (other == null)
                return false;

            return _bytes.SequenceEqual(other._bytes);
        }

        public static bool TryParse(string s, out Multihash mh)
        {
            try
            {
                var bytes = Multibase.Decode(s);
                if (bytes != null && bytes.Length > 0)
                {
                    mh = Decode(bytes);
                    return true;
                }
            }
            catch { }

            var bases = new MultibaseEncoding[] { Multibase.Base2, Multibase.Base8, Multibase.Base16, Multibase.Base32, Multibase.Base58, Multibase.Base64 };
            foreach (var @base in bases)
            {
                try
                {
                    var bytes = Multibase.DecodeRaw(@base, s);
                    if (bytes != null && bytes.Length > 0)
                    {
                        mh = Decode(bytes);
                        return true;
                    }
                }
                catch { }
            }

            mh = null;
            return false;
        }

        public static Multihash Parse(string s)
        {
            Multihash mh;
            if (!TryParse(s, out mh))
                throw new FormatException("Not a valid multihash");

            return mh;
        }

        [Obsolete("Use Parse/TryParse instead")]
        public static Multihash FromHexString(string s) => Cast(Multibase.DecodeRaw(Multibase.Base16, s));

        [Obsolete("Use Parse/TryParse instead")]
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

        private static TAlgorithm Get<TAlgorithm>() where TAlgorithm : MultihashAlgorithm
        {
            MultihashAlgorithm algo;
            if (!_algorithms.TryGetValue(typeof(TAlgorithm), out algo))
            {
                algo = Activator.CreateInstance<TAlgorithm>();
                _algorithms.TryAdd(typeof(TAlgorithm), algo);
            }

            return (TAlgorithm)algo;
        }

        public static byte[] Encode<TAlgorithm>(byte[] data) where TAlgorithm : MultihashAlgorithm
        {
            if (data.Length > 127)
                throw new Exception("Length not supported");

            var algo = Get<TAlgorithm>();

            return new[] { (byte)algo.Code, (byte)data.Length }.Concat(data).ToArray();
        }

        public static Multihash Sum<TAlgorithm>(byte[] data, int length = -1) where TAlgorithm : MultihashAlgorithm
        {
            var algo = Get<TAlgorithm>();

            return new Multihash(algo.Code, algo.ComputeHash(data).Take(length != -1 ? length : algo.DefaultLength).ToArray());
        }

        public static async Task<Multihash> SumAsync<TAlgorithm>(byte[] data, int length = -1) where TAlgorithm : MultihashAlgorithm
        {
            var algo = Get<TAlgorithm>();

            return new Multihash(algo.Code, (await algo.ComputeHashAsync(data)).Take(length != -1 ? length : algo.DefaultLength).ToArray());
        }

        public static implicit operator Multihash(byte[] buf) => Decode(buf);
        public static implicit operator byte[](Multihash mh) => mh._bytes;
        public static implicit operator Multihash(string s) => Parse(s);
        public static implicit operator string(Multihash mh) => mh.ToString(Multibase.Base16);

        public static string GetName(int code) => Enum.IsDefined(typeof(HashType), (HashType)code) ? ((HashType)code).ToString().Replace("_", "-").ToLower() : "unsupported";

        public static HashType GetCode(string name)
        {
            HashType result;
            return HashType.TryParse(name.Replace("-", "_"), true, out result) ? result : HashType.UNKNOWN;
        }
    }
}
