using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User;

public class UserResponseModel
{
    public UserModel Data { get; set; }
    public MessageResponseModel Response { get; set; }
}
