
namespace Frontend.Api.Feature.Account;

public class AccountService
{
    private readonly ILocalStorageService _localStorageService;

    public AccountService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    //public async Task<AccountListResponseModel> GetAccounts()
    //{

    //}
}
