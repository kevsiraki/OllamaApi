using OllamaApi.Providers;
using OllamaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add controllers to the service collection
builder.Services.AddHttpClient(); // Dependency injection for HttpClient

builder.Services.AddSingleton<IChatProvider, OpenAIProvider>(); // Register OpenAIProvider as a singleton service for IChatProvider
builder.Services.AddSingleton<IChatProvider, OllamaProvider>(); // Register OllamaProvider as a singleton service for IChatProvider
builder.Services.AddSingleton<IChatProvider, DeepSeekProvider>(); // Register DeepSeekProvider as a singleton service for IChatProvider

builder.Services.AddSingleton<ChatService>(); // Register ChatService as a singleton service, which will be injected into the controller(s) that require it

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();