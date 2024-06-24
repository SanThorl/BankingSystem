
using BackendServices.Features.User;
using Frontend.Api.Feature.Account;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44376") });
//builder.Services.AddScoped(sp => new HttpClient());
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7276") });
builder.Services.AddScoped<HttpClientService>();
builder.Services.AddSingleton<Config>();


builder.Services.AddRefitService<IUserApi>(builder.Configuration);
builder.Services.AddRefitService<IAccountApi>(builder.Configuration);

builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});

builder.Services.AddScoped<LocalStorageService>();

builder.Services.AddScoped<LocalStorageUserService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<InjectService>();

await builder.Build().RunAsync();
