using System.Text.Json.Serialization;

namespace WorkExperience.Server.Models
{
    public class Character
    {
        [JsonPropertyName("actor")]
        public string? Actor { get; set; }

        [JsonPropertyName("alive")]
        public bool? Alive { get; set; }

        [JsonPropertyName("alternate_actors")]
        public List<string>? AlternateActors { get; set; }

        [JsonPropertyName("alternate_names")]
        public List<string>? AlternateNames { get; set; }

        [JsonPropertyName("ancestry")]
        public string? Ancestry { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [JsonPropertyName("eyeColour")]
        public string? EyeColour { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("hairColour")]
        public string? HairColour { get; set; }

        [JsonPropertyName("house")]
        public string? House { get; set; }

        [JsonPropertyName("hogwartsStaff")]
        public bool? HogwartsStaff { get; set; }

        [JsonPropertyName("hogwartsStudent")]
        public bool? HogwartsStudent { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("patronus")]
        public string? Patronus { get; set; }

        [JsonPropertyName("species")]
        public string? Species { get; set; }

        [JsonPropertyName("wand")]
        public Wands? Wand { get; set; }

        [JsonPropertyName("wizard")]
        public bool? Wizard { get; set; }

        [JsonPropertyName("yearOfBirth")]
        public int? YearOfBirth { get; set; }
    }
}
