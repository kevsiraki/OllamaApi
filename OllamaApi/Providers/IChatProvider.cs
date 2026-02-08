using Microsoft.Extensions.AI;
using OllamaApi.Models;
using ChatResponse = OllamaApi.Models.ChatResponse;

namespace OllamaApi.Providers
{
    /// <summary>
    /// The IChatProvider interface defines a contract for chat providers that can generate responses based on chat requests.
    /// </summary>
    public interface IChatProvider
    {
        string Name { get; }
        Task<ChatResponse> SendAsync(ChatRequest request);
    }
}