
using Microsoft.AspNetCore.Mvc;

using TestImplementationCoupling.Services.Abstractions;

namespace TestImplementationCoupling.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {
        private readonly ICountCharactersService _service;

        public DummyController(ICountCharactersService service)
        {
            _service = service;
        }

        [HttpGet("/{word}")]
        public IActionResult Get([FromRoute] string word)
        {
            int numberOfCharacters = _service.CountCharacters(word);
            string response = $"The word '{word}' contains {numberOfCharacters} characters.";

            return Ok(response);
        }
    }
}
