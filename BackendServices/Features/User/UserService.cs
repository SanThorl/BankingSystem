
using Azure;
using Models.User;
using System.ComponentModel.DataAnnotations;

namespace BackendServices.Features.User;

public class UserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    #region Get User List With pagination
    public async Task<UserListResponseModel> GetUserList(int pageNo, int pageSize)
    {
        var query = _db.TblUsers.AsNoTracking();
        var result = await query
            .OrderByDescending(x => x.UserId)
             .Skip((pageNo - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();

        var rowCount = await query.CountAsync();
        var pageCount = rowCount / pageSize;
        if (rowCount % pageSize > 0)
            pageCount++;
        var lst = query.Select(x => x.Change()).ToList();

        UserListResponseModel model = new UserListResponseModel()
        {
            lstData = lst,
            PageSetting = new PageSettingModel(pageNo, pageSize, pageCount),
            Response = new MessageResponseModel(true, "Success"),
        };

        return model;
    }
    #endregion

    #region Get Individual User By Code
    public async Task<UserResponseModel> GetUserByCode(string userCode)
    {
        var query = _db.TblUsers.AsNoTracking();
        var result = await query.FirstOrDefaultAsync(x => x.UserCode == userCode);
        UserResponseModel model = new UserResponseModel()
        {
            Data = result!.Change(),
            Response = new MessageResponseModel(true, "Success")
        };
        return model;
    }
    #endregion

    #region Create User + GenerateCode
    public async Task<UserResponseModel> CreateUser(UserRequestModel reqModel)
    {
        var resModel = new TblUser()
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

        var itemCode = GenerateUserCode();
        resModel.UserCode = itemCode;
        await _db.AddAsync(resModel);
        var result = await _db.SaveChangesAsync();

        UserResponseModel model = new()
        {
            Data = resModel.Change(),
            Response = new MessageResponseModel(true, "Successfully Saved.")
        };
        return model;
    }

    public string GenerateUserCode()
    {
        var lastCode = "AB000";
        if (int.TryParse(lastCode.Substring(2), out int numericCode))
        {
            numericCode++;
            while (IsAlreadyUsedCode("AB" + numericCode.ToString("D3")))
                numericCode++;
            return "AB" + numericCode.ToString("D3");
        }
        return "AB000";
    }

    private bool IsAlreadyUsedCode(string userCode)
    {
        return _db.TblUsers.Any(x => x.UserCode == userCode);
    } 
    #endregion

    //public async Task<UserResponseModel> UpdateUser(UserRequestModel reqModel)
    //{
    //    UserResponseModel resModel = new UserResponseModel();
    //    var item = await _db.TblUsers.AsNoTracking().FirstOrDefaultAsync(x => x.UserCode == reqModel.UserCode);
    //    if(item is null)
    //    {
    //        throw new Exception("Invalid User!");
    //    }
    //}

    #region Delete User
    public async Task<UserResponseModel> DeleteUser(string userCode)
    {
        UserResponseModel model = new UserResponseModel();

        var query = _db.TblUsers.AsNoTracking();
        var item = await query.FirstOrDefaultAsync(x => x.UserCode == userCode);
        if (item is null)
        {
            throw new Exception("Invalid User");
        }

        _db.Entry(item).State = EntityState.Deleted;
        _db.TblUsers.Remove(item);
        var result = await _db.SaveChangesAsync();
        model = new UserResponseModel()
        {
            Response = new MessageResponseModel(true, "Successfully Deleted.")
        };
        return model;
    }
    #endregion
}
