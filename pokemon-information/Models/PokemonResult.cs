namespace PokemonInformation.Models
{
  public record PokemonResult(string Name, string Habitat, bool IsLegendary)
  {
    private readonly string description;

    public string Description
    {
      get => description;
      init => description = value.Replace("\n", " ").Replace("\f", " ");
    }
  }
}
