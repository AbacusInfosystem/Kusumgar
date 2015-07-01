using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class RoleInfo
    {
        public RoleInfo()
        {
            //RoleEntity = new M_Role();

          //  RoleEntity.Is_Active = true;
        }

        //public M_Role RoleEntity { get; set; }

        public int Role_Id { get; set; }

        public string Role_Name { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
    }
}
