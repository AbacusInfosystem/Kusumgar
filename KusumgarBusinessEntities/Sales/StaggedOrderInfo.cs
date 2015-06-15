using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities
{
    public class StaggedOrderInfo
    {
        public int Stagged_Order_Id { get; set; }

        public int Enquiry_Id { get; set; }

        public int Quantity { get; set; }

        public DateTime Delivery_Date { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}
