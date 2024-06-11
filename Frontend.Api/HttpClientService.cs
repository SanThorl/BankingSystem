
namespace Frontend.Api;

public class HttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<T>> JsonToObjectList<T>(string url)
    {
        var result = await _httpClient.GetFromJsonAsync<T[]>(url);
        return result!.ToList();
    }
}