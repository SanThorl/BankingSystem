﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User;

public class UserListResponseModel
{
    public PageSettingModel PageSetting { get; set; }
    public List<UserModel> lstData { get; set; }
    public MessageResponseModel Response { get; set; }
}
