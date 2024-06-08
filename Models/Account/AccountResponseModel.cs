using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Account;

public class AccountResponseModel
{
    public MessageResponseModel Response { get; set; }
    public AccountModel Data { get; set; }
}
