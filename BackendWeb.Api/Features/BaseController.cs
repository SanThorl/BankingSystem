
namespace BackendWeb.Api.Features;
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult InternalServerError(Exception ex)
    {
        return Ok(new { Response = new MessageResponseModel(false, ex) });
    }
    
}
