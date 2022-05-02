using System;
using System.Collections.Generic;
using System.Linq;
using Pokemon.Info;

namespace Users.Info
{ 
    public class UserInfo : VerifyUserAccount
    {
       public IList<PokemonManager> Teams = new List<PokemonManager>();
       public string UserName{get; set; }
       public string Password{get; set; }
       public bool verified{get; set; }
    }
}