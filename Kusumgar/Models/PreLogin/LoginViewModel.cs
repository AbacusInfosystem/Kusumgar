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
            Employee = new EmployeeInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public EmployeeInfo Employee { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
}