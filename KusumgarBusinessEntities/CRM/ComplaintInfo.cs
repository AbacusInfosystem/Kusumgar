using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ComplaintInfo
    {
       // public Complaint Complaint_Entity { get; set; }
       
        public ComplaintInfo()
        {
          //  Complaint_Entity = new Complaint();

            ComplaintLots = new List<ComplaintLotMappingInfo>();
        }

        public int Complaint_Id { get; set; }

        public int Customer_Id { get; set; }

        public int Order_Id { get; set; }

        public int Challan_No { get; set; }

        public string CDescription { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }


        #region Additional Fields

        public string Customer_Name { get; set; }

        public List<ComplaintLotMappingInfo> ComplaintLots { get; set; }

        public string Order_No 
        { 
            get 
            {
                return ((Order)Order_Id).ToString();
            }
            set 
            {
                value = Order_No;
            }
        }

        public string Challan_No_Str
        {
            get
            {
                return ((Challan_No)Challan_No).ToString();
            }
            set
            {
                value = Challan_No_Str;
            }
        }

        #endregion

    }
}
