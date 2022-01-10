using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using PokemonInformation.Data;
using PokemonInformation.Models;
using PokemonInformation.Repository;

namespace PokemonInformationTest
{
  public class DataTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task PokemonData_Returns_Pokemon_No_Translation()
    {
      var mockPokemonRepository = new Mock<IPokemonRepository>();
      mockPokemonRepository.Setup(x => x.GetPokemon("bulbasaur"))
        .Returns(() => Task.FromResult(new PokemonResult("bulbasaur", "foo", "bar", false)));

      var mockTranslationRepository = new Mock<ITranslationRepository>();
      mockTranslationRepository.Setup(x => x.GetYodaTranslationForDescription(It.IsAny<string>())).Returns(string.Empty);
      mockTranslationRepository.Setup(x => x.GetShakespeareTranslation(It.IsAny<string>())).Returns(string.Empty);

      var data = new PokemonData(new NullLogger<PokemonData>(), mockPokemonRepository.Object, mockTranslationRepository.Object);

      var result = await data.GetPokemonInformationWithTranslation("bulbasaur").ConfigureAwait(false);

      mockTranslationRepository.Verify(mock => mock.GetYodaTranslationForDescription(It.IsAny<string>()), Times.Never);
      mockTranslationRepository.Verify(mock => mock.GetShakespeareTranslation(It.IsAny<string>()), Times.Once);

      Assert.AreEqual(result.Description, "foo");
    }

    [Test]
    public async Task PokemonData_Returns_Yoda_Translation_IsLegendary()
    {
      var mockPokemonRepository = new Mock<IPokemonRepository>();
      mockPokemonRepository.Setup(x => x.GetPokemon("mewtwo"))
        .Returns(() => Task.FromResult(new PokemonResult("mewtwo", "", "bar", true)));

      var mockTranslationRepository = new Mock<ITranslationRepository>();
      mockTranslationRepository.Setup(x => x.GetYodaTranslationForDescription(It.IsAny<string>())).Returns("yoda");

      var data = new PokemonData(new NullLogger<PokemonData>(), mockPokemonRepository.Object, mockTranslationRepository.Object);

      _ = await data.GetPokemonInformationWithTranslation("mewtwo").ConfigureAwait(false);

      mockTranslationRepository.Verify(mock => mock.GetYodaTranslationForDescription(It.IsAny<string>()), Times.Once);
      mockTranslationRepository.Verify(mock => mock.GetShakespeareTranslation(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task PokemonData_Returns_Yoda_Translation_For_Cave()
    {
      var mockPokemonRepository = new Mock<IPokemonRepository>();
      mockPokemonRepository.Setup(x => x.GetPokemon("zubat"))
        .Returns(() => Task.FromResult(new PokemonResult("zubat", "", "cave", false)));

      var mockTranslationRepository = new Mock<ITranslationRepository>();
      mockTranslationRepository.Setup(x => x.GetYodaTranslationForDescription(It.IsAny<string>())).Returns("yoda");

      var data = new PokemonData(new NullLogger<PokemonData>(), mockPokemonRepository.Object, mockTranslationRepository.Object);

      _ = await data.GetPokemonInformationWithTranslation("zubat").ConfigureAwait(false);

      mockTranslationRepository.Verify(mock => mock.GetYodaTranslationForDescription(It.IsAny<string>()), Times.Once);
      mockTranslationRepository.Verify(mock => mock.GetShakespeareTranslation(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task PokemonData_Returns_Shakespeare_Translation()
    {
      var mockPokemonRepository = new Mock<IPokemonRepository>();
      mockPokemonRepository.Setup(x => x.GetPokemon("charmander"))
        .Returns(() => Task.FromResult(new PokemonResult("charmander", "", "mountain", false)));

      var mockTranslationRepository = new Mock<ITranslationRepository>();

      var data = new PokemonData(new NullLogger<PokemonData>(), mockPokemonRepository.Object, mockTranslationRepository.Object);

      _ = await data.GetPokemonInformationWithTranslation("charmander").ConfigureAwait(false);

      mockTranslationRepository.Verify(mock => mock.GetYodaTranslationForDescription(It.IsAny<string>()), Times.Never);
      mockTranslationRepository.Verify(mock => mock.GetShakespeareTranslation(It.IsAny<string>()), Times.Once);
    }
  }
}