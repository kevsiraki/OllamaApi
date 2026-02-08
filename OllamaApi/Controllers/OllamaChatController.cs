using Microsoft.AspNetCore.Mvc;
using OllamaApi.Attributes;
using OllamaApi.Models;

namespace OllamaApi.Controllers
{

    /// <summary>
    /// This controller provides an endpoint for interacting with Ollama's chat models.
    /// 
    /// Source: https://ollama.com/docs/api#chat-completions
    /// </summary>

    [ApiKey]
    [ApiController]
    [Route("api/[controller]")]
    public class OllamaChatController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public OllamaChatController(IHttpClientFactory factory, IConfiguration config)
        {
            _httpClient = factory.CreateClient();
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var ollamaRequest = new
            {
                model = _config["OllamaModel"] ?? throw new Exception("OllamaModel missing"),
                prompt = request.Prompt,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync(
                _config["OllamaChatUri"] ?? throw new Exception("OllamaChatUri missing"),
                ollamaRequest);

            var result = await response.Content.ReadAsStringAsync();

            return Ok(result);
        }
    }
}