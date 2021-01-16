using Microsoft.AspNetCore.Mvc;

using Moq;

using TestImplementationCoupling.Services.Abstractions;
using TestImplementationCoupling.WebApi.Controllers;

using Xunit;

namespace TestImplementationCoupling.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void Get_ServiceReturnsNumber_CorrectResponseProvided()
        {
            // ARRANGE
            string word = "word";
            int numberOfCharacters = 4;
            string expectedResponse = $"The word '{word}' contains {numberOfCharacters} characters.";
            Mock<ICountCharactersService> mock = new Mock<ICountCharactersService>();
            mock
                .Setup(m => m.CountCharacters(It.IsAny<string>()))
                .Returns(numberOfCharacters);
            DummyController controller = new DummyController(mock.Object);

            // ACT
            IActionResult response = controller.Get(word);

            // ASSERT
            Assert.IsType<OkObjectResult>(response);
            OkObjectResult okResponse = (OkObjectResult)response;
            Assert.IsType<string>(okResponse.Value);
            string content = (string)okResponse.Value;
            Assert.Equal(expectedResponse, content);
        }
    }
}
