using DatabaseServices.Models;
using Frontend.Api.Services;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Api.Feature.User;

public class UserService
{
    private readonly LocalStorageService _localStorageService;

    public UserService(LocalStorageService localStorageService)
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
    public async Task<UserResponseModel> GetUserByCode(string userCode)
    {
        UserResponseModel model = new UserResponseModel();
        var lst = await _localStorageService.GetList<TblUser>(EumService.Tbl_User.GetKeyName());
        lst ??= [];
        var item = lst.FirstOrDefault(x => x.UserCode == userCode);
        if(item is null)
        {
            model.Response = new MessageResponseModel(false, "Invalid User Code");
            return model;
        }

        model.Data = item.Change();
        model.Response = new MessageResponseModel(true, "Success");
        return model;
    }
}

