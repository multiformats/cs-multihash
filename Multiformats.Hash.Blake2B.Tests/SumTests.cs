using System;
using System.Text;
using NUnit.Framework;

namespace Multiformats.Hash.Tests
{
    [TestFixture]
    public partial class SumTests
    {
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
