using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KusumgarBusinessEntities
{
   public class VendorInfo
    {

        public VendorInfo()
      {
         // Vendor_Entity = new M_Vendor();
          //Product_Vendor_Entity = new M_Product_Vendors();

          Material_Vendor_Details = new MaterialVendorInfo();

          Material_Category_Entity = new MaterialCategoryInfo();
       
       }
        //public M_Vendor Vendor_Entity { get; set; }

        //  public M_Product_Vendors Product_Vendor_Entity { get; set; }

        public int Vendor_Id { get; set; }

        public string Vendor_Name { get; set; }

        public string HeadOfficeAddress { get; set; }

        public int Head_Office_State { get; set; }

        public string Head_Office_ZipCode { get; set; }

        public int Head_Office_Nation { get; set; }

        public string Head_Office_Landline1 { get; set; }

        public string Head_Office_Landline2 { get; set; }

        public string Head_Office_FaxNo { get; set; }

        public string Email { get; set; }

        public string Quality_Certification { get; set; }

        public int Quality_Certification_Year { get; set; }

        public string Quality_Certification_Category { get; set; }

        public string Performance_Certification { get; set; }

        public int Performance_Certification_Year { get; set; }

        public string Performance_Certification_Category { get; set; }

        public string Remark_about_Supplier { get; set; }

        public bool Block_Payment { get; set; }

        public int Shipment_Methods { get; set; }

        public string Flagged_Supplier { get; set; }

        public string Delivary_Term_Code { get; set; }

        public bool Is_Approved_By_Director { get; set; }

        public string Central_Excise_Registration_Details { get; set; }

        public string Registration_No { get; set; }

        public string Range { get; set; }

        public string Division { get; set; }

        public string PAN { get; set; }

        public string TAN { get; set; }

        public string Tax_Excemption_Code { get; set; }

        public int Currency_Code { get; set; }

        public string VAT_Type { get; set; }

        public int PaymentTerms { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public int Product_Category { get; set; }

        public string Code { get; set; }

        #region Additional Fields

        public MaterialVendorInfo Material_Vendor_Details { get; set; }

        public MaterialCategoryInfo Material_Category_Entity { get; set; }
       
        public string PreviousCategoryName {get;set; }

        #endregion
    }
}
