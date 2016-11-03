using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multiformats.Hash.Algorithms;
using NUnit.Framework;

namespace Multiformats.Hash.Tests
{
    [TestFixture]
    public class SumTests
    {
        [Test]
        public void TestSHA1()
        {
            var text = "hello world";
            var hash = "5drNu81uhrFLRiS4bxWgAkpydaLUPW";

            var mh = Multihash.Sum<SHA1>(Encoding.UTF8.GetBytes(text));
            Assert.That(mh.B58String(), Is.EqualTo(hash));
        }

        [Test]
        public void TestSHA2_256()
        {
            var text = "hello world";
            var hash = "QmaozNR7DZHQK1ZcU9p7QdrshMvXqWK6gpu5rmrkPdT3L4";

            var mh = Multihash.Sum<SHA2_256>(Encoding.UTF8.GetBytes(text));
            Assert.That(mh.B58String(), Is.EqualTo(hash));
        }

        [Test]
        public void TestSHA2_512()
        {
            var text = "hello world";
            var hash = "8Vtkv2tdQ43bNGdWN9vNx9GVS9wrbXHk4ZW8kmucPmaYJwwedXir52kti9wJhcik4HehyqgLrQ1hBuirviLhxgRBNv";

            var mh = Multihash.Sum<SHA2_512>(Encoding.UTF8.GetBytes(text));
            Assert.That(mh.B58String(), Is.EqualTo(hash));
        }

        [Test]
        public void TestSHA3()
        {
            var text = "hello world";
            var hash = "8tWhXW5oUwtPd9d3FnjuLP1NozN3vc45rmsoWEEfrZL1L6gi9dqi1YkZu5iHb2HJ8WbZaaKAyNWWRAa8yaxMkGKJmX";

            var mh = Multihash.Sum<SHA3>(Encoding.UTF8.GetBytes(text));
            Assert.That(mh.B58String(), Is.EqualTo(hash));
        }

        [Test]
        public void TestBlake2B()
        {
            var text = "hello world";
            var hash = "021ced8799296ceca557832ab941a50b4a11f83478cf141f51f933f653ab9fbcc05a037cddbed06e309bf334942c4e58cdf1a46e237911ccd7fcf9787cbc7fd0";

            var mh = Multihash.Sum<Blake2B>(Encoding.UTF8.GetBytes(text));
            Assert.That(BitConverter.ToString(mh.Digest).Replace("-", "").ToLower(), Is.EqualTo(hash));
        }
    }
}
