using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ContactInfo
    {
        public ContactInfo()
        {
            contact_Entity = new Contact();

            Contact_Custom_Fields_List = new List<ContactCustomFieldsInfo>();

            Custom_Fields = new ContactCustomFieldsInfo();
        }

        public Contact contact_Entity { get; set; }

        public List<ContactCustomFieldsInfo> Contact_Custom_Fields_List { get; set; }

        public ContactCustomFieldsInfo Custom_Fields { get; set; }

        public string Customer_Name { get; set; }
    }
}
