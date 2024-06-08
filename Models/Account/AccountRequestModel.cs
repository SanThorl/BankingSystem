using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Account;

public class AccountRequestModel
{
    #region Naw San ra ai
    public string ToAccount { get; set; }
    public string FromAccount { get; set; }
    #endregion
    public string? AccountNo { get; set; }

    public string CustomerCode { get; set; } = null!;

    public decimal Balance { get; set; }

    public string? CustomerName { get; set; }
}
