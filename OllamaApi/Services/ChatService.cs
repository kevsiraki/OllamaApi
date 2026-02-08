using OllamaApi.Models;
using OllamaApi.Providers;

namespace OllamaApi.Services
{
    /// <summary>
    /// Provides chat functionality by managing multiple chat providers and sending chat requests to the appropriate
    /// provider.
    /// </summary>
    public class ChatService
    {
        private readonly Dictionary<string, IChatProvider> _providers;

        public ChatService(IEnumerable<IChatProvider> providers)
        {
            _providers = providers.ToDictionary(p => p.Name.ToLower());
        }

        public Task<ChatResponse> SendAsync(ChatRequest request)
        {
            if (!_providers.TryGetValue(request.Provider.ToLower(), out var provider))
                throw new Exception("Provider not found");

            return provider.SendAsync(request);
        }
    }
}