using Microsoft.Extensions.AI;
using OllamaApi.Models;
using OpenAI;
using ChatResponse = OllamaApi.Models.ChatResponse;

namespace OllamaApi.Providers
{
    /// <summary>
    /// Provides chat functionality using the OpenAI API, implementing the IChatProvider interface.
    /// </summary>
    public class OpenAIProvider : IChatProvider
    {
        private readonly IChatClient _client;

        public string Name => "openai";

        public OpenAIProvider(IConfiguration config)
        {
            var key = config["OpenAI:OpenAIKey"]
                ?? throw new Exception("OpenAIKey Missing");

            var model = config["OpenAI:OpenAIModelName"] 
                ?? throw new Exception("OpenAIModelName Missing");

            _client = new OpenAIClient(key)
                .GetChatClient(model)
                .AsIChatClient();
        }

        public async Task<ChatResponse> SendAsync(ChatRequest request)
        {
            var result = await _client.GetResponseAsync(request.Prompt);

            return new ChatResponse
            {
                Content = result.Text,
                Provider = Name
            };
        }
    }
}