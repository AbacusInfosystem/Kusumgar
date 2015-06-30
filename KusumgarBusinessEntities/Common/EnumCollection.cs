using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities.Common
{
    public enum MessageType
    {
        Danger,
        Info,
        Warning,
        Success
    }

    public enum AppFunction
    {
        // Dashboard
        Dashboard,

        // Employee
        Employee_Search,
        Employee_Create,
        Employee_Edit,

        // Role
        Role_Search,
        Role_Create,
        Role_Edit,

        // Customer
        Customer_Search,
        Customer_Create,
        Customer_Edit,

        // Customer Contact
        Customer_Contact_Search,
        Customer_Contact_Create,
        Customer_Contact_Edit,

        // Vendor
        Vendor_Search,
        Vendor_Create,
        Vendor_Edit,


        // Vendor Contact
        Vendor_Contact_Search,
        Vendor_Contact_Create,
        Vendor_Contact_Edit,

        // Material
        Material_Search,
        Material_Create,
        Material_Edit,

        // Workcenter
        Workcenter_Search,
        Workcenter_Create,
        Workcenter_Edit,

        // Defect
        Defect_Search,
        Defect_Create,
        Defect_Edit,

        // Defect Type
        Defect_Type_Search,
        Defect_Type_Create,
        Defect_Type_Edit,

        // Test
        Test_Search,
        Test_Create,
        Test_Edit,

        // Test Unit
        Test_Unit_Search,
        Test_Unit_Create,
        Test_Unit_Edit,

        // Attribute Code
        Attribute_Code_Search,
        Attribute_Code_Create,
        Attribute_Code_Edit,

        // Complaint
        Complaint_Search,
        Complaint_Create,
        Complaint_Edit,


        // YArticle
        YArticle_Search,
        YArticle_Create,
        YArticle_Edit,

        




    }

    public enum UserRoles
    {
        Director,
        PPC_Head,
        Sales_Head,
        PPC,
        Sales,
        Tender_Coordinator
    }

    public enum AttributeName
    {
        Denier = 1,
        TwistMingle = 2,
        Twist_type = 3,
        Ply = 4,
        Yarn_Type = 5,
        Shade = 6,
        Filaments = 7,
        Origin = 8,
        Shrinkage = 9,
        Tenasity = 10,
        Chemical_Treatment = 11,
        Colour = 12,
        Supplier = 13,
        Weave = 14,
        Chemical_Finish = 15,
        Mechanical_Finish = 16,
        Type = 17,
        Unit = 18,
        Process = 19,
        Department = 20
    }

    public enum StoredProcedures
    {
        //Login
        Authenticate_User_sp,
        Get_Session_Data_sp,

        // Employee 
        Update_User_Sp,
        Get_Users_By_Id_Sp,
        Insert_User_Sp,
        Get_Users_Sp,
        Get_Users_By_Name_Sp,
        Check_Existing_User_Sp,

        // Role 
        Get_Role_Sp,
        Insert_Role_Sp,
        Update_Role_Sp,
        Get_Role_By_Name_Sp,
        Get_Role_By_Id_Sp,
        Check_Existing_Role_Sp,


        // User Role Mapping
        Get_User_Role_By_UserId_Sp,
        Insert_User_Role_Sp,
        Delete_User_Role_By_UserId_Sp,

        // Role Access Function
        Get_Access_Function_Sp,
        Get_Access_Function_By_Role_Id_Sp,
        Insert_Role_Access_Sp,

        // Customer 
        Insert_Customer_sp,
        Update_Customer_Sp,
        Get_Customer_By_Name_Sp,
        Get_Customer_Sp,
        Get_Customer_By_Id_Sp,
        Check_Existing_Customer_Sp,
        Get_Customer_By_Email_Sp,
        Get_Customer_By_Turnover_Sp,
        Get_Customer_By_Turnover_Email_Sp,
        Get_Customer_By_Turnover_Name_Sp,
        Get_Customer_By_Email_Name_Sp,
        Get_Customer_By_Email_Name_Turnover_Sp,
        Get_Customer_by_Nation_Id_Sp,
        Get_Customer_by_Nation_Id_Turnover_Sp,
        Get_Customer_By_Turnover_Customer_Id_Sp,
        Get_Customer_By_Turnover_Customer_Id_Nation_Id_Sp,
        Get_Customer_By_Customer_Id_Nation_Id_Sp,
        Get_Customers_By_Status_Sp,
        //
        Get_Customers_By_Pin_Code_Nation_Id_State_Id_Customer_Id_Sp,
        Get_Customers_By_Pin_Code_Customer_Id_Nation_Id_Sp,
        Get_Customers_By_State_Id_Customer_Id_Nation_Id_Sp,
        Get_Customers_By_Pin_Code_Customer_Id_Sp,
        Get_Customers_by_Nation_Id_Pin_Code_Sp,
        Get_Customers_By_State_Id_Nation_Id_Sp,
        Get_Customers_By_Pin_Code_Sp,
        Get_Customers_By_Pin_Cide_Nation_Id_State_Id_Sp,
        Update_Customer_Other_By_Customer_Id_Sp,



        Update_Customer_Block_Order_Sp,

        // Customer Address 
        Insert_Customer_Address,
        Update_Customer_Address,
        Delete_Customer_Address_By_Id,

        // Customer Contact Type
        Insert_Customer_Contact_Type_Sp,
        Delete_Customer_Contact_Type_By_Id_Sp,
        Get_Customer_Contact_Type_By_Id_Sp,

        // Financial Details
        Insert_Bank_Details_Sp,
        Update_Bank_Details_Sp,

        //Nation
        Get_Nation_Sp,
        Get_Nation_By_Customer_Id_Sp,

        //State
        Get_State_By_Nation_Id_Sp,

        // Contact 
        Insert_Contact_sp,
        Update_Contact_sp,
        Get_Contact_sp,
        Get_Contact_By_Customer_Name_sp,
        
        // Contact Custom Fields
        Insert_Contact_Custom_Fields_Sp,
        Update_Contact_Custom_Fields_Sp,
        Get_Contact_Custom_Fields_by_Contact_Id_Sp,
        Get_Contact_by_Id_sp,
        Delete_Contact_Custom_Fields_By_Id,

        //Defect Type
        Get_Defect_Types_sp,
        Get_Defect_Type_By_Id_sp,
        Get_Defect_Type_By_Name_sp,
        Insert_Defect_Type_sp,
        Update_Defect_Type_sp,
        Get_Defect_AutoComplete_Sp,

        //Defect
        Get_Defects_sp,
        Get_Defect_By_Id_sp,
        Get_Defect_By_Defect_Name_By_Process_Name_sp,
        Get_Defect_By_Name_sp,
        Insert_Defect_sp,
        Update_Defect_sp,
        Get_Defect_By_Process_Id_sp,
        Get_Defect_Type_AutoComplete_Sp,

        //TestUnit
        Get_Test_Units_sp,
        Get_Test_Unit_By_Name_sp,
        Insert_Test_Unit_sp,
        Update_Test_Unit_sp,
        Get_Test_Unit_By_Id_sp,

        //Test
        Get_Tests_sp,
        Insert_Test_sp,
        Update_Test_sp,
        Get_Test_By_Id_sp,
        //Get_Fabric_Types_sp,
        //Get_Test_By_Fabric_Type_sp,
        Get_Test_By_Process_Id_sp,
        Get_Test_Unit_AutoComplete_sp,
        Get_Test_By_Test_Name_sp,

        //AttributeCode
        Get_Attribute_Codes_sp,
        Insert_Attribute_Code_sp,
        Get_Attribute_Code_By_Id_sp,
        Update_Attribute_Code_sp,
        Get_Attribute_Code_By_Attribute_Name_sp,

        // Complaint
        Insert_Complaint_Sp,
        Update_Complaint_Sp,
        Get_Complaints_Sp,
        Get_Complaint_By_Id_Sp,
        Get_Complaint_By_Cust_Id_Sp,
        Insert_Complaint_Lot_Mapping_Sp,
        Get_Complaint_Lot_Mapping_By_Complaint_Id_Sp,

        //ConsumableMaster
        Get_Category_Name_sp,
        Get_SubCategory_Name_sp,
        Get_Consumable_sp,
        Insert_Consumable_sp,
        Insert_Consumable_Vendor_sp,
        Get_Consumable_Vendor_sp,
        Delete_Vendor_By_Id,
        Get_Consumable_By_Id_sp,
        Update_Consumable_Sp,
        Get_Consumable_By_Category_By_Material_Sp,
        Get_Consumable_By_Category_Id_sp,
        Get_Consumable_By_Material_Name_sp,
        Get_Vendor_By_Name_Sp,
        Update_Consumable_Vendors_Sp,

        //VendorContact
        //Insert_Contact_sp,
        //Get_Vendor_By_Name_Sp,
        Get_Vendor_Contact_sp,
        Get_Vendor_Contact_By_Id_sp,
        Get_Vendor_Contacts_By_Vendor_Name_sp,
        Delete_Vendor_Contact_Custom_Field_By_Id,


        //Industrial
        Insert_Industrial_Master_Sp,
        Update_Industrial_Master_Sp,
        Get_Industrial_Master_List_Sp,
        Get_Industrial_Master_By_Id_Sp,
        Get_Industrial_Category_Sp,
        Get_Group_By_CategoryId_Sp,
        Insert_Industrial_Vendor_Sp,
        Delete_Industrial_Vendor_By_Id_Sp,
        Get_Industrial_Vendor_List_By_Id_Sp,
        Get_Industrial_Masters_By_Category_Name_Sp,
        Get_Industrial_Masters_By_Category_Group_Name_Sp,


        // Y Article 
        Insert_Y_Article_sp,
        Update_Y_Article_sp,
        Get_Y_Articles_sp,
        Get_Y_Articles_By_Full_Code_sp,
        Get_Y_Articles_By_Yarn_Type_Id_sp,
        Get_Y_Article_By_Id_sp,
        Get_Y_Articles_By_Full_Code_Yarn_Type_sp,
        Get_Y_Articles_By_YArticle_Id_Yarn_Type_sp,
        Get_Work_Centers_By_Code_Purpose_Sp,

        //Vendor

        Insert_Vendor_sp,
        Insert_Product_Vendors_sp,
        Get_Vendors_Sp,
        Update_Product_Vendors_sp,
        Update_Vendor_sp,
        Get_Vendor_By_Id_Sp,
        //Get_Vendor_By_Name_Sp,
        Delete_Product_Service_By_Id,
        Get_Product_Vendor_By_Id_Sp,
        Check_Existing_Vendor_Sp,
        Get_Vendors_By_Vendor_Id_Material_Id_Sp,
        Get_Vendors_By_Material_Id_Sp,
        Update_Vendor_Certificate_Sp,
        Update_Vendor_Other_Details_Sp,
        Update_Vendor_Central_Excise_Sp,

        
        Update_Attribute_Code_Name_sp,

        //Product
        Insert_Product_Sp,
        Update_Product_Sp,
        Get_Products_Sp,
        Get_Product_By_Id_Sp,
        Get_Product_Categories_sp,
        Get_Product_SubCategory_By_CategoryId_Sp,
        Get_Products_By_Product_Name_Sp,
        Get_Products_By_Product_Id_Sp,
        Insert_Product_Vendor_Sp,
        Delete_Product_Vendor_By_Id_Sp,
        Get_Product_Vendors_By_Id_Sp,

        // Material
        Insert_Material_Sp,
        Update_Material_Sp,
        Get_Materials_Sp,
        Get_Materials_By_Material_Id_Sp,
        Get_Materials_By_Material_Name_Sp,
        Get_Material_By_Id_Sp,
        Delete_Material_Vendor_By_Id_Sp,
        Get_Material_Vendors_By_Id_Sp,
        Insert_Material_Vendor_Sp,
        Get_Material_Categories_sp,
        Get_Material_SubCategory_By_CategoryId_Sp,
        Get_Materials_By_Material_Id_Vendor_Id_Sp,
        Get_Materials_By_Vendor_Id_Sp,

        // Work Center

        Get_Factories_Sp,
        Get_Processes_Sp,
        Get_Work_Centers_Sp,
        Get_Work_Centers_By_Factory_Id_Sp,
        Get_Work_Stations_By_Factory_Id_Sp,
        Get_Work_Stations_By_Work_Center_Id_Sp,
        Get_Work_Stations_By_Process_Id_Sp,
        Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_Sp,
        Get_Work_Stations_By_Factory_Id_By_Process_Id_Sp,
        Get_Work_Stations_By_Work_Center_Id_By_Process_Id_Sp,
        Get_Work_Stations_By_Factory_Id_By_Work_Center_Id_By_Process_Id_Sp,
        Insert_Work_Station_sp,
        Update_Work_Station_sp,
        Get_Work_Stations_Sp,
        Get_Work_Stations_By_Work_Station_Id_Sp,
        Insert_Work_Station_Process_sp,
        Delete_Work_Station_Process_By_Work_Station_Id_Sp,
        Get_Work_Center_By_Work_Station_Id_Sp,

        //Quality

        Insert_Quality_Sp,
        Update_Quality_Sp,
        Get_Quality_Sp,
        Get_Quality_By_Id_Sp,
        Get_Yarn_Types_sp,
        Get_Quality_By_Yarn_Types_Sp,
        Get_Weaves_Types_sp,
        Get_Application_AutoComplete_sp,
        Insert_Application_sp,
        Delete_Quality_Application_By_Id,
        Get_Quality_Application_sp,
        Get_Quality_Market_Segment_sp,
        Insert_Segment_sp,
        Delete_Quality_Market_Segment_By_Id_sp,
        Get_Segment_AutoComplete_sp,
        Check_Existing_Quality_No_Sp,
        Get_Work_Station_Processes_Sp,

        //Customer Quality
        Get_Qualities_Sp,
        Insert_Customer_Quality_Sp,
        Get_Customer_Quality_By_Id_Sp,
        Update_Customer_Quality_Sp,
        Get_Sample_By_No_Sp,
        Get_Customer_Qualities_Sp,
        Get_Customer_Qualities_By_Customer_Id_Sp,
        Get_Customer_Qualities_By_Quality_Id_Sp,
        Get_Customer_Qualities_By_Customer_Id_Quality_Id_Sp,

        //G Article
        Insert_G_Article_Sp,
        Update_G_Article_Sp,
        Get_G_Articles_Sp,
        Get_G_Articles_By_G_Article_Id_By_Yarn_Type_Id_Sp,
        Get_G_Articles_By_G_Article_Id_Sp,

        //PArticle

        Insert_P_Article_Sp,
        Update_P_Article_Sp,
        Get_P_Article_Sp,
 
        Get_P_Article_By_Id_sp,
        Get_P_Articles_By_Full_Code_sp,
        Get_P_Articles_By_Yarn_Type_Id_sp,
        Get_P_Articles_By_PArticle_Id_Yarn_Type_sp,
        // Enquiry
        Insert_Enquiry_Sp,
        Update_Enquiry_Sp,
        Get_Enquiries_Sp,
        Get_Enquiry_By_Id_Sp,
        Get_Enquiries_By_Status_Sp,
        Insert_Staggered_Order_Sp,
        Update_Staggered_Order_Sp,
        Get_Staggered_Order_Sp,
        Get_Staggered_Order_By_Id_Sp,
        Get_Staggered_Order_By_Enquiry_Id_Sp,
        Delete_Staggered_Order_By_Id,
        Insert_Temp_Customer_Quality_Details_Sp,
        Update_Temp_Customer_Quality_Details_Sp,
        Get_Temp_Customer_Quality_Details_By_Id_Sp,
        Insert_Supporting_Details_Sp,
        Update_Supporting_Details_Sp,
        Get_Supporting_Details_Sp,
        Get_Supporting_Details_By_Enquiry_Id_Sp,
        Get_Enquiries_By_Customer_Id_Sp,
        Get_Enquiries_By_Customer_Id_Quality_Id_Sp,
        Get_Enquiries_By_Quality_Id_Sp,
        Update_Enquiry_Quality_Id_Status_Sp,
        Get_Enquiries_By_Status_Ids_Sp,
        Get_Enquiries_For_PPC_Checkpoint_Sp,
        Get_Quality_Details_By_Id_Sp,
        Update_Enquiry_PPC_Checkpoint_Sp,

        // Quality 
        Get_Quality_Autocomplete,
        Get_G_Articles_By_Yarn_Type_Id_Sp,
        Get_G_Articles_By_Full_Code_Sp,



        // Attachments
        Insert_Attachment_Sp,
        Delete_Attachment_By_Id,
        Get_Attachments_By_Ref_Type_Ref_Id_Sp,
        Get_Attachments_By_Id_Sp,

        // Temp Functional Visual Parameters
        Insert_Temp_Functional_Parameters_Sp,
        Insert_Temp_Visual_Parameters_Sp,
        Get_Temp_Visual_Parameters_By_Enquiry_Id,
        Get_Temp_Functional_Parameters_By_Enquiry_Id,
        Delete_Temp_Functional_Parameters_By_Id,
        Delete_Temp_Visual_Parameters_By_Id,


        //Process
        Insert_Process_Sp,
        Update_Process_Sp,
        Get_Process_Sp,
        Get_Process_By_Id_Sp,
        Get_Process_By_Process_Name_Sp,

        //W Article
        Insert_W_Article_Sp,
        Update_W_Article_Sp,
        Get_W_Articles_Sp,
        Get_W_Article_By_Id_Sp,
        Get_W_Articles_By_Full_Code_Sp,
        Get_W_Articles_By_Yarn_Type_Id_Sp,
        Get_W_Articles_By_WArticle_Id_Yarn_Type_Sp,
        
        //C Article
        Insert_C_Article_Sp,
        Update_C_Article_Sp,
        Get_C_Articles_Sp,
        Get_C_Article_By_Id_Sp,
        Get_C_Articles_By_Full_Code_Sp,
        Get_C_Articles_By_Yarn_Type_Id_Sp,
        Get_C_Articles_By_CArticle_Id_Yarn_Type_Sp,

        //Packing
        Insert_Packing_Sp,
        Update_Packing_Sp,
        Get_Packing_Sp,
        Get_Packing_By_Id_Sp,
        Get_Packing_By_Packing_Name_Sp,
    }

    public enum GenderType
    {
        Male = 1,
        Female = 2,
        Transgender = 3
    }

    public enum CompanyType
    {
        Propritory =1,
        Private = 2,
        Limited= 3,
    }

    public enum CompanyStatus
    {
        Progressive = 1,
        Stable = 2,
        Turmoil = 3,
    }

    public enum CustomerAddressType
    {
        Shipping = 1,
        Billing = 2,
    }

    public enum CurrencyType
    {
        Rupees = 1,
        Dollars = 2,
        Euros = 3,
        Pounds = 4,
    }
    public enum PriorityOrder
    {
        Primary = 1,
        Secondary = 2,
        Last_Option = 3,
    }


    public enum PaymentTerms
    {
        LC = 1,
        Cash = 2,
    }

    public enum DMUStatusRole
    {
        Initiator = 1,
        Decider = 2,
        Influencer = 3,
        User = 4,
        Gatekeeper = 5,
        Champion = 6,
        Coach = 7,
    }

    public enum DMUStatusInfluence
    {
        option1 = 1,
        option2 = 2,
        option3 = 3,
        option4 = 4,
        option5 = 5,
    }
   
      public enum ProductVendor
      {
          ProductType=1,
          Service=2
      }
   
    public enum ShipmentMethod
    {
        method1=1,
        method2=2
    }

    public enum ArticleType
    {
        YArticle = 1,
        WArticle = 2,
        GArticle = 3,
        PArticle = 4,
        CArticle = 5
    }

    public enum ProductType
    {
        Finish_Product = 1,
        Raw_Material =2,
        Service = 3
    }

    public enum EnquiryType
    {
        Trial =1,
        Stock = 2,
        General = 3
    }

    public enum EnquiryStatus
    {
        Enquiry_Arrived = 1,
        Passed_PPC_Check_Point = 2,
        Passed_W_Manager_Check_Point = 3,
        Passed_P_Manager_Check_Point = 4,
        Passed_C_Manager_Check_Point = 5,
        Temp_Quality_Set_Created = 6,
        Quality_Assigned = 7,
        Planned = 8
    }

    public enum OrderStatus
    {
        Order_Arrived = 1,
        
    }

    public enum RefType
    {
        Enquiry = 1, 
    }

    public enum DispatchType
    {
        By_Sea = 1,
        By_Air = 2,
        By_Route = 3,
    }

    // Temp Enums
    public enum Order
    {
        ord0001 = 1,
        ord0002 = 2,
        ord0003 = 3,
        ord0004 = 4,
        ord0005 = 5,
    }

    public enum Challan_No
    {
        cha001 = 1,
        cha002 = 2,
        cha003 = 3,
        cha004 = 4,
        cha005 = 5,
    }

    public enum Lot_No
    {
        lot001 = 1,
        lot002 = 2,
        lot003 = 3,
        lot004 = 4,
        lot005 = 5,
    }

    // 

}
