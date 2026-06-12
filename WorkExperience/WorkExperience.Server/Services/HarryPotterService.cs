using System.Text.Json;
using WorkExperience.Server.Models;
using WorkExperience.Server.Interfaces;

namespace WorkExperience.Server.Services
{
    public class HarryPotterService : IHarryPotterService
    {
        private readonly HttpClient _httpClient;

        public HarryPotterService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("characters");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(json);

            return characters ?? new List<Character>();
        }
    }
}
