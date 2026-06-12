using Microsoft.AspNetCore.Mvc;
using WorkExperience.Server.Interfaces;

namespace WorkExperience.Server.Controllers
{
    [ApiController]
    [Route("harrypotter/")]
    public class HarryPotterController : ControllerBase
    {
        private readonly IHarryPotterService _harryPotterService;

        public HarryPotterController(IHarryPotterService harryPotterService)
        {
            _harryPotterService = harryPotterService;
        }

        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            List<Models.Character> characters = await _harryPotterService.GetCharactersAsync();
            return Ok(characters);
        }
    }
}
