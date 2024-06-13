namespace Frontend.Api.Feature;

public class ApiService
{
    private readonly EnumApiType _enumApiType;
    private readonly IUserApi _iUserApi;
    private readonly UserService _userService;

    public ApiService(Config conFig, EnumApiType enumApiType, IUserApi iUserApi, UserService userService)
    {
        _enumApiType = conFig.EnumApiType;
        _iUserApi = iUserApi;
        _userService = userService;
    }

    public async Task<UserListResponseModel> GetUserList(int pageNo, int pageSize)
    {
        return _enumApiType == EnumApiType.Backend
            ? await _iUserApi.GetUsers(pageNo, pageSize)
            : await _userService.GetUsers(pageNo, pageSize);
    }

    public async Task<UserResponseModel> GetUserByCode(string userCode)
    {
        return _enumApiType == EnumApiType.Backend
            ? await _iUserApi.GetUserByCode(userCode)
            : await _userService.GetUserByCode(userCode);
    }

    public async Task<UserResponseModel> DeleteUser(string userCode)
    {
        return _enumApiType = EnumApiType.Backend
            ? await _iUserApi.DeleteUser(userCode)
            : await _userService.
    }
}
