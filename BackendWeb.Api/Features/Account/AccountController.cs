using BackendServices.Features.Account;
using Microsoft.AspNetCore.Mvc;

namespace BackendWeb.Api.Features.Account;
[Route("api/controller")]
[ApiController]
public class AccountController : BaseController
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }
    #region Get Account List
    [HttpGet]
    public async Task<IActionResult> GetAccounts()
    {
        try
        {
            var model = await _accountService.GetAccounts();
            return Ok(model);
        }
       catch(Exception ex)
        {
            return InternalServerError(ex);
        }
    }
    #endregion
}
