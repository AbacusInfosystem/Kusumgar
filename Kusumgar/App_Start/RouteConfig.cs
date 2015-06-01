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
            defaults: new { controller = "QualityCreation", action = "Search", id = UrlParameter.Optional },
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
         defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
         namespaces: new string[] { "Kusumgar.Controllers" });
            #endregion

            #region PostLogin

            #region System

            routes.MapRoute(
            name: "system-1",
            url: "system/unauthorize-access/{returnURL}",
            defaults: new { controller = "System", action = "UnAuthorize", returnURL = UrlParameter.Optional },
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
            defaults: new { controller = "Complaint", action = "GetComplaintById", id = UrlParameter.Optional },
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
            defaults: new { controller = "Complaint", action = "GetComplaintList", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "complaint-6",
            url: "crm/get-customer-id-by-customername/{CustomerName}",
            defaults: new { controller = "Complaint", action = "GetCustomerId", vendor_Name = UrlParameter.Optional }
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



            #endregion

            #region Process

            routes.MapRoute(
            name: "process-1",
            url: "master/process",
            defaults: new { controller = "Process", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Process Route Code

            routes.MapRoute(
            name: "process-route-code-1",
            url: "master/process-route-code",
            defaults: new { controller = "ProcessRouteCode", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Workcenter

            routes.MapRoute(
            name: "workcenter-1",
            url: "master/workcenter",
            defaults: new { controller = "Workcenter", action = "Index", id = UrlParameter.Optional },
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

            #endregion

            #region G Article

            routes.MapRoute(
            name: "g-article-1",
            url: "master/g-article",
            defaults: new { controller = "GArticle", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region P Article

            routes.MapRoute(
           name: "p-article-1",
           url: "master/p-article",
           defaults: new { controller = "PArticle", action = "Index", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region C Article

            routes.MapRoute(
           name: "c-article-1",
           url: "master/c-article",
           defaults: new { controller = "CArticle", action = "Index", id = UrlParameter.Optional },
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
            name: "quality-creation-1",
            url: "master/quality-creation",
            defaults: new { controller = "QualityCreation", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Customer Quality Creation

            routes.MapRoute(
            name: "customer-quality-creation-1",
            url: "master/customer-quality-creation",
            defaults: new { controller = "CustomerQualityCreation", action = "Index", id = UrlParameter.Optional },
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

            #endregion

            #region Ajax

            routes.MapRoute(
            name: "ajax-1",
            url: "ajax/test/{testUnitName}",
            defaults: new { controller = "Test", action = "Get_Test_AutoComplete", id = UrlParameter.Optional },
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
            defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-2",
            url: "master/edit-material",
            defaults: new { controller = "Product", action = "Get_Product_By_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "material-3",
            url: "master/insert-product",
            defaults: new { controller = "Product", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "product-4",
            url: "master/update-product",
            defaults: new { controller = "Product", action = "Update", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "product-5",
            url: "master/search-product",
            defaults: new { controller = "Product", action = "Get_Products", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "product-6",
            url: "master/product-subcategory-by-category-id",
            defaults: new { controller = "Product", action = "Get_Product_SubCategory_By_Category_Id", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "product-7",
            url: "master/get-product-by-product-name/{product_Name}",
            defaults: new { controller = "Product", action = "Get_Products_By_Name_Autocomplete", product_Name = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "product-8",
            url: "master/get-vendor-id-by-vendorname/{vendor_Name}",
            defaults: new { controller = "Product", action = "Get_Vendor_Autocomplete", vendor_Name = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "product-9",
            url: "master/insert-product-vendor",
            defaults: new { controller = "Product", action = "Insert_Product_Vendor", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "product-10",
            url: "master/delete-product-vendor",
            defaults: new { controller = "Product", action = "Delete_Product_Vendor_By_Id", id = UrlParameter.Optional },
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

            routes.MapRoute(
            name: "enquiry-5",
            url: "ppc/planning",
            defaults: new { controller = "Enquiry", action = "PPC_Planning", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
           name: "enquiry-6",
           url: "ppc/planning/scheduler",
           defaults: new { controller = "Enquiry", action = "_Schedule", id = UrlParameter.Optional },
           namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
          name: "enquiry-7",
          url: "ppc/planning/scheduler-bind",
          defaults: new { controller = "Enquiry", action = "BindSchedule", id = UrlParameter.Optional },
          namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #endregion

            #region Ajax

            routes.MapRoute(
            name: "ajax-2",
            url: "ajax/customer-list/{Customer_Name}",
            defaults: new { controller = "Ajax", action = "Get_Customer_AutoComplete", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });


            routes.MapRoute(
            name: "ajax-3",
            url: "ajax/vendor-list/{vendor_Name}",
            defaults: new { controller = "Vendor", action = "Get_Vendor_Autocomplete", id = UrlParameter.Optional },
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