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
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public CustomerManager _customerMgr;

        public NationManager _nationManager;

        public StateManager _stateMgr;

        public CustomerController()
        {
            _customerMgr = new CustomerManager();

            _nationManager = new NationManager();

            _stateMgr = new StateManager();
        }

        public ActionResult Index(CustomerViewModel _customerViewModel)
        {
            try
            {

                _customerViewModel.Pager.IsPagingRequired = false;

                _customerViewModel.Nation_List = _nationManager.Get_Nation_List(_customerViewModel.Pager);

                _customerViewModel.State_List = _stateMgr.Get_State_List(Convert.ToInt32(_customerViewModel.Customer.Customer_Entity.Head_Office_Nation), _customerViewModel.Pager);
            }
            catch(Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return View("Index", _customerViewModel);
        }

        public ActionResult Search(CustomerViewModel _customerViewModel)
        {
            return View("Search", _customerViewModel);
        }

        public ActionResult Insert(CustomerViewModel _customerViewModel)
        {
            try
            {
                int customerId = _customerMgr.Insert_Customer(_customerViewModel.Customer);

                _customerViewModel.Customer.Customer_Entity.Company_Id = customerId;

                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("CU001"));
            }
            catch(Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_customerViewModel);
        }

        public ActionResult Update(CustomerViewModel _customerViewModel)
        {
            try
            {
                _customerMgr.Update_Customer(_customerViewModel.Customer);

                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("CU002"));
            }
            catch (Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_customerViewModel);
        }

        public ActionResult Insert_Customer_Address(CustomerViewModel _customerViewModel)
        {
            try
            {
                _customerMgr.Insert_Customer_Address(_customerViewModel.Customer.Customer_Address);

                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("CU003"));

                _customerViewModel.Customer = _customerMgr.Get_Customer_By_Id(Convert.ToInt32(_customerViewModel.Customer.Customer_Address.Customer_Address_Entity.Customer_Id));
            }
            catch (Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_customerViewModel);
        }

        public ActionResult Update_Customer_Address(CustomerViewModel _customerViewModel)
        {
            try
            {
                _customerMgr.Update_Customer_Address(_customerViewModel.Customer.Customer_Address);

                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("CU004"));

                _customerViewModel.Customer = _customerMgr.Get_Customer_By_Id(Convert.ToInt32(_customerViewModel.Customer.Customer_Address.Customer_Address_Entity.Customer_Id));
            }
            catch (Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_customerViewModel);
        }

        public ActionResult Insert_Bank_Details(CustomerViewModel _customerViewModel)
        {
            try
            {
                _customerMgr.Insert_Bank_Details(_customerViewModel.Customer.Bank_Details);

                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("CU005"));

            }
            catch (Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_customerViewModel);
        }

        public ActionResult Update_Bank_Details(CustomerViewModel _customerViewModel)
        {
            try
            {
                _customerMgr.Update_Bank_Details(_customerViewModel.Customer.Bank_Details);

                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("CU006"));
 
            }
            catch (Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }


            return Json(_customerViewModel);
        }

        public ActionResult Get_Customer_List(CustomerViewModel _customerViewModel)
        {
            try
            {
                if(!string.IsNullOrEmpty(_customerViewModel.Filter_Value.Customer_Name) && !string.IsNullOrEmpty(_customerViewModel.Filter_Value.Email) && !string.IsNullOrEmpty(_customerViewModel.Filter_Value.Turnover) )
                {
                     _customerViewModel.Customer_List = _customerMgr.Get_Customer_By_Email_Name_Turnover(_customerViewModel.Filter_Value.Email,_customerViewModel.Filter_Value.Customer_Name,_customerViewModel.Filter_Value.Turnover,  _customerViewModel.Pager);
                }
                else if(!string.IsNullOrEmpty(_customerViewModel.Filter_Value.Customer_Name) && !string.IsNullOrEmpty(_customerViewModel.Filter_Value.Email))
                {
                    _customerViewModel.Customer_List = _customerMgr.Get_Customer_By_Email_Name(_customerViewModel.Filter_Value.Email, _customerViewModel.Filter_Value.Customer_Name, _customerViewModel.Pager);
                }
                else if(!string.IsNullOrEmpty(_customerViewModel.Filter_Value.Customer_Name) && !string.IsNullOrEmpty(_customerViewModel.Filter_Value.Turnover))
                {
                    _customerViewModel.Customer_List = _customerMgr.Get_Customer_By_Turnover_Name(_customerViewModel.Filter_Value.Turnover, _customerViewModel.Filter_Value.Customer_Name, _customerViewModel.Pager);
                }
                else if(!string.IsNullOrEmpty(_customerViewModel.Filter_Value.Email) && !string.IsNullOrEmpty(_customerViewModel.Filter_Value.Turnover) )
                {
                    _customerViewModel.Customer_List = _customerMgr.Get_Customer_By_Turnover_Email(_customerViewModel.Filter_Value.Turnover, _customerViewModel.Filter_Value.Email, _customerViewModel.Pager);
                }
                else if(!string.IsNullOrEmpty(_customerViewModel.Filter_Value.Customer_Name))
                {
                       _customerViewModel.Customer_List = _customerMgr.Get_Customer_List_By_Name(_customerViewModel.Filter_Value.Customer_Name, _customerViewModel.Pager);
                }
                else if(!string.IsNullOrEmpty(_customerViewModel.Filter_Value.Email))
                {
                    _customerViewModel.Customer_List = _customerMgr.Get_Customer_By_Email(_customerViewModel.Filter_Value.Email, _customerViewModel.Pager);
                }
                else if(!string.IsNullOrEmpty(_customerViewModel.Filter_Value.Turnover))
                {
                    _customerViewModel.Customer_List = _customerMgr.Get_Customer_By_Turnover(_customerViewModel.Filter_Value.Turnover, _customerViewModel.Pager);
                }
                else
                {
                    _customerViewModel.Customer_List = _customerMgr.Get_Customer_List(_customerViewModel.Pager);
                }

                _customerViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", _customerViewModel.Pager.TotalRecords, _customerViewModel.Pager.CurrentPage + 1, _customerViewModel.Pager.PageSize, 10, true);
            }
            catch(Exception ex)
            {
                _customerViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }

            return Json(_customerViewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_Customer_By_Id(CustomerViewModel _customerViewModel)
        {
            try
            {
                _customerViewModel.Customer = _customerMgr.Get_Customer_By_Id(_customerViewModel.Customer.Customer_Entity.Company_Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Index(_customerViewModel);
        }

        public ActionResult Get_State_by_Nation_Id(int Nation_Id)
        {
            List<StateInfo> StateList = new List<StateInfo>();

            StateManager _stateMgr = new StateManager();

            try
            {
                PaginationInfo Pager = new PaginationInfo();

                Pager.IsPagingRequired = false;

                StateList = _stateMgr.Get_State_List(Nation_Id, Pager);
            }
            catch(Exception ex)
            {

            }
            return Json(StateList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete_Customer_Address_By_Id(int Customer_Address_Id)
        {
            List<FriendlyMessageInfo> FriendlyMessage = new List<FriendlyMessageInfo>();

            try
            {
                
                _customerMgr.Delete_Customer_Address_By_Id(Customer_Address_Id);

                FriendlyMessage.Add(MessageStore.Get("CU007"));

            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Json(new { FriendlyMessage }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Check_Existing_Customer(string Customer_Name)
        {
            bool check = false;

            try
            {
                check = _customerMgr.Check_Existing_Customer(Customer_Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

    }
}
