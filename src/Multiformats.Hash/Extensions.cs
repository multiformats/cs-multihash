using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BinaryEncoding;

namespace Multiformats.Hash
{
    public static class Extensions
    {
        public static Multihash ReadMultihash(this Stream stream)
        {
            uint code;
            if (Binary.Varint.Read(stream, out code) <= 0)
                return null;

            uint length;
            if (Binary.Varint.Read(stream, out length) <= 0)
                return null;

            var buffer = new byte[length];
            if (stream.Read(buffer, 0, buffer.Length) != length)
                return null;

            return Multihash.Cast(Binary.Varint.GetBytes(code).Concat(Binary.Varint.GetBytes(length), buffer));
        }

        public static async Task<Multihash> ReadMultihashAsync(this Stream stream, CancellationToken cancellationToken)
        {
            var code = await Binary.Varint.ReadUInt32Async(stream);
            // @Todo: we should check how many bytes we have read,
            //        but the method we're using doesn't support that.

            var length = await Binary.Varint.ReadUInt32Async(stream);
            if (length == 0)
                return null;

            var buffer = new byte[length];
            if (await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken) != length)
                return null;

            return Multihash.Cast(Binary.Varint.GetBytes(code).Concat(Binary.Varint.GetBytes(length), buffer));
        }

        public static void Write(this Stream stream, Multihash mh)
        {
            var bytes = mh.ToBytes();
            stream.Write(bytes, 0, bytes.Length);
        }

        public static Task WriteAsync(this Stream stream, Multihash mh, CancellationToken cancellationToken)
        {
            var bytes = mh.ToBytes();
            return stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        }

        internal static byte[] Slice(this byte[] buffer, int offset = 0, int? count = null)
        {
            var result = new byte[Math.Min(count ?? buffer.Length - offset, buffer.Length - offset)];
            Buffer.BlockCopy(buffer, offset, result, 0, result.Length);
            return result;
        }

        internal static byte[] Concat(this byte[] buffer, params byte[][] buffers)
        {
            var result = new byte[buffer.Length + buffers.Sum(b => b.Length)];
            Buffer.BlockCopy(buffer, 0, result, 0, buffer.Length);
            var offset = buffer.Length;
            foreach (var buf in buffers)
            {
                Buffer.BlockCopy(buf, 0, result, offset, buf.Length);
                offset += buf.Length;
            }
            return result;
        }
    }
}
