﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PokeApiNet;
using PokemonInformation.Models;

namespace PokemonInformation.Repository
{
  /// <summary>
  /// Wrapper around the PokeApi.
  /// </summary>
  public class PokemonRepository : IPokemonRepository, IDisposable
  {
    private readonly PokeApiClient pokeClient = new();
    private readonly ILogger<PokemonRepository> _logger;

    public PokemonRepository(ILogger<PokemonRepository> logger)
    {
      _logger = logger;
    }

    /// <summary>
    /// Return a pokemon with the given name, otherwise null.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>PokemonResult.</returns>
    public async Task<PokemonResult> GetPokemon(string name)
    {
      try
      {
        var pokemon = await pokeClient.GetResourceAsync<Pokemon>(name).ConfigureAwait(false);
        var species = await pokeClient.GetResourceAsync<PokemonSpecies>(pokemon.Id).ConfigureAwait(false);

        return new PokemonResult(
          pokemon.Name,
          species.FlavorTextEntries.First(s => s.Language.Name == "en").FlavorText, // Spec says any English flavour; just grab the first.
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

    public void Dispose()
    {
      pokeClient?.Dispose();
    }
  }
}
