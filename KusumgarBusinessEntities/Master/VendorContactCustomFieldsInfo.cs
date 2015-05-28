using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class VendorContactCustomFieldsInfo
    {
       public VendorContactCustomFieldsInfo()
        {
            Custom_Fields_Entity = new Contact_Custom_Fields();
        }

        public Contact_Custom_Fields Custom_Fields_Entity { get; set; }
    }
}
