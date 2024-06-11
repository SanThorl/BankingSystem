
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
        public IActionResult GetUsers(int pageNo, int pageSize)
        {
            try
            {
                var model = _userService.GetUserList(pageNo, pageSize);
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
