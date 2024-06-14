using BackendServices.Features.User;

namespace Frontend.Api.Feature;

public class ApiService
{
    private readonly EnumApiType _enumApiType;
    private readonly IUserApi _iUserApi;
    private readonly UserService _backend;
    private readonly LocalStorageUserService _userService;

    public ApiService(Config conFig, EnumApiType enumApiType, IUserApi iUserApi, UserService backend, LocalStorageUserService userService
        )
    {
        _enumApiType = conFig.EnumApiType;
        _iUserApi = iUserApi;
        _userService = userService;
        _backend = backend;
    }

    public async Task<UserListResponseModel> GetUserList(int pageNo, int pageSize)
    {
        return _enumApiType == EnumApiType.Backend
            ? await _iUserApi.GetUsers(pageNo, pageSize)
            : await _backend.GetUserList(pageNo, pageSize);
    }

    public async Task<UserResponseModel> GetUserByCode(string userCode)
    {
        return _enumApiType == EnumApiType.Backend
            ? await _iUserApi.GetUserByCode(userCode)
            : await _backend.GetUserByCode(userCode);
    }

    public async Task<UserResponseModel> CreateUser(UserRequestModel reqModel)
    {
        return _enumApiType == EnumApiType.Backend
            ? await _iUserApi.CreateUser(reqModel)
            : await _backend.CreateUser(reqModel);
    }

    public async Task CreateUser(List<UserRequestModel> reqModel)
    {
        await _userService.CreateUser(reqModel);
    }

    public async Task<UserResponseModel> DeleteUser(string userCode)
    {
        return _enumApiType == EnumApiType.Backend
            ? await _iUserApi.DeleteUser(userCode)
            : await _backend.DeleteUser(userCode);
    }
}
