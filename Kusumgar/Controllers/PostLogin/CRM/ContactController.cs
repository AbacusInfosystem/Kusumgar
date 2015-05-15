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

namespace Kusumgar.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Customer/

        public ContactManager _contactMgr { get; set; }

        public ContactController()
        {
            _contactMgr = new ContactManager();
        }

        public ActionResult Index(ContactViewModel _contactViewModel)
        {

            try
            {

            }
            catch(Exception ex)
            {
                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", _contactViewModel);
        }

        public ActionResult Search(ContactViewModel _contactViewModel)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View(_contactViewModel);
        }

        public ActionResult Insert(ContactViewModel _contactViewModel)
        {
            try
            {
                _contactViewModel.contact.contact_Entity.Contact_Id = _contactMgr.Insert_Contact(_contactViewModel.contact);

                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("CO001"));
            }
            catch(Exception ex)
            {
                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_contactViewModel);
        }

        public ActionResult Update(ContactViewModel _contactViewModel)
        {
            try
            {
                _contactMgr.Update_Contact(_contactViewModel.contact);

                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("CO002"));
            }
            catch (Exception ex)
            {
                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_contactViewModel);
        }

        public ActionResult Insert_Contact_Custom_Fields(ContactViewModel _contactViewModel)
        {
            try
            {
                _contactMgr.Insert_Contact_Custom_Fields(_contactViewModel.contact.Custom_Fields);

                _contactViewModel.contact = _contactMgr.Get_Contact_By_Id(_contactViewModel.contact.Custom_Fields.Custom_Fields_Entity.Contact_Id);

                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("CO003"));
            }
            catch (Exception ex)
            {
                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_contactViewModel);
        }

        public ActionResult Update_Contact_Custom_Fields(ContactViewModel _contactViewModel)
        {
            try
            {
                _contactMgr.Update_Contact_Custom_Fields(_contactViewModel.contact.Custom_Fields);

                _contactViewModel.contact = _contactMgr.Get_Contact_By_Id(_contactViewModel.contact.Custom_Fields.Custom_Fields_Entity.Contact_Id);

                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("CO004"));
            }
            catch (Exception ex)
            {
                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_contactViewModel);
        }

         public ActionResult Get_Contact_List(ContactViewModel _contactViewModel)
        {
            try
            {
                if (_contactViewModel.Filter_Val.Customer_Id != 0)
                {
                    _contactViewModel.Contact_List = _contactMgr.Get_Contact_List_By_Name(_contactViewModel.Filter_Val.Customer_Id, _contactViewModel.Pager);

                    if(string.IsNullOrEmpty(_contactViewModel.Filter_Val.Customer_Name))
                    {
                        _contactViewModel.Filter_Val.Customer_Name = _contactViewModel.Contact_List.Select(a => a.Customer_Name).FirstOrDefault();
                    }
                }
                else
                {
                    _contactViewModel.Contact_List = _contactMgr.Get_Contact_List(_contactViewModel.Pager);
                }

                _contactViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", _contactViewModel.Pager.TotalRecords, _contactViewModel.Pager.CurrentPage + 1, _contactViewModel.Pager.PageSize, 10, true);
            }
             catch(Exception ex)
            {
                _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_contactViewModel);
        }

         public ActionResult Get_Contact_By_Id(ContactViewModel _contactViewModel)
         {
             try
             {
                 _contactViewModel.contact = _contactMgr.Get_Contact_By_Id(_contactViewModel.contact.contact_Entity.Contact_Id);
             }
            catch(Exception ex)
             {
                 _contactViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
             }

             return  Index(_contactViewModel);
         }

         public ActionResult Delete_Contact_Custom_Fields(int Contact_Custom_Field_Id)
         {
             List<FriendlyMessageInfo> FriendlyMessage = new List<FriendlyMessageInfo>();

             try
             {
                 _contactMgr.Delete_Contact_Custom_Fields(Contact_Custom_Field_Id);

                 FriendlyMessage.Add(MessageStore.Get("CO005"));
             }
             catch (Exception ex)
             {
                 FriendlyMessage.Add(MessageStore.Get("SYS01"));
             }

             return Json(new { FriendlyMessage }, JsonRequestBehavior.AllowGet);
         }
    }
}
