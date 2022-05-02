using System;
using System.Collections.Generic;
using Pokemon.Info;

namespace Users.Info
{
    public interface Iuser
    {
        string UserName {get; set;}
        string Password {get; set;}
        bool verified{get; set; }
    } 
}