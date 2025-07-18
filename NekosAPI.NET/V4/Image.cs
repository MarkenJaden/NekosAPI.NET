using Newtonsoft.Json;

namespace NekosAPI.NET.V4
{
    public class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("color_dominant")]
        public List<int> ColorDominant { get; set; }

        [JsonProperty("color_palette")]
        public List<List<int>> ColorPalette { get; set; }

        [JsonProperty("artist_name")]
        public string ArtistName { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }
    }
}
