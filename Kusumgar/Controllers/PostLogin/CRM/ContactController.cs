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

namespace Kusumgar.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Customer/

        public ContactManager _contactMan;

        public ContactController()
        {
            _contactMan = new ContactManager();
        }

        public ActionResult Index(ContactViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            try
            {

            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Index " + ex.ToString());
            }

            return View("Index", cViewModel);
        }

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

        public JsonResult Insert(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.contact.contact_Entity.CreatedBy = 1;

                cViewModel.contact.contact_Entity.UpdatedBy = 1;

                cViewModel.contact.contact_Entity.Contact_Id = _contactMan.Insert_Contact(cViewModel.contact);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO001"));
            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Insert " + ex.ToString());
            }

            return Json(cViewModel);
        }

        public JsonResult Update(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.contact.contact_Entity.UpdatedBy = 1;

                _contactMan.Update_Contact(cViewModel.contact);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO002"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Update " + ex.ToString());
            }

            return Json(cViewModel);
        }

        public JsonResult Insert_Contact_Custom_Fields(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.contact.Custom_Fields.Custom_Fields_Entity.CreatedBy = 1;

                cViewModel.contact.Custom_Fields.Custom_Fields_Entity.UpdatedBy = 1;

                _contactMan.Insert_Contact_Custom_Fields(cViewModel.contact.Custom_Fields);

                cViewModel.contact = _contactMan.Get_Contact_By_Id(cViewModel.contact.Custom_Fields.Custom_Fields_Entity.Contact_Id);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO003"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Insert_Contact_Custom_Fields " + ex.ToString());
            }

            return Json(cViewModel);
        }

        public JsonResult Update_Contact_Custom_Fields(ContactViewModel cViewModel)
        {
            try
            {
                cViewModel.contact.Custom_Fields.Custom_Fields_Entity.UpdatedBy = 1;

                _contactMan.Update_Contact_Custom_Fields(cViewModel.contact.Custom_Fields);

                cViewModel.contact = _contactMan.Get_Contact_By_Id(cViewModel.contact.Custom_Fields.Custom_Fields_Entity.Contact_Id);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CO004"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Contact Controller - Update_Contact_Custom_Fields " + ex.ToString());
            }

            return Json(cViewModel);
        }

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
             catch(Exception ex)
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
        //
         public ActionResult Get_Contact_By_Id(ContactViewModel cViewModel)
         {
             try
             {
                 cViewModel.contact = _contactMan.Get_Contact_By_Id(cViewModel.contact.contact_Entity.Contact_Id);
             }
            catch(Exception ex)
             {
                 cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                 Logger.Error("Contact Controller - Get_Contact_By_Id " + ex.ToString());
             }

             return  Index(cViewModel);
         }

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
