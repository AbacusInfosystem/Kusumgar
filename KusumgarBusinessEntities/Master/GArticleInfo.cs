using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities.Common;



namespace KusumgarBusinessEntities
{
    public class GArticleInfo
    {
        public GArticleInfo()
        {
            Qualities = new List<QualityInfo>();

            Quality = new QualityInfo();

            Vendors = new List<VendorInfo>();

            Vendor = new VendorInfo();
        }

        public List<QualityInfo> Qualities { get; set; }

        public QualityInfo Quality { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public VendorInfo Vendor { get; set; }
       
        public int G_Article_Id { get; set; }

        public int Quality_Id { get; set; }

        public int Yarn_Type_Id { get; set; }

        public int Weave_Id { get; set; }

        public int Grey_with_Cms { get; set; }

        public int GSM { get; set; }

        public string Full_Code { get; set; }

        public int Warp_1 { get; set; }

        public int Warp_2 { get; set; }

        public int Warp_3 { get; set; }

        public int Warp_4 { get; set; }

        public int Weft_1 { get; set; }

        public int Weft_2 { get; set; }

        public int Weft_3 { get; set; }

        public int Weft_4 { get; set; }

        public string Reed { get; set; }

        public string Pick { get; set; }

        public string R_S { get; set; }

        public string G_W { get; set; }

        public int Total_Ends { get; set; }

        public decimal Beam_Weight { get; set; }

        public decimal Beam_Roll { get; set; }

        public decimal Weave { get; set; }

        public decimal No_Of_Healds { get; set; }

        public string Drawing_Sequence_Body { get; set; }

        public string Drawing_Sequence_Selvedge { get; set; }

        public int Roll_Size { get; set; }

        public int Warp_Yarn_Vendor { get; set; }

        public int Weft_Yarn_Vendor { get; set; }

        public int RSP { get; set; }

        public int Warping_Meters { get; set; }

        public string Draft { get; set; }

        public int Crimp_In_Percentage { get; set; }

        public int Peg_Plan_Rows { get; set; }

        public int Peg_Plan_Columns { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }
        
        public int Quality_No { get; set; }

        public string Yarn_Type_Name { get; set; }

        public string Weave_Name { get; set; }

        public string Warp_Yarn_Vendor_Name { get; set; }

        public string Weft_Yarn_Vendor_Name { get; set; }

        public string Warp_Name_1 { get; set; }
        public string Warp_Name_2 { get; set; }
        public string Warp_Name_3 { get; set; }
        public string Warp_Name_4 { get; set; }

        public string Weft_Name_1 { get; set; }
        public string Weft_Name_2 { get; set; }
        public string Weft_Name_3 { get; set; }
        public string Weft_Name_4 { get; set; }

        public string Yarn_Type_Code { get; set; }

        public string Weave_Code { get; set; }
      
    }

        
}
