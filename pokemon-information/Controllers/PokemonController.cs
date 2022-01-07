using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonInformation.Interfaces;
using PokemonInformation.Models;

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
    public PokemonResult Get(string pokemonName)
    {
      _logger.LogInformation(pokemonName);

      return _data.GetPokemonInformation(pokemonName).Result;
    }

    [HttpGet("translated/{pokemonName}")]
    public PokemonResult GetTranslated(string pokemonName)
    {
      _logger.LogInformation(pokemonName);

      // TODO: empty string?
      // TODO: translated information

      return _data.GetPokemonInformation(pokemonName).Result;
    }
  }
}
