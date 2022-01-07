using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonInformation.Interfaces;

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
    public IEnumerable<WeatherForecast> Get(string pokemonName)
    {
      _logger.LogInformation(pokemonName);

      return _data.Data;
    }

    [HttpGet("translated/{pokemonName}")]
    public IEnumerable<WeatherForecast> GetTranslated(string pokemonName)
    {
      _logger.LogInformation(pokemonName);

      return _data.Data;
    }
  }
}
