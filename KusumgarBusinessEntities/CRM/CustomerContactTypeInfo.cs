using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class CustomerContactTypeInfo
    {
        public CustomerContactTypeInfo()
        {

        }

        public int Customer_Contact_Type_Id { get; set; }

        public int Customer_Id { get; set; }

        public string Contact_Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }
    }
}
