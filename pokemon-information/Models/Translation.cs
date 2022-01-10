using System.Text.Json.Serialization;

namespace PokemonInformation.Models
{
  public record Contents
  {
    [JsonPropertyName("translated")]
    public string Translated { get; set; }
  }

  public record Translation
  {
    [JsonPropertyName("contents")]
    public Contents Contents { get; set; }
  }
}
