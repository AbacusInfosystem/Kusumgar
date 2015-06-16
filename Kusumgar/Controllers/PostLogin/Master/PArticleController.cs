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
    public class PArticleController : Controller
    {
        //
        // GET: /PArticle/
        public PArticleManager _particleMan;

        public AttributeCodeManager _attMan;

        public PArticleController()
        {
            _particleMan = new PArticleManager();

            _attMan = new AttributeCodeManager();
         }
       
        public ActionResult Index(PArticleViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false; 

            pViewModel.Quality_Nos= _particleMan.Get_Quality(ref pager);

            pViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);

            return View("Index", pViewModel);
        }

        public ActionResult Search(PArticleViewModel pViewModel)
        {

            ViewBag.Title = "KPCL ERP :: Search";

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            try
            {
                pViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("PArticle Controller - Insert " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return View("Search", pViewModel);
        }

        public JsonResult Insert(PArticleViewModel pViewModel)
        {
            try
            {
                pViewModel.PArticle.CreatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                pViewModel.PArticle.UpdatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                pViewModel.PArticle.CreatedOn = DateTime.Now;

                pViewModel.PArticle.UpdatedOn = DateTime.Now;

                int pArticle_Id = _particleMan.Insert_PArticle(pViewModel.PArticle);

                pViewModel.PArticle.P_Article_Id = pArticle_Id;

                pViewModel.Friendly_Message.Add(MessageStore.Get("PA011"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("PArticle Controller - Insert " + ex.ToString());
            }

            return Json(pViewModel);
        }

        public PartialViewResult Load_PArticle(PArticleViewModel pViewModel)
        {
            return PartialView("_PArticle", pViewModel);
        }

        public JsonResult Update(PArticleViewModel pViewModel)
        {
            try
            {
                pViewModel.PArticle.UpdatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                pViewModel.PArticle.UpdatedOn = DateTime.Now;

                _particleMan.Update_PArticle(pViewModel.PArticle);

                pViewModel.Friendly_Message.Add(MessageStore.Get("PA012"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("PArticle Controller - Update " + ex.ToString());
            }

            return Json(pViewModel);
        }

        public JsonResult Get_PArticles(PArticleViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = pViewModel.Pager;

                if (pViewModel.Filter.PArticle_Id != 0 && pViewModel.Filter.Yarn_Type_Id != 0)
                {
                    pViewModel.PArticles = _particleMan.Get_P_Articles_By_PArticle_Id_Yarn_Type(pViewModel.Filter.PArticle_Id, pViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else if (pViewModel.Filter.PArticle_Id != 0)
                {
                    pViewModel.PArticles = _particleMan.Get_PArticles_By_Id(pViewModel.Filter.PArticle_Id, ref pager);
                }
                else if (pViewModel.Filter.Yarn_Type_Id != 0)
                {
                    pViewModel.PArticles = _particleMan.Get_PArticles_By_Yarn_Type_Id(pViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else
                {
                    pViewModel.PArticles = _particleMan.Get_PArticles(ref pager);
                }

                pViewModel.Pager = pager;

                pViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pViewModel.Pager.TotalRecords, pViewModel.Pager.CurrentPage + 1, pViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("PArticle Controller - Get_PArticles " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return Json(pViewModel);
        }

        public ActionResult Get_PArticle_By_Id(PArticleViewModel pViewModel)
        {
            try
            {
                pViewModel.PArticle = _particleMan.Get_PArticles_By_Id(pViewModel.PArticle.P_Article_Id);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("PArticle Controller - Get_PArticle_By_Id " + ex.ToString());
            }

            return Index(pViewModel);
        }

        public JsonResult Get_PArticles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            try
            {
                autoCompletes = _particleMan.Get_PArticles_By_Full_Code(full_Code);
            }
            catch (Exception ex)
            {
                Logger.Error("PArticle Controller - Get_PArticles_By_Full_Code " + ex.ToString());
            }

            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }
    }
}
