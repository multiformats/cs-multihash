using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryEncoding;
using Multiformats.Base;
using Org.BouncyCastle.Utilities.Encoders;
using Xunit;

namespace Multiformats.Hash.Tests
{
    public class MultihashTests
    {
        [Theory]
        [InlineData("0beec7b5ea3f0fdbc95d0dd47f3c5bc275da8a33", 0x11, "sha1")]
        [InlineData("0beec7b5", 0x11, "sha1")]
        [InlineData("2c26b46b68ffc68ff99b453c1d30413413422d706483bfa0f98a5e886266e7ae", 0x12, "sha2-256")]
        [InlineData("2c26b46b", 0x12, "sha2-256")]
        [InlineData("0beec7b5ea3f0fdbc9", 0xb220, "blake2b-256")]
        public void TestEncode(string hex, int code, string name)
        {
            var ob = Hex.Decode(hex);
            var nb = Binary.Varint.GetBytes((uint)code).Concat(Binary.Varint.GetBytes((uint)ob.Length)).Concat(ob).ToArray();

            var encoded = Multihash.Encode(ob, (HashType)code);

            Assert.Equal(encoded, nb);

            var h = TestCastToMultihash(hex, code, name);
            Assert.Equal((byte[])h, nb);
        }

        private static Multihash TestCastToMultihash(string hex, int code, string name)
        {
            var ob = Hex.Decode(hex);
            var b = Binary.Varint.GetBytes((uint) code).Concat(Binary.Varint.GetBytes((uint) ob.Length)).Concat(ob).ToArray();
            return Multihash.Cast(b);
        }

        [Fact]
        public void CanDecodeFromMultibase()
        {
            var hex = Multibase.DecodeRaw(Multibase.Base58, "8Vtkv2tdQ43bNGdWN9vNx9GVS9wrbXHk4ZW8kmucPmaYJwwedXir52kti9wJhcik4HehyqgLrQ1hBuirviLhxgRBNv");
            var mb = Multibase.Base32.Encode(hex);
            Multihash mh;
            Assert.True(Multihash.TryParse(mb, out mh));
            Assert.Equal(mh.ToBytes(), hex);
        }

        [Theory]
        [InlineData("0beec7b5ea3f0fdbc95d0dd47f3c5bc275da8a33", 0x11, "sha1")]
        [InlineData("0beec7b5", 0x11, "sha1")]
        [InlineData("2c26b46b68ffc68ff99b453c1d30413413422d706483bfa0f98a5e886266e7ae", 0x12, "sha2-256")]
        [InlineData("2c26b46b", 0x12, "sha2-256")]
        [InlineData("0beec7b5ea3f0fdbc9", 0xb220, "blake2b-256")]
        public void TestDecode(string hex, int code, string name)
        {
            var ob = Hex.Decode(hex);
            var nb = Binary.Varint.GetBytes((uint)code).Concat(Binary.Varint.GetBytes((uint)ob.Length)).Concat(ob).ToArray();

            var dec = Multihash.Decode(nb);
            Assert.Equal((int)dec.Code, code);
            Assert.Equal(dec.Name, name);
            Assert.Equal(dec.Length, ob.Length);
            Assert.Equal(dec.Digest, ob);
        }

        [Theory]
        [InlineData(0x00, "id")]
        [InlineData(0xd4, "md4")]
        [InlineData(0xd5, "md5")]
        [InlineData(0x11, "sha1")]
        [InlineData(0x12, "sha2-256")]
        [InlineData(0x13, "sha2-512")]
        [InlineData(0x14, "sha3-512")]
        [InlineData(0x15, "sha3-384")]
        [InlineData(0x16, "sha3-256")]
        [InlineData(0x17, "sha3-224")]
        [InlineData(0x18, "shake-128")]
        [InlineData(0x19, "shake-256")]
        [InlineData(0x1A, "keccak-224")]
        [InlineData(0x1B, "keccak-256")]
        [InlineData(0x1C, "keccak-384")]
        [InlineData(0x1D, "keccak-512")]
        [InlineData(0xb240, "blake2b-512")]
        [InlineData(0xb260, "blake2s-256")]
        [InlineData(0x56, "dbl-sha2-256")]
        [InlineData(0x22, "murmur3-32")]
        [InlineData(0x23, "murmur3-128")]
        public void TestTable(int code, string name)
        {
            if (Multihash.GetName(code) != name)
                Assert.True(false, $"Table mismatch: {Multihash.GetName(code)}, {name}");

            if ((int)Multihash.GetCode(name) != code)
                Assert.True(false, $"Table mismatch: {Multihash.GetCode(name)}, {code}");
        }

