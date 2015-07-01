using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class CustomerQualityFunctionalParameterInfo
    {
        public int Customer_Quality_Functional_Parameter_Id { get; set; }

        public int Customer_Quality_Id { get; set; }

        public int Test_Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        

        #region Additional Fields

        public string Test_Name { get; set; }

        public string Label
        {
            get
            {
                return Test_Name;
            }
            set
            {
                Label = value;
            }
        }

        public int Value
        {
            get
            {
                return Customer_Quality_Functional_Parameter_Id;
            }
            set
            {
                Value = value;
            }
        }

        #endregion
    }
}
