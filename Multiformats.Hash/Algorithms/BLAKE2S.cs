﻿using System;
using Blake2s;

namespace Multiformats.Hash.Algorithms
{
    public abstract class BLAKE2S : MultihashAlgorithm
    {
        private readonly Func<Hasher> _factory;

        protected BLAKE2S(int bits)
            : base(GetHashType(bits), GetName(bits), bits / 8)
        {
            _factory = () =>
            {
                var algo = Blake2S.Create(new Blake2sConfig {OutputSizeInBytes = bits / 8});
                algo.Init();
                return algo;
            };
        }

        private static HashType GetHashType(int bytes) => (HashType)Enum.Parse(typeof(HashType), $"BLAKE2S_{bytes}");
        private static string GetName(int bytes) => $"blake2s-{bytes}";
        public override byte[] ComputeHash(byte[] data) => _factory().AsHashAlgorithm().ComputeHash(data);
    }
	
    [MultihashAlgorithmExport(HashType.BLAKE2S_8, "blake2s-8", 8)]
    public class BLAKE2S_8 : BLAKE2S { public BLAKE2S_8() : base(8) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_16, "blake2s-16", 16)]
    public class BLAKE2S_16 : BLAKE2S { public BLAKE2S_16() : base(16) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_24, "blake2s-24", 24)]
    public class BLAKE2S_24 : BLAKE2S { public BLAKE2S_24() : base(24) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_32, "blake2s-32", 32)]
    public class BLAKE2S_32 : BLAKE2S { public BLAKE2S_32() : base(32) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_40, "blake2s-40", 40)]
    public class BLAKE2S_40 : BLAKE2S { public BLAKE2S_40() : base(40) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_48, "blake2s-48", 48)]
    public class BLAKE2S_48 : BLAKE2S { public BLAKE2S_48() : base(48) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_56, "blake2s-56", 56)]
    public class BLAKE2S_56 : BLAKE2S { public BLAKE2S_56() : base(56) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_64, "blake2s-64", 64)]
    public class BLAKE2S_64 : BLAKE2S { public BLAKE2S_64() : base(64) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_72, "blake2s-72", 72)]
    public class BLAKE2S_72 : BLAKE2S { public BLAKE2S_72() : base(72) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_80, "blake2s-80", 80)]
    public class BLAKE2S_80 : BLAKE2S { public BLAKE2S_80() : base(80) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_88, "blake2s-88", 88)]
    public class BLAKE2S_88 : BLAKE2S { public BLAKE2S_88() : base(88) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_96, "blake2s-96", 96)]
    public class BLAKE2S_96 : BLAKE2S { public BLAKE2S_96() : base(96) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_104, "blake2s-104", 104)]
    public class BLAKE2S_104 : BLAKE2S { public BLAKE2S_104() : base(104) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_112, "blake2s-112", 112)]
    public class BLAKE2S_112 : BLAKE2S { public BLAKE2S_112() : base(112) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_120, "blake2s-120", 120)]
    public class BLAKE2S_120 : BLAKE2S { public BLAKE2S_120() : base(120) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_128, "blake2s-128", 128)]
    public class BLAKE2S_128 : BLAKE2S { public BLAKE2S_128() : base(128) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_136, "blake2s-136", 136)]
    public class BLAKE2S_136 : BLAKE2S { public BLAKE2S_136() : base(136) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_144, "blake2s-144", 144)]
    public class BLAKE2S_144 : BLAKE2S { public BLAKE2S_144() : base(144) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_152, "blake2s-152", 152)]
    public class BLAKE2S_152 : BLAKE2S { public BLAKE2S_152() : base(152) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_160, "blake2s-160", 160)]
    public class BLAKE2S_160 : BLAKE2S { public BLAKE2S_160() : base(160) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_168, "blake2s-168", 168)]
    public class BLAKE2S_168 : BLAKE2S { public BLAKE2S_168() : base(168) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_176, "blake2s-176", 176)]
    public class BLAKE2S_176 : BLAKE2S { public BLAKE2S_176() : base(176) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_184, "blake2s-184", 184)]
    public class BLAKE2S_184 : BLAKE2S { public BLAKE2S_184() : base(184) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_192, "blake2s-192", 192)]
    public class BLAKE2S_192 : BLAKE2S { public BLAKE2S_192() : base(192) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_200, "blake2s-200", 200)]
    public class BLAKE2S_200 : BLAKE2S { public BLAKE2S_200() : base(200) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_208, "blake2s-208", 208)]
    public class BLAKE2S_208 : BLAKE2S { public BLAKE2S_208() : base(208) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_216, "blake2s-216", 216)]
    public class BLAKE2S_216 : BLAKE2S { public BLAKE2S_216() : base(216) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_224, "blake2s-224", 224)]
    public class BLAKE2S_224 : BLAKE2S { public BLAKE2S_224() : base(224) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_232, "blake2s-232", 232)]
    public class BLAKE2S_232 : BLAKE2S { public BLAKE2S_232() : base(232) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_240, "blake2s-240", 240)]
    public class BLAKE2S_240 : BLAKE2S { public BLAKE2S_240() : base(240) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_248, "blake2s-248", 248)]
    public class BLAKE2S_248 : BLAKE2S { public BLAKE2S_248() : base(248) { } }
    [MultihashAlgorithmExport(HashType.BLAKE2S_256, "blake2s-256", 256)]
    public class BLAKE2S_256 : BLAKE2S { public BLAKE2S_256() : base(256) { } }
}
