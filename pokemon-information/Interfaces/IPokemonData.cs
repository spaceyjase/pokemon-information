using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeApiNet;

namespace PokemonInformation.Interfaces
{
  public interface IPokemonData
  {
    Task<Models.PokemonResult> GetPokemonInformation(string name);
  }
}
