using OllamaApi.Models;

namespace OllamaApi.Providers
{
    /// <summary>
    /// Provides chat functionality using the Ollama API, implementing the IChatProvider interface.
    /// </summary>
    public class OllamaProvider : IChatProvider
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public string Name => "ollama";

        public OllamaProvider(IHttpClientFactory factory, IConfiguration config)
        {
            _http = factory.CreateClient();
            _config = config;
        }

        public async Task<ChatResponse> SendAsync(ChatRequest request)
        {
            var ollamaUri = _config["Ollama:OllamaChatUri"]
                ?? throw new Exception("OllamaChatUri missing");

            var model = _config["Ollama:OllamaModel"]
                ?? throw new Exception("OllamaModel missing");

            var ollamaRequest = new
            {
                model = model,
                prompt = request.Prompt,
                stream = false
            };

            var response = await _http.PostAsJsonAsync(
                ollamaUri,
                ollamaRequest
            );

            response.EnsureSuccessStatusCode();

            var ollamaResponse =
                await response.Content.ReadFromJsonAsync<OllamaApiResponse>();


            return new ChatResponse
            {
                Content = ollamaResponse.response,
                Provider = Name
            };
        }
    }
}