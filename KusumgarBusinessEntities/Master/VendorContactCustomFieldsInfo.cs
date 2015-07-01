using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class VendorContactCustomFieldsInfo
    {
       public VendorContactCustomFieldsInfo()
        {
            //Custom_Fields_Entity = new Contact_Custom_Fields();
        }

        //public Contact_Custom_Fields Custom_Fields_Entity { get; set; }

       public int Contact_Custom_Field_Id { get; set; }

       public int Contact_Id { get; set; }

       public string Field_Name { get; set; }

       public string Field_Value { get; set; }

       public bool Is_Active { get; set; }

       public DateTime CreatedOn { get; set; }

       public int CreatedBy { get; set; }

       public DateTime UpdatedOn { get; set; }

       public int UpdatedBy { get; set; }
    }
}
