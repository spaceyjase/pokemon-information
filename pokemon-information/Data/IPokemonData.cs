using System.Threading.Tasks;

namespace PokemonInformation.Data
{
  public interface IPokemonData
  {
    Task<Models.PokemonResult> GetPokemonInformation(string name);
  }
}
