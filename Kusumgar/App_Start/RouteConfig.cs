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

            // Start : Added by kaustubh | Date : 03/30/2015
            routes.MapRoute(
            name: "menu-10",
            url: "master/yarn-category-code/search",
            defaults: new { controller = "YarnCategoryCode", action = "Search", id = UrlParameter.Optional },
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

            // End by kaustubh 



            #endregion

            #region PostLogin

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
            defaults: new { controller = "Customer", action = "Get_Customer_List", id = UrlParameter.Optional },
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

            #endregion

            #region Masters

            #region DefectType

            routes.MapRoute(
            name: "defect-type-1",
            url: "master/defect-type",
            defaults: new { controller = "DefectType", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
            name: "defect-type-2",
            url: "master/defect-type",
            defaults: new { controller = "DefectType", action = "Insert", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            routes.MapRoute(
             name: "defect-type-3",
             url: "master/defect-type",
             defaults: new { controller = "DefectType", action = "GetDefectById", id = UrlParameter.Optional },
             namespaces: new string[] { "Kusumgar.Controllers" });


            routes.MapRoute(
                       name: "defect-type-4",
                       url: "master/defect-type",
                       defaults: new { controller = "DefectType", action = "Update", id = UrlParameter.Optional },
                       namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Defect

            routes.MapRoute(
            name: "defect-1",
            url: "master/defect",
            defaults: new { controller = "Defect", action = "Index", id = UrlParameter.Optional },
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
            url: "master/test-unit",
            defaults: new { controller = "TestUnit", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Test

            routes.MapRoute(
            name: "test-1",
            url: "master/test",
            defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            // Start : Added by kaustubh | Date : 03/30/2015
            #region Yarn Category

            routes.MapRoute(
            name: "yarn-category-1",
            url: "master/attribute-code",
            defaults: new { controller = "AttributeCode", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "Kusumgar.Controllers" });

            #endregion

            #region Y Article

            routes.MapRoute(
            name: "y-article-1",
            url: "master/y-article",
            defaults: new { controller = "YArticle", action = "Index", id = UrlParameter.Optional },
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

            // End by kaustubh 




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