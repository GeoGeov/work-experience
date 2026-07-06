using System.Text.Json.Serialization;

namespace HarryPotter.Client.Models
{
    public class Spell
    {
        [JsonPropertyName("id")]
        public string? id { get; set; }

        [JsonPropertyName("name")]
        public decimal? name { get; set; }
        
        [JsonPropertyName("description")]
        public string? description { get; set; }
    }
}
