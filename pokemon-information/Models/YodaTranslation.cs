using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokemonInformation.Models
{
  public record Contents
  {
    [JsonPropertyName("translated")]
    public string Translated { get; set; }
  }

  public record YodaTranslation
  {
    [JsonPropertyName("contents")]
    public Contents Contents { get; set; }
  }
}
