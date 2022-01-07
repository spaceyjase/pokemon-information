using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonInformation.Models
{
  public record PokemonResult(string Name, string Description, string Habitat, bool IsLegendary);
}
