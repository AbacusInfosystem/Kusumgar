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
            Contact_List = new List<ContactInfo>();

            contact = new ContactInfo();

            FriendlyMessage = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Pager.PageSize = 1;

            FilterVal = new Contact_Filter();
        }

        public List<ContactInfo> Contact_List { get; set; }

        public ContactInfo contact { get; set; }

        public List<FriendlyMessageInfo> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public Contact_Filter FilterVal { get; set; }
    }

    public class Contact_Filter
    {
        public int Customer_Id { get; set; }
    }
}