using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class YArticleInfo:M_Y_Article
    {
        public YArticleInfo()
        {
            //YArticle_Entity = new M_Y_Article();
        }

        //public M_Y_Article YArticle_Entity { get; set; }

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

        public string Work_Station_Code { get; set; }

    }
}
