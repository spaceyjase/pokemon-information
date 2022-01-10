using System.Threading.Tasks;
using PokemonInformation.Models;

namespace PokemonInformation.Repository
{
  /// <summary>
  /// Wrapper around the PokeApi.
  /// </summary>
  public interface IPokemonRepository
  {
    /// <summary>
    /// Return a pokemon with the given name, otherwise null.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>PokemonResult.</returns>
    Task<PokemonResult> GetPokemon(string name);
  }
}
