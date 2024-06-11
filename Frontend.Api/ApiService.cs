
namespace Frontend.Api;

public class ApiService
{
    private readonly EnumApiType _enumApiType;
    private readonly IUserApi _iUserApi;
    private readonly UserService _userService;

    public ApiService(Config conFig,EnumApiType enumApiType, IUserApi iUserApi = null, UserService userService = null)
    {
        _enumApiType = conFig.enumApiType;
        _iUserApi = iUserApi;
        _userService = userService;
    }

public async Task<UserListResponseModel> GetUserList(int pageNo, int pageSize)
    {
        return _enumApiType == EnumApiType.Backend
            ? await _iUserApi.GetUsers(pageNo, pageSize)
            : await _userService.GetUsers(pageNo, pageSize);
    }
}
