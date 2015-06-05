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
        public List<UserInfo> Users { get; set; }

       public UserInfo User { get; set; }

       public int UserId { get; set; }

       public User_Filter Filter { get; set; }

       public PaginationInfo Pager { get; set; }

       public List<FriendlyMessageInfo> Friendly_Message { get; set; }

       public List<RoleInfo> Roles { get; set; }
        
        public UserViewModel()
        {
            Users = new List<UserInfo>();

            User = new UserInfo();

            Filter = new User_Filter();

            Pager = new PaginationInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Roles = new List<RoleInfo>();
        }

    }

    public class User_Filter
    {
       public string FirstName { get; set; }

       public int User_Id { get; set; }
    }
}