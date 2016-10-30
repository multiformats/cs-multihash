using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var h = TestCaseToMultihash(hex, code, name);
            Assert.That((byte[])h, Is.EqualTo(nb));
        }

        private static Multihash TestCaseToMultihash(string hex, int code, string name)
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
        [TestCase(0x14, "sha3")]
        [TestCase(0x40, "blake2b")]
        //[TestCase(0x41, "blake2s")]
        public void TestTable(byte code, string name)
        {
            if (Multihash.GetName(code) != name)
                Assert.Fail($"Table mismatch: {Multihash.GetName(code)}, {name}");

            if ((byte)Multihash.GetCode(name) != code)
                Assert.Fail($"Table mismatch: {Multihash.GetCode(name)}, {code}");
        }
    }
}
