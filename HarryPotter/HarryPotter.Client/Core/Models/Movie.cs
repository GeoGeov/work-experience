using System.Text.Json.Serialization;

namespace HarryPotter.Client.Core.Models
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonPropertyName("synopsis")]
        public string? Synopsis { get; set; }

        [JsonPropertyName("poster")]
        public string? Poster { get; set; }
    }
}
