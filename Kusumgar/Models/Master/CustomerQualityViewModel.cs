using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    
    public class CustomerQualityViewModel
    {
        public CustomerQualityViewModel()
        {
            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Customer_Quality = new CustomerQualityInfo();

            Customer_Qualities = new List<CustomerQualityInfo>();

            Filter = new CustomerQualityFilter();

            Attachment = new AttachmentsInfo();

            Attachments = new List<AttachmentsInfo>();

        }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public CustomerQualityInfo Customer_Quality { get; set; }

        public List<CustomerQualityInfo> Customer_Qualities { get; set; }

        public CustomerQualityFilter Filter { get; set; }

        public AttachmentsInfo Attachment { get; set; }

        public List<AttachmentsInfo> Attachments { get; set; }

        public class CustomerQualityFilter
        {
        public int Customer_Id { get; set; }

        public int Quality_Id { get; set; }

        }
    }

}

