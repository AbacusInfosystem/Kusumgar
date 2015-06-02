using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ComplaintInfo
    {
        public Complaint Complaint_Entity { get; set; }
        public string Customer_Name { get; set; }
        public ComplaintInfo()
        {
            Complaint_Entity = new Complaint();
        }
    }
}
