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
        public Complaint ComplaintEntity { get; set; }
        public string CustomerName { get; set; }
        public ComplaintInfo()
        {
            ComplaintEntity = new Complaint();
        }
    }
}
