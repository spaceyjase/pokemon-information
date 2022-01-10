using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PokeApiNet;
using PokemonInformation.Models;

namespace PokemonInformation.Repository
{
  public class PokemonRepository : IPokemonRepository, IDisposable
  {
    private readonly PokeApiClient pokeClient = new();
    private readonly ILogger<PokemonRepository> _logger;

    public PokemonRepository(ILogger<PokemonRepository> logger)
    {
      _logger = logger;
    }

    public async Task<PokemonResult> GetPokemon(string name)
    {
      try
      {
        var pokemon = await pokeClient.GetResourceAsync<Pokemon>(name).ConfigureAwait(false);
        var species = await pokeClient.GetResourceAsync<PokemonSpecies>(pokemon.Id).ConfigureAwait(false);

        return new PokemonResult(pokemon.Name, species.Habitat.Name, species.IsLegendary)
        {
          Description = species.FlavorTextEntries.First(s => s.Language.Name == "en").FlavorText, // Spec says any English flavour; just grab the first.
        };
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
      GC.SuppressFinalize(this);
    }
  }
}
