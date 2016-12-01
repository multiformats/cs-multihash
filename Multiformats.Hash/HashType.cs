using System;

namespace Multiformats.Hash
{
    public enum HashType : byte
    {
        SHA1 = 0x11,
        SHA2_256 = 0x12,
        SHA2_512 = 0x13,
        SHA3_512 = 0x14,
        SHA3_384 = 0x15,
        SHA3_256 = 0x16,
        SHA3_224 = 0x17,
        SHAKE_128 = 0x18,
        SHAKE_256 = 0x19,
        KECCAK_224 = 0x1A,
        KECCAK_256 = 0x1B,
        KECCAK_384 = 0x1C,
        KECCAK_512 = 0x1D,
        BLAKE2B = 0x40,
        BLAKE2S = 0x41,
        DBL_SHA2_256 = 0x56,
        UNKNOWN = 0,

        [Obsolete("Use SHA3_512 instead")]
        SHA3 = SHA3_512
    }
}