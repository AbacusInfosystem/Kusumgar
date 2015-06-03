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
    public class YArticleController : Controller
    {
        //
        // GET: /YArticle/

        public YArticleManager _yArticleMan;

        public AttributeCodeManager _attMan;

        public YArticleController()
        {
            _yArticleMan = new YArticleManager();

            _attMan = new AttributeCodeManager();
        }

        public ActionResult Index(YArticleViewModel yViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false; 

            try
            {
                yViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(pager);

                yViewModel.Is_Primary = true;
            }
            catch(Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Index " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return View("Index",yViewModel);
        }

        public ActionResult Search(YArticleViewModel yViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Search";

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            try
            {
                yViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(pager);
            }
            catch(Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Insert " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Search",yViewModel);
        }

        public PartialViewResult Load_YArticle(YArticleViewModel yViewModel)
        {
            return PartialView("_YArticle", yViewModel);
        }

        public JsonResult Insert(YArticleViewModel yViewModel)
        {
            try
            {
                yViewModel.YArticle.CreatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                yViewModel.YArticle.UpdatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                int yArticle_Id = _yArticleMan.Insert_YArticle(yViewModel.YArticle);

                yViewModel.YArticle.Y_Article_Id = yArticle_Id;

                yViewModel.Friendly_Message.Add(MessageStore.Get("YA001"));
            }
            catch (Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Insert " + ex.ToString());
            }

            return Json(yViewModel);
        }

        public JsonResult Update(YArticleViewModel yViewModel)
        {
            try
            {
                yViewModel.YArticle.UpdatedBy = ((UserInfo)Session["User"]).UserEntity.UserId;

                _yArticleMan.Update_YArticle(yViewModel.YArticle);

                yViewModel.Friendly_Message.Add(MessageStore.Get("YA002"));
            }
            catch (Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Update " + ex.ToString());
            }

            return Json(yViewModel);
        }

        public JsonResult Get_YArticles(YArticleViewModel yViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = yViewModel.Pager;

                if(yViewModel.Filter.YArticle_Id != 0 && yViewModel.Filter.Yarn_Type_Id != 0)
                {
                    yViewModel.YArticles = _yArticleMan.Get_Y_Articles_By_YArticle_Id_Yarn_Type(yViewModel.Filter.YArticle_Id, yViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else if (yViewModel.Filter.YArticle_Id != 0)
                {
                    yViewModel.YArticles = _yArticleMan.Get_YArticles_By_Id(yViewModel.Filter.YArticle_Id, ref pager);
                }
                else if ( yViewModel.Filter.Yarn_Type_Id != 0)
                {
                    yViewModel.YArticles = _yArticleMan.Get_YArticles_By_Yarn_Type_Id( yViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else
                {
                    yViewModel.YArticles = _yArticleMan.Get_YArticles(ref pager);
                }

                yViewModel.Pager = pager;

                yViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", yViewModel.Pager.TotalRecords, yViewModel.Pager.CurrentPage + 1, yViewModel.Pager.PageSize, 10, true);
            }
            catch(Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Update " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return Json(yViewModel);
        }

        public ActionResult Get_YArticle_By_Id(YArticleViewModel yViewModel)
        {
            try
            {
                yViewModel.YArticle = _yArticleMan.Get_YArticle_By_Id(yViewModel.YArticle.Y_Article_Id);
            }
            catch(Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Update " + ex.ToString());
            }

            return Index(yViewModel);
        }

        public JsonResult Get_YArticles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            try
            {
                autoCompletes = _yArticleMan.Get_YArticles_By_Full_Code(full_Code);
            }
            catch (Exception ex)
            {
                Logger.Error("YArticle Controller - Get_YArticles_By_Full_Code " + ex.ToString());
            }

            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Work_Stations_By_Code_Purpose(string work_Station_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            try
            {
                autoCompletes = _yArticleMan.Get_Work_Stations_By_Code_Purpose(work_Station_Code);
            }
            catch (Exception ex)
            {
                Logger.Error("YArticle Controller - Get_Work_Stations " + ex.ToString());
            }

            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }

    }
}
