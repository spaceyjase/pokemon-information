using System.Threading.Tasks;
using PokemonInformation.Models;

namespace PokemonInformation.Repository
{
  public interface IPokemonRepository
  {
    Task<PokemonResult> GetPokemon(string name);
  }
}
