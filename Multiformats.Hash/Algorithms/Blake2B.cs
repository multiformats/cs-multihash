using System;
using Blake2Sharp;

namespace Multiformats.Hash.Algorithms
{
    [Obsolete("Use specific bit type instead")]
    public class BLAKE2B : MultihashAlgorithm
    {
        private readonly Hasher _algo;

        public BLAKE2B()
            : base(HashType.BLAKE2B, "blake2b", 64)
        {
            _algo = Blake2B.Create(new Blake2BConfig {OutputSizeInBytes = 64});
            _algo.Init();
        }

        protected BLAKE2B(int bits)
            : base(GetHashType(bits), GetName(bits), bits / 8)
        {
            _algo = Blake2B.Create(new Blake2BConfig { OutputSizeInBytes = bits / 8 });
            _algo.Init();
        }

        private static HashType GetHashType(int bytes) => (HashType) Enum.Parse(typeof(HashType), $"BLAKE2B_{bytes}");
        private static string GetName(int bytes) => $"blake2b-{bytes}";
        public override byte[] ComputeHash(byte[] data) => _algo.AsHashAlgorithm().ComputeHash(data);
    }

    public class BLAKE2B_8 : BLAKE2B { public BLAKE2B_8() : base(8) { } }
    public class BLAKE2B_16 : BLAKE2B { public BLAKE2B_16() : base(16) { } }
    public class BLAKE2B_24 : BLAKE2B { public BLAKE2B_24() : base(24) { } }
    public class BLAKE2B_32 : BLAKE2B { public BLAKE2B_32() : base(32) { } }
    public class BLAKE2B_40 : BLAKE2B { public BLAKE2B_40() : base(40) { } }
    public class BLAKE2B_48 : BLAKE2B { public BLAKE2B_48() : base(48) { } }
    public class BLAKE2B_56 : BLAKE2B { public BLAKE2B_56() : base(56) { } }
    public class BLAKE2B_64 : BLAKE2B { public BLAKE2B_64() : base(64) { } }
    public class BLAKE2B_72 : BLAKE2B { public BLAKE2B_72() : base(72) { } }
    public class BLAKE2B_80 : BLAKE2B { public BLAKE2B_80() : base(80) { } }
    public class BLAKE2B_88 : BLAKE2B { public BLAKE2B_88() : base(88) { } }
    public class BLAKE2B_96 : BLAKE2B { public BLAKE2B_96() : base(96) { } }
    public class BLAKE2B_104 : BLAKE2B { public BLAKE2B_104() : base(104) { } }
    public class BLAKE2B_112 : BLAKE2B { public BLAKE2B_112() : base(112) { } }
    public class BLAKE2B_120 : BLAKE2B { public BLAKE2B_120() : base(120) { } }
    public class BLAKE2B_128 : BLAKE2B { public BLAKE2B_128() : base(128) { } }
    public class BLAKE2B_136 : BLAKE2B { public BLAKE2B_136() : base(136) { } }
    public class BLAKE2B_144 : BLAKE2B { public BLAKE2B_144() : base(144) { } }
    public class BLAKE2B_152 : BLAKE2B { public BLAKE2B_152() : base(152) { } }
    public class BLAKE2B_160 : BLAKE2B { public BLAKE2B_160() : base(160) { } }
    public class BLAKE2B_168 : BLAKE2B { public BLAKE2B_168() : base(168) { } }
    public class BLAKE2B_176 : BLAKE2B { public BLAKE2B_176() : base(176) { } }
    public class BLAKE2B_184 : BLAKE2B { public BLAKE2B_184() : base(184) { } }
    public class BLAKE2B_192 : BLAKE2B { public BLAKE2B_192() : base(192) { } }
    public class BLAKE2B_200 : BLAKE2B { public BLAKE2B_200() : base(200) { } }
    public class BLAKE2B_208 : BLAKE2B { public BLAKE2B_208() : base(208) { } }
    public class BLAKE2B_216 : BLAKE2B { public BLAKE2B_216() : base(216) { } }
    public class BLAKE2B_224 : BLAKE2B { public BLAKE2B_224() : base(224) { } }
    public class BLAKE2B_232 : BLAKE2B { public BLAKE2B_232() : base(232) { } }
    public class BLAKE2B_240 : BLAKE2B { public BLAKE2B_240() : base(240) { } }
    public class BLAKE2B_248 : BLAKE2B { public BLAKE2B_248() : base(248) { } }
    public class BLAKE2B_256 : BLAKE2B { public BLAKE2B_256() : base(256) { } }
    public class BLAKE2B_264 : BLAKE2B { public BLAKE2B_264() : base(264) { } }
    public class BLAKE2B_272 : BLAKE2B { public BLAKE2B_272() : base(272) { } }
    public class BLAKE2B_280 : BLAKE2B { public BLAKE2B_280() : base(280) { } }
    public class BLAKE2B_288 : BLAKE2B { public BLAKE2B_288() : base(288) { } }
    public class BLAKE2B_296 : BLAKE2B { public BLAKE2B_296() : base(296) { } }
    public class BLAKE2B_304 : BLAKE2B { public BLAKE2B_304() : base(304) { } }
    public class BLAKE2B_312 : BLAKE2B { public BLAKE2B_312() : base(312) { } }
    public class BLAKE2B_320 : BLAKE2B { public BLAKE2B_320() : base(320) { } }
    public class BLAKE2B_328 : BLAKE2B { public BLAKE2B_328() : base(328) { } }
    public class BLAKE2B_336 : BLAKE2B { public BLAKE2B_336() : base(336) { } }
    public class BLAKE2B_344 : BLAKE2B { public BLAKE2B_344() : base(344) { } }
    public class BLAKE2B_352 : BLAKE2B { public BLAKE2B_352() : base(352) { } }
    public class BLAKE2B_360 : BLAKE2B { public BLAKE2B_360() : base(360) { } }
    public class BLAKE2B_368 : BLAKE2B { public BLAKE2B_368() : base(368) { } }
    public class BLAKE2B_376 : BLAKE2B { public BLAKE2B_376() : base(376) { } }
    public class BLAKE2B_384 : BLAKE2B { public BLAKE2B_384() : base(384) { } }
    public class BLAKE2B_392 : BLAKE2B { public BLAKE2B_392() : base(392) { } }
    public class BLAKE2B_400 : BLAKE2B { public BLAKE2B_400() : base(400) { } }
    public class BLAKE2B_408 : BLAKE2B { public BLAKE2B_408() : base(408) { } }
    public class BLAKE2B_416 : BLAKE2B { public BLAKE2B_416() : base(416) { } }
    public class BLAKE2B_424 : BLAKE2B { public BLAKE2B_424() : base(424) { } }
    public class BLAKE2B_432 : BLAKE2B { public BLAKE2B_432() : base(432) { } }
    public class BLAKE2B_440 : BLAKE2B { public BLAKE2B_440() : base(440) { } }
    public class BLAKE2B_448 : BLAKE2B { public BLAKE2B_448() : base(448) { } }
    public class BLAKE2B_456 : BLAKE2B { public BLAKE2B_456() : base(456) { } }
    public class BLAKE2B_464 : BLAKE2B { public BLAKE2B_464() : base(464) { } }
    public class BLAKE2B_472 : BLAKE2B { public BLAKE2B_472() : base(472) { } }
    public class BLAKE2B_480 : BLAKE2B { public BLAKE2B_480() : base(480) { } }
    public class BLAKE2B_488 : BLAKE2B { public BLAKE2B_488() : base(488) { } }
    public class BLAKE2B_496 : BLAKE2B { public BLAKE2B_496() : base(496) { } }
    public class BLAKE2B_504 : BLAKE2B { public BLAKE2B_504() : base(504) { } }
    public class BLAKE2B_512 : BLAKE2B { public BLAKE2B_512() : base(512) { } }
}
