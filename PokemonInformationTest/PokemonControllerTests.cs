using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using PokemonInformation.Controllers;
using PokemonInformation.Data;
using PokemonInformation.Models;

namespace PokemonInformationTest
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task PokemonInformation_Returns_Expected_Data()
    {
      var mockData = new Mock<IPokemonData>();
      mockData.Setup(x => x.GetPokemonInformation("mewtwo")).Returns(() => Task.FromResult(
        new PokemonResult("mewtwo", "bar", true)));

      var controller = new PokemonController(new NullLogger<PokemonController>(), mockData.Object);

      var result = await controller.Get("mewtwo").ConfigureAwait(false) as OkObjectResult;

      mockData.Verify(mock => mock.GetPokemonInformation(It.IsAny<string>()), Times.Once);
      Assert.IsTrue(result is { StatusCode: 200 });
    }

    [Test]
    public async Task PokemonInformation_Returns_404()
    {
      var mockData = new Mock<IPokemonData>();
      mockData.Setup(x => x.GetPokemonInformation(It.IsAny<string>())).Returns(() => Task.FromResult<PokemonResult>(null));

      var controller = new PokemonController(new NullLogger<PokemonController>(), mockData.Object);

      var result = await controller.Get("foo").ConfigureAwait(false) as NotFoundResult;

      mockData.Verify(mock => mock.GetPokemonInformation(It.IsAny<string>()), Times.Once);
      Assert.IsTrue(result is { StatusCode: 404 });
    }
  }
}