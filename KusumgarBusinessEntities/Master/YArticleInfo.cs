using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class YArticleInfo
    {
        public YArticleInfo()
        {
            //YArticle_Entity = new M_Y_Article();
        }

        //public M_Y_Article YArticle_Entity { get; set; }

        public int Y_Article_Id { get; set; }

        public int Denier_Id { get; set; }

        public int Twist_Mingle_Id { get; set; }

        public int Twist_Type_Id { get; set; }

        public int Ply_Id { get; set; }

        public int Yarn_Type_Id { get; set; }

        public int Shade_Id { get; set; }

        public int Filaments_Id { get; set; }

        public int Origin_Id { get; set; }

        public int Shrinkage_Id { get; set; }

        public int Tenasity_Id { get; set; }

        public int Chemical_Treatment_Id { get; set; }

        public int Colour_Id { get; set; }

        public int Supplier_Id { get; set; }

        public string Full_Code { get; set; }

        public int Given_By_Id { get; set; }

        public int Validated_By_Id { get; set; }

        public int Developed_Under_Id { get; set; }

        public string Lead_Time_To_Purchase { get; set; }

        public int Work_Center_Id { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Additional Fields

        public string Denier_Name { get; set; }

        public string Twist_Mingle_Name { get; set; }

        public string Twist_Type_Name { get; set; }

        public string Ply_Name { get; set; }

        public string Yarn_Type_Name { get; set; }

        public string Shade_Name { get; set; }

        public string Filaments_Name { get; set; }

        public string Shrinkage_Name { get; set; }

        public string Tenasity_Name { get; set; }

        public string Chemical_Treatment_Name { get; set; }

        public string Colour_Name { get; set; }

        public string Supplier_Name { get; set; }

        public string Origin_Name { get; set; }

        public string Developed_Under_Name { get; set; }

        public string Given_By_Name { get; set; }

        public string Validated_By_Name { get; set; }

        public string Work_Center_Code { get; set; }

        #endregion

    }
}
