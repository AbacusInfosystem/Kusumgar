using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using Kusumgar.Common;

namespace Kusumgar.Models.PreLogin
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            User = new UserInfo();

            Friendly_Message = new List<FriendlyMessage>();
        }

        public UserInfo User { get; set; }

        public List<FriendlyMessage> Friendly_Message { get; set; }
        

    }
}