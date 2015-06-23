using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;
using KusumgarCrossCutting.Logging;
using System.Web.Security;


namespace Kusumgar.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Customer/

        public ContactManager _contactMan;
        public CustomerManager _customerMan;

        public ContactController()
        {
            _contactMan = new ContactManager();
            _customerMan = new CustomerManager();
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Create)]

        public ActionResult Index(ContactViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";
            PaginationInfo pager = new PaginationInfo();
            try
            {
                cViewModel.Customer_Contact_Types = _customerMan.Get_Customer_Contact_Type_By_Id(cViewModel.Contact.Customer_Id, ref pager);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Index " + ex.ToString());
            }

            return View("Index", cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Search)]

        public ActionResult Search(ContactViewModel cViewModel)
        {
            

            ViewBag.Title = "KPCL ERP :: Search";

            try
            {

            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Search " + ex.ToString());
            }

            return View(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Create)]

        public JsonResult Insert(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.Contact.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Contact.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Contact.CreatedOn = DateTime.Now;

                cViewModel.Contact.UpdatedOn = DateTime.Now;

                cViewModel.Contact.Contact_Id = _contactMan.Insert_Contact(cViewModel.Contact);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO001"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Insert " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Edit)]

        public JsonResult Update(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.Contact.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Contact.UpdatedOn = DateTime.Now;

                _contactMan.Update_Contact(cViewModel.Contact);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO002"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Update " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Create)]

        public JsonResult Insert_Contact_Custom_Fields(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.Contact.Custom_Fields.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Contact.Custom_Fields.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Contact.Custom_Fields.CreatedOn = DateTime.Now;

                cViewModel.Contact.Custom_Fields.UpdatedOn = DateTime.Now;

                _contactMan.Insert_Contact_Custom_Fields(cViewModel.Contact.Custom_Fields);

                cViewModel.Contact = _contactMan.Get_Contact_By_Id(cViewModel.Contact.Custom_Fields.Contact_Id);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO003"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Insert_Contact_Custom_Fields " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Create)]

        public JsonResult Update_Contact_Custom_Fields(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.Contact.Custom_Fields.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Contact.Custom_Fields.UpdatedOn = DateTime.Now;

                _contactMan.Update_Contact_Custom_Fields(cViewModel.Contact.Custom_Fields);

                cViewModel.Contact = _contactMan.Get_Contact_By_Id(cViewModel.Contact.Custom_Fields.Contact_Id);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO004"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Update_Contact_Custom_Fields " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Search)]

        public JsonResult Get_Contact_List(ContactViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = cViewModel.Pager;

                if (cViewModel.Filter.Customer_Id != 0)
                {
                    cViewModel.Contacts = _contactMan.Get_Contacts_By_Name(cViewModel.Filter.Customer_Id, ref pager);
                }
                else
                {

                    cViewModel.Contacts = _contactMan.Get_Contacts(ref pager);
                }

                cViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cViewModel.Pager.TotalRecords, cViewModel.Pager.CurrentPage + 1, cViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Get_Contact_List " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Edit)]

        public ActionResult Get_Contact_By_Id(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.Contact = _contactMan.Get_Contact_By_Id(cViewModel.Contact.Contact_Id);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Get_Contact_By_Id " + ex.ToString());
            }

            return Index(cViewModel);
        }

        public JsonResult Get_Contact_Type_By_Customer_Id(int customer_Id)
        {
            List<CustomerContactTypeInfo> Customer_Contact_Types = new List<CustomerContactTypeInfo>();
            try
            {
                PaginationInfo pager = new PaginationInfo();
                pager.IsPagingRequired = false;
                Customer_Contact_Types = _customerMan.Get_Customer_Contact_Type_By_Id(customer_Id, ref pager);
            }
            catch (Exception ex)
            {                
                Logger.Error("Contact Controller - Get_Contact_Type_By_Customer_Id " + ex.ToString());
            }
            return Json(Customer_Contact_Types, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(AppFunction.Customer_Contact_Edit)]

        public JsonResult Delete_Contact_Custom_Fields(int contact_Custom_Field_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _contactMan.Delete_Contact_Custom_Fields(contact_Custom_Field_Id);

                Friendly_Message.Add(MessageStore.Get("CO005"));
            }
            catch (Exception ex)
            {
                Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Delete_Contact_Custom_Fields " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }
    }
}
