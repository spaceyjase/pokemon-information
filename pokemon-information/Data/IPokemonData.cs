using System.Threading.Tasks;

namespace PokemonInformation.Data
{
  public interface IPokemonData
  {
    Task<Models.PokemonResult> GetPokemonInformation(string pokemonName);
    Task<Models.PokemonResult> GetPokemonInformationWithTranslation(string pokemonName);
  }
}
