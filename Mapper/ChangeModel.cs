using DatabaseServices.Models;
using Models.Account;

namespace Mapper;

public static class ChangeModel
{
    #region Account
    public static TblAccount Change(this AccountRequestModel model)
    {
        return new TblAccount()
        {
            CustomerName = model.CustomerName,
            CustomerCode = model.CustomerCode,
            Balance = model.Balance
        };
    }

    public static AccountModel Change(this TblAccount item)
    {
        return new AccountModel()
        {
            AccountId = item.AccountId,
            AccountNo = item.AccountNo,
            CustomerCode = item.CustomerCode,
            CustomerName = item.CustomerName,
            Balance = item.Balance
        };
    }
    #endregion
}
