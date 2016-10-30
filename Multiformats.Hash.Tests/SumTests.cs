using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Multiformats.Hash.Tests
{
    [TestFixture]
    public partial class SumTests
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
    }
}
