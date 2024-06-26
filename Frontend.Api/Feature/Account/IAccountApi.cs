﻿
namespace Frontend.Api.Feature.Account
{
    public interface IAccountApi
    {
        [Get("/api/account/")]
        Task<AccountListResponseModel> GetAccounts();

        [Get("/api/account/{pageNo}/{pageSize}")]
        Task<AccountListResponseModel> GetAccountsList(int pageNo, int pageSize);
    }
}
