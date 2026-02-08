using Microsoft.AspNetCore.Mvc;
using OllamaApi.Attributes;
using OllamaApi.Models;
using OllamaApi.Services;

namespace OllamaApi.Controllers
{
    /// <summary>
    /// This controller provides an endpoint for interacting with various chat providers to generate responses based on user prompts.
    /// </summary>
    [ApiKey]
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _service;

        public ChatController(ChatService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Chat(ChatRequest request)
        {
            var result = await _service.SendAsync(request);

            return Ok(result);
        }
    }
}