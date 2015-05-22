using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class RoleManager
    {
       public RoleRepo _roleRepo { get; set; }

       public RoleManager()
        {
            _roleRepo = new RoleRepo();
        }

        public List<RoleInfo> Get_Roles(ref PaginationInfo pager)
        {
            return _roleRepo.Get_Roles(ref pager);
        }

        public List<RoleInfo> Get_Roles_By_Name(string role_Name, ref PaginationInfo pager)
        {
            return _roleRepo.Get_Roles_By_Name(role_Name, ref pager);
        }

        public RoleInfo Get_Role_By_Id(int role_Id)
        {
            return _roleRepo.Get_Role_By_Id(role_Id);
        }

        public int Insert_Role(RoleInfo role)
        {
            return _roleRepo.Insert_Role(role);
        }

        public void Update_Role(RoleInfo role)
        {
            _roleRepo.Update_Role(role);
        }

        public bool Check_Existing_Role (string role_Name)
        {
            return _roleRepo.Check_Existing_Role(role_Name);
        }

    }
}
