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
    public class RoleAccessManager
    {
        public RoleAccessRepo _roleAccessRepo { get; set; }

        public RoleAccessManager()
        {
            _roleAccessRepo = new RoleAccessRepo();
        }

        public List<RoleAccessInfo> Get_Access_List()
        {
            return _roleAccessRepo.Get_Access_List();
        }

        public List<RoleAccessInfo> Get_Role_Access_List_By_Role_Id(int RoleId)
        {
            return _roleAccessRepo.Get_Role_Access_List_By_Role_Id(RoleId);
        }

        public void Insert_Role_Access(int RoleId, int[] Access_Ids)
        {
            _roleAccessRepo.Insert_Role_Access(RoleId, Access_Ids);
        }

    }
}
