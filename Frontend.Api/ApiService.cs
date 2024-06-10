using Frontend.Api.Feature.User;
using Frontend.Api.Services;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Api;

public class ApiService
{
    private readonly EnumApiType _enumApiType;
    private readonly IUserApi _iUserApi;
    private readonly UserService _userService;

    public ApiService(EnumApiType enumApiType, IUserApi iUserApi = null, UserService userService = null)
    {
        _enumApiType = enumApiType;
        _iUserApi = iUserApi;
        _userService = userService;
    }

public async Task<UserListResponseModel> GetUserList()
    {

    }
}
