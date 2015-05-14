﻿using System;
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
        EmployeeSearch,
        EmployeeInsert,
        EmployeeUpdate,
        RoleSearch,
        RoleInsert,
        RoleUpdate
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
        Yarn_type = 5,
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

        // Customer Address 
        Insert_Customer_Address,
        Update_Customer_Address,
        Delete_Customer_Address_By_Id,

        // Financial Details
        Insert_Bank_Details_Sp,
        Update_Bank_Details_Sp,

        //Nation
        Get_Nation_Sp,

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

        //Defect
        Get_Defects_sp,
        List_Defect_Types_sp,
        Get_Defect_By_Id_sp,
        Get_Defect_By_Name_By_Type_sp,
        Get_Defect_By_Name_sp,
        Get_Defect_By_Type_sp,
        Insert_Defect_sp,
        Update_Defect_sp,

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
        Get_Fabric_Types_sp,
        Get_Test_By_Fabric_Type_sp,
        Get_Test_Unit_AutoComplete_sp,

        //AttributeCode
        Get_Attribute_Codes_sp,
        Insert_Attribute_Code_sp,
        Get_Attribute_Code_By_Id_sp,
        Update_Attribute_Code_sp,
        Get_Attribute_Code_By_Attribute_Name_sp,

        // Complaint
        Insert_Complaint_Sp,
        Update_Complaint_Sp,
        Get_Complaint_List_Sp,
        Get_Complaint_By_Id_Sp,
        Get_Complaint_By_CustName_Sp,

        //ConsumableMaster
        Get_Consumable_Master_sp,
        Insert_ConsumableMaster_sp,

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

    public enum PaymentTerms
    {
        LC = 1,
        Cash = 2,
    }

    public enum DMUStatusRole
    {
        option1 = 1,
        option2 = 2,
        option3 = 3,
        option4 = 4,
        option5 = 5,
    }

    public enum DMUStatusInfluence
    {
        option1 = 1,
        option2 = 2,
        option3 = 3,
        option4 = 4,
        option5 = 5,
    }
   
}