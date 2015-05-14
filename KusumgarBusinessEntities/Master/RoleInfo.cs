using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class RoleInfo
    {
        public RoleInfo()
        {
            RoleEntity = new M_Role();

            RoleEntity.Is_Active = true;
        }

        public M_Role RoleEntity { get; set; }
    }
}
