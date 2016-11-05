using System;
using System.Linq;
using System.Text;
using Multiformats.Base;
using NUnit.Framework;
using Org.BouncyCastle.Utilities.Encoders;

namespace Multiformats.Hash.Tests
{
    [TestFixture]
    public class MultihashTests
    {
        [TestCase("0beec7b5ea3f0fdbc95d0dd47f3c5bc275da8a33", 0x11, "sha1")]
        [TestCase("0beec7b5", 0x11, "sha1")]
        [TestCase("2c26b46b68ffc68ff99b453c1d30413413422d706483bfa0f98a5e886266e7ae", 0x12, "sha2-256")]
        [TestCase("2c26b46b", 0x12, "sha2-256")]
        [TestCase("0beec7b5ea3f0fdbc9", 0x40, "blake2b")]
        public void TestEncode(string hex, int code, string name)
        {
            var ob = Hex.Decode(hex);
            var nb = new[] {(byte) code, (byte) ob.Length}.Concat(ob).ToArray();

            var encoded = Multihash.Encode(ob, (HashType)code);

            Assert.That(encoded, Is.EqualTo(nb));

            var h = TestCastToMultihash(hex, code, name);
            Assert.That((byte[])h, Is.EqualTo(nb));
        }

        private static Multihash TestCastToMultihash(string hex, int code, string name)
        {
            var ob = Hex.Decode(hex);
            var b = new byte[2 + ob.Length];
            b[0] = (byte)code;
            b[1] = (byte) ob.Length;
            ob.CopyTo(b, 2);
            return Multihash.Cast(b);
        }

        [TestCase("0beec7b5ea3f0fdbc95d0dd47f3c5bc275da8a33", 0x11, "sha1")]
        [TestCase("0beec7b5", 0x11, "sha1")]
        [TestCase("2c26b46b68ffc68ff99b453c1d30413413422d706483bfa0f98a5e886266e7ae", 0x12, "sha2-256")]
        [TestCase("2c26b46b", 0x12, "sha2-256")]
        [TestCase("0beec7b5ea3f0fdbc9", 0x40, "blake2b")]
        public void TestDecode(string hex, byte code, string name)
        {
            var ob = Hex.Decode(hex);
            var nb = new[] {(byte) code, (byte) ob.Length}.Concat(ob).ToArray();

            var dec = Multihash.Decode(nb);
            Assert.That((byte)dec.Code, Is.EqualTo(code));
            Assert.That(dec.Name, Is.EqualTo(name));
            Assert.That(dec.Length, Is.EqualTo(ob.Length));
            Assert.That(dec.Digest, Is.EqualTo(ob));
        }

        [TestCase(0x11, "sha1")]
        [TestCase(0x12, "sha2-256")]
        [TestCase(0x13, "sha2-512")]
        [TestCase(0x14, "sha3-512")]
        [TestCase(0x15, "sha3-384")]
        [TestCase(0x16, "sha3-256")]
        [TestCase(0x17, "sha3-224")]
        [TestCase(0x18, "shake-128")]
        [TestCase(0x19, "shake-256")]
        [TestCase(0x1A, "keccak-224")]
        [TestCase(0x1B, "keccak-256")]
        [TestCase(0x1C, "keccak-384")]
        [TestCase(0x1D, "keccak-512")]
        [TestCase(0x40, "blake2b")]
        [TestCase(0x41, "blake2s")]
        public void TestTable(byte code, string name)
        {
            if (Multihash.GetName(code) != name)
                Assert.Fail($"Table mismatch: {Multihash.GetName(code)}, {name}");

            if ((byte)Multihash.GetCode(name) != code)
                Assert.Fail($"Table mismatch: {Multihash.GetCode(name)}, {code}");
        }

        [TestCase("5drNu81uhrFLRiS4bxWgAkpydaLUPW", "hello world")] // sha1
        [TestCase("QmaozNR7DZHQK1ZcU9p7QdrshMvXqWK6gpu5rmrkPdT3L4", "hello world")] // sha2_256
        [TestCase("8Vtkv2tdQ43bNGdWN9vNx9GVS9wrbXHk4ZW8kmucPmaYJwwedXir52kti9wJhcik4HehyqgLrQ1hBuirviLhxgRBNv", "hello world")] // sha2_512
        [TestCase("8tWhXW5oUwtPd9d3FnjuLP1NozN3vc45rmsoWEEfrZL1L6gi9dqi1YkZu5iHb2HJ8WbZaaKAyNWWRAa8yaxMkGKJmX", "hello world")] // sha3_512
        public void TestVerify(string mhs, string data)
        {
            var mh = Multihash.Parse(mhs);
            var bytes = Encoding.UTF8.GetBytes(data);

            Assert.That(mh.Verify(bytes));
        }

        [TestCase(HashType.SHA1)]
        [TestCase(HashType.SHA2_256)]
        [TestCase(HashType.SHA2_512)]
        [TestCase(HashType.SHA3_224)]
        [TestCase(HashType.SHA3_256)]
        [TestCase(HashType.SHA3_384)]
        [TestCase(HashType.SHA3_512)]
        [TestCase(HashType.KECCAK_224)]
        [TestCase(HashType.KECCAK_256)]
        [TestCase(HashType.KECCAK_384)]
        [TestCase(HashType.KECCAK_512)]
        [TestCase(HashType.SHAKE_128)]
        [TestCase(HashType.SHAKE_256)]
        [TestCase(HashType.BLAKE2B)]
        [TestCase(HashType.BLAKE2S)]
        public void VerifyRoundTrip(HashType type)
        {
            var rand = new Random(Environment.TickCount);
            var bytes = new byte[rand.Next(1024, 4096)];
            rand.NextBytes(bytes);

            var mh = Multihash.Sum(type, bytes);
            var str = mh.ToString();
            var mh2 = Multihash.Parse(str);

            Assert.That(mh2.Verify(bytes), Is.True);
        }
    }
}
