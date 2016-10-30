namespace Multiformats.Hash
{
    public enum HashType : byte
    {
        SHA1 = 0x11,
        SHA2_256 = 0x12,
        SHA2_512 = 0x13,
        SHA3 = 0x14,
        BLAKE2B = 0x40,
        BLAKE2S = 0x41,
        UNKNOWN = 0
    }
}