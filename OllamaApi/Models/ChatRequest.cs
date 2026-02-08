namespace OllamaApi.Models
{

    /// <summary>
    /// This class represents a chat request that contains a prompt. 
    /// It is used as the input model for the chat endpoints in both the OpenAIChatController and OllamaChatController.
    /// </summary>

    public class ChatRequest
    {
        public string Prompt { get; set; }
    }
}
