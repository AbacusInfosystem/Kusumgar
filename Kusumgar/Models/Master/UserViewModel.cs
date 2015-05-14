using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class UserViewModel
    {
       public  List<UserInfo> UserList { get; set; }

       public UserInfo User { get; set; }

       public int UserId { get; set; }

       public Filter FilterVal { get; set; }

       public PaginationInfo Pager { get; set; }

       public List<FriendlyMessageInfo> FriendlyMessage { get; set; }

       public List<RoleInfo> RoleInfoList { get; set; }
        
        public UserViewModel()
        {
            UserList = new List<UserInfo>();

            User = new UserInfo();

            FilterVal = new Filter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessageInfo>();

            RoleInfoList = new List<RoleInfo>();
        }

    }

    public class Filter
    {
       public string FirstName { get; set; }
    }
}