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
        public M_Material Material_Entity { get; set; }
        public string Product_Category_Name { get; set; }
        public string Product_SubCategory_Name { get; set; }

        public MaterialInfo()
        {
            Material_Entity = new M_Material();
        }

        public string Product_Type_Str
        {
            get
            {
                if (Material_Entity.Product_Type != 0)
                {
                    return ((ProductType)Material_Entity.Product_Type).ToString().Replace('_', ' ');
                }
                else
                {
                    return "";
                }
            }
            set
            {
                Product_Type_Str = value;
            }
        }
    }
}
