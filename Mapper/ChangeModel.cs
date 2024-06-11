using DatabaseServices.Models;
using Models.Account;
using Models.User;

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

    //public static TblUser Change(this UserRequestModel model)
    //{
    //    return new TblUser()
    //    {
    //        UserCode = model.UserCode,
    //        UserName = model.UserName,
            
    //    };
    //}

    public static UserModel Change(this TblUser item)
    {
        UserModel model = new UserModel
        {
            UserId = item.UserId,
            UserCode = item.UserCode,
            UserName = item.UserName,
            CustomerId = item.CustomerId,
            FullName = item.FullName,
            Email = item.Email,
            Address = item.Address,
            MobileNo = item.MobileNo,
            Nrc = item.Nrc,
            StateCode = item.StateCode,
            TownshipCode = item.TownshipCode
        };
        return model;
    }
}
