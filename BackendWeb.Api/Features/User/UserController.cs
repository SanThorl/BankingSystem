
using BackendServices.Features.User;
using Microsoft.VisualBasic;

namespace BackendWeb.Api.Features.User
{
    [Route("api/controller")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        #region UserList with Pagination
        [HttpGet("{pageNo}/{pageSize}")]
        public async Task<IActionResult> GetUsers(int pageNo, int pageSize)
        {
            try
            {
                var model = await _userService.GetUserList(pageNo, pageSize);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region Get User By Code
        [HttpGet("{userCode}")]
        public async Task<IActionResult> GetUserByCode(string userCode)
        {
            try
            {
                var model = await _userService.GetUserByCode(userCode);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region Create User
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestModel reqModel)
        {
            try
            {
                var model = await _userService.CreateUser(reqModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        #endregion

        #region  Update  User Infomation
        [HttpPut("{userCode}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestModel reqModel)
        {
            try
            {
                var model = await _userService.UpdateUser(reqModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        } 
        #endregion

        #region Delete User
        [HttpDelete("{userCode}")]
        public async Task<IActionResult> DeleteUser(string userCode)
        {
            try
            {
                var model = await _userService.DeleteUser(userCode);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        } 
        #endregion
    }
}
