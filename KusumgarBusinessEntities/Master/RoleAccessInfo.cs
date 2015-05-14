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
            RoleAccessEntity = new M_Role_Access_Function_Mapping();
        }

        public M_Role_Access_Function_Mapping RoleAccessEntity { get; set; }

        public string Access_Name { get; set; }
    }
}
