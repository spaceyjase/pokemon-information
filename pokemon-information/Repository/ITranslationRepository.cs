using System.Threading.Tasks;

namespace PokemonInformation.Repository
{
  /// <summary>
  /// Wrapper around translation API endpoints.
  /// </summary>
  public interface ITranslationRepository
  {
    /// <summary>
    /// Grab Yoda-ish for the given description.
    /// </summary>
    /// <param name="description"></param>
    /// <returns>Yoda translation (or null).</returns>
    Task<string> GetYodaTranslationForDescription(string description);

    /// <summary>
    /// Get Shakespeare translation for the given description.
    /// </summary>
    /// <param name="description"></param>
    /// <returns>Shakespeare translation (or null).</returns>
    Task<string> GetShakespeareTranslation(string description);
  }
}
