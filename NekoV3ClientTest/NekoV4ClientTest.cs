using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NekosAPI.NET.V4;

namespace NekoV4ClientTest
{
    [TestClass]
    public class ApiClientTest
    {
        private readonly ApiClient _client = new(new HttpClient());

        [TestMethod]
        public async Task TestGetRandomImageAsync()
        {
            var result = await _client.ImagesAsync();
            Assert.IsNotNull(result);
            Console.WriteLine($"Image URL: {result.Items.First().Url}");
        }
    }
}
