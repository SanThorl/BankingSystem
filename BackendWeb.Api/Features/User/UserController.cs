
using BackendServices.Features.User;

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

        [HttpGet("{userCode}")]
        public async Task<IActionResult> GetUserByCode(string userCode)
        {
            try
            {
                var model = await _userService.GetUserByCode(userCode);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
