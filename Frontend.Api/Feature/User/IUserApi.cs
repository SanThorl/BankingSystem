using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Api.Feature.User;

public interface IUserApi
{
    //[Get("/api/user/")]
    //Task<UserListResponseModel> GetUsers();

    [Get("/api/user/{pageNo}/{pageSize}")]
    Task<UserListResponseModel> GetUsers(int pageNo, int pageSize);

    [Get("/api/user/{userCode}")]
    Task<UserResponseModel> GetUserByCode(string userCode);

    [Post("/api/user/create")]
    Task<UserResponseModel> CreateUser(UserRequestModel reqModel);

    [Put("/api/user/{userCode}")]
    Task<UserResponseModel> UpdateUser(UserRequestModel reqModel);

    [Delete("/api/user/delete{userCode}")]
    Task<UserResponseModel> DeleteUser(string userCode);
}
