
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

    public async Task<UserResponseModel> GetUserByCode(string userCode)
    {
        var item = _db.TblUsers.AsNoTracking();
        var result = await item.FirstOrDefaultAsync(x => x.UserCode == userCode);
        UserResponseModel model = new UserResponseModel()
        {
            Data = result!.Change(),
            Response = new MessageResponseModel(true, "Success")
        };
        return model;
    }
}
