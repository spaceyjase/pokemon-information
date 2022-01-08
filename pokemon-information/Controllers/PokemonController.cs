using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonInformation.Data;

namespace PokemonInformation.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PokemonController : ControllerBase
  {
    private readonly ILogger<PokemonController> _logger;
    private readonly IPokemonData _data;

    public PokemonController(ILogger<PokemonController> logger, IPokemonData data)
    {
      _logger = logger;
      _data = data;
    }

    [HttpGet("{pokemonName}")]
    public async Task<IActionResult> Get(string pokemonName)
    {
      _logger.LogInformation(pokemonName);

      var result = await _data.GetPokemonInformation(pokemonName).ConfigureAwait(false);
      return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("translated/{pokemonName}")]
    public async Task<IActionResult> GetTranslated(string pokemonName)
    {
      _logger.LogInformation(pokemonName);

      // TODO: translated information
      var result = await _data.GetPokemonInformation(pokemonName).ConfigureAwait(false);

      return result != null ? Ok(result) : NotFound();
    }
  }
}
