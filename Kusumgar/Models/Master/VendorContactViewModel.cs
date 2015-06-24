using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class VendorContactViewModel
    {
        public VendorContactViewModel()
        {
            Vendor_Contact = new VendorContactInfo();

            Vendor_Contacts = new List<VendorContactInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Filter = new Vendor_Contact_Filter();

        }

        public List<VendorContactInfo> Vendor_Contacts { get; set; }

        public VendorContactInfo Vendor_Contact { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public Vendor_Contact_Filter Filter { get; set; }

    }

        public class Vendor_Contact_Filter
        {
            public int Vendor_Id { get; set; }

            public string Vendor_Name { get; set; }
        }
    
}