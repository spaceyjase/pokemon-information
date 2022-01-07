using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonInformation.Interfaces
{
  public interface IPokemonData
  {
    IEnumerable<WeatherForecast> Data { get; }
  }
}
