using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Account;

public class AccountListResponseModel
{
    public List<AccountModel> ListData { get; set; }
    public MessageResponseModel Response { get; set; }
    public PageSettingModel PageSetting { get; set; }
}
