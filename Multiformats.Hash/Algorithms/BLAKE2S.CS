using System;
using System.Security.Cryptography;
using Blake2s;
using Blake2Sharp;
using Hasher = Blake2s.Hasher;

namespace Multiformats.Hash.Algorithms
{
    [Obsolete("Use specific bit type instead")]
    public class BLAKE2S : MultihashAlgorithm
    {
        private readonly Hasher _algo;

        public BLAKE2S()
            : base(HashType.BLAKE2S, "blake2s", 32)
        {
            _algo = Blake2S.Create(new Blake2sConfig {OutputSizeInBytes = 32});
            _algo.Init();
        }

        protected BLAKE2S(int bits)
            : base(GetHashType(bits), GetName(bits), bits / 8)
        {
            _algo = Blake2S.Create(new Blake2sConfig { OutputSizeInBytes = bits / 8 });
            _algo.Init();
        }

        private static HashType GetHashType(int bytes) => (HashType)Enum.Parse(typeof(HashType), $"BLAKE2S_{bytes}");
        private static string GetName(int bytes) => $"blake2s-{bytes}";
        public override byte[] ComputeHash(byte[] data) => _algo.AsHashAlgorithm().ComputeHash(data);
    }

    public class BLAKE2S_8 : BLAKE2S { public BLAKE2S_8() : base(8) { } }
    public class BLAKE2S_16 : BLAKE2S { public BLAKE2S_16() : base(16) { } }
    public class BLAKE2S_24 : BLAKE2S { public BLAKE2S_24() : base(24) { } }
    public class BLAKE2S_32 : BLAKE2S { public BLAKE2S_32() : base(32) { } }
    public class BLAKE2S_40 : BLAKE2S { public BLAKE2S_40() : base(40) { } }
    public class BLAKE2S_48 : BLAKE2S { public BLAKE2S_48() : base(48) { } }
    public class BLAKE2S_56 : BLAKE2S { public BLAKE2S_56() : base(56) { } }
    public class BLAKE2S_64 : BLAKE2S { public BLAKE2S_64() : base(64) { } }
    public class BLAKE2S_72 : BLAKE2S { public BLAKE2S_72() : base(72) { } }
    public class BLAKE2S_80 : BLAKE2S { public BLAKE2S_80() : base(80) { } }
    public class BLAKE2S_88 : BLAKE2S { public BLAKE2S_88() : base(88) { } }
    public class BLAKE2S_96 : BLAKE2S { public BLAKE2S_96() : base(96) { } }
    public class BLAKE2S_104 : BLAKE2S { public BLAKE2S_104() : base(104) { } }
    public class BLAKE2S_112 : BLAKE2S { public BLAKE2S_112() : base(112) { } }
    public class BLAKE2S_120 : BLAKE2S { public BLAKE2S_120() : base(120) { } }
    public class BLAKE2S_128 : BLAKE2S { public BLAKE2S_128() : base(128) { } }
    public class BLAKE2S_136 : BLAKE2S { public BLAKE2S_136() : base(136) { } }
    public class BLAKE2S_144 : BLAKE2S { public BLAKE2S_144() : base(144) { } }
    public class BLAKE2S_152 : BLAKE2S { public BLAKE2S_152() : base(152) { } }
    public class BLAKE2S_160 : BLAKE2S { public BLAKE2S_160() : base(160) { } }
    public class BLAKE2S_168 : BLAKE2S { public BLAKE2S_168() : base(168) { } }
    public class BLAKE2S_176 : BLAKE2S { public BLAKE2S_176() : base(176) { } }
    public class BLAKE2S_184 : BLAKE2S { public BLAKE2S_184() : base(184) { } }
    public class BLAKE2S_192 : BLAKE2S { public BLAKE2S_192() : base(192) { } }
    public class BLAKE2S_200 : BLAKE2S { public BLAKE2S_200() : base(200) { } }
    public class BLAKE2S_208 : BLAKE2S { public BLAKE2S_208() : base(208) { } }
    public class BLAKE2S_216 : BLAKE2S { public BLAKE2S_216() : base(216) { } }
    public class BLAKE2S_224 : BLAKE2S { public BLAKE2S_224() : base(224) { } }
    public class BLAKE2S_232 : BLAKE2S { public BLAKE2S_232() : base(232) { } }
    public class BLAKE2S_240 : BLAKE2S { public BLAKE2S_240() : base(240) { } }
    public class BLAKE2S_248 : BLAKE2S { public BLAKE2S_248() : base(248) { } }
    public class BLAKE2S_256 : BLAKE2S { public BLAKE2S_256() : base(256) { } }
}
