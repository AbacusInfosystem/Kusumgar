using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class MaterialInfo
    {
      //  public M_Material Material_Entity { get; set; }
      
        public MaterialInfo()
        {
           // Material_Entity = new M_Material();
        }

        public int Material_Id { get; set; }

        public string Material_Code { get; set; }

        public int Material_Category_Id { get; set; }

        public int Material_SubCategory_Id { get; set; }

        public string Material_Name { get; set; }

        public string Size { get; set; }

        public string COD { get; set; }

        public int Material_Type { get; set; }

        public bool Original_Manufacturer { get; set; }

        public string Inspection_Facility { get; set; }

        public string Testing_Facility { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public string Material_Category_Name { get; set; }

        public string Material_SubCategory_Name { get; set; }

        public string Material_Type_Str
        {
            get
            {
                if (Material_Type != 0)
                {
                    return ((ProductType)Material_Type).ToString().Replace('_', ' ');
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Material_Type_Str = value;
            }
        }

        #endregion
    }
}
