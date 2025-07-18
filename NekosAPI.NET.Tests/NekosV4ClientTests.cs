using NekosAPI.NET.V4;
using System.Threading.Tasks;
using Xunit;

namespace NekosAPI.NET.Tests
{
    public class NekosV4ClientTests
    {
        [Fact]
        public async Task GetRandomImagesAsync_ShouldReturnImages()
        {
            // Arrange
            var client = new NekosV4Client();

            // Act
            var images = await client.GetRandomImagesAsync();

            // Assert
            Assert.NotNull(images);
            Assert.NotEmpty(images);
        }

        [Fact]
        public async Task GetRandomImagesAsync_WithLimit_ShouldReturnLimitedImages()
        {
            // Arrange
            var client = new NekosV4Client();
            int limit = 5;

            // Act
            var images = await client.GetRandomImagesAsync(limit: limit);

            // Assert
            Assert.NotNull(images);
            Assert.NotEmpty(images);
            Assert.Equal(limit, images.Length);
        }
    }
}