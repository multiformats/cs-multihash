using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multiformats.Hash
{
    public static class Extensions
    {
        public static Multihash ReadMultihash(this Stream stream)
        {
            var mhhdr = new byte[2];
            if (stream.Read(mhhdr, 0, 2) != 2)
                return null;

            var length = mhhdr[1];
            if (length > 127)
                throw new NotSupportedException("Varints not supported");

            var buffer = new byte[length + 2];
            Buffer.BlockCopy(mhhdr, 0, buffer, 0, 2);

            if (stream.Read(buffer, 2, length) != length)
                throw new Exception("Could not read entire Multihash");

            return Multihash.Cast(buffer);
        }

        public static async Task<Multihash> ReadMultihashAsync(this Stream stream, CancellationToken cancellationToken)
        {
            var mhhdr = new byte[2];
            if (await stream.ReadAsync(mhhdr, 0, 2, cancellationToken) != 2)
                return null;

            var length = mhhdr[1];
            if (length > 127)
                throw new NotSupportedException("Varints not supported");

            var buffer = new byte[length + 2];
            Buffer.BlockCopy(mhhdr, 0, buffer, 0, 2);

            if (await stream.ReadAsync(buffer, 2, length, cancellationToken) != length)
                throw new Exception("Could not read entire Multihash");

            return Multihash.Cast(buffer);
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
