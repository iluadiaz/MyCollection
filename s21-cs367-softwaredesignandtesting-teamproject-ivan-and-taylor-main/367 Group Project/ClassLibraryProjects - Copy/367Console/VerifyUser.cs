using System;
using Users.Info;
using System.Collections.Generic;

namespace Users.Info
{
    public class VerifyUserAccount 
    {
        public bool verifyAccount(UserInfo user, string username)
       { 
            UserInfo tempUser = new UserInfo();

            tempUser.UserName = username;

            if(user.UserName == tempUser.UserName)
            {
            user.verified = true;
            return  user.verified;
            }
            else
            user.verified = false;
            return  user.verified;
       }

       
        public bool passwordChecker(UserInfo user, string password)
       {
            UserInfo tempUser = new UserInfo();

            tempUser.Password = password;

            if(user.Password == password)
            return true;
            else
            return false;
       }
    }
}