
namespace Frontend.Api.Services
{
    public enum EumService
    {
        Tbl_User,
        Tbl_Account,
        Tbl_State,
        Tbl_Township,
        Tbl_AdminUser,
        Tbl_TransactionHistory
    }

    public static class EnumService
    {
        public static string GetKeyName(this EumService key)
        {
            return key.ToString();
        }
    }
}
