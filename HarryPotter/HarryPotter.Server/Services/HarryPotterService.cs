using System.Text.Json;
using HarryPotter.Server.Models;
using HarryPotter.Server.Interfaces;

namespace HarryPotter.Server.Services
{
    //as far as im aware this doesnt ever run
    //but im just updating incase actually used
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
        public async Task<List<Spell>> GetSpellsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("spells");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Spell>? spells = JsonSerializer.Deserialize<List<Spell>>(json);

            return spells ?? new List<Spell>();
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("https://api.potterdb.com/v1/movies");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                List<Movie>? movies = JsonSerializer.Deserialize<List<Movie>>(json);

                return movies ?? new List<Movie>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Movie>();
            }
        }
    }
}
