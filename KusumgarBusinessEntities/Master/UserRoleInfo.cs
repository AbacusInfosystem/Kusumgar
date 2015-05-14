using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class UserRoleInfo
    {
        public UserRoleInfo ()
        {
            UserRoleEntity = new M_User_Role_Mapping();
        }

        public M_User_Role_Mapping UserRoleEntity { get; set; }

        public string Role_Name { get; set; }

       
        }
    }

