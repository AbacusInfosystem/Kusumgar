using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities.CMS
{
    public class EmployeeInfo
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }
    }
}
