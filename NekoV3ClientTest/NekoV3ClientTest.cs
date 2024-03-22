using System;
using System.Linq;
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
        private readonly RandomNekoClient _randomClient = new(new HttpClient());
        private readonly TagNekoClient _tagClient = new(new HttpClient());

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

        [TestMethod]
        public async Task CheckTotalNekoExplicitImages()
        {
            var result = await _randomClient.ImagesAsync(rating: ["explicit"], tag: [8]);
            Console.WriteLine($"Total images: {result.Items.Count}");

            var duplicateIds = result.Items
                .GroupBy(i => i.Id)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);

            if (duplicateIds.Any())
            {
                Console.WriteLine("Found duplicate IDs:");
                foreach (var id in duplicateIds)
                {
                    Console.WriteLine($"Duplicate ID: {id}");
                }
            }
            else
            {
                Console.WriteLine("No duplicate IDs found.");
            }

            foreach (var image in result.Items)
            {
                Console.WriteLine($"Image ID: {image.Id} Link: {image.Image_url}");
            }
        }
    }
}