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
    public class WArticleController : Controller
    {
        //
        // GET: /WArticle/

        public WArticleManager _wArticleMan;
        public AttributeCodeManager _attMan;

        public WArticleController()
        {
            _wArticleMan = new WArticleManager();
            _attMan = new AttributeCodeManager();
        }
        
        public ActionResult Index(WArticleViewModel wViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";
            PaginationInfo pager = new PaginationInfo();
            pager.IsPagingRequired = false;

            try
            {
                wViewModel.Quality_List = _wArticleMan.Get_Quality(ref pager);
                wViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);
                wViewModel.Is_Primary = true;
            }
            catch (Exception ex)
            {
                wViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("WArticle Controller - Index " + ex.ToString());
            }
            return View("Index", wViewModel);
        }

        public ActionResult Search(WArticleViewModel wViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";
            PaginationInfo pager = new PaginationInfo();
            pager.IsPagingRequired = false;

            try
            {
                wViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);
            }
            catch (Exception ex)
            {
                wViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("WArticle Controller - Search " + ex.ToString());
            }
            return View("Search", wViewModel);
        }

        public PartialViewResult Load_WArticle(WArticleViewModel wViewModel)
        {
            return PartialView("_WArticle", wViewModel);
        }

        public JsonResult Insert(WArticleViewModel wViewModel)
        {
            try
            {
                wViewModel.WArticle.CreatedBy = ((UserInfo)Session["User"]).UserId;
                wViewModel.WArticle.CreatedOn = DateTime.Now;
                wViewModel.WArticle.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                wViewModel.WArticle.UpdatedOn = DateTime.Now;
                int wArticle_Id = _wArticleMan.Insert_WArticle(wViewModel.WArticle);
                wViewModel.WArticle.W_Article_Id = wArticle_Id;
                wViewModel.Friendly_Message.Add(MessageStore.Get("WA001"));
            }
            catch (Exception ex)
            {
                wViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("WArticle Controller - Insert " + ex.ToString());
            }
            return Json(wViewModel);
        }

        public JsonResult Update(WArticleViewModel wViewModel)
        {
            try
            {
                wViewModel.WArticle.UpdatedBy = ((UserInfo)Session["User"]).UserId;
                wViewModel.WArticle.UpdatedOn = DateTime.Now;
                _wArticleMan.Update_WArticle(wViewModel.WArticle);
                wViewModel.Friendly_Message.Add(MessageStore.Get("WA002"));
            }
            catch (Exception ex)
            {
                wViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("WArticle Controller - Update " + ex.ToString());
            }
            return Json(wViewModel);
        }

        public JsonResult Get_WArticles(WArticleViewModel wViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = wViewModel.Pager;
                if (wViewModel.Filter.WArticle_Id != 0 && wViewModel.Filter.Yarn_Type_Id != 0)
                {
                    wViewModel.WArticles = _wArticleMan.Get_W_Articles_By_WArticle_Id_Yarn_Type(wViewModel.Filter.WArticle_Id, wViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else if (wViewModel.Filter.WArticle_Id != 0)
                {
                    wViewModel.WArticles = _wArticleMan.Get_WArticles_By_WArticle_Id(wViewModel.Filter.WArticle_Id, ref pager);
                }
                else if (wViewModel.Filter.Yarn_Type_Id != 0)
                {
                    wViewModel.WArticles = _wArticleMan.Get_WArticles_By_Yarn_Type_Id(wViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else
                {
                    wViewModel.WArticles = _wArticleMan.Get_WArticles(ref pager);
                }
                wViewModel.Pager = pager;
                wViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", wViewModel.Pager.TotalRecords, wViewModel.Pager.CurrentPage + 1, wViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                wViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("WArticle Controller - Update " + ex.ToString());
            }
            return Json(wViewModel);
        }

        public ActionResult Get_WArticle_By_Id(WArticleViewModel wViewModel)
        {
            try
            {
                wViewModel.WArticle = _wArticleMan.Get_WArticle_By_Id(wViewModel.WArticle.W_Article_Id);
            }
            catch (Exception ex)
            {
                wViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));
                Logger.Error("WArticle Controller - Update " + ex.ToString());
            }
            return Index(wViewModel);
        }

        public JsonResult Get_WArticles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();
            try
            {
                autoCompletes = _wArticleMan.Get_WArticles_By_Full_Code(full_Code);
            }
            catch (Exception ex)
            {
                Logger.Error("WArticle Controller - Get_WArticles_By_Full_Code " + ex.ToString());
            }
            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }

    }
}
