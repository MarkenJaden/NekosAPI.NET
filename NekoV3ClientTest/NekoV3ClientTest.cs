using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NekosAPI.NET.V3;

namespace NekoV3ClientTest
{
    [TestClass]
    public class ApiClientTest
    {
        private readonly ApiNekoClient _client = new(new HttpClient());

        [TestMethod]
        public async Task TestIndexAsync()
        {
            await _client.IndexAsync();
            var images = await _client.ImagesAsync(rating: ["safe"], tag: [8], limit: 3);
            foreach (var item in images.Items)
            {
                //Do whatever you want to do with this
                Console.WriteLine(item.Image_url);
            }
        }

        [TestMethod]
        public async Task TestImagesAsync()
        {
            var result = await _client.ImagesAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestTagsAsync()
        {
            var result = await _client.TagsAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestTagAsync()
        {
            var result = await _client.TagAsync(8);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestImageAsync()
        {
            var result = await _client.ImageAsync(8);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestArtistsAsync()
        {
            var result = await _client.ArtistsAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestArtistAsync()
        {
            var result = await _client.ArtistAsync(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestCharactersAsync()
        {
            var result = await _client.CharactersAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestCharacterAsync()
        {
            var result = await _client.CharacterAsync(1);
            Assert.IsNotNull(result);
        }
    }
}