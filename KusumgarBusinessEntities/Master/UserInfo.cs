using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class UserInfo
    {
        public UserInfo()
        {
            UserEntity = new M_User();

            UserRoleList = new List<UserRoleInfo>();
        }

        public M_User UserEntity { get; set; }

        public string Gender 
        {
            get
            {
                return ((GenderType)UserEntity.Gender).ToString();
            }
            set
            {
                Gender = value;
            }
        }

        public List<UserRoleInfo> UserRoleList { get; set; }

        public string Role_Ids
        {
            get;
            set;
        }
    }
}
