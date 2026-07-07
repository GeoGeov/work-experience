using HarryPotter.Client.Core.Models;
using System.Text.Json;

namespace HarryPotter.Client.Core.Services
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
        public async Task<List<Spell>> GetSpellsAsync()
        {
            try {
                HttpResponseMessage response = await _httpClient.GetAsync($"{BaseAddress}spells");
                Console.WriteLine(response);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                List<Spell>? spells = JsonSerializer.Deserialize<List<Spell>>(json);

                return spells ?? new List<Spell>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Spell>();
            }

            
        }
    }
}
