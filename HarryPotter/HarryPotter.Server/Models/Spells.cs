using System.Text.Json.Serialization;

namespace HarryPotter.Server.Models
{
    public class Spells
    {
        [JsonPropertyName("id")]
        public string? id { get; set; }

        [JsonPropertyName("name")]
        public decimal? name { get; set; }

        [JsonPropertyName("description")]
        public string? description { get; set; }
    }
}
