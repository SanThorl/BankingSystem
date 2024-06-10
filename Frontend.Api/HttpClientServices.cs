
namespace Frontend.Api
{
    public class HttpClientServices
    {
        private readonly HttpClient _httpClient;

        public HttpClientServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<T>> JsonToObjectList<T>(string url)
        {
            var result = await _httpClient.GetFromJsonAsync<T[]>(url);
            return result!.ToList();
        }
    }
