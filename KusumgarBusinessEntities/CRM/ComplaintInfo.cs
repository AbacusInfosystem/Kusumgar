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
       // public Complaint Complaint_Entity { get; set; }
       
        public ComplaintInfo()
        {
          //  Complaint_Entity = new Complaint();
        }

        public int Complaint_Id { get; set; }

        public int Customer_Id { get; set; }

        public string Order_Id { get; set; }

        public string Order_Item_Id { get; set; }

        public string Challan_No { get; set; }

        public string CDescription { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public string Customer_Name { get; set; }

        #endregion

    }
}
