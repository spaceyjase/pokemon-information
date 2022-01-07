using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeApiNet;
using PokemonInformation.Interfaces;

namespace PokemonInformation.Data
{
  public class PokemonData : IPokemonData
  {
    readonly PokeApiClient pokeClient = new PokeApiClient();

    public async Task<Models.PokemonResult> GetPokemonInformation(string name)
    {
      var pokemon = await pokeClient.GetResourceAsync<Pokemon>(name).ConfigureAwait(false);
      var species = await pokeClient.GetResourceAsync<PokemonSpecies>(pokemon.Id).ConfigureAwait(false);

      return new Models.PokemonResult(
        pokemon.Name,
        species.FlavorTextEntries.First(s => s.Language.Name == "en").FlavorText, // Assuming English...
        species.Habitat.Name,
        species.IsLegendary
      );
    }
  }
}
