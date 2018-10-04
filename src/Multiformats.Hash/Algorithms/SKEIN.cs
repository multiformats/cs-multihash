using System;
using System.Composition;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Multiformats.Hash.Algorithms
{
    public abstract class SKEIN : MultihashAlgorithm
    {
        private readonly Func<IDigest> _factory;

        protected SKEIN(HashType code, string name, int defaultLength, Func<IDigest> factory)
            : base(code, name, defaultLength)
        {
            _factory = factory;
        }

        public override byte[] ComputeHash(byte[] data, int length = -1) => _factory().ComputeHash(data);
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_8, "skein256-8", 8)]
    public class SKEIN256_8 : SKEIN
    {
        public SKEIN256_8()
			: base(HashType.SKEIN256_8, "skein256-8", 8, () => new SkeinDigest(256, 8))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_16, "skein256-16", 16)]
    public class SKEIN256_16 : SKEIN
    {
        public SKEIN256_16()
			: base(HashType.SKEIN256_16, "skein256-16", 16, () => new SkeinDigest(256, 16))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_24, "skein256-24", 24)]
    public class SKEIN256_24 : SKEIN
    {
        public SKEIN256_24()
			: base(HashType.SKEIN256_24, "skein256-24", 24, () => new SkeinDigest(256, 24))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_32, "skein256-32", 32)]
    public class SKEIN256_32 : SKEIN
    {
        public SKEIN256_32()
			: base(HashType.SKEIN256_32, "skein256-32", 32, () => new SkeinDigest(256, 32))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_40, "skein256-40", 40)]
    public class SKEIN256_40 : SKEIN
    {
        public SKEIN256_40()
			: base(HashType.SKEIN256_40, "skein256-40", 40, () => new SkeinDigest(256, 40))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_48, "skein256-48", 48)]
    public class SKEIN256_48 : SKEIN
    {
        public SKEIN256_48()
			: base(HashType.SKEIN256_48, "skein256-48", 48, () => new SkeinDigest(256, 48))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_56, "skein256-56", 56)]
    public class SKEIN256_56 : SKEIN
    {
        public SKEIN256_56()
			: base(HashType.SKEIN256_56, "skein256-56", 56, () => new SkeinDigest(256, 56))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_64, "skein256-64", 64)]
    public class SKEIN256_64 : SKEIN
    {
        public SKEIN256_64()
			: base(HashType.SKEIN256_64, "skein256-64", 64, () => new SkeinDigest(256, 64))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_72, "skein256-72", 72)]
    public class SKEIN256_72 : SKEIN
    {
        public SKEIN256_72()
			: base(HashType.SKEIN256_72, "skein256-72", 72, () => new SkeinDigest(256, 72))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_80, "skein256-80", 80)]
    public class SKEIN256_80 : SKEIN
    {
        public SKEIN256_80()
			: base(HashType.SKEIN256_80, "skein256-80", 80, () => new SkeinDigest(256, 80))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_88, "skein256-88", 88)]
    public class SKEIN256_88 : SKEIN
    {
        public SKEIN256_88()
			: base(HashType.SKEIN256_88, "skein256-88", 88, () => new SkeinDigest(256, 88))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_96, "skein256-96", 96)]
    public class SKEIN256_96 : SKEIN
    {
        public SKEIN256_96()
			: base(HashType.SKEIN256_96, "skein256-96", 96, () => new SkeinDigest(256, 96))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_104, "skein256-104", 104)]
    public class SKEIN256_104 : SKEIN
    {
        public SKEIN256_104()
			: base(HashType.SKEIN256_104, "skein256-104", 104, () => new SkeinDigest(256, 104))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_112, "skein256-112", 112)]
    public class SKEIN256_112 : SKEIN
    {
        public SKEIN256_112()
			: base(HashType.SKEIN256_112, "skein256-112", 112, () => new SkeinDigest(256, 112))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_120, "skein256-120", 120)]
    public class SKEIN256_120 : SKEIN
    {
        public SKEIN256_120()
			: base(HashType.SKEIN256_120, "skein256-120", 120, () => new SkeinDigest(256, 120))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_128, "skein256-128", 128)]
    public class SKEIN256_128 : SKEIN
    {
        public SKEIN256_128()
			: base(HashType.SKEIN256_128, "skein256-128", 128, () => new SkeinDigest(256, 128))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_136, "skein256-136", 136)]
    public class SKEIN256_136 : SKEIN
    {
        public SKEIN256_136()
			: base(HashType.SKEIN256_136, "skein256-136", 136, () => new SkeinDigest(256, 136))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_144, "skein256-144", 144)]
    public class SKEIN256_144 : SKEIN
    {
        public SKEIN256_144()
			: base(HashType.SKEIN256_144, "skein256-144", 144, () => new SkeinDigest(256, 144))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_152, "skein256-152", 152)]
    public class SKEIN256_152 : SKEIN
    {
        public SKEIN256_152()
			: base(HashType.SKEIN256_152, "skein256-152", 152, () => new SkeinDigest(256, 152))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_160, "skein256-160", 160)]
    public class SKEIN256_160 : SKEIN
    {
        public SKEIN256_160()
			: base(HashType.SKEIN256_160, "skein256-160", 160, () => new SkeinDigest(256, 160))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_168, "skein256-168", 168)]
    public class SKEIN256_168 : SKEIN
    {
        public SKEIN256_168()
			: base(HashType.SKEIN256_168, "skein256-168", 168, () => new SkeinDigest(256, 168))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_176, "skein256-176", 176)]
    public class SKEIN256_176 : SKEIN
    {
        public SKEIN256_176()
			: base(HashType.SKEIN256_176, "skein256-176", 176, () => new SkeinDigest(256, 176))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_184, "skein256-184", 184)]
    public class SKEIN256_184 : SKEIN
    {
        public SKEIN256_184()
			: base(HashType.SKEIN256_184, "skein256-184", 184, () => new SkeinDigest(256, 184))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_192, "skein256-192", 192)]
    public class SKEIN256_192 : SKEIN
    {
        public SKEIN256_192()
			: base(HashType.SKEIN256_192, "skein256-192", 192, () => new SkeinDigest(256, 192))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_200, "skein256-200", 200)]
    public class SKEIN256_200 : SKEIN
    {
        public SKEIN256_200()
			: base(HashType.SKEIN256_200, "skein256-200", 200, () => new SkeinDigest(256, 200))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_208, "skein256-208", 208)]
    public class SKEIN256_208 : SKEIN
    {
        public SKEIN256_208()
			: base(HashType.SKEIN256_208, "skein256-208", 208, () => new SkeinDigest(256, 208))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_216, "skein256-216", 216)]
    public class SKEIN256_216 : SKEIN
    {
        public SKEIN256_216()
			: base(HashType.SKEIN256_216, "skein256-216", 216, () => new SkeinDigest(256, 216))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_224, "skein256-224", 224)]
    public class SKEIN256_224 : SKEIN
    {
        public SKEIN256_224()
			: base(HashType.SKEIN256_224, "skein256-224", 224, () => new SkeinDigest(256, 224))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_232, "skein256-232", 232)]
    public class SKEIN256_232 : SKEIN
    {
        public SKEIN256_232()
			: base(HashType.SKEIN256_232, "skein256-232", 232, () => new SkeinDigest(256, 232))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_240, "skein256-240", 240)]
    public class SKEIN256_240 : SKEIN
    {
        public SKEIN256_240()
			: base(HashType.SKEIN256_240, "skein256-240", 240, () => new SkeinDigest(256, 240))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_248, "skein256-248", 248)]
    public class SKEIN256_248 : SKEIN
    {
        public SKEIN256_248()
			: base(HashType.SKEIN256_248, "skein256-248", 248, () => new SkeinDigest(256, 248))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN256_256, "skein256-256", 256)]
    public class SKEIN256_256 : SKEIN
    {
        public SKEIN256_256()
			: base(HashType.SKEIN256_256, "skein256-256", 256, () => new SkeinDigest(256, 256))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_8, "skein512-8", 8)]
    public class SKEIN512_8 : SKEIN
    {
        public SKEIN512_8()
			: base(HashType.SKEIN512_8, "skein512-8", 8, () => new SkeinDigest(512, 8))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_16, "skein512-16", 16)]
    public class SKEIN512_16 : SKEIN
    {
        public SKEIN512_16()
			: base(HashType.SKEIN512_16, "skein512-16", 16, () => new SkeinDigest(512, 16))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_24, "skein512-24", 24)]
    public class SKEIN512_24 : SKEIN
    {
        public SKEIN512_24()
			: base(HashType.SKEIN512_24, "skein512-24", 24, () => new SkeinDigest(512, 24))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_32, "skein512-32", 32)]
    public class SKEIN512_32 : SKEIN
    {
        public SKEIN512_32()
			: base(HashType.SKEIN512_32, "skein512-32", 32, () => new SkeinDigest(512, 32))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_40, "skein512-40", 40)]
    public class SKEIN512_40 : SKEIN
    {
        public SKEIN512_40()
			: base(HashType.SKEIN512_40, "skein512-40", 40, () => new SkeinDigest(512, 40))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_48, "skein512-48", 48)]
    public class SKEIN512_48 : SKEIN
    {
        public SKEIN512_48()
			: base(HashType.SKEIN512_48, "skein512-48", 48, () => new SkeinDigest(512, 48))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_56, "skein512-56", 56)]
    public class SKEIN512_56 : SKEIN
    {
        public SKEIN512_56()
			: base(HashType.SKEIN512_56, "skein512-56", 56, () => new SkeinDigest(512, 56))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_64, "skein512-64", 64)]
    public class SKEIN512_64 : SKEIN
    {
        public SKEIN512_64()
			: base(HashType.SKEIN512_64, "skein512-64", 64, () => new SkeinDigest(512, 64))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_72, "skein512-72", 72)]
    public class SKEIN512_72 : SKEIN
    {
        public SKEIN512_72()
			: base(HashType.SKEIN512_72, "skein512-72", 72, () => new SkeinDigest(512, 72))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_80, "skein512-80", 80)]
    public class SKEIN512_80 : SKEIN
    {
        public SKEIN512_80()
			: base(HashType.SKEIN512_80, "skein512-80", 80, () => new SkeinDigest(512, 80))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_88, "skein512-88", 88)]
    public class SKEIN512_88 : SKEIN
    {
        public SKEIN512_88()
			: base(HashType.SKEIN512_88, "skein512-88", 88, () => new SkeinDigest(512, 88))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_96, "skein512-96", 96)]
    public class SKEIN512_96 : SKEIN
    {
        public SKEIN512_96()
			: base(HashType.SKEIN512_96, "skein512-96", 96, () => new SkeinDigest(512, 96))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_104, "skein512-104", 104)]
    public class SKEIN512_104 : SKEIN
    {
        public SKEIN512_104()
			: base(HashType.SKEIN512_104, "skein512-104", 104, () => new SkeinDigest(512, 104))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_112, "skein512-112", 112)]
    public class SKEIN512_112 : SKEIN
    {
        public SKEIN512_112()
			: base(HashType.SKEIN512_112, "skein512-112", 112, () => new SkeinDigest(512, 112))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_120, "skein512-120", 120)]
    public class SKEIN512_120 : SKEIN
    {
        public SKEIN512_120()
			: base(HashType.SKEIN512_120, "skein512-120", 120, () => new SkeinDigest(512, 120))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_128, "skein512-128", 128)]
    public class SKEIN512_128 : SKEIN
    {
        public SKEIN512_128()
			: base(HashType.SKEIN512_128, "skein512-128", 128, () => new SkeinDigest(512, 128))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_136, "skein512-136", 136)]
    public class SKEIN512_136 : SKEIN
    {
        public SKEIN512_136()
			: base(HashType.SKEIN512_136, "skein512-136", 136, () => new SkeinDigest(512, 136))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_144, "skein512-144", 144)]
    public class SKEIN512_144 : SKEIN
    {
        public SKEIN512_144()
			: base(HashType.SKEIN512_144, "skein512-144", 144, () => new SkeinDigest(512, 144))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_152, "skein512-152", 152)]
    public class SKEIN512_152 : SKEIN
    {
        public SKEIN512_152()
			: base(HashType.SKEIN512_152, "skein512-152", 152, () => new SkeinDigest(512, 152))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_160, "skein512-160", 160)]
    public class SKEIN512_160 : SKEIN
    {
        public SKEIN512_160()
			: base(HashType.SKEIN512_160, "skein512-160", 160, () => new SkeinDigest(512, 160))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_168, "skein512-168", 168)]
    public class SKEIN512_168 : SKEIN
    {
        public SKEIN512_168()
			: base(HashType.SKEIN512_168, "skein512-168", 168, () => new SkeinDigest(512, 168))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_176, "skein512-176", 176)]
    public class SKEIN512_176 : SKEIN
    {
        public SKEIN512_176()
			: base(HashType.SKEIN512_176, "skein512-176", 176, () => new SkeinDigest(512, 176))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_184, "skein512-184", 184)]
    public class SKEIN512_184 : SKEIN
    {
        public SKEIN512_184()
			: base(HashType.SKEIN512_184, "skein512-184", 184, () => new SkeinDigest(512, 184))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_192, "skein512-192", 192)]
    public class SKEIN512_192 : SKEIN
    {
        public SKEIN512_192()
			: base(HashType.SKEIN512_192, "skein512-192", 192, () => new SkeinDigest(512, 192))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_200, "skein512-200", 200)]
    public class SKEIN512_200 : SKEIN
    {
        public SKEIN512_200()
			: base(HashType.SKEIN512_200, "skein512-200", 200, () => new SkeinDigest(512, 200))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_208, "skein512-208", 208)]
    public class SKEIN512_208 : SKEIN
    {
        public SKEIN512_208()
			: base(HashType.SKEIN512_208, "skein512-208", 208, () => new SkeinDigest(512, 208))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_216, "skein512-216", 216)]
    public class SKEIN512_216 : SKEIN
    {
        public SKEIN512_216()
			: base(HashType.SKEIN512_216, "skein512-216", 216, () => new SkeinDigest(512, 216))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_224, "skein512-224", 224)]
    public class SKEIN512_224 : SKEIN
    {
        public SKEIN512_224()
			: base(HashType.SKEIN512_224, "skein512-224", 224, () => new SkeinDigest(512, 224))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_232, "skein512-232", 232)]
    public class SKEIN512_232 : SKEIN
    {
        public SKEIN512_232()
			: base(HashType.SKEIN512_232, "skein512-232", 232, () => new SkeinDigest(512, 232))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_240, "skein512-240", 240)]
    public class SKEIN512_240 : SKEIN
    {
        public SKEIN512_240()
			: base(HashType.SKEIN512_240, "skein512-240", 240, () => new SkeinDigest(512, 240))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_248, "skein512-248", 248)]
    public class SKEIN512_248 : SKEIN
    {
        public SKEIN512_248()
			: base(HashType.SKEIN512_248, "skein512-248", 248, () => new SkeinDigest(512, 248))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_256, "skein512-256", 256)]
    public class SKEIN512_256 : SKEIN
    {
        public SKEIN512_256()
			: base(HashType.SKEIN512_256, "skein512-256", 256, () => new SkeinDigest(512, 256))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_264, "skein512-264", 264)]
    public class SKEIN512_264 : SKEIN
    {
        public SKEIN512_264()
			: base(HashType.SKEIN512_264, "skein512-264", 264, () => new SkeinDigest(512, 264))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_272, "skein512-272", 272)]
    public class SKEIN512_272 : SKEIN
    {
        public SKEIN512_272()
			: base(HashType.SKEIN512_272, "skein512-272", 272, () => new SkeinDigest(512, 272))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_280, "skein512-280", 280)]
    public class SKEIN512_280 : SKEIN
    {
        public SKEIN512_280()
			: base(HashType.SKEIN512_280, "skein512-280", 280, () => new SkeinDigest(512, 280))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_288, "skein512-288", 288)]
    public class SKEIN512_288 : SKEIN
    {
        public SKEIN512_288()
			: base(HashType.SKEIN512_288, "skein512-288", 288, () => new SkeinDigest(512, 288))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_296, "skein512-296", 296)]
    public class SKEIN512_296 : SKEIN
    {
        public SKEIN512_296()
			: base(HashType.SKEIN512_296, "skein512-296", 296, () => new SkeinDigest(512, 296))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_304, "skein512-304", 304)]
    public class SKEIN512_304 : SKEIN
    {
        public SKEIN512_304()
			: base(HashType.SKEIN512_304, "skein512-304", 304, () => new SkeinDigest(512, 304))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_312, "skein512-312", 312)]
    public class SKEIN512_312 : SKEIN
    {
        public SKEIN512_312()
			: base(HashType.SKEIN512_312, "skein512-312", 312, () => new SkeinDigest(512, 312))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_320, "skein512-320", 320)]
    public class SKEIN512_320 : SKEIN
    {
        public SKEIN512_320()
			: base(HashType.SKEIN512_320, "skein512-320", 320, () => new SkeinDigest(512, 320))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_328, "skein512-328", 328)]
    public class SKEIN512_328 : SKEIN
    {
        public SKEIN512_328()
			: base(HashType.SKEIN512_328, "skein512-328", 328, () => new SkeinDigest(512, 328))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_336, "skein512-336", 336)]
    public class SKEIN512_336 : SKEIN
    {
        public SKEIN512_336()
			: base(HashType.SKEIN512_336, "skein512-336", 336, () => new SkeinDigest(512, 336))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_344, "skein512-344", 344)]
    public class SKEIN512_344 : SKEIN
    {
        public SKEIN512_344()
			: base(HashType.SKEIN512_344, "skein512-344", 344, () => new SkeinDigest(512, 344))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_352, "skein512-352", 352)]
    public class SKEIN512_352 : SKEIN
    {
        public SKEIN512_352()
			: base(HashType.SKEIN512_352, "skein512-352", 352, () => new SkeinDigest(512, 352))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_360, "skein512-360", 360)]
    public class SKEIN512_360 : SKEIN
    {
        public SKEIN512_360()
			: base(HashType.SKEIN512_360, "skein512-360", 360, () => new SkeinDigest(512, 360))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_368, "skein512-368", 368)]
    public class SKEIN512_368 : SKEIN
    {
        public SKEIN512_368()
			: base(HashType.SKEIN512_368, "skein512-368", 368, () => new SkeinDigest(512, 368))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_376, "skein512-376", 376)]
    public class SKEIN512_376 : SKEIN
    {
        public SKEIN512_376()
			: base(HashType.SKEIN512_376, "skein512-376", 376, () => new SkeinDigest(512, 376))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_384, "skein512-384", 384)]
    public class SKEIN512_384 : SKEIN
    {
        public SKEIN512_384()
			: base(HashType.SKEIN512_384, "skein512-384", 384, () => new SkeinDigest(512, 384))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_392, "skein512-392", 392)]
    public class SKEIN512_392 : SKEIN
    {
        public SKEIN512_392()
			: base(HashType.SKEIN512_392, "skein512-392", 392, () => new SkeinDigest(512, 392))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_400, "skein512-400", 400)]
    public class SKEIN512_400 : SKEIN
    {
        public SKEIN512_400()
			: base(HashType.SKEIN512_400, "skein512-400", 400, () => new SkeinDigest(512, 400))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_408, "skein512-408", 408)]
    public class SKEIN512_408 : SKEIN
    {
        public SKEIN512_408()
			: base(HashType.SKEIN512_408, "skein512-408", 408, () => new SkeinDigest(512, 408))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_416, "skein512-416", 416)]
    public class SKEIN512_416 : SKEIN
    {
        public SKEIN512_416()
			: base(HashType.SKEIN512_416, "skein512-416", 416, () => new SkeinDigest(512, 416))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_424, "skein512-424", 424)]
    public class SKEIN512_424 : SKEIN
    {
        public SKEIN512_424()
			: base(HashType.SKEIN512_424, "skein512-424", 424, () => new SkeinDigest(512, 424))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_432, "skein512-432", 432)]
    public class SKEIN512_432 : SKEIN
    {
        public SKEIN512_432()
			: base(HashType.SKEIN512_432, "skein512-432", 432, () => new SkeinDigest(512, 432))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_440, "skein512-440", 440)]
    public class SKEIN512_440 : SKEIN
    {
        public SKEIN512_440()
			: base(HashType.SKEIN512_440, "skein512-440", 440, () => new SkeinDigest(512, 440))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_448, "skein512-448", 448)]
    public class SKEIN512_448 : SKEIN
    {
        public SKEIN512_448()
			: base(HashType.SKEIN512_448, "skein512-448", 448, () => new SkeinDigest(512, 448))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_456, "skein512-456", 456)]
    public class SKEIN512_456 : SKEIN
    {
        public SKEIN512_456()
			: base(HashType.SKEIN512_456, "skein512-456", 456, () => new SkeinDigest(512, 456))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_464, "skein512-464", 464)]
    public class SKEIN512_464 : SKEIN
    {
        public SKEIN512_464()
			: base(HashType.SKEIN512_464, "skein512-464", 464, () => new SkeinDigest(512, 464))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_472, "skein512-472", 472)]
    public class SKEIN512_472 : SKEIN
    {
        public SKEIN512_472()
			: base(HashType.SKEIN512_472, "skein512-472", 472, () => new SkeinDigest(512, 472))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_480, "skein512-480", 480)]
    public class SKEIN512_480 : SKEIN
    {
        public SKEIN512_480()
			: base(HashType.SKEIN512_480, "skein512-480", 480, () => new SkeinDigest(512, 480))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_488, "skein512-488", 488)]
    public class SKEIN512_488 : SKEIN
    {
        public SKEIN512_488()
			: base(HashType.SKEIN512_488, "skein512-488", 488, () => new SkeinDigest(512, 488))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_496, "skein512-496", 496)]
    public class SKEIN512_496 : SKEIN
    {
        public SKEIN512_496()
			: base(HashType.SKEIN512_496, "skein512-496", 496, () => new SkeinDigest(512, 496))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_504, "skein512-504", 504)]
    public class SKEIN512_504 : SKEIN
    {
        public SKEIN512_504()
			: base(HashType.SKEIN512_504, "skein512-504", 504, () => new SkeinDigest(512, 504))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN512_512, "skein512-512", 512)]
    public class SKEIN512_512 : SKEIN
    {
        public SKEIN512_512()
			: base(HashType.SKEIN512_512, "skein512-512", 512, () => new SkeinDigest(512, 512))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_8, "skein1024-8", 8)]
    public class SKEIN1024_8 : SKEIN
    {
        public SKEIN1024_8()
			: base(HashType.SKEIN1024_8, "skein1024-8", 8, () => new SkeinDigest(1024, 8))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_16, "skein1024-16", 16)]
    public class SKEIN1024_16 : SKEIN
    {
        public SKEIN1024_16()
			: base(HashType.SKEIN1024_16, "skein1024-16", 16, () => new SkeinDigest(1024, 16))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_24, "skein1024-24", 24)]
    public class SKEIN1024_24 : SKEIN
    {
        public SKEIN1024_24()
			: base(HashType.SKEIN1024_24, "skein1024-24", 24, () => new SkeinDigest(1024, 24))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_32, "skein1024-32", 32)]
    public class SKEIN1024_32 : SKEIN
    {
        public SKEIN1024_32()
			: base(HashType.SKEIN1024_32, "skein1024-32", 32, () => new SkeinDigest(1024, 32))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_40, "skein1024-40", 40)]
    public class SKEIN1024_40 : SKEIN
    {
        public SKEIN1024_40()
			: base(HashType.SKEIN1024_40, "skein1024-40", 40, () => new SkeinDigest(1024, 40))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_48, "skein1024-48", 48)]
    public class SKEIN1024_48 : SKEIN
    {
        public SKEIN1024_48()
			: base(HashType.SKEIN1024_48, "skein1024-48", 48, () => new SkeinDigest(1024, 48))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_56, "skein1024-56", 56)]
    public class SKEIN1024_56 : SKEIN
    {
        public SKEIN1024_56()
			: base(HashType.SKEIN1024_56, "skein1024-56", 56, () => new SkeinDigest(1024, 56))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_64, "skein1024-64", 64)]
    public class SKEIN1024_64 : SKEIN
    {
        public SKEIN1024_64()
			: base(HashType.SKEIN1024_64, "skein1024-64", 64, () => new SkeinDigest(1024, 64))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_72, "skein1024-72", 72)]
    public class SKEIN1024_72 : SKEIN
    {
        public SKEIN1024_72()
			: base(HashType.SKEIN1024_72, "skein1024-72", 72, () => new SkeinDigest(1024, 72))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_80, "skein1024-80", 80)]
    public class SKEIN1024_80 : SKEIN
    {
        public SKEIN1024_80()
			: base(HashType.SKEIN1024_80, "skein1024-80", 80, () => new SkeinDigest(1024, 80))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_88, "skein1024-88", 88)]
    public class SKEIN1024_88 : SKEIN
    {
        public SKEIN1024_88()
			: base(HashType.SKEIN1024_88, "skein1024-88", 88, () => new SkeinDigest(1024, 88))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_96, "skein1024-96", 96)]
    public class SKEIN1024_96 : SKEIN
    {
        public SKEIN1024_96()
			: base(HashType.SKEIN1024_96, "skein1024-96", 96, () => new SkeinDigest(1024, 96))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_104, "skein1024-104", 104)]
    public class SKEIN1024_104 : SKEIN
    {
        public SKEIN1024_104()
			: base(HashType.SKEIN1024_104, "skein1024-104", 104, () => new SkeinDigest(1024, 104))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_112, "skein1024-112", 112)]
    public class SKEIN1024_112 : SKEIN
    {
        public SKEIN1024_112()
			: base(HashType.SKEIN1024_112, "skein1024-112", 112, () => new SkeinDigest(1024, 112))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_120, "skein1024-120", 120)]
    public class SKEIN1024_120 : SKEIN
    {
        public SKEIN1024_120()
			: base(HashType.SKEIN1024_120, "skein1024-120", 120, () => new SkeinDigest(1024, 120))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_128, "skein1024-128", 128)]
    public class SKEIN1024_128 : SKEIN
    {
        public SKEIN1024_128()
			: base(HashType.SKEIN1024_128, "skein1024-128", 128, () => new SkeinDigest(1024, 128))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_136, "skein1024-136", 136)]
    public class SKEIN1024_136 : SKEIN
    {
        public SKEIN1024_136()
			: base(HashType.SKEIN1024_136, "skein1024-136", 136, () => new SkeinDigest(1024, 136))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_144, "skein1024-144", 144)]
    public class SKEIN1024_144 : SKEIN
    {
        public SKEIN1024_144()
			: base(HashType.SKEIN1024_144, "skein1024-144", 144, () => new SkeinDigest(1024, 144))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_152, "skein1024-152", 152)]
    public class SKEIN1024_152 : SKEIN
    {
        public SKEIN1024_152()
			: base(HashType.SKEIN1024_152, "skein1024-152", 152, () => new SkeinDigest(1024, 152))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_160, "skein1024-160", 160)]
    public class SKEIN1024_160 : SKEIN
    {
        public SKEIN1024_160()
			: base(HashType.SKEIN1024_160, "skein1024-160", 160, () => new SkeinDigest(1024, 160))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_168, "skein1024-168", 168)]
    public class SKEIN1024_168 : SKEIN
    {
        public SKEIN1024_168()
			: base(HashType.SKEIN1024_168, "skein1024-168", 168, () => new SkeinDigest(1024, 168))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_176, "skein1024-176", 176)]
    public class SKEIN1024_176 : SKEIN
    {
        public SKEIN1024_176()
			: base(HashType.SKEIN1024_176, "skein1024-176", 176, () => new SkeinDigest(1024, 176))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_184, "skein1024-184", 184)]
    public class SKEIN1024_184 : SKEIN
    {
        public SKEIN1024_184()
			: base(HashType.SKEIN1024_184, "skein1024-184", 184, () => new SkeinDigest(1024, 184))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_192, "skein1024-192", 192)]
    public class SKEIN1024_192 : SKEIN
    {
        public SKEIN1024_192()
			: base(HashType.SKEIN1024_192, "skein1024-192", 192, () => new SkeinDigest(1024, 192))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_200, "skein1024-200", 200)]
    public class SKEIN1024_200 : SKEIN
    {
        public SKEIN1024_200()
			: base(HashType.SKEIN1024_200, "skein1024-200", 200, () => new SkeinDigest(1024, 200))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_208, "skein1024-208", 208)]
    public class SKEIN1024_208 : SKEIN
    {
        public SKEIN1024_208()
			: base(HashType.SKEIN1024_208, "skein1024-208", 208, () => new SkeinDigest(1024, 208))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_216, "skein1024-216", 216)]
    public class SKEIN1024_216 : SKEIN
    {
        public SKEIN1024_216()
			: base(HashType.SKEIN1024_216, "skein1024-216", 216, () => new SkeinDigest(1024, 216))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_224, "skein1024-224", 224)]
    public class SKEIN1024_224 : SKEIN
    {
        public SKEIN1024_224()
			: base(HashType.SKEIN1024_224, "skein1024-224", 224, () => new SkeinDigest(1024, 224))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_232, "skein1024-232", 232)]
    public class SKEIN1024_232 : SKEIN
    {
        public SKEIN1024_232()
			: base(HashType.SKEIN1024_232, "skein1024-232", 232, () => new SkeinDigest(1024, 232))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_240, "skein1024-240", 240)]
    public class SKEIN1024_240 : SKEIN
    {
        public SKEIN1024_240()
			: base(HashType.SKEIN1024_240, "skein1024-240", 240, () => new SkeinDigest(1024, 240))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_248, "skein1024-248", 248)]
    public class SKEIN1024_248 : SKEIN
    {
        public SKEIN1024_248()
			: base(HashType.SKEIN1024_248, "skein1024-248", 248, () => new SkeinDigest(1024, 248))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_256, "skein1024-256", 256)]
    public class SKEIN1024_256 : SKEIN
    {
        public SKEIN1024_256()
			: base(HashType.SKEIN1024_256, "skein1024-256", 256, () => new SkeinDigest(1024, 256))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_264, "skein1024-264", 264)]
    public class SKEIN1024_264 : SKEIN
    {
        public SKEIN1024_264()
			: base(HashType.SKEIN1024_264, "skein1024-264", 264, () => new SkeinDigest(1024, 264))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_272, "skein1024-272", 272)]
    public class SKEIN1024_272 : SKEIN
    {
        public SKEIN1024_272()
			: base(HashType.SKEIN1024_272, "skein1024-272", 272, () => new SkeinDigest(1024, 272))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_280, "skein1024-280", 280)]
    public class SKEIN1024_280 : SKEIN
    {
        public SKEIN1024_280()
			: base(HashType.SKEIN1024_280, "skein1024-280", 280, () => new SkeinDigest(1024, 280))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_288, "skein1024-288", 288)]
    public class SKEIN1024_288 : SKEIN
    {
        public SKEIN1024_288()
			: base(HashType.SKEIN1024_288, "skein1024-288", 288, () => new SkeinDigest(1024, 288))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_296, "skein1024-296", 296)]
    public class SKEIN1024_296 : SKEIN
    {
        public SKEIN1024_296()
			: base(HashType.SKEIN1024_296, "skein1024-296", 296, () => new SkeinDigest(1024, 296))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_304, "skein1024-304", 304)]
    public class SKEIN1024_304 : SKEIN
    {
        public SKEIN1024_304()
			: base(HashType.SKEIN1024_304, "skein1024-304", 304, () => new SkeinDigest(1024, 304))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_312, "skein1024-312", 312)]
    public class SKEIN1024_312 : SKEIN
    {
        public SKEIN1024_312()
			: base(HashType.SKEIN1024_312, "skein1024-312", 312, () => new SkeinDigest(1024, 312))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_320, "skein1024-320", 320)]
    public class SKEIN1024_320 : SKEIN
    {
        public SKEIN1024_320()
			: base(HashType.SKEIN1024_320, "skein1024-320", 320, () => new SkeinDigest(1024, 320))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_328, "skein1024-328", 328)]
    public class SKEIN1024_328 : SKEIN
    {
        public SKEIN1024_328()
			: base(HashType.SKEIN1024_328, "skein1024-328", 328, () => new SkeinDigest(1024, 328))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_336, "skein1024-336", 336)]
    public class SKEIN1024_336 : SKEIN
    {
        public SKEIN1024_336()
			: base(HashType.SKEIN1024_336, "skein1024-336", 336, () => new SkeinDigest(1024, 336))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_344, "skein1024-344", 344)]
    public class SKEIN1024_344 : SKEIN
    {
        public SKEIN1024_344()
			: base(HashType.SKEIN1024_344, "skein1024-344", 344, () => new SkeinDigest(1024, 344))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_352, "skein1024-352", 352)]
    public class SKEIN1024_352 : SKEIN
    {
        public SKEIN1024_352()
			: base(HashType.SKEIN1024_352, "skein1024-352", 352, () => new SkeinDigest(1024, 352))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_360, "skein1024-360", 360)]
    public class SKEIN1024_360 : SKEIN
    {
        public SKEIN1024_360()
			: base(HashType.SKEIN1024_360, "skein1024-360", 360, () => new SkeinDigest(1024, 360))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_368, "skein1024-368", 368)]
    public class SKEIN1024_368 : SKEIN
    {
        public SKEIN1024_368()
			: base(HashType.SKEIN1024_368, "skein1024-368", 368, () => new SkeinDigest(1024, 368))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_376, "skein1024-376", 376)]
    public class SKEIN1024_376 : SKEIN
    {
        public SKEIN1024_376()
			: base(HashType.SKEIN1024_376, "skein1024-376", 376, () => new SkeinDigest(1024, 376))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_384, "skein1024-384", 384)]
    public class SKEIN1024_384 : SKEIN
    {
        public SKEIN1024_384()
			: base(HashType.SKEIN1024_384, "skein1024-384", 384, () => new SkeinDigest(1024, 384))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_392, "skein1024-392", 392)]
    public class SKEIN1024_392 : SKEIN
    {
        public SKEIN1024_392()
			: base(HashType.SKEIN1024_392, "skein1024-392", 392, () => new SkeinDigest(1024, 392))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_400, "skein1024-400", 400)]
    public class SKEIN1024_400 : SKEIN
    {
        public SKEIN1024_400()
			: base(HashType.SKEIN1024_400, "skein1024-400", 400, () => new SkeinDigest(1024, 400))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_408, "skein1024-408", 408)]
    public class SKEIN1024_408 : SKEIN
    {
        public SKEIN1024_408()
			: base(HashType.SKEIN1024_408, "skein1024-408", 408, () => new SkeinDigest(1024, 408))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_416, "skein1024-416", 416)]
    public class SKEIN1024_416 : SKEIN
    {
        public SKEIN1024_416()
			: base(HashType.SKEIN1024_416, "skein1024-416", 416, () => new SkeinDigest(1024, 416))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_424, "skein1024-424", 424)]
    public class SKEIN1024_424 : SKEIN
    {
        public SKEIN1024_424()
			: base(HashType.SKEIN1024_424, "skein1024-424", 424, () => new SkeinDigest(1024, 424))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_432, "skein1024-432", 432)]
    public class SKEIN1024_432 : SKEIN
    {
        public SKEIN1024_432()
			: base(HashType.SKEIN1024_432, "skein1024-432", 432, () => new SkeinDigest(1024, 432))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_440, "skein1024-440", 440)]
    public class SKEIN1024_440 : SKEIN
    {
        public SKEIN1024_440()
			: base(HashType.SKEIN1024_440, "skein1024-440", 440, () => new SkeinDigest(1024, 440))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_448, "skein1024-448", 448)]
    public class SKEIN1024_448 : SKEIN
    {
        public SKEIN1024_448()
			: base(HashType.SKEIN1024_448, "skein1024-448", 448, () => new SkeinDigest(1024, 448))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_456, "skein1024-456", 456)]
    public class SKEIN1024_456 : SKEIN
    {
        public SKEIN1024_456()
			: base(HashType.SKEIN1024_456, "skein1024-456", 456, () => new SkeinDigest(1024, 456))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_464, "skein1024-464", 464)]
    public class SKEIN1024_464 : SKEIN
    {
        public SKEIN1024_464()
			: base(HashType.SKEIN1024_464, "skein1024-464", 464, () => new SkeinDigest(1024, 464))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_472, "skein1024-472", 472)]
    public class SKEIN1024_472 : SKEIN
    {
        public SKEIN1024_472()
			: base(HashType.SKEIN1024_472, "skein1024-472", 472, () => new SkeinDigest(1024, 472))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_480, "skein1024-480", 480)]
    public class SKEIN1024_480 : SKEIN
    {
        public SKEIN1024_480()
			: base(HashType.SKEIN1024_480, "skein1024-480", 480, () => new SkeinDigest(1024, 480))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_488, "skein1024-488", 488)]
    public class SKEIN1024_488 : SKEIN
    {
        public SKEIN1024_488()
			: base(HashType.SKEIN1024_488, "skein1024-488", 488, () => new SkeinDigest(1024, 488))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_496, "skein1024-496", 496)]
    public class SKEIN1024_496 : SKEIN
    {
        public SKEIN1024_496()
			: base(HashType.SKEIN1024_496, "skein1024-496", 496, () => new SkeinDigest(1024, 496))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_504, "skein1024-504", 504)]
    public class SKEIN1024_504 : SKEIN
    {
        public SKEIN1024_504()
			: base(HashType.SKEIN1024_504, "skein1024-504", 504, () => new SkeinDigest(1024, 504))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_512, "skein1024-512", 512)]
    public class SKEIN1024_512 : SKEIN
    {
        public SKEIN1024_512()
			: base(HashType.SKEIN1024_512, "skein1024-512", 512, () => new SkeinDigest(1024, 512))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_520, "skein1024-520", 520)]
    public class SKEIN1024_520 : SKEIN
    {
        public SKEIN1024_520()
			: base(HashType.SKEIN1024_520, "skein1024-520", 520, () => new SkeinDigest(1024, 520))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_528, "skein1024-528", 528)]
    public class SKEIN1024_528 : SKEIN
    {
        public SKEIN1024_528()
			: base(HashType.SKEIN1024_528, "skein1024-528", 528, () => new SkeinDigest(1024, 528))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_536, "skein1024-536", 536)]
    public class SKEIN1024_536 : SKEIN
    {
        public SKEIN1024_536()
			: base(HashType.SKEIN1024_536, "skein1024-536", 536, () => new SkeinDigest(1024, 536))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_544, "skein1024-544", 544)]
    public class SKEIN1024_544 : SKEIN
    {
        public SKEIN1024_544()
			: base(HashType.SKEIN1024_544, "skein1024-544", 544, () => new SkeinDigest(1024, 544))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_552, "skein1024-552", 552)]
    public class SKEIN1024_552 : SKEIN
    {
        public SKEIN1024_552()
			: base(HashType.SKEIN1024_552, "skein1024-552", 552, () => new SkeinDigest(1024, 552))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_560, "skein1024-560", 560)]
    public class SKEIN1024_560 : SKEIN
    {
        public SKEIN1024_560()
			: base(HashType.SKEIN1024_560, "skein1024-560", 560, () => new SkeinDigest(1024, 560))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_568, "skein1024-568", 568)]
    public class SKEIN1024_568 : SKEIN
    {
        public SKEIN1024_568()
			: base(HashType.SKEIN1024_568, "skein1024-568", 568, () => new SkeinDigest(1024, 568))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_576, "skein1024-576", 576)]
    public class SKEIN1024_576 : SKEIN
    {
        public SKEIN1024_576()
			: base(HashType.SKEIN1024_576, "skein1024-576", 576, () => new SkeinDigest(1024, 576))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_584, "skein1024-584", 584)]
    public class SKEIN1024_584 : SKEIN
    {
        public SKEIN1024_584()
			: base(HashType.SKEIN1024_584, "skein1024-584", 584, () => new SkeinDigest(1024, 584))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_592, "skein1024-592", 592)]
    public class SKEIN1024_592 : SKEIN
    {
        public SKEIN1024_592()
			: base(HashType.SKEIN1024_592, "skein1024-592", 592, () => new SkeinDigest(1024, 592))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_600, "skein1024-600", 600)]
    public class SKEIN1024_600 : SKEIN
    {
        public SKEIN1024_600()
			: base(HashType.SKEIN1024_600, "skein1024-600", 600, () => new SkeinDigest(1024, 600))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_608, "skein1024-608", 608)]
    public class SKEIN1024_608 : SKEIN
    {
        public SKEIN1024_608()
			: base(HashType.SKEIN1024_608, "skein1024-608", 608, () => new SkeinDigest(1024, 608))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_616, "skein1024-616", 616)]
    public class SKEIN1024_616 : SKEIN
    {
        public SKEIN1024_616()
			: base(HashType.SKEIN1024_616, "skein1024-616", 616, () => new SkeinDigest(1024, 616))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_624, "skein1024-624", 624)]
    public class SKEIN1024_624 : SKEIN
    {
        public SKEIN1024_624()
			: base(HashType.SKEIN1024_624, "skein1024-624", 624, () => new SkeinDigest(1024, 624))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_632, "skein1024-632", 632)]
    public class SKEIN1024_632 : SKEIN
    {
        public SKEIN1024_632()
			: base(HashType.SKEIN1024_632, "skein1024-632", 632, () => new SkeinDigest(1024, 632))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_640, "skein1024-640", 640)]
    public class SKEIN1024_640 : SKEIN
    {
        public SKEIN1024_640()
			: base(HashType.SKEIN1024_640, "skein1024-640", 640, () => new SkeinDigest(1024, 640))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_648, "skein1024-648", 648)]
    public class SKEIN1024_648 : SKEIN
    {
        public SKEIN1024_648()
			: base(HashType.SKEIN1024_648, "skein1024-648", 648, () => new SkeinDigest(1024, 648))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_656, "skein1024-656", 656)]
    public class SKEIN1024_656 : SKEIN
    {
        public SKEIN1024_656()
			: base(HashType.SKEIN1024_656, "skein1024-656", 656, () => new SkeinDigest(1024, 656))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_664, "skein1024-664", 664)]
    public class SKEIN1024_664 : SKEIN
    {
        public SKEIN1024_664()
			: base(HashType.SKEIN1024_664, "skein1024-664", 664, () => new SkeinDigest(1024, 664))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_672, "skein1024-672", 672)]
    public class SKEIN1024_672 : SKEIN
    {
        public SKEIN1024_672()
			: base(HashType.SKEIN1024_672, "skein1024-672", 672, () => new SkeinDigest(1024, 672))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_680, "skein1024-680", 680)]
    public class SKEIN1024_680 : SKEIN
    {
        public SKEIN1024_680()
			: base(HashType.SKEIN1024_680, "skein1024-680", 680, () => new SkeinDigest(1024, 680))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_688, "skein1024-688", 688)]
    public class SKEIN1024_688 : SKEIN
    {
        public SKEIN1024_688()
			: base(HashType.SKEIN1024_688, "skein1024-688", 688, () => new SkeinDigest(1024, 688))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_696, "skein1024-696", 696)]
    public class SKEIN1024_696 : SKEIN
    {
        public SKEIN1024_696()
			: base(HashType.SKEIN1024_696, "skein1024-696", 696, () => new SkeinDigest(1024, 696))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_704, "skein1024-704", 704)]
    public class SKEIN1024_704 : SKEIN
    {
        public SKEIN1024_704()
			: base(HashType.SKEIN1024_704, "skein1024-704", 704, () => new SkeinDigest(1024, 704))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_712, "skein1024-712", 712)]
    public class SKEIN1024_712 : SKEIN
    {
        public SKEIN1024_712()
			: base(HashType.SKEIN1024_712, "skein1024-712", 712, () => new SkeinDigest(1024, 712))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_720, "skein1024-720", 720)]
    public class SKEIN1024_720 : SKEIN
    {
        public SKEIN1024_720()
			: base(HashType.SKEIN1024_720, "skein1024-720", 720, () => new SkeinDigest(1024, 720))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_728, "skein1024-728", 728)]
    public class SKEIN1024_728 : SKEIN
    {
        public SKEIN1024_728()
			: base(HashType.SKEIN1024_728, "skein1024-728", 728, () => new SkeinDigest(1024, 728))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_736, "skein1024-736", 736)]
    public class SKEIN1024_736 : SKEIN
    {
        public SKEIN1024_736()
			: base(HashType.SKEIN1024_736, "skein1024-736", 736, () => new SkeinDigest(1024, 736))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_744, "skein1024-744", 744)]
    public class SKEIN1024_744 : SKEIN
    {
        public SKEIN1024_744()
			: base(HashType.SKEIN1024_744, "skein1024-744", 744, () => new SkeinDigest(1024, 744))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_752, "skein1024-752", 752)]
    public class SKEIN1024_752 : SKEIN
    {
        public SKEIN1024_752()
			: base(HashType.SKEIN1024_752, "skein1024-752", 752, () => new SkeinDigest(1024, 752))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_760, "skein1024-760", 760)]
    public class SKEIN1024_760 : SKEIN
    {
        public SKEIN1024_760()
			: base(HashType.SKEIN1024_760, "skein1024-760", 760, () => new SkeinDigest(1024, 760))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_768, "skein1024-768", 768)]
    public class SKEIN1024_768 : SKEIN
    {
        public SKEIN1024_768()
			: base(HashType.SKEIN1024_768, "skein1024-768", 768, () => new SkeinDigest(1024, 768))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_776, "skein1024-776", 776)]
    public class SKEIN1024_776 : SKEIN
    {
        public SKEIN1024_776()
			: base(HashType.SKEIN1024_776, "skein1024-776", 776, () => new SkeinDigest(1024, 776))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_784, "skein1024-784", 784)]
    public class SKEIN1024_784 : SKEIN
    {
        public SKEIN1024_784()
			: base(HashType.SKEIN1024_784, "skein1024-784", 784, () => new SkeinDigest(1024, 784))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_792, "skein1024-792", 792)]
    public class SKEIN1024_792 : SKEIN
    {
        public SKEIN1024_792()
			: base(HashType.SKEIN1024_792, "skein1024-792", 792, () => new SkeinDigest(1024, 792))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_800, "skein1024-800", 800)]
    public class SKEIN1024_800 : SKEIN
    {
        public SKEIN1024_800()
			: base(HashType.SKEIN1024_800, "skein1024-800", 800, () => new SkeinDigest(1024, 800))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_808, "skein1024-808", 808)]
    public class SKEIN1024_808 : SKEIN
    {
        public SKEIN1024_808()
			: base(HashType.SKEIN1024_808, "skein1024-808", 808, () => new SkeinDigest(1024, 808))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_816, "skein1024-816", 816)]
    public class SKEIN1024_816 : SKEIN
    {
        public SKEIN1024_816()
			: base(HashType.SKEIN1024_816, "skein1024-816", 816, () => new SkeinDigest(1024, 816))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_824, "skein1024-824", 824)]
    public class SKEIN1024_824 : SKEIN
    {
        public SKEIN1024_824()
			: base(HashType.SKEIN1024_824, "skein1024-824", 824, () => new SkeinDigest(1024, 824))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_832, "skein1024-832", 832)]
    public class SKEIN1024_832 : SKEIN
    {
        public SKEIN1024_832()
			: base(HashType.SKEIN1024_832, "skein1024-832", 832, () => new SkeinDigest(1024, 832))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_840, "skein1024-840", 840)]
    public class SKEIN1024_840 : SKEIN
    {
        public SKEIN1024_840()
			: base(HashType.SKEIN1024_840, "skein1024-840", 840, () => new SkeinDigest(1024, 840))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_848, "skein1024-848", 848)]
    public class SKEIN1024_848 : SKEIN
    {
        public SKEIN1024_848()
			: base(HashType.SKEIN1024_848, "skein1024-848", 848, () => new SkeinDigest(1024, 848))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_856, "skein1024-856", 856)]
    public class SKEIN1024_856 : SKEIN
    {
        public SKEIN1024_856()
			: base(HashType.SKEIN1024_856, "skein1024-856", 856, () => new SkeinDigest(1024, 856))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_864, "skein1024-864", 864)]
    public class SKEIN1024_864 : SKEIN
    {
        public SKEIN1024_864()
			: base(HashType.SKEIN1024_864, "skein1024-864", 864, () => new SkeinDigest(1024, 864))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_872, "skein1024-872", 872)]
    public class SKEIN1024_872 : SKEIN
    {
        public SKEIN1024_872()
			: base(HashType.SKEIN1024_872, "skein1024-872", 872, () => new SkeinDigest(1024, 872))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_880, "skein1024-880", 880)]
    public class SKEIN1024_880 : SKEIN
    {
        public SKEIN1024_880()
			: base(HashType.SKEIN1024_880, "skein1024-880", 880, () => new SkeinDigest(1024, 880))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_888, "skein1024-888", 888)]
    public class SKEIN1024_888 : SKEIN
    {
        public SKEIN1024_888()
			: base(HashType.SKEIN1024_888, "skein1024-888", 888, () => new SkeinDigest(1024, 888))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_896, "skein1024-896", 896)]
    public class SKEIN1024_896 : SKEIN
    {
        public SKEIN1024_896()
			: base(HashType.SKEIN1024_896, "skein1024-896", 896, () => new SkeinDigest(1024, 896))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_904, "skein1024-904", 904)]
    public class SKEIN1024_904 : SKEIN
    {
        public SKEIN1024_904()
			: base(HashType.SKEIN1024_904, "skein1024-904", 904, () => new SkeinDigest(1024, 904))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_912, "skein1024-912", 912)]
    public class SKEIN1024_912 : SKEIN
    {
        public SKEIN1024_912()
			: base(HashType.SKEIN1024_912, "skein1024-912", 912, () => new SkeinDigest(1024, 912))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_920, "skein1024-920", 920)]
    public class SKEIN1024_920 : SKEIN
    {
        public SKEIN1024_920()
			: base(HashType.SKEIN1024_920, "skein1024-920", 920, () => new SkeinDigest(1024, 920))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_928, "skein1024-928", 928)]
    public class SKEIN1024_928 : SKEIN
    {
        public SKEIN1024_928()
			: base(HashType.SKEIN1024_928, "skein1024-928", 928, () => new SkeinDigest(1024, 928))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_936, "skein1024-936", 936)]
    public class SKEIN1024_936 : SKEIN
    {
        public SKEIN1024_936()
			: base(HashType.SKEIN1024_936, "skein1024-936", 936, () => new SkeinDigest(1024, 936))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_944, "skein1024-944", 944)]
    public class SKEIN1024_944 : SKEIN
    {
        public SKEIN1024_944()
			: base(HashType.SKEIN1024_944, "skein1024-944", 944, () => new SkeinDigest(1024, 944))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_952, "skein1024-952", 952)]
    public class SKEIN1024_952 : SKEIN
    {
        public SKEIN1024_952()
			: base(HashType.SKEIN1024_952, "skein1024-952", 952, () => new SkeinDigest(1024, 952))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_960, "skein1024-960", 960)]
    public class SKEIN1024_960 : SKEIN
    {
        public SKEIN1024_960()
			: base(HashType.SKEIN1024_960, "skein1024-960", 960, () => new SkeinDigest(1024, 960))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_968, "skein1024-968", 968)]
    public class SKEIN1024_968 : SKEIN
    {
        public SKEIN1024_968()
			: base(HashType.SKEIN1024_968, "skein1024-968", 968, () => new SkeinDigest(1024, 968))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_976, "skein1024-976", 976)]
    public class SKEIN1024_976 : SKEIN
    {
        public SKEIN1024_976()
			: base(HashType.SKEIN1024_976, "skein1024-976", 976, () => new SkeinDigest(1024, 976))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_984, "skein1024-984", 984)]
    public class SKEIN1024_984 : SKEIN
    {
        public SKEIN1024_984()
			: base(HashType.SKEIN1024_984, "skein1024-984", 984, () => new SkeinDigest(1024, 984))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_992, "skein1024-992", 992)]
    public class SKEIN1024_992 : SKEIN
    {
        public SKEIN1024_992()
			: base(HashType.SKEIN1024_992, "skein1024-992", 992, () => new SkeinDigest(1024, 992))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_1000, "skein1024-1000", 1000)]
    public class SKEIN1024_1000 : SKEIN
    {
        public SKEIN1024_1000()
			: base(HashType.SKEIN1024_1000, "skein1024-1000", 1000, () => new SkeinDigest(1024, 1000))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_1008, "skein1024-1008", 1008)]
    public class SKEIN1024_1008 : SKEIN
    {
        public SKEIN1024_1008()
			: base(HashType.SKEIN1024_1008, "skein1024-1008", 1008, () => new SkeinDigest(1024, 1008))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_1016, "skein1024-1016", 1016)]
    public class SKEIN1024_1016 : SKEIN
    {
        public SKEIN1024_1016()
			: base(HashType.SKEIN1024_1016, "skein1024-1016", 1016, () => new SkeinDigest(1024, 1016))
        {
        }
    }

    [Export(typeof(IMultihashAlgorithm))]
    [MultihashAlgorithmExport(HashType.SKEIN1024_1024, "skein1024-1024", 1024)]
    public class SKEIN1024_1024 : SKEIN
    {
        public SKEIN1024_1024()
			: base(HashType.SKEIN1024_1024, "skein1024-1024", 1024, () => new SkeinDigest(1024, 1024))
        {
        }
    }
}
