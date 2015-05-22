using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace Kusumgar.Models
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            Contacts = new List<ContactInfo>();

            contact = new ContactInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Filter = new Contact_Filter();
        }

        public List<ContactInfo> Contacts{ get; set; }

        public ContactInfo contact { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public Contact_Filter Filter { get; set; }
    }

    public class Contact_Filter
    {
        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }
    }
}