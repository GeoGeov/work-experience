using System.Text.Json.Serialization;

namespace HarryPotter.Server.Models
{
    public class Spell
    {
        [JsonPropertyName("id")]
        public string? id { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }
        
        [JsonPropertyName("description")]
        public string? description { get; set; }
    }
}
