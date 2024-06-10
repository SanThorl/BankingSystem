using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Api.Feature.User;

public class UserService
{
    private readonly ILocalStorageService _localStorageService;

    public UserService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<UserListResponseModel> GetUsers(int pageNo, int pageSize)
    {
        UserListResponseModel model = new UserListResponseModel();
        var query = await _localStorageService.GetList
    }
}
