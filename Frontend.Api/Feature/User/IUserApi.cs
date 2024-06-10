using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Api.Feature.User;

public interface IUserApi
{
    [Get("/api/user/")]
    Task<UserListResponseModel> GetUsers();

    [Get("/api/user/{pageNo}/{pageSize}")]
    Task<UserListResponseModel> GetUsers(int pageNo, int pageSize);
}
