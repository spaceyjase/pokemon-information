using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PokemonInformation.Repository;

namespace PokemonInformation.Data
{
  public class PokemonData : IPokemonData
  {
    private readonly ILogger<PokemonData> _logger;
    private readonly IPokemonRepository _repository;

    public PokemonData(ILogger<PokemonData> logger, IPokemonRepository repository)
    {
      _logger = logger;
      _repository = repository;
    }

    public async Task<Models.PokemonResult> GetPokemonInformation(string name)
    {
      return await _repository.GetPokemon(name);
    }
  }
}
