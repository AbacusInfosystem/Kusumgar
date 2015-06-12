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
            Supporting_Details = new SupportingDetailsInfo();

            Staggered_Orders = new List<StaggeredOrderInfo>();

            Temp_Customer_Quality_Details = new TempCustomerQualityDetailsInfo();

            Attachments = new List<AttachmentsInfo>();

            Staggered_Order = new StaggeredOrderInfo();

            Temp_Functional_Parameters = new TempFunctionalParametersInfo();

            Temp_Visual_Parameters = new TempVisualParametersInfo();
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

        #region Additional Fields

        public string Enquiry_Type
        {
            get
            {
                return ((EnquiryType)Enquiry_Type_Id).ToString();
            }
            set
            {
                value = Enquiry_Type;
            }
        }

        public string Customer_Name { get; set; }

        public string Quality_No { get; set; }

        public SupportingDetailsInfo Supporting_Details { get; set; }

        public StaggeredOrderInfo Staggered_Order { get; set; }

        public List<StaggeredOrderInfo> Staggered_Orders { get; set; }

        public TempCustomerQualityDetailsInfo Temp_Customer_Quality_Details { get; set; }

        public List<AttachmentsInfo> Attachments { get; set; }

        public TempFunctionalParametersInfo Temp_Functional_Parameters { get; set; }

        public TempVisualParametersInfo Temp_Visual_Parameters { get; set; }

        public string  Enquiry_Status
        {
            get
            {
                return ((EnquiryStatus)Enquiry_Status_Id).ToString().Replace('_',' ');             
            }
            set
            {
                Enquiry_Status = value; 
            }
        }

        #endregion
    }
}
