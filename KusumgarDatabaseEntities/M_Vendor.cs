//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KusumgarDatabaseEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_Vendor
    {
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
        public Nullable<int> Quality_Certification_Year { get; set; }
        public string Quality_Certification_Category { get; set; }
        public string Performance_Certification { get; set; }
        public string Remark_about_Supplier { get; set; }
        public Nullable<bool> Block_Payment { get; set; }
        public string Shipment_Methods { get; set; }
        public string Flagged_Supplier { get; set; }
        public string Delivary_Term_Code { get; set; }
        public Nullable<bool> Is_Approved_By_Director { get; set; }
        public string Central_Excise_Registration_Details { get; set; }
        public string Registration_No { get; set; }
        public string Range { get; set; }
        public string Division { get; set; }
        public string PAN { get; set; }
        public string TAN { get; set; }
        public string Tax_Excemption_Code { get; set; }
        public Nullable<int> Currency_Code { get; set; }
        public string VAT_Type { get; set; }
        public Nullable<int> PaymentTerms { get; set; }
        public bool Is_Active { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<int> Performance_Certification_Year { get; set; }
        public string Performance_Certification_Category { get; set; }
    }
}
