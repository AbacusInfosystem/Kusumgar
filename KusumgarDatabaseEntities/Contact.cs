

namespace KusumgarDatabaseEntities
{
using System;
    using System.Collections.Generic;
    
public partial class Contact
{
    public int Contact_Id { get; set; }
    public int Contact_Type { get; set; }
    public int Customer_Id { get; set; }
    public int Vendor_Id { get; set; }
    public string Contact_Name { get; set; }
    public string Designation { get; set; }
    public string Office_Address { get; set; }
    public string Office_Landline1 { get; set; }
    public string Office_Landline2 { get; set; }
    public string Mobile1 { get; set; }
    public string Mobile2 { get; set; }
    public string Official_Email { get; set; }
    public string Personal_Email { get; set; }
    public bool Is_Billing_Contact { get; set; }
    public int DMU_Status_Role { get; set; }
    public int DMU_Status_Influence { get; set; }
    public bool Is_Active { get; set; }
    public System.DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public System.DateTime UpdatedOn { get; set; }
    public int UpdatedBy { get; set; }
        public int Customer_Contact_Type_Id { get; set; }
}
}
