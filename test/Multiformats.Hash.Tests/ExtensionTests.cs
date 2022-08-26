using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Multiformats.Hash.Tests
{
    public class ExtensionTests
    {
        public HashType[] SupportedHashTypes { get; }

        public ExtensionTests()
        {
            SupportedHashTypes = Enum.GetValues(typeof(HashType)).Cast<HashType>().ToArray();
        }

        [Fact]
        public void Read_StreamGivenMultistreamContent_ReturnsValidMultihashes()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToArray();

            using var stream = new MemoryStream(hashes.SelectMany(mh => (byte[])mh).ToArray());
            foreach (var hash in hashes)
            {
                var mh = stream.ReadMultihash();

                Assert.NotNull(mh);
                Assert.Equal(mh, hash);
                Assert.True(mh.Verify(data));
            }
        }

        [Fact]
        public async Task Read_StreamGivenMultistreamContent_ReturnsValidMultihashes_Async()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToArray();

            await using var stream = new MemoryStream(hashes.SelectMany(mh => (byte[])mh).ToArray());
            foreach (var hash in hashes)
            {
                var mh = await stream.ReadMultihashAsync(CancellationToken.None);

                Assert.NotNull(mh);
                Assert.Equal(mh, hash);
                Assert.True(await mh.VerifyAsync(data));
            }
        }

        [Fact]
        public void ReadWrite_Roundtrip()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToList();

            using var stream = new MemoryStream();
            foreach (var hash in hashes)
            {
                stream.Write(hash);
            }

            stream.Seek(0, SeekOrigin.Begin);

            foreach (var hash in hashes)
            {
                var mh = stream.ReadMultihash();

                Assert.NotNull(mh);
                Assert.Equal(mh, hash);
                Assert.True(mh.Verify(data));
            }
        }

        [Fact]
        public async Task ReadWrite_Roundtrip_Async()
        {
            var data = Encoding.UTF8.GetBytes("hello world");
            var hashes = SupportedHashTypes.Select(type => Multihash.Sum(type, data)).ToList();

            await using var stream = new MemoryStream();
            foreach (var hash in hashes)
            {
                await stream.WriteAsync(hash, CancellationToken.None);
            }

            stream.Seek(0, SeekOrigin.Begin);

            foreach (var hash in hashes)
            {
                var mh = await stream.ReadMultihashAsync(CancellationToken.None);

                Assert.NotNull(mh);
                Assert.Equal(mh, hash);
                Assert.True(await mh.VerifyAsync(data));
            }
        }
    }
}
