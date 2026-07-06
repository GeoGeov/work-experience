using System.Text.Json.Serialization;

namespace HarryPotter.Server.Models
{
    public class Wands
    {
        [JsonPropertyName("core")]
        public string? Core { get; set; }

        [JsonPropertyName("length")]
        public decimal? Length { get; set; }

        [JsonPropertyName("wood")]
        public string? Wood { get; set; }
    }
}
