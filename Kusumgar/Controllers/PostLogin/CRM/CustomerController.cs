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
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public CustomerManager _customerMan;

        public NationManager _nationMan;

        public StateManager _stateMan;

        public CustomerController()
        {
            _customerMan = new CustomerManager();

            _nationMan = new NationManager();

            _stateMan = new StateManager();
        }

        [AuthorizeUser(AppFunction.Customer_Create)]

        public ActionResult Index(CustomerViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();

            try
            {

                pager.IsPagingRequired = false;

                cViewModel.Nations = _nationMan.Get_Nations(ref pager);

                cViewModel.States = _stateMan.Get_States(cViewModel.Customer.Customer_Entity.Head_Office_Nation, ref pager);
            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Index " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Index", cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Search)]

        public ActionResult Search(CustomerViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager.IsPagingRequired = false;

                cViewModel.Nations = _nationMan.Get_Nations(ref pager);

                cViewModel.Pager.IsPagingRequired = true;
            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Search " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Search", cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Create)]

        public JsonResult Insert(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer.Customer_Entity.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Customer.Customer_Entity.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Customer.Customer_Entity.CreatedOn = DateTime.Now;

                cViewModel.Customer.Customer_Entity.UpdatedOn = DateTime.Now;

                int customer_Id = _customerMan.Insert_Customer(cViewModel.Customer);

                cViewModel.Customer.Customer_Entity.Customer_Id = customer_Id;

                cViewModel.Friendly_Message.Add(MessageStore.Get("CU001"));
            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Insert " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Edit)]

        public JsonResult Update(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer.Customer_Entity.UpdatedOn = DateTime.Now;

                cViewModel.Customer.Customer_Entity.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                _customerMan.Update_Customer(cViewModel.Customer);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CU002"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Update " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Create)]

        public JsonResult Insert_Customer_Address(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer.Customer_Address.Customer_Address_Entity.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Customer.Customer_Address.Customer_Address_Entity.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Customer.Customer_Address.Customer_Address_Entity.CreatedOn = DateTime.Now;

                cViewModel.Customer.Customer_Address.Customer_Address_Entity.UpdatedOn = DateTime.Now;

                _customerMan.Insert_Customer_Address(cViewModel.Customer.Customer_Address);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CU003"));

                cViewModel.Customer = _customerMan.Get_Customer_By_Id(cViewModel.Customer.Customer_Address.Customer_Address_Entity.Customer_Id);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Insert_Customer_Address " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Edit)]

        public JsonResult Update_Customer_Address(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer.Customer_Address.Customer_Address_Entity.UpdatedOn = DateTime.Now;

                cViewModel.Customer.Customer_Address.Customer_Address_Entity.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                _customerMan.Update_Customer_Address(cViewModel.Customer.Customer_Address);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CU004"));

                cViewModel.Customer = _customerMan.Get_Customer_By_Id(cViewModel.Customer.Customer_Address.Customer_Address_Entity.Customer_Id);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Update_Customer_Address " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Create)]

        public JsonResult Insert_Bank_Details(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer.Bank_Details.CreatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Customer.Bank_Details.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Customer.Bank_Details.CreatedOn = DateTime.Now;

                cViewModel.Customer.Bank_Details.UpdatedOn = DateTime.Now;

                _customerMan.Insert_Bank_Details(cViewModel.Customer.Bank_Details);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CU005"));

            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Insert_Bank_Details " + ex.ToString());
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Edit)]

        public JsonResult Update_Bank_Details(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer.Bank_Details.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                cViewModel.Customer.Bank_Details.UpdatedOn = DateTime.Now;

                _customerMan.Update_Bank_Details(cViewModel.Customer.Bank_Details);

                cViewModel.Friendly_Message.Add(MessageStore.Get("CU006"));
 
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Update_Bank_Details " + ex.ToString());
            }


            return Json(cViewModel);
        }

        [AuthorizeUser(AppFunction.Customer_Search)]

        public JsonResult Get_Customers(CustomerViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                //if(!string.IsNullOrEmpty(cViewModel.Filter.Customer_Name) && !string.IsNullOrEmpty(cViewModel.Filter.Email) && !string.IsNullOrEmpty(cViewModel.Filter.Turnover) )
                //{
                //     cViewModel.Customers = _customerMan.Get_Customer_By_Email_Name_Turnover(cViewModel.Filter.Email,cViewModel.Filter.Customer_Name,cViewModel.Filter.Turnover,  cViewModel.Pager);
                //}
                //else if(!string.IsNullOrEmpty(cViewModel.Filter.Customer_Name) && !string.IsNullOrEmpty(cViewModel.Filter.Email))
                //{
                //    cViewModel.Customers = _customerMan.Get_Customer_By_Email_Name(cViewModel.Filter.Email, cViewModel.Filter.Customer_Name, cViewModel.Pager);
                //}
                //else if(!string.IsNullOrEmpty(cViewModel.Filter.Customer_Name) && !string.IsNullOrEmpty(cViewModel.Filter.Turnover))
                //{
                //    cViewModel.Customers = _customerMan.Get_Customer_By_Turnover_Name(cViewModel.Filter.Turnover, cViewModel.Filter.Customer_Name, cViewModel.Pager);
                //}
                //else if(!string.IsNullOrEmpty(cViewModel.Filter.Email) && !string.IsNullOrEmpty(cViewModel.Filter.Turnover) )
                //{
                //    cViewModel.Customers = _customerMan.Get_Customer_By_Turnover_Email(cViewModel.Filter.Turnover, cViewModel.Filter.Email, cViewModel.Pager);
                //}
                //else if(!string.IsNullOrEmpty(cViewModel.Filter.Customer_Name))
                //{
                //       cViewModel.Customers = _customerMan.Get_Customers_By_Name(cViewModel.Filter.Customer_Name, cViewModel.Pager);
                //}
                //else if(!string.IsNullOrEmpty(cViewModel.Filter.Email))
                //{
                //    cViewModel.Customers = _customerMan.Get_Customer_By_Email(cViewModel.Filter.Email, cViewModel.Pager);
                //}
                //else if(!string.IsNullOrEmpty(cViewModel.Filter.Turnover))
                //{
                //    cViewModel.Customers = _customerMan.Get_Customer_By_Turnover(cViewModel.Filter.Turnover, cViewModel.Pager);
                //}
                //else
                //{
                //    cViewModel.Customers = _customerMan.Get_Customers(cViewModel.Pager);
                //}

                pager = cViewModel.Pager;

                if (!string.IsNullOrEmpty(cViewModel.Filter.Turnover) && cViewModel.Filter.Nation_Id != 0 && cViewModel.Filter.Customer_Id != 0)
                {
                    cViewModel.Customers = _customerMan.Get_Customers_By_Turnover_Customer_Id_Nation_Id(cViewModel.Filter.Turnover, cViewModel.Filter.Nation_Id, cViewModel.Filter.Customer_Id, ref pager);
                }
                else if( cViewModel.Filter.Nation_Id != 0 && cViewModel.Filter.Customer_Id != 0)
                {
                    cViewModel.Customers = _customerMan.Get_Customers_By_Customer_Id_Nation_Id(cViewModel.Filter.Nation_Id, cViewModel.Filter.Customer_Id, ref pager);
                }
                else if(!string.IsNullOrEmpty(cViewModel.Filter.Turnover) && cViewModel.Filter.Customer_Id != 0)
                {
                    cViewModel.Customers = _customerMan.Get_Customers_By_Turnover_Customer_Id(cViewModel.Filter.Turnover, cViewModel.Filter.Customer_Id, ref pager);
                }
                else if(!string.IsNullOrEmpty(cViewModel.Filter.Turnover) && cViewModel.Filter.Nation_Id != 0)
                {
                    cViewModel.Customers = _customerMan.Get_Customers_by_Nation_Id_Turnover(cViewModel.Filter.Turnover, cViewModel.Filter.Nation_Id, ref pager);
                }
                else if (cViewModel.Filter.Nation_Id != 0)
                {
                    cViewModel.Customers = _customerMan.Get_Customers_by_Nation_Id(cViewModel.Filter.Nation_Id, ref pager);
                }
                else if (!string.IsNullOrEmpty(cViewModel.Filter.Turnover))
                {
                    cViewModel.Customers = _customerMan.Get_Customers_By_Turnover(cViewModel.Filter.Turnover, ref  pager);
                }
                else if (cViewModel.Filter.Customer_Id != 0)
                {
                    cViewModel.Customers = _customerMan.Get_Customers_By_Id(cViewModel.Filter.Customer_Id, ref  pager);

                }
                else
                {
                    cViewModel.Customers = _customerMan.Get_Customers(ref pager);
                }

                cViewModel.Pager = pager;

                cViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cViewModel.Pager.TotalRecords, cViewModel.Pager.CurrentPage + 1, cViewModel.Pager.PageSize, 10, true);
            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Get_Customers " + ex.ToString());
            }
            finally
                {
                    pager = null;
                }

            return Json(cViewModel, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(AppFunction.Customer_Edit)]

        public ActionResult Get_Customer_By_Id(CustomerViewModel cViewModel)
        {
            try
            {
                cViewModel.Customer = _customerMan.Get_Customer_By_Id(cViewModel.Customer.Customer_Entity.Customer_Id);
            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Get_Customer_By_Id " + ex.ToString());
            }

            return Index(cViewModel);
        }

        public JsonResult Get_State_by_Nation_Id(int nation_Id)
        {
            List<StateInfo> StateList = new List<StateInfo>();

            StateManager _stateMgr = new StateManager();

            try
            {
                PaginationInfo pager = new PaginationInfo();

                pager.IsPagingRequired = false;

                StateList = _stateMgr.Get_States(nation_Id, ref pager);
            }
            catch(Exception ex)
            {
                Logger.Error("Customer Controller - Get_State_by_Nation_Id " + ex.ToString());
            }
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(AppFunction.Customer_Edit)]

        public JsonResult Delete_Customer_Address_By_Id(int customer_Address_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            try
            {

                _customerMan.Delete_Customer_Address_By_Id(customer_Address_Id);

                Friendly_Message.Add(MessageStore.Get("CU007"));

            }
            catch(Exception ex)
            {
                Logger.Error("Customer Controller - Delete_Customer_Address_By_Id " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Check_Existing_Customer(string customer_Name)
        {
            bool check = false;

            try
            {
                check = _customerMan.Check_Existing_Customer(customer_Name);
            }
            catch (Exception ex)
            {
                Logger.Error("Customer Controller - Check_Existing_Customer " + ex.ToString());
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Customer_AutoComplete(string Customer_Name)
        {
            List<AutocompleteInfo> Customer_List = new List<AutocompleteInfo>();

            try
            {
                Customer_List = _customerMan.Get_Customer_AutoComplete(Customer_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(Customer_List, JsonRequestBehavior.AllowGet);
        }

    }
}
