using System.Text;
using NUnit.Framework;

namespace Multiformats.Hash.Tests
{
    [TestFixture]
    public partial class SumTests
    {
        [Test]
        public void TestSHA3()
        {
            var text = "hello world";
            var hash = "8tWhXW5oUwtPd9d3FnjuLP1NozN3vc45rmsoWEEfrZL1L6gi9dqi1YkZu5iHb2HJ8WbZaaKAyNWWRAa8yaxMkGKJmX";

            var mh = Multihash.Sum<SHA3>(Encoding.UTF8.GetBytes(text));
            Assert.That(mh.B58String(), Is.EqualTo(hash));
        }
    }
}
