using NUnit.Framework;
using PokemonInformation.Models;

namespace PokemonInformationTest
{
  class PokemonResultTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PokemonData_Description_IsCorrect()
    {
      const string expected = "hello world foobar";
      PokemonResult result = new("mewtwo", "cave", true)
      {
        Description = "hello\nworld\ffoobar"
      };

      Assert.AreEqual(expected, result.Description);
    }
  }
}
