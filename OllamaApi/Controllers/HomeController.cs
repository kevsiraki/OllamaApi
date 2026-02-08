using Microsoft.AspNetCore.Mvc;
using OllamaApi.Attributes;
using OllamaApi.Models;
using OllamaApi.Services;

namespace OllamaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        private readonly ChatService _service;

        public HomeController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Home(ChatRequest request)
        {
            return Ok("AI Gateway Services Are Running.");
        }
    }
}
