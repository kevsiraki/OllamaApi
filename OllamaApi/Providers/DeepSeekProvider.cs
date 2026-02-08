using Microsoft.Extensions.AI;
using OllamaApi.Models;
using OpenAI;
using System.ClientModel;
using ApiChatResponse = OllamaApi.Models.ChatResponse;

namespace OllamaApi.Providers
{
    /// <summary>
    /// Provides chat functionality using the DeepSeek API, implementing the IChatProvider interface.
    /// It uses the OpenAI client to interact with the DeepSeek API, allowing for seamless integration and response generation based on chat requests.
    /// </summary>
    public class DeepSeekProvider : IChatProvider
    {
        private readonly IChatClient _client;

        public string Name => "deepseek";

        public DeepSeekProvider(IConfiguration config)
        {
            var apiKey = config["DeepSeek:DeepSeekApiKey"]
                ?? throw new Exception("DeepSeekApiKey missing");

            var baseUrl = config["DeepSeek:DeepSeekBaseUrl"]
                ?? throw new Exception("DeepSeekBaseUrl missing");

            var model = config["DeepSeek:DeepSeekModel"]
                ?? "deepseek-chat";

            var openAI = new OpenAIClient(
                new ApiKeyCredential(apiKey),
                new OpenAIClientOptions
                {
                    Endpoint = new Uri(baseUrl)
                });

            _client = openAI
                .GetChatClient(model)
                .AsIChatClient();
        }

        public async Task<ApiChatResponse> SendAsync(ChatRequest request)
        {
            var result = await _client.GetResponseAsync(request.Prompt);

            return new ApiChatResponse
            {
                Content = result.Text,
                Provider = Name
            };
        }
    }
}