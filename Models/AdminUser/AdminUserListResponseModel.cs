﻿
using Models.User;

namespace Models.AdminUser;

public class AdminUserListResponseModel
{
    public List<AdminUserModel> lstData { get; set; }
    public MessageResponseModel Response { get; set; }
    public PageSettingModel PageSetting { get; set; }
}
