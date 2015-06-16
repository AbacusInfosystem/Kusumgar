using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities
{
    public class TempCustomerQualityDetailsInfo
    {
        public int Enquiry_Id { get; set; }

        public string Width_Of_Fabric { get; set; }

        public string Coating { get; set; }

        public string Applications { get; set; }

        public string Physical_Appearance { get; set; }

        public int Shades { get; set; }

        public string Finish { get; set; }

        public string Prints { get; set; }

        public int Customer_Approved_Sample { get; set; }

        public string Market_Segment { get; set; }

        public string Lable_Tagging { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Additional Fields

        public string Sample_No { get; set; }

        public string Shade_Name { get; set; }

        #endregion

    }
}
