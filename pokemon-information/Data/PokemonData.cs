using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PokemonInformation.Models;
using PokemonInformation.Repository;

namespace PokemonInformation.Data
{
  public class PokemonData : IPokemonData
  {
    private readonly ILogger<PokemonData> _logger;
    private readonly IPokemonRepository _pokemonRepository;
    private readonly ITranslationRepository _translationRepository;

    public PokemonData(ILogger<PokemonData> logger, IPokemonRepository repository, ITranslationRepository translationRepository)
    {
      _logger = logger;
      _pokemonRepository = repository;
      _translationRepository = translationRepository;
    }

    public async Task<PokemonResult> GetPokemonInformation(string pokemonName)
    {
      _logger.LogDebug($"{nameof(GetPokemonInformation)}: {pokemonName}");
      return await _pokemonRepository.GetPokemon(pokemonName);
    }

    public async Task<PokemonResult> GetPokemonInformationWithTranslation(string pokemonName)
    {
      _logger.LogDebug($"{nameof(GetPokemonInformationWithTranslation)}: {pokemonName}");
      var pokemon = await GetPokemonInformation(pokemonName);

      if (pokemon == null)
      {
        return null;
      }

      if (pokemon.IsLegendary || pokemon.Habitat == "cave")
      {
        var yodaTranslation = await _translationRepository.GetYodaTranslationForDescription(pokemon.Description);
        return !string.IsNullOrEmpty(yodaTranslation) ? new PokemonResult(pokemon.Name, pokemon.Habitat, pokemon.IsLegendary)
        {
          Description = yodaTranslation
        } : pokemon;
      }

      var shakespeareTranslation = _translationRepository.GetShakespeareTranslation(pokemon.Description);
      return !string.IsNullOrEmpty(shakespeareTranslation) ? new PokemonResult(pokemon.Name, pokemon.Habitat, pokemon.IsLegendary)
      {
        Description = shakespeareTranslation
      } : pokemon;
    }
  }
}
