using System.Text.Json;
using WorkExperience.Client.Core.Models;

namespace WorkExperience.Client.Core.Services
{
    public class HarryPotterService
    {
        private readonly HttpClient _httpClient;

        private const string BaseAddress = "harrypotter/";

        public HarryPotterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseAddress}characters");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(json);

            return characters ?? new List<Character>();
        }

    }
}
