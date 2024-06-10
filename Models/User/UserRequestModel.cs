﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User;

public class UserRequestModel
{
    public string UserCode { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? CustomerId { get; set; }
    public string FullName { get; set; } = null!;
    public string MobileNo { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Nrc { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string StateCode { get; set; } = null!;
    public string TownshipCode { get; set; } = null!;
}
