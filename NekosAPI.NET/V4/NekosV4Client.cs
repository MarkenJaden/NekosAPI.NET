using Newtonsoft.Json;

namespace NekosAPI.NET.V4
{
    public class NekosV4Client
    {
        private readonly HttpClient _httpClient = new();
        private const string BaseUrl = "https://api.nekosapi.com/v4/";

        public async Task<Image[]> GetRandomImagesAsync(int? limit = null, Rating[] rating = null, int[] artist = null, int[] tags = null)
        {
            var queryParams = new List<string>();
            if (limit.HasValue)
            {
                queryParams.Add($"limit={limit.Value}");
            }
            if (rating is { Length: > 0 })
            {
                queryParams.Add($"rating={string.Join(",", rating)}");
            }
            if (artist is { Length: > 0 })
            {
                queryParams.Add($"artist={string.Join(",", artist)}");
            }
            if (tags is { Length: > 0 })
            {
                queryParams.Add($"tags={string.Join(",", tags)}");
            }

            var url = $"{BaseUrl}images/random";
            if (queryParams.Any())
            {
                url += $"?{string.Join("&", queryParams)}";
            }

            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Image[]>(response);
        }
    }

    public enum Rating
    {
        safe,
        suggestive,
        borderline,
        explict
    }
}