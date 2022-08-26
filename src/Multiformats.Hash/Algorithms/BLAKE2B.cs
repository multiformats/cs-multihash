using System;
using System.Composition;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public abstract class BLAKE2B : MultihashAlgorithm
    {
        private readonly Func<IDigest> _factory;

        protected BLAKE2B(int bits) : base(GetHashType(bits), GetName(bits), bits / 8)
        {
            _factory = () => new Blake2bDigest(null, bits / 8, null, null);
        }

        private static HashType GetHashType(int bytes) => (HashType)Enum.Parse(typeof(HashType), $"BLAKE2B_{bytes}");
        private static string GetName(int bytes) => $"blake2b-{bytes}";
        public override byte[] ComputeHash(byte[] data, int length = -1) => _factory().ComputeHash(data);
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_8, "blake2b-8", 8)]
    public class BLAKE2B_8 : BLAKE2B { public BLAKE2B_8() : base(8) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_16, "blake2b-16", 16)]
    public class BLAKE2B_16 : BLAKE2B { public BLAKE2B_16() : base(16) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_24, "blake2b-24", 24)]
    public class BLAKE2B_24 : BLAKE2B { public BLAKE2B_24() : base(24) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_32, "blake2b-32", 32)]
    public class BLAKE2B_32 : BLAKE2B { public BLAKE2B_32() : base(32) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_40, "blake2b-40", 40)]
    public class BLAKE2B_40 : BLAKE2B { public BLAKE2B_40() : base(40) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_48, "blake2b-48", 48)]
    public class BLAKE2B_48 : BLAKE2B { public BLAKE2B_48() : base(48) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_56, "blake2b-56", 56)]
    public class BLAKE2B_56 : BLAKE2B { public BLAKE2B_56() : base(56) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_64, "blake2b-64", 64)]
    public class BLAKE2B_64 : BLAKE2B { public BLAKE2B_64() : base(64) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_72, "blake2b-72", 72)]
    public class BLAKE2B_72 : BLAKE2B { public BLAKE2B_72() : base(72) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_80, "blake2b-80", 80)]
    public class BLAKE2B_80 : BLAKE2B { public BLAKE2B_80() : base(80) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_88, "blake2b-88", 88)]
    public class BLAKE2B_88 : BLAKE2B { public BLAKE2B_88() : base(88) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_96, "blake2b-96", 96)]
    public class BLAKE2B_96 : BLAKE2B { public BLAKE2B_96() : base(96) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_104, "blake2b-104", 104)]
    public class BLAKE2B_104 : BLAKE2B { public BLAKE2B_104() : base(104) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_112, "blake2b-112", 112)]
    public class BLAKE2B_112 : BLAKE2B { public BLAKE2B_112() : base(112) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_120, "blake2b-120", 120)]
    public class BLAKE2B_120 : BLAKE2B { public BLAKE2B_120() : base(120) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_128, "blake2b-128", 128)]
    public class BLAKE2B_128 : BLAKE2B { public BLAKE2B_128() : base(128) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_136, "blake2b-136", 136)]
    public class BLAKE2B_136 : BLAKE2B { public BLAKE2B_136() : base(136) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_144, "blake2b-144", 144)]
    public class BLAKE2B_144 : BLAKE2B { public BLAKE2B_144() : base(144) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_152, "blake2b-152", 152)]
    public class BLAKE2B_152 : BLAKE2B { public BLAKE2B_152() : base(152) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_160, "blake2b-160", 160)]
    public class BLAKE2B_160 : BLAKE2B { public BLAKE2B_160() : base(160) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_168, "blake2b-168", 168)]
    public class BLAKE2B_168 : BLAKE2B { public BLAKE2B_168() : base(168) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_176, "blake2b-176", 176)]
    public class BLAKE2B_176 : BLAKE2B { public BLAKE2B_176() : base(176) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_184, "blake2b-184", 184)]
    public class BLAKE2B_184 : BLAKE2B { public BLAKE2B_184() : base(184) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_192, "blake2b-192", 192)]
    public class BLAKE2B_192 : BLAKE2B { public BLAKE2B_192() : base(192) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_200, "blake2b-200", 200)]
    public class BLAKE2B_200 : BLAKE2B { public BLAKE2B_200() : base(200) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_208, "blake2b-208", 208)]
    public class BLAKE2B_208 : BLAKE2B { public BLAKE2B_208() : base(208) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_216, "blake2b-216", 216)]
    public class BLAKE2B_216 : BLAKE2B { public BLAKE2B_216() : base(216) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_224, "blake2b-224", 224)]
    public class BLAKE2B_224 : BLAKE2B { public BLAKE2B_224() : base(224) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_232, "blake2b-232", 232)]
    public class BLAKE2B_232 : BLAKE2B { public BLAKE2B_232() : base(232) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_240, "blake2b-240", 240)]
    public class BLAKE2B_240 : BLAKE2B { public BLAKE2B_240() : base(240) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_248, "blake2b-248", 248)]
    public class BLAKE2B_248 : BLAKE2B { public BLAKE2B_248() : base(248) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_256, "blake2b-256", 256)]
    public class BLAKE2B_256 : BLAKE2B { public BLAKE2B_256() : base(256) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_264, "blake2b-264", 264)]
    public class BLAKE2B_264 : BLAKE2B { public BLAKE2B_264() : base(264) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_272, "blake2b-272", 272)]
    public class BLAKE2B_272 : BLAKE2B { public BLAKE2B_272() : base(272) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_280, "blake2b-280", 280)]
    public class BLAKE2B_280 : BLAKE2B { public BLAKE2B_280() : base(280) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_288, "blake2b-288", 288)]
    public class BLAKE2B_288 : BLAKE2B { public BLAKE2B_288() : base(288) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_296, "blake2b-296", 296)]
    public class BLAKE2B_296 : BLAKE2B { public BLAKE2B_296() : base(296) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_304, "blake2b-304", 304)]
    public class BLAKE2B_304 : BLAKE2B { public BLAKE2B_304() : base(304) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_312, "blake2b-312", 312)]
    public class BLAKE2B_312 : BLAKE2B { public BLAKE2B_312() : base(312) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_320, "blake2b-320", 320)]
    public class BLAKE2B_320 : BLAKE2B { public BLAKE2B_320() : base(320) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_328, "blake2b-328", 328)]
    public class BLAKE2B_328 : BLAKE2B { public BLAKE2B_328() : base(328) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_336, "blake2b-336", 336)]
    public class BLAKE2B_336 : BLAKE2B { public BLAKE2B_336() : base(336) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_344, "blake2b-344", 344)]
    public class BLAKE2B_344 : BLAKE2B { public BLAKE2B_344() : base(344) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_352, "blake2b-352", 352)]
    public class BLAKE2B_352 : BLAKE2B { public BLAKE2B_352() : base(352) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_360, "blake2b-360", 360)]
    public class BLAKE2B_360 : BLAKE2B { public BLAKE2B_360() : base(360) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_368, "blake2b-368", 368)]
    public class BLAKE2B_368 : BLAKE2B { public BLAKE2B_368() : base(368) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_376, "blake2b-376", 376)]
    public class BLAKE2B_376 : BLAKE2B { public BLAKE2B_376() : base(376) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_384, "blake2b-384", 384)]
    public class BLAKE2B_384 : BLAKE2B { public BLAKE2B_384() : base(384) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_392, "blake2b-392", 392)]
    public class BLAKE2B_392 : BLAKE2B { public BLAKE2B_392() : base(392) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_400, "blake2b-400", 400)]
    public class BLAKE2B_400 : BLAKE2B { public BLAKE2B_400() : base(400) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_408, "blake2b-408", 408)]
    public class BLAKE2B_408 : BLAKE2B { public BLAKE2B_408() : base(408) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_416, "blake2b-416", 416)]
    public class BLAKE2B_416 : BLAKE2B { public BLAKE2B_416() : base(416) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_424, "blake2b-424", 424)]
    public class BLAKE2B_424 : BLAKE2B { public BLAKE2B_424() : base(424) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_432, "blake2b-432", 432)]
    public class BLAKE2B_432 : BLAKE2B { public BLAKE2B_432() : base(432) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_440, "blake2b-440", 440)]
    public class BLAKE2B_440 : BLAKE2B { public BLAKE2B_440() : base(440) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_448, "blake2b-448", 448)]
    public class BLAKE2B_448 : BLAKE2B { public BLAKE2B_448() : base(448) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_456, "blake2b-456", 456)]
    public class BLAKE2B_456 : BLAKE2B { public BLAKE2B_456() : base(456) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_464, "blake2b-464", 464)]
    public class BLAKE2B_464 : BLAKE2B { public BLAKE2B_464() : base(464) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_472, "blake2b-472", 472)]
    public class BLAKE2B_472 : BLAKE2B { public BLAKE2B_472() : base(472) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_480, "blake2b-480", 480)]
    public class BLAKE2B_480 : BLAKE2B { public BLAKE2B_480() : base(480) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_488, "blake2b-488", 488)]
    public class BLAKE2B_488 : BLAKE2B { public BLAKE2B_488() : base(488) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_496, "blake2b-496", 496)]
    public class BLAKE2B_496 : BLAKE2B { public BLAKE2B_496() : base(496) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_504, "blake2b-504", 504)]
    public class BLAKE2B_504 : BLAKE2B { public BLAKE2B_504() : base(504) { } }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.BLAKE2B_512, "blake2b-512", 512)]
    public class BLAKE2B_512 : BLAKE2B { public BLAKE2B_512() : base(512) { } }
}
