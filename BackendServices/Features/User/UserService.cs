
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

    public async Task<UserListResponseModel> GetUserList(int pageNo, int pageSize)
    {
        var query = _db.TblUsers.AsNoTracking();
        var result = await query.OrderByDescending(x => x.UserId)
            .Skip((pageNo - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var rowCount = await query.CountAsync();
        var pageCount = pageNo / pageSize;
        if (rowCount%pageSize>0)
            pageCount++;

        var userList = result.Select(x => x.Change()).ToList();
        UserListResponseModel model = new()
        {
            lstData = userList,
            PagaSetting = new PageSettingModel(pageNo, pageSize, pageCount),
            Response = new MessageResponseModel(true, "Success")
        };
        return model;
    }
}
