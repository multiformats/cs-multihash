using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Multiformats.Hash.Tests
{
    [TestFixture]
    public class ExtensionTests
    {
        public HashType[] SupportedHashTypes { get; private set; }

        [SetUp]
        public void Setup()
        {
            var hashes =
                Enum.GetValues(typeof(HashType)).Cast<HashType>().Where(type => type != HashType.UNKNOWN).ToList();

#if ____MonoCS__CS__
            HashType hash;
            while ((hash = hashes.FirstOrDefault(h => h.ToString().StartsWith("BLAKE2S"))) != default(HashType))
            {
                hashes.Remove(hash);
            }
#endif

            SupportedHashTypes = hashes.ToArray();
        }

        [Test]
        public void Read_StreamGivenMultistreamContent_ReturnsValidMultihashes()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToArray();

            using (var stream = new MemoryStream(hashes.SelectMany(mh => (byte[])mh).ToArray()))
            {
                foreach (var hash in hashes)
                {
                    var mh = stream.ReadMultihash();

                    Assert.That(mh, Is.Not.Null);
                    Assert.That(mh, Is.EqualTo(hash));
                    Assert.That(mh.Verify(data), Is.True);
                }
            }
        }

        [Test]
        public async Task Read_StreamGivenMultistreamContent_ReturnsValidMultihashes_Async()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToArray();

            using (var stream = new MemoryStream(hashes.SelectMany(mh => (byte[])mh).ToArray()))
            {
                foreach (var hash in hashes)
                {
                    var mh = await stream.ReadMultihashAsync(CancellationToken.None);

                    Assert.That(mh, Is.Not.Null);
                    Assert.That(mh, Is.EqualTo(hash));
                    Assert.That(mh.Verify(data), Is.True);
                }
            }
        }

        [Test]
        public void ReadWrite_Roundtrip()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToList();

            using (var stream = new MemoryStream())
            {
                foreach (var hash in hashes)
                {
                    stream.Write(hash);
                }

                stream.Seek(0, SeekOrigin.Begin);

                foreach (var hash in hashes)
                {
                    var mh = stream.ReadMultihash();

                    Assert.That(mh, Is.Not.Null);
                    Assert.That(mh, Is.EqualTo(hash));
                    Assert.That(mh.Verify(data), Is.True);
                }
            }
        }

        [Test]
        public async Task ReadWrite_Roundtrip_Async()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToList();

            using (var stream = new MemoryStream())
            {
                foreach (var hash in hashes)
                {
                    await stream.WriteAsync(hash, CancellationToken.None);
                }

                stream.Seek(0, SeekOrigin.Begin);

                foreach (var hash in hashes)
                {
                    var mh = await stream.ReadMultihashAsync(CancellationToken.None);

                    Assert.That(mh, Is.Not.Null);
                    Assert.That(mh, Is.EqualTo(hash));
                    Assert.That(mh.Verify(data), Is.True);
                }
            }
        }
    }
}
