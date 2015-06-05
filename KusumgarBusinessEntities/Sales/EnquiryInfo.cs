using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class EnquiryInfo
    {
        public EnquiryInfo()
        {
            SupportingDetails = new SupportingDetailsInfo();

            StaggedOrders = new List<StaggedOrderInfo>();

            TempCustomerQualityDetails = new TempCustomerQualityDetailsInfo();

            Attachments = new List<AttachmentsInfo>();
        }

        public int Enquiry_Id { get; set; }

        public int Enquiry_Type_Id { get; set; }

        public string Enquiry_No { get; set; }

        public int Enquiry_Status_Id { get; set; }

        public int Customer_Id { get; set; }

        public int Quality_Id { get; set; }

        public int PPC_Article_Type_Id { get; set; }

        public int Quality_Set_Id { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string Customer_Name { get; set; }

        public string Quality_No { get; set; }

        public SupportingDetailsInfo SupportingDetails { get; set; }

        public List<StaggedOrderInfo> StaggedOrders { get; set; }

        public TempCustomerQualityDetailsInfo TempCustomerQualityDetails { get; set; }

        public List<AttachmentsInfo> Attachments { get; set; }
    }
}
