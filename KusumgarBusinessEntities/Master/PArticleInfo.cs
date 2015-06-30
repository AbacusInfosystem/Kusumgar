using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KusumgarBusinessEntities
{
  public  class PArticleInfo

    {
        public int P_Article_Id { get; set; }

        public int Quality_No { get; set; }

        public int Yarn_Type_Id { get; set; }

        public int Weave_Id { get; set; }

        public int Shade_Id { get; set; }

        public int Chemical_Finish_Id { get; set; }

        public int Mechanical_Finish_Id { get; set; }

        public decimal P_Finish_width { get; set; }

        public int Type_Id { get; set; }

        public string Full_Code { get; set; }

        public int Given_By_Id { get; set; }

        public int Validated_By_Id { get; set; }

        public int Developed_Under_Id { get; set; }

        public string Batch { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string Yarn_Type_Name { get; set; }

        public string Weave_Name { get; set; }

        public string Shades_Name { get; set; }

        public string Chemical_Finish_Name { get; set; }

        public string Mechanical_Finish_Name { get; set; }

        public string Type_Name { get; set; }

        public string Developed_Under_Name { get; set; }

        public string Given_By_Name { get; set; }

        public string Validated_By_Name { get; set; }
        
        public int Quality_Nos { get; set; }

      //
        public string Yarn_Type_Code { get; set; }

        public string Weave_Code { get; set; }

        public string Shade_Code { get; set; }

        public string Chemical_Finish_Code { get; set; }

        public string Mechanical_Finish_Code { get; set; }

        public string Type_Code { get; set; }

    }
}

