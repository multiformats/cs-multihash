using System;
using System.Text;
using Multiformats.Base;
using Multiformats.Hash.Algorithms;
using Org.BouncyCastle.Utilities.Encoders;
using Xunit;

namespace Multiformats.Hash.Tests
{
    public class SumTests
    {
        [Fact]
        public void TestID()
        {
            var text = "hello world";
            var hash = "DVBjHhYDaZ47EzaX1";

            var mh = Multihash.Sum<ID>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.ToString(Multibase.Base58), hash);
        }

        [Fact]
        public void TestMD4()
        {
            var text = "hello world";
            var hash = Hex.Decode("aa010fbc1d14c795d86ef98c95479d17");

            var mh = Multihash.Sum<MD4>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(hash, mh.Digest);
        }

        [Fact]
        public void TestMD5()
        {
            var text = "hello world";
            var hash = Hex.Decode("5eb63bbbe01eeed093cb22bb8f5acdc3");

            var mh = Multihash.Sum<MD5>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(hash, mh.Digest);
        }

        [Fact]
        public void TestSHA1()
        {
            var text = "hello world";
            var hash = "5drNu81uhrFLRiS4bxWgAkpydaLUPW";

            var mh = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.ToString(Multibase.Base58), hash);
        }

        [Fact]
        public void TestSHA2_256()
        {
            var text = "hello world";
            var hash = "QmaozNR7DZHQK1ZcU9p7QdrshMvXqWK6gpu5rmrkPdT3L4";

            var mh = Multihash.Sum<SHA2_256>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.ToString(Multibase.Base58), hash);
        }

        [Fact]
        public void TestSHA2_512()
        {
            var text = "hello world";
            var hash = "8Vtkv2tdQ43bNGdWN9vNx9GVS9wrbXHk4ZW8kmucPmaYJwwedXir52kti9wJhcik4HehyqgLrQ1hBuirviLhxgRBNv";

            var mh = Multihash.Sum<SHA2_512>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.ToString(Multibase.Base58), hash);
        }

        [Fact]
        public void TestSHA3_512()
        {
            var text = "hello world";
            var hash = "8tWhXW5oUwtPd9d3FnjuLP1NozN3vc45rmsoWEEfrZL1L6gi9dqi1YkZu5iHb2HJ8WbZaaKAyNWWRAa8yaxMkGKJmX";

            var mh = Multihash.Sum<SHA3_512>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.ToString(Multibase.Base58), hash);
        }

        [Fact]
        public void TestSHA3_384()
        {
            var text = "hello world";
            var hash = Hex.Decode("83bff28dde1b1bf5810071c6643c08e5b05bdb836effd70b403ea8ea0a634dc4997eb1053aa3593f590f9c63630dd90b");

            var mh = Multihash.Sum<SHA3_384>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestSHA3_256()
        {
            var text = "hello world";
            var hash = Hex.Decode("644bcc7e564373040999aac89e7622f3ca71fba1d972fd94a31c3bfbf24e3938");

            var mh = Multihash.Sum<SHA3_256>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestSHA3_224()
        {
            var text = "hello world";
            var hash = Hex.Decode("dfb7f18c77e928bb56faeb2da27291bd790bc1045cde45f3210bb6c5");

            var mh = Multihash.Sum<SHA3_224>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestBlake2B()
        {
            var text = "hello world";
            var hash = "021ced8799296ceca557832ab941a50b4a11f83478cf141f51f933f653ab9fbcc05a037cddbed06e309bf334942c4e58cdf1a46e237911ccd7fcf9787cbc7fd0";

            var mh = Multihash.Sum<BLAKE2B_512>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(BitConverter.ToString(mh.Digest).Replace("-", "").ToLower(), hash);
        }

        [Fact]
        public void TestBlake2S()
        {
            var text = "hello world";
            var hash = "9aec6806794561107e594b1f6a8a6b0c92a0cba9acf5e5e93cca06f781813b0b";

            var mh = Multihash.Sum<BLAKE2S_256>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(BitConverter.ToString(mh.Digest).Replace("-", "").ToLower(), hash);
        }

        [Fact]
        public void TestKeccak_224()
        {
            var text = "hello world";
            var hash = Hex.Decode("25f3ecfebabe99686282f57f5c9e1f18244cfee2813d33f955aae568");

            var mh = Multihash.Sum<KECCAK_224>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestKeccak_256()
        {
            var text = "hello world";
            var hash = Hex.Decode("47173285a8d7341e5e972fc677286384f802f8ef42a5ec5f03bbfa254cb01fad");

            var mh = Multihash.Sum<KECCAK_256>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestKeccak_384()
        {
            var text = "hello world";
            var hash = Hex.Decode("65fc99339a2a40e99d3c40d695b22f278853ca0f925cde4254bcae5e22ece47e6441f91b6568425adc9d95b0072eb49f");

            var mh = Multihash.Sum<KECCAK_384>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestKeccak_512()
        {
            var text = "hello world";
            var hash = Hex.Decode("3ee2b40047b8060f68c67242175660f4174d0af5c01d47168ec20ed619b0b7c42181f40aa1046f39e2ef9efc6910782a998e0013d172458957957fac9405b67d");

            var mh = Multihash.Sum<KECCAK_512>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestShake_128()
        {
            var text = "hello world";
            var hash = Hex.Decode("3a9159f071e4dd1c8c4f968607c30942");

            var mh = Multihash.Sum<SHAKE_128>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestShake_256()
        {
            var text = "hello world";
            var hash = Hex.Decode("369771bb2cb9d2b04c1d54cca487e372d9f187f73f7ba3f65b95c8ee7798c527");

            var mh = Multihash.Sum<SHAKE_256>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestDblSha2_256()
        {
            var text = "foo";
            var hash = Hex.Decode("c7ade88fc7a21498a6a5e5c385e1f68bed822b72aa63c4a9a48a02c2466ee29e");

            var mh = Multihash.Sum<DBL_SHA2_256>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestMurmur3_128()
        {
            var text = "beep boop";
            var hash = Hex.Decode("acfe9c5bbf88f075c0c4df0464430ead");

            var mh = Multihash.Sum<MURMUR3_128>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }

        [Fact]
        public void TestMurmur3_32()
        {
            var text = "beep boop";
            var hash = Hex.Decode("243ddb9e");

            var mh = Multihash.Sum<MURMUR3_32>(Encoding.UTF8.GetBytes(text));
            Assert.Equal(mh.Digest, hash);
        }
    }
}
