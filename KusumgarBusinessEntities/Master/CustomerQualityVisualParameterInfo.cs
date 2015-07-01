using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class CustomerQualityVisualParameterInfo
    {
        public int Customer_Quality_Visual_Parameter_Id { get; set; }

        public int Customer_Quality_Id { get; set; }

        public int Defect_Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

       

        #region Additional Fields

        public string Defect_Name { get; set; }

        public string Label
        {
            get
            {
                return Defect_Name;
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
                return Customer_Quality_Visual_Parameter_Id;
            }
            set
            {
                Value = value;
            }
        }

        #endregion
    }
}
