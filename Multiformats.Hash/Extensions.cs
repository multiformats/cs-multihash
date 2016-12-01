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

            return Multihash.Cast(Binary.Varint.GetBytes(code).Concat(Binary.Varint.GetBytes(length)).Concat(buffer).ToArray());
        }

        public static async Task<Multihash> ReadMultihashAsync(this Stream stream, CancellationToken cancellationToken)
        {
            var code = await Binary.Varint.ReadUInt32Async(stream);
            if (code == 0)
                return null;

            var length = await Binary.Varint.ReadUInt32Async(stream);
            if (length == 0)
                return null;

            var buffer = new byte[length];
            if (await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken) != length)
                return null;

            return Multihash.Cast(Binary.Varint.GetBytes(code).Concat(Binary.Varint.GetBytes(length)).Concat(buffer).ToArray());
        }

        public static void Write(this Stream stream, Multihash mh)
        {
            var bytes = (byte[])mh;
            stream.Write(bytes, 0, bytes.Length);
        }

        public static Task WriteAsync(this Stream stream, Multihash mh, CancellationToken cancellationToken)
        {
            var bytes = (byte[])mh;
            return stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        }
    }
}
