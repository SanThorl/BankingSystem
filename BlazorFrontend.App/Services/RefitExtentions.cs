using Refit;
using System.Reflection.Metadata.Ecma335;

namespace BlazorFrontend.App.Services;

public static class RefitExtentions
{
    public static IHttpClientBuilder AddRefitService<T>(this IServiceCollection services, IConfiguration configuration) where T : class
    {
#warning Uri gaw BeckendApi kaw na la ai hpe ganing hku na port gaba bai lang a ta?(44303)
        var httpClientBuilder = services.AddRefitClient<T>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7276"));
        return httpClientBuilder;
    }
}
