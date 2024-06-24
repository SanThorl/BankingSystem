
using System.ComponentModel;

namespace Frontend.Api.Feature.User;

public class LocalStorageUserService
{
    private readonly LocalStorageService _localStorageService;

    public LocalStorageUserService(LocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    #region Get User list with pagination
    public async Task<UserListResponseModel> GetUsers(int pageNo, int pageSize)
    {
        UserListResponseModel model = new UserListResponseModel();
        var query = await _localStorageService.GetList<TblUser>(EumService.Tbl_User.ToString());
        if (pageNo == 0)
        {
            model = new UserListResponseModel()
            {
                lstData = query.Select(x => x.Change()).ToList(),
                Response = new MessageResponseModel(true, "Success.")
            };
            return model;
        }
        else
        {
            query ??= [];
            var result = query
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var rowCount = query.Count();
            var pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
                pageCount++;

            model = new UserListResponseModel()
            {
                lstData = result.Select(x => x.Change()).ToList(),
                Response = new MessageResponseModel(true, "Success"),
                PageSetting = new PageSettingModel(pageNo, pageSize, pageCount)
            };
            return model;
        }
    }
    #endregion
    #region Get User
    public async Task<UserResponseModel> GetUserByCode(string userCode)
    {
        UserResponseModel model = new UserResponseModel();
        var lst = await _localStorageService.GetList<TblUser>(EumService.Tbl_User.GetKeyName());
        lst ??= [];
        var item = lst.FirstOrDefault(x => x.UserCode == userCode);
        if (item is null)
        {
            model.Response = new MessageResponseModel(false, "Invalid User Code");
            return model;
        }

        model.Data = item.Change();
        model.Response = new MessageResponseModel(true, "Success");
        return model;
    }
    #endregion

    #region Create User + Generate Unique User Code
    public async Task<UserResponseModel> CreateUser(UserRequestModel reqModel)
    {
        UserResponseModel resModel = new UserResponseModel();
        var userItem = new TblUser()
        {
            UserName = reqModel.UserName,
            FullName = reqModel.FullName,
            Email = reqModel.Email,
            Address = reqModel.Address,
            MobileNo = reqModel.MobileNo,
            Nrc = reqModel.Nrc,
            StateCode = reqModel.StateCode,
            TownshipCode = reqModel.TownshipCode
        };
        userItem.UserCode = await GenerateUserCode();
        var lst = await _localStorageService.GetList<TblUser>(EumService.Tbl_User.GetKeyName());
        lst ??= [];
        lst.Add(userItem);
        await _localStorageService.SetList(EumService.Tbl_User.GetKeyName(), lst);
        resModel.Response = new MessageResponseModel(true, "Successfully Register.");
        return resModel;
    }

    private async Task<string> GenerateUserCode()
    {
        string latestUserCode = "AB000";

        if (int.TryParse(latestUserCode.Substring(2), out int numericPart))
        {
            numericPart++;

            while (await IsUserCodeAlreadyUsed("AB" + numericPart.ToString("D3")))
            {
                numericPart++;
            }

            return "AB" + numericPart.ToString("D3");
        }

        return "AB000";
    }

    private async Task<bool> IsUserCodeAlreadyUsed(string userCode)
    {
        var lst = await _localStorageService.GetList<TblUser>(EumService.Tbl_User.GetKeyName());
        return lst.Any(x => x.UserCode == userCode);
    }

    public async Task CreateUser(List<UserRequestModel> reqModel)
    {
        await _localStorageService.SetList(EumService.Tbl_User.GetKeyName(), reqModel);
    } 
    #endregion

    public async Task  UpdateUser(UserRequestModel reqModel)
    {
        UserResponseModel resModel = new UserResponseModel();
        var lst = await _localStorageService.GetList<TblUser>(EumService.Tbl_User.GetKeyName());
        lst ??= [];
        var item = lst.FirstOrDefault(x => x.UserCode == reqModel.UserCode);
        var index = lst.FindIndex(x => item != null && x.UserCode == item.UserCode);
        if(item is null)
        {
            resModel.Response = new MessageResponseModel(false, "User is not found!");
            return resModel;
        }
    }

    #region Delete User
    public async Task<UserResponseModel> DeleteUser(string userCode)
    {
        UserResponseModel model = new UserResponseModel();
        var lst = await _localStorageService.GetList<TblUser>(EumService.Tbl_User.GetKeyName());
        lst ??= [];
        var item = lst.FirstOrDefault(x => x.UserCode == userCode);
        if (item is null)
        {
            model.Response = new MessageResponseModel(false, "Invalid User Code.");
            return model;
        }

        lst.Remove(item);
        await _localStorageService.SetList<TblUser>(EumService.Tbl_User.GetKeyName(), lst);
        model.Response = new MessageResponseModel(true, "Successfully Deleted");
        return model;
    } 
    #endregion
}

