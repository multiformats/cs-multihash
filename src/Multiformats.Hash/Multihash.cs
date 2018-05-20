using System;
using System.Linq;
using System.Threading.Tasks;
using BinaryEncoding;
using Multiformats.Base;
using Multiformats.Hash.Algorithms;

namespace Multiformats.Hash
{
    public class Multihash
    {
        private static readonly Registry _registry = new Registry();

        public HashType Code { get; }
        public string Name { get; }
        public int Length => Digest?.Length ?? 0;
        public byte[] Digest { get; }

        public static HashType[] SupportedHashCodes => _registry.SupportedHashTypes;

        private readonly Lazy<byte[]> _bytes;

        protected Multihash(byte[] bytes)
        {
            _bytes = new Lazy<byte[]>(() => bytes);
        }

        protected Multihash(HashType code, byte[] digest)
        {
            Code = code;
            Name = GetName((int) code);
            Digest = digest;

            _bytes = new Lazy<byte[]>(() => Encode(digest, code));
        }

        public string ToString(MultibaseEncoding encoding) => Multibase.EncodeRaw(encoding, _bytes.Value);
        public override string ToString() => ToString(MultibaseEncoding.Base16Lower);

        [Obsolete("Use ToString() instead")]
        public string B58String() => ToString(MultibaseEncoding.Base58Btc);

        [Obsolete("Use ToString() instead")]
        public string ToHexString() => ToString(MultibaseEncoding.Base16Lower);

        public byte[] ToBytes() => _bytes.Value;

        public override bool Equals(object obj)
        {
            var other = (Multihash) obj;
            return other != null && _bytes.Value.SequenceEqual(other._bytes.Value);
        }

        public override int GetHashCode() => (int) Code ^ Length ^ Digest.Sum(b => b);

        public bool Verify(byte[] data) => Sum(Code, data, Length).Equals(this);
        public Task<bool> VerifyAsync(byte[] data) => SumAsync(Code, data, Length).ContinueWith(mh => mh.Result?.Equals(this) ?? false);

        private static readonly MultibaseEncoding[] _encodings =
        {
            MultibaseEncoding.Base16Lower,
            MultibaseEncoding.Base32Lower,
            MultibaseEncoding.Base58Btc,
            MultibaseEncoding.Base64,
            MultibaseEncoding.Base2,
            MultibaseEncoding.Base8,
        };

        public static bool TryParse(string s, out Multihash mh)
        {
            foreach (var encoding in _encodings)
            {
                try
                {
                    var bytes = Multibase.DecodeRaw(encoding, s);
                    mh = Decode(bytes);
                    return true;
                }
                catch (Exception) { }
            }

            mh = null;
            return false;
        }

        public static Multihash Parse(string s)
        {
            if (!TryParse(s, out var mh))
                throw new FormatException("Not a valid multihash");

            return mh;
        }

        [Obsolete("Use Parse/TryParse instead")]
        public static Multihash FromHexString(string s) => Cast(Multibase.Base16.Decode(s));

        [Obsolete("Use Parse/TryParse instead")]
        public static Multihash FromB58String(string s) => Cast(Multibase.Base58.Decode(s));

        public static Multihash Cast(byte[] buf) => Decode(buf);

        public static Multihash Decode(byte[] buf)
        {
            if (buf == null)
                throw new ArgumentNullException(nameof(buf));

            if (buf.Length < 2)
                throw new Exception("Too short");

            var offset = Binary.Varint.Read(buf, 0, out uint code);
            offset += Binary.Varint.Read(buf, offset, out uint length);

            if (length > buf.Length - offset)
                throw new Exception("Incosistent length");

            return new Multihash((HashType)code, buf.Slice(offset));
        }

        public static byte[] Encode(byte[] data, HashType code) => Binary.Varint.GetBytes((uint) code).Concat(Binary.Varint.GetBytes((uint)data.Length), data);
        public static Multihash Encode(string s, HashType code) => Encode(Multibase.Base32.Decode(s), code);
        public static byte[] Encode<TAlgorithm>(byte[] data) where TAlgorithm : IMultihashAlgorithm
        {
            var algo = Registry.GetHashType<TAlgorithm>();
            if (!algo.HasValue)
                throw new NotSupportedException($"{typeof(TAlgorithm)} is not supported.");

            return Binary.Varint.GetBytes((uint)algo.Value).Concat(Binary.Varint.GetBytes((uint)data.Length), data);
        }

        private static Multihash Sum(IMultihashAlgorithm algo, byte[] data, int length) => new Multihash(algo.Code, algo.ComputeHash(data).Slice(0, length != -1 ? length : algo.DefaultLength));
        public static Multihash Sum(HashType code, byte[] data, int length = -1) => _registry.Use(code, algo => Sum(algo, data, length));
        public static Multihash Sum<TAlgorithm>(byte[] data, int length = -1) where TAlgorithm : IMultihashAlgorithm => _registry.Use<TAlgorithm, Multihash>(algo => Sum(algo, data, length));
        private static Task<Multihash> SumAsync(IMultihashAlgorithm algo, byte[] data, int length) => algo.ComputeHashAsync(data).ContinueWith(t => new Multihash(algo.Code, t.Result.Slice(0, length != -1 ? length : algo.DefaultLength)));
        public static Task<Multihash> SumAsync(HashType type, byte[] data, int length = -1) => _registry.UseAsync(type, algo => SumAsync(algo, data, length));
        public static Task<Multihash> SumAsync<TAlgorithm>(byte[] data, int length = -1) where TAlgorithm : IMultihashAlgorithm => _registry.UseAsync<TAlgorithm, Multihash>(algo => SumAsync(algo, data, length));

        public static implicit operator Multihash(byte[] buf) => Decode(buf);
        public static implicit operator byte[](Multihash mh) => mh._bytes.Value;
        public static implicit operator Multihash(string s) => Parse(s);
        public static implicit operator string(Multihash mh) => mh.ToString(MultibaseEncoding.Base16Lower);

        public static string GetName(HashType code) => code.ToString().Replace("_", "-").ToLower();
        public static string GetName(int code) => Enum.IsDefined(typeof(HashType), (HashType)code) ? GetName((HashType)code) : "unsupported";

        public static HashType? GetCode(string name) => Enum.TryParse(name.Replace("-", "_"), true, out HashType result) ? result : new HashType?();
    }
}
