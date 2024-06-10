
namespace Frontend.Api.Services
{
    public class LocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;

        public LocalStorageService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<List<T>> GetList<T>(string key)
        {
            var result = await _localStorageService.GetItemAsync<List<T>>(key);
            return result ?? [];
        }

        public async Task SetList<T>(string key, List<T> lst)
        {
            await _localStorageService.SetItemAsync(key, lst);
        }
    }
}
