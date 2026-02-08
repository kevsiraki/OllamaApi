namespace OllamaApi.Models
{
    /// <summary>
    /// This class represents a chat request that contains a prompt. 
    /// It is used as the input model for the chat endpoints in both the OpenAIChatController and OllamaChatController.
    /// </summary>

    public class ChatRequest
    {
        public string Provider { get; set; } = string.Empty; // openai, ollama, deepseek
        public string Prompt { get; set; } = string.Empty;
    }
}