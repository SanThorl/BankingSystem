using Refit;
using System.Reflection.Metadata.Ecma335;

namespace BlazorFrontend.App.Services;

public static class RefitExtentions
{
    public static IHttpClientBuilder AddRefitService<T>(this IServiceCollection services, IConfiguration configuration) where T : class
    {
        var httpClientBuilder = services.AddRefitClient<T>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:44376"));
        return httpClientBuilder;
    }
}
