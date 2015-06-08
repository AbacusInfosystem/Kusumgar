using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class EnquiryViewModel
    {
       

        public EnquiryViewModel()
        {
            Friendly_Message = new List<FriendlyMessageInfo>();
            Pager = new PaginationInfo();
            Enquiry = new EnquiryInfo();
            Enquiries = new List<EnquiryInfo>();

            Filter = new Enquiry_Filter();
        }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public PaginationInfo Pager { get; set; }
        public EnquiryInfo Enquiry { get; set; }
        public List<EnquiryInfo> Enquiries { get; set; }

        public Enquiry_Filter Filter { get; set; }
       
    }

    
    public class Enquiry_Filter
    {
        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }

        public int Quality_Id { get; set; }

        public string Quality_No { get; set; }
    }
}