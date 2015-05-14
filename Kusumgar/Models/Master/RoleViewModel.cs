using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace Kusumgar.Models
{
    public class RoleViewModel
    {
        public PaginationInfo Pager { get; set; }

        public List<RoleInfo> RoleList { get; set; }

        public RoleInfo Role { get; set; }

        public List<FriendlyMessageInfo> FriendlyMessage { get; set; }

        public Role_Filter Role_FilterVal { get; set; }

        public int Role_Id { get; set; }

        public List<RoleAccessInfo> Role_Access_List { get; set; }

        public List<RoleAccessInfo> Selecetd_Role_Access_List { get; set; }

        public int[] Selected_Role_Access { get; set; }

        public RoleViewModel()
        {
            Pager = new PaginationInfo();

            RoleList = new List<RoleInfo>();

            Role = new RoleInfo();

            FriendlyMessage = new List<FriendlyMessageInfo>();

            Role_FilterVal = new Role_Filter();

            Role_Access_List = new List<RoleAccessInfo>();

            Selecetd_Role_Access_List = new List<RoleAccessInfo>();

            Role_Id = 0;

            Selected_Role_Access = new int[0];
        }
    }

    public class Role_Filter
    {
        public string Role_Name { get; set; }
    }
}