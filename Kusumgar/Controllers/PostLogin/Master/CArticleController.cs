using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;

using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;
using KusumgarCrossCutting.Logging;

namespace Kusumgar.Controllers
{
    public class CArticleController : Controller
    {
        //
        // GET: /CArticle/

        public CArticleManager _cArticleMan;
        public AttributeCodeManager _attMan;

        public CArticleController()
        {
            _cArticleMan = new CArticleManager();
            _attMan = new AttributeCodeManager();
        }
        
        public ActionResult Index(CArticleViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";
            PaginationInfo pager = new PaginationInfo();
            pager.IsPagingRequired = false;

            try
            {
                cViewModel.Quality_List = _cArticleMan.Get_Quality(ref pager);
                cViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);
                cViewModel.Is_Primary = true;
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("CArticle Controller - Index " + ex.ToString());
            }
            return View("Index", cViewModel);
        }

        public ActionResult Search(CArticleViewModel cViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";
            PaginationInfo pager = new PaginationInfo();
            pager.IsPagingRequired = false;

            try
            {
                cViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("CArticle Controller - Search " + ex.ToString());
            }
            return View("Search", cViewModel);
        }

        public PartialViewResult Load_CArticle(CArticleViewModel cViewModel)
        {
            return PartialView("_CArticle", cViewModel);
        }

        public JsonResult Insert(CArticleViewModel cViewModel)
        {
            try
            {
                cViewModel.CArticle.CreatedBy = ((UserInfo)Session["User"]).UserId;
                cViewModel.CArticle.CreatedOn = DateTime.Now;
                cViewModel.CArticle.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                cViewModel.CArticle.UpdatedOn = DateTime.Now;
                int cArticle_Id = _cArticleMan.Insert_CArticle(cViewModel.CArticle);
                cViewModel.CArticle.C_Article_Id = cArticle_Id;
                cViewModel.Friendly_Message.Add(MessageStore.Get("CA001"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("CArticle Controller - Insert " + ex.ToString());
            }
            return Json(cViewModel);
        }

        public JsonResult Update(CArticleViewModel cViewModel)
        {
            try
            {
                cViewModel.CArticle.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                cViewModel.CArticle.UpdatedOn = DateTime.Now;
                _cArticleMan.Update_CArticle(cViewModel.CArticle);
                cViewModel.Friendly_Message.Add(MessageStore.Get("CA002"));
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("CArticle Controller - Update " + ex.ToString());
            }
            return Json(cViewModel);
        }

        public JsonResult Get_CArticles(CArticleViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = cViewModel.Pager;
                if (cViewModel.Filter.CArticle_Id != 0 && cViewModel.Filter.Yarn_Type_Id != 0)
                {
                    cViewModel.CArticles = _cArticleMan.Get_C_Articles_By_CArticle_Id_Yarn_Type(cViewModel.Filter.CArticle_Id, cViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else if (cViewModel.Filter.CArticle_Id != 0)
                {
                    cViewModel.CArticles = _cArticleMan.Get_CArticles_By_CArticle_Id(cViewModel.Filter.CArticle_Id, ref pager);
                }
                else if (cViewModel.Filter.Yarn_Type_Id != 0)
                {
                    cViewModel.CArticles = _cArticleMan.Get_CArticles_By_Yarn_Type_Id(cViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else
                {
                    cViewModel.CArticles = _cArticleMan.Get_CArticles(ref pager);
                }
                cViewModel.Pager = pager;
                cViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cViewModel.Pager.TotalRecords, cViewModel.Pager.CurrentPage + 1, cViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("CArticle Controller - Update " + ex.ToString());
            }
            return Json(cViewModel);
        }

        public ActionResult Get_CArticle_By_Id(CArticleViewModel cViewModel)
        {
            try
            {
                cViewModel.CArticle = _cArticleMan.Get_CArticle_By_Id(cViewModel.CArticle.C_Article_Id);
            }
            catch (Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("CArticle Controller - Update " + ex.ToString());
            }
            return Index(cViewModel);
        }

        public JsonResult Get_CArticles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();
            try
            {
                autoCompletes = _cArticleMan.Get_CArticles_By_Full_Code(full_Code);
            }
            catch (Exception ex)
            {
                Logger.Error("CArticle Controller - Get_CArticles_By_Full_Code " + ex.ToString());
            }
            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }

    }
}
