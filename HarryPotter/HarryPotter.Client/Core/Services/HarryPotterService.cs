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
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{BaseAddress}characters");
                Console.WriteLine(response);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                List<Character>? characters = JsonSerializer.Deserialize<List<Character>>(json);

                return characters ?? new List<Character>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Character>();
            }
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
        //this is the most horrendous code
        public async Task<List<Movie>> GetMoviesAsync()
        {
            try
            {
                //get the json
                HttpResponseMessage response = await _httpClient.GetAsync("https://api.potterdb.com/v1/movies");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();


                //parse jspn
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                //try to find the data we want
                //3 diff cases copilot suggested as far as im aware only one should be needed, but i aint touching it
                JsonElement arrayElement;
                if (root.ValueKind == JsonValueKind.Array)
                {
                    arrayElement = root;
                }
                else if (root.TryGetProperty("data", out var data) && data.ValueKind == JsonValueKind.Array)
                {
                    arrayElement = data;
                }
                else if (root.TryGetProperty("movies", out var moviesProp) && moviesProp.ValueKind == JsonValueKind.Array)
                {
                    arrayElement = moviesProp;
                }


                //cry
                //copilot did ts and it works im not touching it
                else
                {
                    JsonElement? firstArray = null;
                    foreach (var prop in root.EnumerateObject())
                    {
                        if (prop.Value.ValueKind == JsonValueKind.Array)
                        {
                            firstArray = prop.Value;
                            break;
                        }
                    }
                    if (firstArray.HasValue)
                    {
                        arrayElement = firstArray.Value;
                    }
                    else
                    {
                        return new List<Movie>();
                    }
                }

                var moviesList = new List<Movie>();
                //just manually put the data into the list because the json is a mess and i dont want to deal with it
                foreach (var item in arrayElement.EnumerateArray())
                {
                    try
                    {
                        string? id = null;
                        if (item.TryGetProperty("id", out var idProp))
                        {
                            id = idProp.ValueKind == JsonValueKind.String ? idProp.GetString() : idProp.GetRawText();
                        }

                        JsonElement source = item;
                        if (item.TryGetProperty("attributes", out var attr) && attr.ValueKind == JsonValueKind.Object)
                        {
                            source = attr;
                        }

                        string? title = source.TryGetProperty("title", out var t) ? t.GetString() : null;
                        string? poster = source.TryGetProperty("poster", out var p) ? p.GetString() : null;
                        string? summary = source.TryGetProperty("summary", out var s) ? s.GetString() : null;
                        string? releaseDate = source.TryGetProperty("release_date", out var rd) ? rd.GetString() : null;

                        moviesList.Add(new Movie
                        {
                            Id = id,
                            Title = title,
                            Poster = poster,
                            Synopsis = summary,
                            ReleaseDate = releaseDate
                        });
                    }
                    catch
                    {
                        // ignore malformed item
                    }
                }

                return moviesList;
            }

            // this shouldnt run if things work, unfortunately it does very often
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Movie>();
            }
        }
    }
}
