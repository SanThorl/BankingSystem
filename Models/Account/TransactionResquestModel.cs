using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Account;

public class TransactionResquestModel
{
    public string? AccountNo { get; set; }

    public string CustomerCode { get; set; } = null!;

    public decimal Balance { get; set; }

    public string? CustomerName { get; set; }
    public decimal Amount { get; set; }
}
