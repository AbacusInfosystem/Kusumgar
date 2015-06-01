using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarModel;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;

//using KusumgarBusinessEntities.CMS;


namespace Kusumgar.Controllers.PostLogin.Master
{
    public class VendorContactController : Controller
    {
        public VendorContactManager _vendorcontactMan;

        public VendorContactController()
        {
            _vendorcontactMan = new VendorContactManager();
        }

        public ActionResult Index(VendorContactViewModel vcViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            try
            {

            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Index " + ex.ToString());
            }
            return View("Index" ,vcViewModel);
        }

        public ActionResult Search(VendorContactViewModel vcViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            try
            {

            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Search " + ex.ToString());
            }

            return View("Search", vcViewModel);
        }

        public ActionResult Get_Vendor_Contacts(VendorContactViewModel vcViewModel)
        {
            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager = vcViewModel.Pager;

                if (vcViewModel.Filter.Vendor_Id != 0)
                {
                    vcViewModel.Vendor_Contacts = _vendorcontactMan.Get_Vendor_Contacts_By_Vendor_Name(vcViewModel.Filter.Vendor_Id, ref pager);
                }
                else
                {
                    vcViewModel.Vendor_Contacts = _vendorcontactMan.Get_Vendor_Contacts(ref pager);
                }
                vcViewModel.Pager = pager;

                vcViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", vcViewModel.Pager.TotalRecords, vcViewModel.Pager.CurrentPage + 1, vcViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Get_Vendor_Contacts " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(vcViewModel, JsonRequestBehavior.AllowGet);
        }

        //AutoComplete
        public JsonResult Get_Vendor_AutoComplete(string vendor_Name)
        {
            List<AutocompleteInfo> vendor_contact = new List<AutocompleteInfo>();

            try
            {
                vendor_contact = _vendorcontactMan.Get_Vendor_AutoComplete(vendor_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(vendor_contact, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Insert(VendorContactViewModel vcViewModel)
        {
            try
            {
                vcViewModel.Vendor_Contact.Contact_Entity.CreatedOn = DateTime.Now;

                vcViewModel.Vendor_Contact.Contact_Entity.CreatedBy = ((EmployeeInfo)Session["User"]).EmployeeId;

                vcViewModel.Vendor_Contact.Contact_Entity.UpdatedOn = DateTime.Now;

                vcViewModel.Vendor_Contact.Contact_Entity.UpdatedBy = ((EmployeeInfo)Session["User"]).EmployeeId;
               
                vcViewModel.Vendor_Contact.Contact_Entity.Contact_Id = _vendorcontactMan.Insert_Vendor_Contact(vcViewModel.Vendor_Contact);

                vcViewModel.Friendly_Message.Add(MessageStore.Get("VC001"));
            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Insert " + ex.ToString());
            }

            return Json(vcViewModel);
        }

        public ActionResult Update(VendorContactViewModel vcViewModel)
        {
            try
            {
                vcViewModel.Vendor_Contact.Contact_Entity.UpdatedOn = DateTime.Now;

                vcViewModel.Vendor_Contact.Contact_Entity.UpdatedBy = ((EmployeeInfo)Session["User"]).EmployeeId;

                _vendorcontactMan.Update_Vendor_Contact(vcViewModel.Vendor_Contact);

                vcViewModel.Friendly_Message.Add(MessageStore.Get("VC003"));
            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Update " + ex.ToString());
            }

            return Json(vcViewModel);
        }

        public ActionResult Get_Vendor_Contact_By_Id(VendorContactViewModel vcViewModel)
        {
            try
            {
                vcViewModel.Vendor_Contact = _vendorcontactMan.Get_Vendor_Contact_By_Id(vcViewModel.Vendor_Contact.Contact_Entity.Contact_Id);
            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Get_Vendor_Contact_By_Id " + ex.ToString());
            }

            return View("Index" ,vcViewModel);
        }

        public JsonResult Insert_Vendor_Contact_Custom_Field(VendorContactViewModel vcViewModel)
        {
            try
            {
                vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.CreatedOn = DateTime.Now;

                vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.CreatedBy = ((EmployeeInfo)Session["User"]).EmployeeId;

                vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.UpdatedOn = DateTime.Now;

                vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.UpdatedBy = ((EmployeeInfo)Session["User"]).EmployeeId;
                
                _vendorcontactMan.Insert_Vendor_Contact_Custom_Field(vcViewModel.Vendor_Contact.Vendor_Custom_Field);

                vcViewModel.Vendor_Contact = _vendorcontactMan.Get_Vendor_Contact_By_Id(vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.Contact_Id);

                vcViewModel.Friendly_Message.Add(MessageStore.Get("VC002"));
            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Insert_Vendor_Contact_Custom_Field " + ex.ToString());
            }

            return Json(vcViewModel);
        }

        public JsonResult Update_Vendor_Contact_Custom_Field(VendorContactViewModel vcViewModel)
        {
            try
            {
                vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.UpdatedOn = DateTime.Now;

                vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.UpdatedBy = ((EmployeeInfo)Session["User"]).EmployeeId;

                _vendorcontactMan.Update_Vendor_Contact_Custom_Field(vcViewModel.Vendor_Contact.Vendor_Custom_Field);

                vcViewModel.Vendor_Contact = _vendorcontactMan.Get_Vendor_Contact_By_Id(vcViewModel.Vendor_Contact.Vendor_Custom_Field.Custom_Fields_Entity.Contact_Id);

                vcViewModel.Friendly_Message.Add(MessageStore.Get("VC004"));
            }
            catch (Exception ex)
            {
                vcViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Update_Vendor_Contact_Custom_Field " + ex.ToString());
            }

            return Json(vcViewModel);
        }


        public ActionResult Delete_Vendor_Contact_Custom_Field(int contact_Custom_Field_Id)
        {
            List<FriendlyMessageInfo> friendly_Message = new List<FriendlyMessageInfo>();

            try
            {
                _vendorcontactMan.Delete_Vendor_Contact_Custom_Field(contact_Custom_Field_Id);

                friendly_Message.Add(MessageStore.Get("VC005"));

            }
            catch (Exception ex)
            {
                friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Contact Controller - Delete_Vendor_Contact_Custom_Field " + ex.ToString());
            }

            return Json(new { Friendly_Message = friendly_Message }, JsonRequestBehavior.AllowGet);
        }


    }
}
