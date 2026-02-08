namespace OllamaApi.Models
{
    /// <summary>
    /// This class represents a unified chat response that contains the content of the response and the provider that generated it.
    /// Its purpose is to provide a consistent response model for the chat endpoints for any AI model, 
    /// regardless of the underlying provider used to generate the response.
    /// </summary>
    public class ChatResponse
    {
        public string Content { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
    }

}
