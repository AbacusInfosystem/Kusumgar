using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities
{
    public class SupportingDetailsInfo
    {
        public int Supporting_Details_Id { get; set; }

        public int Enquiry_Id { get; set; }

        public int Rate { get; set; }

        public int Customer_Roll_Length { get; set; }

        public string Packing { get; set; }

        public string Dispatch { get; set; }

        public string Additional_Customer_Prop { get; set; }

        public string Source_Of_Enquiry { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
