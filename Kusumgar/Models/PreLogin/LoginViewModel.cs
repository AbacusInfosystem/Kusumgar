using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;


namespace Kusumgar.Models.PreLogin
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            User = new UserInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }

        public UserInfo User { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        

    }
}