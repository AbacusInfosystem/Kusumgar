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

        public List<RoleInfo> Get_Roles(PaginationInfo Pager)
        {
            return _roleRepo.Get_Roles(Pager);
        }

        public List<RoleInfo> Get_Roles_By_Name(string Role_Name, PaginationInfo Pager)
        {
            return _roleRepo.Get_Roles_By_Name(Role_Name,Pager);
        }

        public RoleInfo Get_Roles_By_Id(int Role_Id)
        {
            return _roleRepo.Get_Roles_By_Id(Role_Id);
        }

        public int Insert_Role(RoleInfo RoleInfo)
        {
          return _roleRepo.Insert_Role(RoleInfo);
        }

        public void Update_Role(RoleInfo RoleInfo)
        {
            _roleRepo.Update_Role(RoleInfo);
        }

        public bool Check_Existing_Role (string Role_Name)
        {
          return  _roleRepo.Check_Existing_Role(Role_Name);
        }

        
    }
}
