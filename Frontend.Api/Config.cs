using System;
using System.Collections.Generic;
using System.Linq;

namespace Frontend.Api
{
    public class Config
    {
        public EnumApiType EnumApiType { get; set; } = EnumApiType.LocalStorage;
        //public EnumApiType EnumApiType { get; set; } = EnumApiType.Backend;
    }
}
