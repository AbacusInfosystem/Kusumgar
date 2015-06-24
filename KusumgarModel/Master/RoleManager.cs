using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<RoleInfo> Get_Roles(ref PaginationInfo Pager)
        {
            return _roleRepo.Get_Roles(ref Pager);
        }

        public List<RoleInfo> Get_Roles_By_Name(string Role_Name, ref PaginationInfo Pager)
        {
            return _roleRepo.Get_Roles_By_Name(Role_Name, ref Pager);
        }

        public RoleInfo Get_Role_By_Id(int Role_Id)
        {
            return _roleRepo.Get_Role_By_Id(Role_Id);
        }

        public List<RoleInfo> Get_Roles_By_Id(int Role_Id, ref PaginationInfo pager)
        {
            return _roleRepo.Get_Roles_By_Id(Role_Id,ref pager);
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

        public List<AutocompleteInfo> Get_Roles_By_Name(string role_Name)
        {
            return _roleRepo.Get_Roles_By_Name(role_Name);
        }
        
    }
}
