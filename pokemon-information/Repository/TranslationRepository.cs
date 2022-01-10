using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PokemonInformation.Models;

namespace PokemonInformation.Repository
{
  public class TranslationRepository: ITranslationRepository
  {
    private readonly ILogger<TranslationRepository> _logger;

    public TranslationRepository(ILogger<TranslationRepository> logger)
    {
      _logger = logger;
    }

    public async Task<string> GetYodaTranslationForDescription(string description)
    {
      var result = string.Empty;
      try
      {
        using HttpClient httpClient = new();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.funtranslations.com/translate/yoda.json?text={description}");
        var response = await httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
          var translation = await response.Content.ReadAsAsync<Translation>();
          result = translation.Contents.Translated;
        }
      }
      catch (HttpRequestException ex)
      {
        _logger.LogWarning(ex.Message);
      }

      return result;
    }

    public async Task<string> GetShakespeareTranslation(string description)
    {
      var result = string.Empty;
      try
      {
        using HttpClient httpClient = new();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.funtranslations.com/translate/shakespeare.json?text={description}");
        var response = await httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
          var translation = await response.Content.ReadAsAsync<Translation>();
          result = translation.Contents.Translated;
        }
      }
      catch (HttpRequestException ex)
      {
        _logger.LogWarning(ex.Message);
      }

      return result;
    }

  }
}
