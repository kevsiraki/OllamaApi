namespace OllamaApi.Models
{
    /// <summary>
    /// Represents a response from the Ollama API.
    /// Used for normalizing the API response to a clean format.
    /// </summary>
    public class OllamaApiResponse
    {
        public string response { get; set; } = string.Empty;
    }
}
