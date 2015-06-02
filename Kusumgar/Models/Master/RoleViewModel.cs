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

        public List<RoleInfo> Roles { get; set; }

        public RoleInfo Role { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Role_Filter Filter { get; set; }

        public int Role_Id { get; set; }

        public List<RoleAccessInfo> Role_Accesses { get; set; }

        public List<RoleAccessInfo> Selecetd_Role_Accesses { get; set; }

        public int[] Selected_Role_Access { get; set; }

        public RoleViewModel()
        {
            Pager = new PaginationInfo();

            Roles = new List<RoleInfo>();

            Role = new RoleInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Filter = new Role_Filter();

            Role_Accesses = new List<RoleAccessInfo>();

            Selecetd_Role_Accesses = new List<RoleAccessInfo>();

            Role_Id = 0;

            Selected_Role_Access = new int[0];
        }
    }

    public class Role_Filter
    {
        public string Role_Name { get; set; }

        public int Role_Id { get; set; }
    }
}