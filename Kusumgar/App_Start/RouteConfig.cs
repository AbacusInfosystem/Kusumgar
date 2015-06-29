using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kusumgar
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Menu

            routes.MapRoute(
            name: "menu-1",
            url: "crm/customer/search",
            defaults: new { controller = "Customer", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-2",
            url: "crm/contact/search",
            defaults: new { controller = "Contact", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-3",
            url: "master/defect-type/search",
            defaults: new { controller = "DefectType", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-4",
            url: "master/defect/search",
            defaults: new { controller = "Defect", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-5",
            url: "master/process/search",
            defaults: new { controller = "Process", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-6",
            url: "master/process-route-code/search",
            defaults: new { controller = "ProcessRouteCode", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-7",
            url: "master/workcenter/search",
            defaults: new { controller = "Workcenter", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-8",
            url: "master/test-unit/search",
            defaults: new { controller = "TestUnit", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-9",
            url: "master/test/search",
            defaults: new { controller = "Test", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-10",
            url: "master/attibute-code/search",
            defaults: new { controller = "AttributeCode", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-11",
            url: "master/y-article/search",
            defaults: new { controller = "YArticle", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-12",
            url: "master/w-article/search",
            defaults: new { controller = "WArticle", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-13",
            url: "master/g-article/search",
            defaults: new { controller = "GArticle", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-14",
            url: "master/p-article/search",
            defaults: new { controller = "PArticle", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-15",
            url: "master/c-article/search",
            defaults: new { controller = "CArticle", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-16",
            url: "master/peg-plan/search",
            defaults: new { controller = "PegPlan", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-17",
            url: "master/article-process-workcenter/search",
            defaults: new { controller = "ArticleProcessWorkCenter", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-18",
            url: "master/quality-creation/search",
            defaults: new { controller = "Quality", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-19",
            url: "master/customer-quality-creation/search",
            defaults: new { controller = "CustomerQualityCreation", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-20",
            url: "sales/enquiry/search",
            defaults: new { controller = "Enquiry", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-21",
            url: "ppc/enquiry/search",
            defaults: new { controller = "Enquiry", action = "Search_PPC_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-22",
            url: "w-manager/enquiry/search",
            defaults: new { controller = "Enquiry", action = "Search_W_Manager_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-23",
            url: "p-manager/enquiry/search",
            defaults: new { controller = "Enquiry", action = "Search_P_Manager_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-24",
            url: "c-manager/enquiry/search",
            defaults: new { controller = "Enquiry", action = "Search_C_Manager_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-25",
            url: "quality-manager/enquiry/search",
            defaults: new { controller = "Enquiry", action = "Search_Quality_Manager_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-26",
            url: "ppc-planning/enquiry/search",
            defaults: new { controller = "Enquiry", action = "Search_PPC_Planning", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-27",
            url: "employee/search",
            defaults: new { controller = "User", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "menu-28",
           url: "role/search",
           defaults: new { controller = "Role", action = "Search", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "menu-29",
           url: "crm/complaint/search",
           defaults: new { controller = "Complaint", action = "Search", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });


            routes.MapRoute(
          name: "menu-30",
          url: "master/consumable/search",
          defaults: new { controller = "Consumable", action = "Search", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
         name: "menu-31",
         url: "master/material/search",
         defaults: new { controller = "Material", action = "Search", id = UrlParameter.Optional },
         namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-32",
            url: "master/vendor/search",
            defaults: new { controller = "Vendor", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "menu-33",
            url: "master/material/search",
            defaults: new { controller = "Material", action = "Search", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region PostLogin

            #region System

            routes.MapRoute(
            name: "system-1",
            url: "system/unauthorize-access/{returnURL}",
            defaults: new { controller = "System", action = "UnAuthorize", returnURL = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "system-2",
            url: "system/error",
            defaults: new { controller = "System", action = "Error", returnURL = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "system-3",
            url: "system/printable-view/{page_String}/{id}",
            defaults: new { controller = "System", action = "PrintableView", page_String = UrlParameter.Optional, id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion



            #region Dashboard

            routes.MapRoute(
            name: "dashboard-1",
            url: "dashboard",
            defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region CRM

            #region Customer

            routes.MapRoute(
            name: "customer-1",
            url: "crm/customer",
            defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-2",
            url: "crm/search-customer",
            defaults: new { controller = "Customer", action = "Get_Customers", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-3",
            url: "crm/insert-customer",
            defaults: new { controller = "Customer", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-4",
            url: "crm/update-customer",
            defaults: new { controller = "Customer", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-5",
            url: "crm/insert-customer-address",
            defaults: new { controller = "Customer", action = "Insert_Customer_Address", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-6",
            url: "crm/update-customer-address",
            defaults: new { controller = "Customer", action = "Update_Customer_Address", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
           name: "customer-7",
           url: "crm/insert-bank-details",
           defaults: new { controller = "Customer", action = "Insert_Bank_Details", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-8",
            url: "crm/update-bank-details",
            defaults: new { controller = "Customer", action = "Update_Bank_Details", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-9",
            url: "crm/state-by-nation-id",
            defaults: new { controller = "Customer", action = "Get_State_by_Nation_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-10",
            url: "crm/edit-customer",
            defaults: new { controller = "Customer", action = "Get_Customer_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-11",
            url: "crm/delete-customer",
            defaults: new { controller = "Customer", action = "Delete_Customer_Address_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-12",
            url: "crm/check-customer",
            defaults: new { controller = "Customer", action = "Check_Existing_Customer", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers.PostLogin.CRM" });

            routes.MapRoute(
            name: "customer-13",
            url: "customer/customer-list/{Customer_Name}",
            defaults: new { controller = "Customer", action = "Get_Customer_AutoComplete", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-14",
            url: "customer/block-order",
            defaults: new { controller = "Customer", action = "Update_Customer_Block_Order", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-15",
            url: "crm/states-by-nation",
            defaults: new { controller = "Customer", action = "Get_States_By_Nation", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
             name: "customer-16",
            url: "crm/search-customers-by-status",
            defaults: new { controller = "Customer", action = "Get_Customers_By_Status", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-17",
            url: "master/insert-customer-contact-type",
            defaults: new { controller = "Customer", action = "Insert_Customer_Contact_Type", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-18",
            url: "master/delete-customer-contact-type",
            defaults: new { controller = "Customer", action = "Delete_Customer_Contact_Type_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "customer-19",
           url: "crm/update-customer-other",
           defaults: new { controller = "Customer", action = "Update_Customer_Other", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-20",
            url: "crm/view-customer",
            defaults: new { controller = "Customer", action = "View_Customer", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-21",
            url: "crm/print-view-customer",
            defaults: new { controller = "Customer", action = "Printable_Customer", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

           

            #endregion

            #region Contact

            routes.MapRoute(
            name: "contact-1",
            url: "crm/contact",
            defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "contact-2",
            url: "crm/contact-search",
            defaults: new { controller = "Contact", action = "Get_Contact_List", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "contact-3",
            url: "crm/get-contact-by-id",
            defaults: new { controller = "Contact", action = "Get_Contact_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "contact-4",
            url: "crm/contact-insert",
            defaults: new { controller = "Contact", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "contact-5",
            url: "crm/contact-update",
            defaults: new { controller = "Contact", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "contact-6",
            url: "crm/contact-custom-field-insert",
            defaults: new { controller = "Contact", action = "Insert_Contact_Custom_Fields", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "contact-7",
            url: "crm/contact-custom-field-update",
            defaults: new { controller = "Contact", action = "Update_Contact_Custom_Fields", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "contact-8",
            url: "crm/delete-contact-custom-field",
            defaults: new { controller = "Contact", action = "Delete_Contact_Custom_Fields", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "contact-9",
           url: "crm/view-contact",
           defaults: new { controller = "Contact", action = "View_Contact", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });
            routes.MapRoute(
            name: "contact-10",
            url: "crm/contact-type-by-customer-id",
            defaults: new { controller = "Contact", action = "Get_Contact_Type_By_Customer_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
          name: "contact-11",
          url: "crm/print-view-contact",
          defaults: new { controller = "Contact", action = "Printable_Contact", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });


            #endregion

            #region Complaint

            routes.MapRoute(
            name: "complaint-1",
            url: "crm/complaint",
            defaults: new { controller = "Complaint", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "complaint-2",
            url: "crm/edit-complaint",
            defaults: new { controller = "Complaint", action = "Get_Complaint_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "complaint-3",
            url: "crm/insert-complaint",
            defaults: new { controller = "Complaint", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "complaint-4",
            url: "crm/update-complaint",
            defaults: new { controller = "Complaint", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "complaint-5",
            url: "crm/search-complaint",
            defaults: new { controller = "Complaint", action = "Get_Complaints", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "complaint-6",
            url: "crm/get-customer-id-by-customername/{customer_Name}",
            defaults: new { controller = "Complaint", action = "Get_Customer_Id", customer_Name = UrlParameter.Optional }
            );

            routes.MapRoute(
           name: "complaint-7",
           url: "crm/get-complaint/{customer_Id}",
           defaults: new { controller = "Complaint", action = "Get_Complaint_Pre_Login", customer_Id = UrlParameter.Optional }
           );

            routes.MapRoute(
         name: "complaint-8",
         url: "crm/insert-complaint-pre-login/",
         defaults: new { controller = "Complaint", action = "Insert_Complaint_Pre_Login", id = UrlParameter.Optional }
         );

            routes.MapRoute(
         name: "complaint-9",
         url: "crm/get-lot-no/{lot_No}",
         defaults: new { controller = "Complaint", action = "Get_Lot_No", lot_No = UrlParameter.Optional }
         );

            #endregion

            #endregion

            #region Masters

            #region DefectType

            routes.MapRoute(
            name: "defect-type-1",
            url: "master/defect-type-creation",
            defaults: new { controller = "DefectType", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "defect-type-2",
            url: "master/insert-defect-type",
            defaults: new { controller = "DefectType", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
             name: "defect-type-3",
             url: "master/edit-defect-type",
             defaults: new { controller = "DefectType", action = "Get_Defect_Type_By_Id", id = UrlParameter.Optional },
             namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
                       name: "defect-type-4",
                       url: "master/update-defect-type",
                       defaults: new { controller = "DefectType", action = "Update", id = UrlParameter.Optional },
                       namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "defect-type-5",
           url: "ajax/defect-type-list/{defect_Type_Name}",
           defaults: new { controller = "DefectType", action = "Get_Defect_Type_AutoComplete", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Defect

            routes.MapRoute(
            name: "defect-1",
            url: "master/defect-creation",
            defaults: new { controller = "Defect", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "defect-2",
            url: "master/insert-defect",
            defaults: new { controller = "Defect", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "defect-3",
            url: "master/edit-defect",
            defaults: new { controller = "Defect", action = "Get_Defect_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "defect-4",
            url: "master/update-defect",
            defaults: new { controller = "Defect", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "defect-5",
           url: "ajax/defect-list/{defect_Name}",
           defaults: new { controller = "Defect", action = "Get_Defect_AutoComplete", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Process

            routes.MapRoute(
            name: "process-1",
            url: "master/process",
            defaults: new { controller = "Process", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "process-2",
            url: "master/edit-process",
            defaults: new { controller = "Process", action = "Get_Process_By_Process_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "process-3",
            url: "master/insert-process",
            defaults: new { controller = "Process", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "process-4",
            url: "master/update-process",
            defaults: new { controller = "Process", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "process-5",
            url: "master/search-process",
            defaults: new { controller = "Process", action = "Get_Process", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "process-6",
            url: "master/get-process-id-by-process-name/{process_Name}",
            defaults: new { controller = "Process", action = "Get_Process_By_Name_Autocomplete", process_Name = UrlParameter.Optional }
            );

            #endregion

            #region Process Route Code

            routes.MapRoute(
            name: "process-route-code-1",
            url: "master/process-route-code",
            defaults: new { controller = "ProcessRouteCode", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Test Unit

            routes.MapRoute(
            name: "test-unit-1",
            url: "master/test-unit-creation",
            defaults: new { controller = "TestUnit", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "test-unit-2",
           url: "master/insert-test-unit",
           defaults: new { controller = "TestUnit", action = "Insert", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "test-unit-3",
           url: "master/edit-test-unit",
           defaults: new { controller = "TestUnit", action = "Get_Test_Unit_By_Id", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "test-unit-4",
           url: "master/update-test-unit",
           defaults: new { controller = "TestUnit", action = "Update", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });




            #endregion

            #region Test

            routes.MapRoute(
            name: "test-1",
            url: "master/test-creation",
            defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "test-2",
           url: "master/insert-test",
           defaults: new { controller = "Test", action = "Insert", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "test-3",
           url: "master/edit-test",
           defaults: new { controller = "Test", action = "Get_Test_By_Id", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "test-4",
           url: "master/update-test",
           defaults: new { controller = "Test", action = "Update", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "test-5",
           url: "master/test-autocomplete/{test_Name}",
           defaults: new { controller = "Test", action = "Get_Test_Autocomplete", test_Name = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });


            #endregion

            #region Attribute Code

            routes.MapRoute(
            name: "attribute-code-1",
            url: "master/attribute-code-creation",
            defaults: new { controller = "AttributeCode", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "attribute-code-2",
           url: "master/insert-attribute-code",
           defaults: new { controller = "AttributeCode", action = "Insert", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "attribute-code-3",
           url: "master/edit-attribute-code",
           defaults: new { controller = "AttributeCode", action = "Get_Attribute_Code_By_Id", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "attribute-code-4",
           url: "master/update-attribute-code",
           defaults: new { controller = "AttributeCode", action = "Update", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Y Article

            routes.MapRoute(
            name: "y-article-1",
            url: "master/y-article",
            defaults: new { controller = "YArticle", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "y-article-2",
            url: "master/partial-y-article",
            defaults: new { controller = "YArticle", action = "Load_YArticle", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "y-article-3",
           url: "master/y-article/get-by-id",
           defaults: new { controller = "YArticle", action = "Get_YArticle_By_Id", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "y-article-4",
            url: "master/y-article/insert",
            defaults: new { controller = "YArticle", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "y-article-5",
            url: "master/y-article/update",
            defaults: new { controller = "YArticle", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "y-article-6",
            url: "master/y-articles/search",
            defaults: new { controller = "YArticle", action = "Get_YArticles", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "y-article-7",
            url: "master/y-articles-by-full-code/{full_Code}",
            defaults: new { controller = "YArticle", action = "Get_YArticles_By_Full_Code", full_Code = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "y-article-8",
            url: "master/y-articles/get-work-stations-by-code-purpose/{work_Station_Code}",
            defaults: new { controller = "YArticle", action = "Get_Work_Stations_By_Code_Purpose", work_Station_Code = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region W Article

            routes.MapRoute(
            name: "w-article-1",
            url: "master/w-article",
            defaults: new { controller = "WArticle", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "w-article-2",
            url: "master/partial-w-article",
            defaults: new { controller = "WArticle", action = "Load_WArticle", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "w-article-3",
            url: "master/w-article/get-by-id",
            defaults: new { controller = "WArticle", action = "Get_WArticle_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "w-article-4",
            url: "master/w-article/insert",
            defaults: new { controller = "WArticle", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "w-article-5",
            url: "master/w-article/update",
            defaults: new { controller = "WArticle", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "w-article-6",
            url: "master/w-articles/search",
            defaults: new { controller = "WArticle", action = "Get_WArticles", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "w-article-7",
            url: "master/w-articles-by-full-code/{full_Code}",
            defaults: new { controller = "WArticle", action = "Get_WArticles_By_Full_Code", full_Code = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region G Article

            routes.MapRoute(
            name: "g-article-1",
            url: "master/g-article",
            defaults: new { controller = "GArticle", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "g-article-2",
            url: "master/g-article/insert",
            defaults: new { controller = "GArticle", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "g-article-3",
            url: "master/g-article/update",
            defaults: new { controller = "GArticle", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "g-article-4",
            url: "master/g-articles-search",
            defaults: new { controller = "GArticle", action = "Get_G_Articles", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "g-article-5",
           url: "master/g-article/get-by-id",
           defaults: new { controller = "GArticle", action = "Get_G_Article_By_Id", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "g-article-6",
            url: "master/g-articles-by-full-code/{full_Code}",
            defaults: new { controller = "GArticle", action = "Get_G_Articles_By_Full_Code", full_Code = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "g-article-7",
           url: "master/view-g-article",
           defaults: new { controller = "GArticle", action = "View_G_Article", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "g-article-8",
            url: "master/print-view-g-article",
            defaults: new { controller = "GArticle", action = "Printable_G_Article", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region P Article

            routes.MapRoute(
           name: "p-article-1",
           url: "master/p-article",
           defaults: new { controller = "PArticle", action = "Index", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
          name: "p-article-2",
          url: "master/p-article/get-by-id",
          defaults: new { controller = "PArticle", action = "Get_PArticle_By_Id", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "p-article-3",
            url: "master/p-article/insert",
            defaults: new { controller = "PArticle", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "p-article-4",
            url: "master/p-article/update",
            defaults: new { controller = "PArticle", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "p-article-5",
            url: "master/p-articles/search",
            defaults: new { controller = "PArticle", action = "Get_PArticles", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "p-article-6",
            url: "master/p-articles-by-full-code/{full_Code}",
            defaults: new { controller = "PArticle", action = "Get_PArticles_By_Full_Code", full_Code = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });
            #endregion

            #region C Article

            routes.MapRoute(
            name: "c-article-1",
            url: "master/c-article",
            defaults: new { controller = "CArticle", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "c-article-2",
            url: "master/partial-c-article",
            defaults: new { controller = "CArticle", action = "Load_CArticle", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "c-article-3",
            url: "master/c-article/get-by-id",
            defaults: new { controller = "CArticle", action = "Get_CArticle_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "c-article-4",
            url: "master/c-article/insert",
            defaults: new { controller = "CArticle", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "c-article-5",
            url: "master/c-article/update",
            defaults: new { controller = "CArticle", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "c-article-6",
            url: "master/c-articles/search",
            defaults: new { controller = "CArticle", action = "Get_CArticles", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "c-article-7",
            url: "master/c-articles-by-full-code/{full_Code}",
            defaults: new { controller = "CArticle", action = "Get_CArticles_By_Full_Code", full_Code = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Peg Plan

            routes.MapRoute(
          name: "peg-plan-1",
          url: "master/peg-plan",
          defaults: new { controller = "PegPlan", action = "Index", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Article Process Workcenter

            routes.MapRoute(
            name: "article-process-workcenter-1",
            url: "master/article-process-workcenter",
            defaults: new { controller = "ArticleProcessWorkCenter", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Quality Creation

            routes.MapRoute(
            name: "quality-1",
            url: "master/quality-creation",
            defaults: new { controller = "Quality", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-2",
            url: "master/insert-quality",
            defaults: new { controller = "Quality", action = "Insert_Quality", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-3",
            url: "master/update-quality",
            defaults: new { controller = "Quality", action = "Update_Quality", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-4",
            url: "master/get-quality-by-id",
            defaults: new { controller = "Quality", action = "Get_Quality_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-5",
            url: "master/delete-quality_application",
            defaults: new { controller = "Quality", action = "Delete_Quality_Application_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-6",
            url: "master/insert-quality-application",
            defaults: new { controller = "Quality", action = "Insert_Application", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-7",
            url: "master/delete-quality_segment",
            defaults: new { controller = "Quality", action = "Delete_Quality_Market_Segment_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-8",
            url: "master/insert-quality-segemnt",
            defaults: new { controller = "Quality", action = "Insert_Segment", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-9",
            url: "master/check-quality-no",
            defaults: new { controller = "Quality", action = "Check_Existing_Quality_No", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-10",
            url: "master/view-quality",
            defaults: new { controller = "Quality", action = "View_Quality", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "quality-11",
            url: "master/print-view-quality",
            defaults: new { controller = "Quality", action = "Printable_Quality", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Customer Quality Creation

            routes.MapRoute(
            name: "customer-quality-1",
            url: "master/customer-quality-creation",
            defaults: new { controller = "CustomerQuality", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-quality-2",
            url: "master/customer-quality-insert",
            defaults: new { controller = "CustomerQuality", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-quality-3",
            url: "master/customer-quality-details-update",
            defaults: new { controller = "CustomerQuality", action = "Update_Details", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-quality-4",
            url: "master/sample-no-list/{sample_No}",
            defaults: new { controller = "CustomerQuality", action = "Get_Sample_No_AutoComplete", sample_No = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-quality-5",
            url: "master/customer-quality-search",
            defaults: new { controller = "CustomerQuality", action = "Get_Customer_Qualities", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-quality-6",
            url: "master/get-customer-quality-by-id",
            defaults: new { controller = "CustomerQuality", action = "Get_Customer_Quality_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "customer-quality-7",
            url: "master/customer-quality-update",
            defaults: new { controller = "CustomerQuality", action = "Update_Details", id = UrlParameter.Optional },
            // defaults: new { controller = "CustomerQuality", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region User

            routes.MapRoute(
            name: "user-1",
            url: "master/employee-creation",
            defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "user-2",
            url: "master/edit-employee",
            defaults: new { controller = "User", action = "Get_User_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "user-3",
            url: "master/insert-employee",
            defaults: new { controller = "User", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "user-4",
            url: "master/update-employee",
            defaults: new { controller = "User", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "user-5",
            url: "master/search-employee",
            defaults: new { controller = "User", action = "Get_Users", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "user-6",
            url: "master/check-user",
            defaults: new { controller = "User", action = "Check_Existing_User", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "user-7",
            url: "master/search-employee-by-name/{name}",
            defaults: new { controller = "User", action = "Get_Users_By_Name",  name = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Role

            routes.MapRoute(
            name: "role-1",
            url: "master/role-creation",
            defaults: new { controller = "Role", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "role-2",
            url: "master/edit-role",
            defaults: new { controller = "Role", action = "Get_Role_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "role-3",
            url: "master/insert-role",
            defaults: new { controller = "Role", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "role-4",
            url: "master/update-role",
            defaults: new { controller = "Role", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "role-5",
            url: "master/search-role",
            defaults: new { controller = "Role", action = "Get_Roles", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "role-6",
            url: "master/check-role",
            defaults: new { controller = "Role", action = "Check_Existing_Role", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "role-7",
           url: "master/search-role-by-name/{name}",
           defaults: new { controller = "Role", action = "Get_Roles_By_Name", name = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Ajax

            routes.MapRoute(
            name: "ajax-1",
            url: "ajax/test/{testUnitName}",
            defaults: new { controller = "Test", action = "Get_Test_Unit_AutoComplete", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
          name: "ajax-2",
          url: "ajax/attachments",
          defaults: new { controller = "Ajax", action = "Insert_Attachment", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
          name: "ajax-3",
          url: "ajax/delete-attachments",
          defaults: new { controller = "Ajax", action = "Delete_Attachment", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
          name: "ajax-4",
          url: "ajax/get-attachments-by-ref-type-id",
          defaults: new { controller = "Ajax", action = "Get_Attachments_By_Ref_Type_Ref_Id", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Vendor

            routes.MapRoute(
            name: "vendor-1",
            url: "master/vendor-creation",
            defaults: new { controller = "Vendor", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "vendor-2",
            url: "master/insert-vendor",
            defaults: new { controller = "Vendor", action = "Insert_Vendor", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
           name: "vendor-3",
           url: "master/update-vendor",
           defaults: new { controller = "Vendor", action = "Update_Vendor", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

           
           routes.MapRoute(
           name: "vendor-4",
           url: "master/get-state-by-nation-id",
           defaults: new { controller = "Vendor", action = "Get_State_by_Nation_Id", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
           name: "vendor-5",
           url: "master/insert-product-service",
           defaults: new { controller = "Vendor", action = "Insert_Product_Service", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
           name: "vendor-6",
           url: "master/update-product-service",
           defaults: new { controller = "Vendor", action = "Update_Product_Service", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

          routes.MapRoute(
          name: "vendor-7",
          url: "master/delete-product-service",
          defaults: new { controller = "Vendor", action = "Delete_Product_Service_By_Id", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

          routes.MapRoute(
            name: "vendor-8",
            url: "master/check-vendor",
            defaults: new { controller = "Vendor", action = "Check_Existing_Vendor", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

          routes.MapRoute(
         name: "vendor-9",
         url: "master/partial-vendor",
         defaults: new { controller = "Vendor", action = "Load_Vendor", id = UrlParameter.Optional },
         namespaces: new string[] { "Kusumgar.Controllers" });

          routes.MapRoute(
       name: "vendor-10",
       url: "ajax/vendor-list/{vendor_Name}",
       defaults: new { controller = "Vendor", action = "Get_Vendor_Autocomplete", id = UrlParameter.Optional },
       namespaces: new string[] { "Kusumgar.Controllers" });


           routes.MapRoute(
           name: "vendor-11",
           url: "master/view-vendor",
           defaults: new { controller = "Vendor", action = "View_Vendor", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
           name: "vendor-12",
           url: "master/print-view-vendor",
           defaults: new { controller = "Vendor", action = "Printable_Vendor", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
         name: "vendor-13",
         url: "master/update-vendor-certificate",
         defaults: new { controller = "Vendor", action = "Update_Vendor_Certificate", id = UrlParameter.Optional },
         namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
          name: "vendor-14",
          url: "master/update-vendor-other-details",
          defaults: new { controller = "Vendor", action = "Update_Vendor_Other_Details", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
          name: "vendor-15",
          url: "master/update-vendor-central-excise",
          defaults: new { controller = "Vendor", action = "Update_Vendor_Central_Excise", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });


            #endregion

            #region Industrial

            routes.MapRoute(
            name: "industrial-1",
            url: "master/industrial",
            defaults: new { controller = "Industrial", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-2",
            url: "master/edit-industrial-master",
            defaults: new { controller = "Industrial", action = "Get_Industrial_Master_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-3",
            url: "master/insert-industrial-master",
            defaults: new { controller = "Industrial", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-4",
            url: "master/update-industrial-master",
            defaults: new { controller = "Industrial", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-5",
            url: "master/search-industrial-master",
            defaults: new { controller = "Industrial", action = "Get_Industrial_Masters", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-6",
            url: "master/group-by-category-id",
            defaults: new { controller = "Industrial", action = "Get_Group_By_CategoryId", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-7",
            url: "master/insert-industrial-vendor",
            defaults: new { controller = "Industrial", action = "Insert_Industrial_Vendor", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-8",
            url: "master/delete-industrial-vendor",
            defaults: new { controller = "Industrial", action = "Delete_Industrial_Vendor_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "industrial-9",
            url: "master/get-vendor-id-by-vendorname/{vendor_Name}",
            defaults: new { controller = "Industrial", action = "Get_Vendor_Autocomplete", vendor_Name = UrlParameter.Optional }
            );            

            #endregion

            #region Consumable

            routes.MapRoute(
            name: "Consumable-1",
            url: "master/Consumable",
            defaults: new { controller = "Consumable", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-2",
            url: "master/insert-consumable",
            defaults: new { controller = "Consumable", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-3",
            url: "master/search-consumable",
            defaults: new { controller = "Consumable", action = "Get_Consumables", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            //For Autocomplete
            routes.MapRoute(
            name: "Consumable-4",
            url: "master/insert_Consumable",
            defaults: new { controller = "Consumable", action = "Get_Supplier_Name", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-5",
            url: "master/insert-consumable_vendor",
            defaults: new { controller = "Consumable", action = "Insert_Consumable_Vendor", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-6",
            url: "master/delete-vendor",
            defaults: new { controller = "Consumable", action = "Delete_Vendor_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-7",
            url: "master/edit-consumable",
            defaults: new { controller = "Consumable", action = "Get_Consumable_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-8",
            url: "master/update-consumable",
            defaults: new { controller = "Consumable", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-9",
            url: "master/vendor-list/{vendor_Name}",
            defaults: new { controller = "Consumable", action = "Get_Vendor_AutoComplete", vendor_Name = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "Consumable-10",
            url: "master/update-consumable_vendor",
            defaults: new { controller = "Consumable", action = "Update_Consumable_Vendors", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region material

            routes.MapRoute(
            name: "material-1",
            url: "master/material",
            defaults: new { controller = "Material", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-2",
            url: "master/edit-material",
            defaults: new { controller = "Material", action = "Get_Material_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-3",
            url: "master/insert-material",
            defaults: new { controller = "Material", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-4",
            url: "master/update-material",
            defaults: new { controller = "Material", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-5",
            url: "master/search-material",
            defaults: new { controller = "Material", action = "Get_Materials", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-6",
            url: "master/material-subcategory-by-category-id",
            defaults: new { controller = "Material", action = "Get_Material_SubCategory_By_Category_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-7",
            url: "master/get-material-by-material-name/{Material_Name}",
            defaults: new { controller = "Material", action = "Get_Materials_By_Name_Autocomplete", Material_Name = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "material-8",
            url: "master/get-vendor-id-by-vendorname/{vendor_Name}",
            defaults: new { controller = "Material", action = "Get_Vendor_Autocomplete", vendor_Name = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "material-9",
            url: "master/insert-material-vendor",
            defaults: new { controller = "Material", action = "Insert_Material_Vendor", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-10",
            url: "master/delete-material-vendor",
            defaults: new { controller = "Material", action = "Delete_Material_Vendor_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "material-11",
           url: "master/view-material",
           defaults: new { controller = "Material", action = "View_Material", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-12",
            url: "master/print-view-material",
            defaults: new { controller = "Material", action = "Printable_Material", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region VendorContact

            routes.MapRoute(
            name: "VendorContact-1",
            url: "master/vendor-contact-insert",
            defaults: new { controller = "VendorContact", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-2",
            url: "master/vendors-list/{vendor_Name}",
            defaults: new { controller = "VendorContact", action = "Get_Vendor_AutoComplete", vendor_Name = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-3",
            url: "master/vendor-contact-search",
            defaults: new { controller = "VendorContact", action = "Get_Vendor_Contacts", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "VendorContact-4",
           url: "master/get-vendor-contact-by-id",
           defaults: new { controller = "VendorContact", action = "Get_Vendor_Contact_By_Id", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-5",
            url: "master/vendor-contact-update",
            defaults: new { controller = "VendorContact", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-6",
            url: "master/vendor-contact-custom-field-insert",
            defaults: new { controller = "VendorContact", action = "Insert_Vendor_Contact_Custom_Field", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-7",
            url: "master/vendor-contact-custom-field-update",
            defaults: new { controller = "VendorContact", action = "Update_Vendor_Contact_Custom_Field", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-8",
            url: "master/delete-vendor-contact-custom-field",
            defaults: new { controller = "VendorContact", action = "Delete_Vendor_Contact_Custom_Field", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-9",
            url: "master/view-vendor-contact",
            defaults: new { controller = "VendorContact", action = "View_Vendor_Contact", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "VendorContact-10",
            url: "master/print-view-vendor-contact",
            defaults: new { controller = "VendorContact", action = "Printable_Vendor_Contact", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region WorkCenter

            routes.MapRoute(
            name: "workcenter-1",
            url: "master/work-station-by-factory-id",
            defaults: new { controller = "WorkCenter", action = "Get_Work_Stations_By_Factory_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "workcenter-2",
            url: "master/insert-work-center",
            defaults: new { controller = "WorkCenter", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "workcenter-3",
            url: "master/work-center-search",
            defaults: new { controller = "WorkCenter", action = "Get_Work_Centers", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "workcenter-4",
            url: "master/get-work-center-by-id",
            defaults: new { controller = "WorkCenter", action = "Get_Work_Centers_By_Work_Center_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "workcenter-5",
            url: "master/update-work-center",
            defaults: new { controller = "WorkCenter", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "workcenter-6",
           url: "master/view-workcenter",
           defaults: new { controller = "WorkCenter", action = "View_Work_Center", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "workcenter-7",
            url: "master/print-view-work_center",
            defaults: new { controller = "WorkCenter", action = "Printable_Work_Center", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Packing

            routes.MapRoute(
            name: "packing-1",
            url: "master/packing",
            defaults: new { controller = "Packing", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "packing-2",
            url: "master/edit-packing",
            defaults: new { controller = "Packing", action = "Get_Packing_By_Packing_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "packing-3",
            url: "master/insert-packing",
            defaults: new { controller = "Packing", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "packing-4",
            url: "master/update-packing",
            defaults: new { controller = "Packing", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "packing-5",
            url: "master/search-packing",
            defaults: new { controller = "Packing", action = "Get_Packing", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "packing-6",
            url: "master/get-packing-id-by-packing-name/{packing_Name}",
            defaults: new { controller = "Packing", action = "Get_Packing_By_Name_Autocomplete", packing_Name = UrlParameter.Optional }
            );

            #endregion

            #endregion

            #region Sales

            #region Enquiry

            routes.MapRoute(
            name: "enquiry-1",
            url: "sales/enquiry",
            defaults: new { controller = "Enquiry", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-2",
            url: "ppc/enquiry-check-point",
            defaults: new { controller = "Enquiry", action = "PPC_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-3",
            url: "design-manager/create-quality-set",
            defaults: new { controller = "Enquiry", action = "QualitySet_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-4",
            url: "quality-manager/verify-quality-set",
            defaults: new { controller = "Enquiry", action = "Quality_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            //routes.MapRoute(
            //name: "enquiry-5",
            //url: "ppc/planning",
            //defaults: new { controller = "Enquiry", action = "PPC_Planning", id = UrlParameter.Optional },
            //namespaces: new string[] { "Kusumgar.Controllers" });

            //routes.MapRoute(
            //name: "enquiry-6",
            //url: "ppc/planning/scheduler",
            //defaults: new { controller = "Enquiry", action = "_Schedule", id = UrlParameter.Optional },
            //namespaces: new string[] { "Kusumgar.Controllers" });

            //routes.MapRoute(
            //name: "enquiry-7",
            //url: "ppc/planning/scheduler-bind",
            //defaults: new { controller = "Enquiry", action = "BindSchedule", id = UrlParameter.Optional },
            //namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-8",
            url: "sales/enquiry",
            defaults: new { controller = "Enquiry", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-9",
            url: "sales/insert-enquiry",
            defaults: new { controller = "Enquiry", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-10",
            url: "sales/update-enquiry",
            defaults: new { controller = "Enquiry", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-11",
            url: "sales/quality-autocomplete/{quality_No}",
            defaults: new { controller = "Enquiry", action = "Get_Quality_Autocomplete", quality_No = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-12",
            url: "sales/enquiry-search",
            defaults: new { controller = "Enquiry", action = "Get_Enquiries", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-13",
            url: "sales/enquiry-by-id",
            defaults: new { controller = "Enquiry", action = "Get_Enquiry_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-14",
            url: "sales/insert-staggered-order",
            defaults: new { controller = "Enquiry", action = "Insert_Staggered_Order", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-15",
            url: "sales/update-staggered-order",
            defaults: new { controller = "Enquiry", action = "Update_Staggered_Order", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-16",
            url: "sales/get-staggered-orders",
            defaults: new { controller = "Enquiry", action = "Get_Staggered_Orders", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-17",
            url: "sales/delete-staggered-order-by-id/{staggered_Order_Id}",
            defaults: new { controller = "Enquiry", action = "Delete_Staggered_Order_By_Id", staggered_Order_Id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-18",
            url: "sales/insert-supporting-details",
            defaults: new { controller = "Enquiry", action = "Insert_Supporting_Details", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-19",
            url: "sales/update-supporting-details",
            defaults: new { controller = "Enquiry", action = "Update_Supporting_Details", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-20",
            url: "sales/insert-temp-customer-quality-details",
            defaults: new { controller = "Enquiry", action = "Insert_Temp_Customer_Quality_Details", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-21",
            url: "sales/update-temp-customer-quality-details",
            defaults: new { controller = "Enquiry", action = "Update_Temp_Customer_Quality_Details", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-22",
            url: "sales/insert-temp-functional-parameters",
            defaults: new { controller = "Enquiry", action = "Insert_Temp_Functional_Parameters", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-23",
            url: "sales/insert-temp-visual-parameters",
            defaults: new { controller = "Enquiry", action = "Insert_Temp_Visual_Parameters", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-24",
            url: "sales/delete_temp_functional_parameters_by_id",
            defaults: new { controller = "Enquiry", action = "Delete_Temp_Functional_Parameters_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-25",
            url: "sales/delete_temp_visual_parameters_by_id",
            defaults: new { controller = "Enquiry", action = "Delete_Temp_Visual_Parameters_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-26",
            url: "sales/get-temp-functional-parameters-by-enquiry-id",
            defaults: new { controller = "Enquiry", action = "Get_Temp_Functional_Parameters_By_Enquiry_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-27",
            url: "sales/get-temp-visual-parameters-by-enquiry-id",
            defaults: new { controller = "Enquiry", action = "Get_Temp_Visual_Parameters_By_Enquiry_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-28",
            url: "sales/get-quality-by-id",
            defaults: new { controller = "Enquiry", action = "Get_Quality_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-29",
            url: "sales/search-ppc-checkpoint",
            defaults: new { controller = "Enquiry", action = "Search_PPC_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-30",
            url: "sales/ppc-checkpoint",
            defaults: new { controller = "Enquiry", action = "PPC_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });


            routes.MapRoute(
            name: "enquiry-31",
            url: "sales/get-customer-quality-details-by-Id",
            defaults: new { controller = "Enquiry", action = "Get_Customer_Quality_Details_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-32",
            url: "sales/get-supporting-details-by-enquiry-Id",
            defaults: new { controller = "Enquiry", action = "Get_Supporting_Details_By_Enquiry_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });


            routes.MapRoute(
            name: "enquiry-33",
            url: "sales/search-w-manager-checkpoint",
            defaults: new { controller = "Enquiry", action = "Search_W_Manager_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });


            routes.MapRoute(
            name: "enquiry-34",
            url: "sales/qualityset-checkpoint",
            defaults: new { controller = "Enquiry", action = "QualitySet_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-35",
            url: "sales/get-enquiries-by-status",
            defaults: new { controller = "Enquiry", action = "Get_Enquiries_By_Status", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-36",
            url: "sales/get-enquiries-for-ppc-chekck-point",
            defaults: new { controller = "Enquiry", action = "Get_Enquiries_For_PPC_Check_Point", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "enquiry-37",
            url: "sales/get-enquiries-for-w-manager-chekck-point",
            defaults: new { controller = "Enquiry", action = "Get_Enquiries_For_W_Manager_Checkpoint", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "enquiry-38",
           url: "sales/update-enquiry-ppc-checkpoint",
           defaults: new { controller = "Enquiry", action = "Update_Enquiry_PPC_Checkpoint", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
        name: "enquiry-39",
        url: "sales/get-nation-by-customer-id",
        defaults: new { controller = "Enquiry", action = "Get_Nations_By_Customer_Id", id = UrlParameter.Optional },
        namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Scheduler 

            routes.MapRoute(
           name: "scheduler-1",
           url: "ppc/planning",
           defaults: new { controller = "Scheduler", action = "PPC_Planning", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "scheduler-2",
           url: "ppc/planning/scheduler",
           defaults: new { controller = "Scheduler", action = "_Schedule", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "scheduler-3",
            url: "ppc/planning/scheduler-bind",
            defaults: new { controller = "Scheduler", action = "BindSchedule", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #endregion

            #region Ajax




         
           

           

           routes.MapRoute(
           name: "ajax-6",
           url: "ajax/application-list/{applicationName}",
           defaults: new { controller = "Quality", action = "Get_Application_Name_AutoComplete", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

           routes.MapRoute(
           name: "ajax-7",
           url: "ajax/segment-list/{segmentName}",
           defaults: new { controller = "Quality", action = "Get_Segment_Name_AutoComplete", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });
           
            #endregion

            #endregion

            #region PreLogin

            routes.MapRoute(
            name: "5.0",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion
        }
    }
}