        [Theory]
        [InlineData("5drNu81uhrFLRiS4bxWgAkpydaLUPW", "hello world")] // sha1
        [InlineData("QmaozNR7DZHQK1ZcU9p7QdrshMvXqWK6gpu5rmrkPdT3L4", "hello world")] // sha2_256
        [InlineData("8Vtkv2tdQ43bNGdWN9vNx9GVS9wrbXHk4ZW8kmucPmaYJwwedXir52kti9wJhcik4HehyqgLrQ1hBuirviLhxgRBNv", "hello world")] // sha2_512
        [InlineData("8tWhXW5oUwtPd9d3FnjuLP1NozN3vc45rmsoWEEfrZL1L6gi9dqi1YkZu5iHb2HJ8WbZaaKAyNWWRAa8yaxMkGKJmX", "hello world")] // sha3_512
        public void TestVerify(string mhs, string data)
        {
            var mh = Multihash.Parse(mhs);
            var bytes = Encoding.UTF8.GetBytes(data);

            Assert.True(mh.Verify(bytes));
        }

        [Theory]
        [InlineData(HashType.ID)]
        [InlineData(HashType.SHA1)]
        [InlineData(HashType.SHA2_256)]
        [InlineData(HashType.SHA2_512)]
        [InlineData(HashType.SHA3_224)]
        [InlineData(HashType.SHA3_256)]
        [InlineData(HashType.SHA3_384)]
        [InlineData(HashType.SHA3_512)]
        [InlineData(HashType.KECCAK_224)]
        [InlineData(HashType.KECCAK_256)]
        [InlineData(HashType.KECCAK_384)]
        [InlineData(HashType.KECCAK_512)]
        [InlineData(HashType.SHAKE_128)]
        [InlineData(HashType.SHAKE_256)]
        [InlineData(HashType.BLAKE2B_256)]
        [InlineData(HashType.BLAKE2S_128)]
        [InlineData(HashType.DBL_SHA2_256)]
        [InlineData(HashType.MURMUR3_32)]
        [InlineData(HashType.MURMUR3_128)]
        public void VerifyRoundTrip(HashType type)
        {
            var rand = new Random(Environment.TickCount);
            var bytes = new byte[rand.Next(1024, 4096)];
            rand.NextBytes(bytes);

            var mh = Multihash.Sum(type, bytes);
            var str = mh.ToString();
            var mh2 = Multihash.Parse(str);

            Assert.True(mh2.Verify(bytes));
        }

        [Theory]
        [InlineData(HashType.ID)]
        [InlineData(HashType.SHA1)]
        [InlineData(HashType.SHA2_256)]
        [InlineData(HashType.SHA2_512)]
        [InlineData(HashType.SHA3_224)]
        [InlineData(HashType.SHA3_256)]
        [InlineData(HashType.SHA3_384)]
        [InlineData(HashType.SHA3_512)]
        [InlineData(HashType.KECCAK_224)]
        [InlineData(HashType.KECCAK_256)]
        [InlineData(HashType.KECCAK_384)]
        [InlineData(HashType.KECCAK_512)]
        [InlineData(HashType.SHAKE_128)]
        [InlineData(HashType.SHAKE_256)]
        [InlineData(HashType.BLAKE2B_256)]
        [InlineData(HashType.BLAKE2S_128)]
        [InlineData(HashType.DBL_SHA2_256)]
        [InlineData(HashType.MURMUR3_32)]
        [InlineData(HashType.MURMUR3_128)]
        public async Task VerifyRoundTripAsync(HashType type)
        {
            var rand = new Random(Environment.TickCount);
            var bytes = new byte[rand.Next(1024, 4096)];
            rand.NextBytes(bytes);

            var mh = await Multihash.SumAsync(type, bytes);
            var str = mh.ToString();
            var mh2 = Multihash.Parse(str);

            Assert.True(await mh2.VerifyAsync(bytes));
        }

        [Theory]
        [InlineData(HashType.ID)]
        [InlineData(HashType.SHA1)]
        [InlineData(HashType.SHA2_256)]
        [InlineData(HashType.SHA2_512)]
        [InlineData(HashType.SHA3_224)]
        [InlineData(HashType.SHA3_256)]
        [InlineData(HashType.SHA3_384)]
        [InlineData(HashType.SHA3_512)]
        [InlineData(HashType.KECCAK_224)]
        [InlineData(HashType.KECCAK_256)]
        [InlineData(HashType.KECCAK_384)]
        [InlineData(HashType.KECCAK_512)]
        [InlineData(HashType.SHAKE_128)]
        [InlineData(HashType.SHAKE_256)]
        [InlineData(HashType.BLAKE2B_256)]
        [InlineData(HashType.BLAKE2S_128)]
        [InlineData(HashType.DBL_SHA2_256)]
        [InlineData(HashType.MURMUR3_32)]
        [InlineData(HashType.MURMUR3_128)]
        public void TestMultithreadedEnvironment(HashType type)
        {
            var rand = new Random(Environment.TickCount);
            var bytes = new byte[32*1024];
            rand.NextBytes(bytes);

            Parallel.For(0, 200, _ => Multihash.Sum(type, bytes));
        }
    }
}
