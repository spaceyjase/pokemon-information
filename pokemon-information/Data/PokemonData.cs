using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PokeApiNet;
using PokemonInformation.Interfaces;

namespace PokemonInformation.Data
{
  public class PokemonData : IPokemonData
  {
    private readonly PokeApiClient pokeClient = new PokeApiClient();
    private readonly ILogger<PokemonData> _logger;

    public PokemonData(ILogger<PokemonData> logger)
    {
      _logger = logger;
    }

    public async Task<Models.PokemonResult> GetPokemonInformation(string name)
    {
      try
      {
        var pokemon = await pokeClient.GetResourceAsync<Pokemon>(name).ConfigureAwait(false);
        var species = await pokeClient.GetResourceAsync<PokemonSpecies>(pokemon.Id).ConfigureAwait(false);

        return new Models.PokemonResult(
          pokemon.Name,
          species.FlavorTextEntries.First(s => s.Language.Name == "en").FlavorText, // Spec says any English flavour
          species.Habitat.Name,
          species.IsLegendary
        );
      }
      catch (HttpRequestException ex)
      {
        _logger.LogWarning(ex.Message);
      }

      return null;
    }
  }
}
