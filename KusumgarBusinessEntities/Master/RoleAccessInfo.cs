using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class RoleAccessInfo
    {
        public RoleAccessInfo()
        {
          //  RoleAccessEntity = new M_Role_Access_Function_Mapping();
        }

        //public M_Role_Access_Function_Mapping RoleAccessEntity { get; set; }

        public int Role_Access_Function_Id { get; set; }

        public int Role_Id { get; set; }

        public int Access_Function_Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public string Access_Name { get; set; }

        #endregion
    }
}
