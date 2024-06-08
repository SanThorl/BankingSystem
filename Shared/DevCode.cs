namespace Shared;

public class DevCode
{
    #region generate random account number(Shaka da ai pi nmu ai. GenerateIBAN() hpe sha shaka da ai)
    public static string GenerateRandomAccountNo()
    {
        Random random = new Random();
        int accountNo = random.Next(100000, 999999);
        string formattedAccountNo = accountNo.ToString("D6");
        return formattedAccountNo;
    }
    #endregion
}