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
           // UserRoleEntity = new M_User_Role_Mapping();
        }

        //public M_User_Role_Mapping UserRoleEntity { get; set; }

        public int User_Role_Id { get; set; }

        public int Role_Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public string Role_Name { get; set; }

        #endregion

    }
    }

