using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;

namespace Multiformats.Hash.Algorithms
{
    internal static class Extensions
    {
        public static byte[] ComputeHash(this IDigest digest, byte[] data)
        {
            digest.Reset();
            digest.BlockUpdate(data, 0, data.Length);
            var hash = new byte[digest.GetByteLength()];
            digest.DoFinal(hash, 0);
            return hash;
        }
    }
}
