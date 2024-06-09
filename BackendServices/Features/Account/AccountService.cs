namespace BackendServices.Features.Account;

public class AccountService
{
    private readonly AppDbContext _db;

    public AccountService(AppDbContext db)
    {
        _db = db;
    }

    #region Get Account List
    public async Task<AccountListResponseModel> GetAccounts()
    {
        var tblAccountList = _db.TblAccounts.AsNoTracking();
        var result = await tblAccountList.OrderByDescending(x => x.AccountId).ToListAsync();
        //var modelAccountList = result.Change(result).ToList();
        var modelAccountList = result.Select(x => x.Change()).ToList();
        AccountListResponseModel model = new AccountListResponseModel()
        {
            ListData = modelAccountList,
            Response = new MessageResponseModel(true, "Getting Accounts Successfully.")
        };
        return model;
    }
    #endregion
}
